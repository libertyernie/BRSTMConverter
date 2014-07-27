using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BRSTMConverter.OutputFormats;

namespace BRSTMConverter.MusicClasses {
	public class SoX : Music {
		public SoX(string input) : base(input) {
			readValuesWithSox();
		}

		public override void convertToWav() {
			base.wavFile = Shared.TMP_DIR + Path.DirectorySeparatorChar +
				Path.GetFileNameWithoutExtension(base.input).Replace(" ","_") + ".wav";
			OutputFormat.soxConvert(base.input, base.wavFile);
		}

		/**
		 * Manually changes the loop start point.
		 * @param loopStart Start of loop, in samples. If this is a negative number, looping will be disabled; if it is 0 or greater; looping will be enabled.
		 * @param loopEnd End of loop, in samples. If this is less than the song length and more than loopStart, it replaces the length of the song; the old/real length won't be saved.
		 */
		public void setLoop(int loopStart, int loopEnd) {
			base.loopStart = loopStart;
			if ((loopEnd < base.length) && (loopEnd > loopStart)) {
				base.length = loopEnd;
			}
		}
	
		protected void readValuesWithSox() {
			Process check = new SoXProcess();
			check.StartInfo.Arguments = "--info " + input.quote();
			check.StartInfo.UseShellExecute = false;
			check.StartInfo.RedirectStandardOutput = true;
			check.StartInfo.RedirectStandardError = true;
			check.Start();
			check.WaitForExit();
			StreamReader cleaner = check.StandardOutput;
			String line = cleaner.ReadLine();
			if (line == null) { // if sox could not read the file and therefore gave no output
				string s = check.StandardError.ReadToEnd();
				throw new MusicFileException("SoX could not read the file " + ToString() + ": " + s);
			}
			while (line != null) {
				if (line.StartsWith("Channels")) {
					base.channels = Int32.Parse(line.Substring(line.IndexOf(':')+2));
				} else if (line.StartsWith("Sample Rate")) {
					base.sampleRate = Int32.Parse(line.Substring(line.IndexOf(':')+2));
				} else if (line.StartsWith("Duration")) {
					String[] splitLine = line.Split(' ');
					int index = Array.IndexOf(splitLine, "samples");
					base.length = Int32.Parse(splitLine[index-1]);
				}
				line = cleaner.ReadLine();
			}
			cleaner.Close();
		}
	}
}
