using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace BRSTMConverter.MusicClasses {
	class Vgmstream : Music {

		public Vgmstream(string input) : base(input) {
			try {
				Process check = new VgmstreamProcess();
				check.StartInfo.Arguments = "-m \"" + input + "\"";
				check.StartInfo.UseShellExecute = false;
				check.StartInfo.RedirectStandardOutput = true;
				check.Start();
				check.WaitForExit();

				if (check.ExitCode != 0) {
					throw new MusicFileException("test.exe cannot read " + input);
				}

				StreamReader cleaner = check.StandardOutput;
				String line = cleaner.ReadLine();
				while (line != null) {
					if (line.Contains("channels:")) {
						int channels = Int32.Parse(line.Substring(line.IndexOf(" ")+1));
						base.channels = channels;
					} else if (line.Contains("sample rate")) {
						String s = line;
						s = s.Substring(line.IndexOf(" ")+1); // cut out "sample"
						s = s.Substring(s.IndexOf(" ")+1); // cut out "rate"
						s = s.Substring(0, s.IndexOf(" ")); // cut out all but the number
						int sampleRate = Int32.Parse(s);
						base.sampleRate = sampleRate;
					} else if (line.Contains("loop start:")) {
						String s = line;
						s = s.Substring(line.IndexOf(" ")+1); // cut out "loop"
						s = s.Substring(s.IndexOf(" ")+1); // cut out "start"
						s = s.Substring(0, s.IndexOf(" ")); // cut out all but the number
						int loopStart = Int32.Parse(s);
						base.loopStart = loopStart;
					} else if (line.Contains("stream total samples:")) {
						String s = line;
						s = s.Substring(line.IndexOf(" ")+1); // cut out "stream"
						s = s.Substring(s.IndexOf(" ")+1); // cut out "total"
						s = s.Substring(s.IndexOf(" ")+1); // cut out "samples"
						s = s.Substring(0, s.IndexOf(" ")); // cut out all but the number
						int length = Int32.Parse(s);
						base.length = length;
					}
					line = cleaner.ReadLine();
				}
				cleaner.Close();

				if (base.Looping) {
				} else {
					base.loopStart = -1;
					// Length is already set
				}
			} catch (Exception e) {
				Shared.errorDialog(e.Message);
			}
		}

		public override void convertToWav() {
			string filename = Path.GetFileName(input);

			String loops = "2.0"; // always use 2 loops in case the loop point is changed through sample rate conversion.
			string wavFile = Shared.TMP_DIR + Path.DirectorySeparatorChar + "in.wav";
			Process getWav = new VgmstreamProcess();
			//String[] cmdLine = { Shared.VGMSTREAM_DIR + File.separator + "test.exe", "-o", wavFile.getCanonicalPath(), "-l", loops, "-f", "0.0", super.getCanonicalPath() };
			//getWav = Runtime.getRuntime().exec(cmdLine);
			getWav.StartInfo.Arguments = "-o " + wavFile + " -l " + loops + " -f 0.0 " + Path.GetFullPath(base.Input).quote();
			getWav.Start();
			getWav.WaitForExit();
			if (getWav.ExitCode != 0) {
				throw new MusicFileException("Failed to create WAV files for " + Path.GetFullPath(base.Input));
			}
			base.wavFile = wavFile;
			//base.temporaryWavFile.deleteOnExit();
		}
	}
}
