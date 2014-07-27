using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.IO.Compression;

namespace BRSTMConverter.MusicClasses {
	class VGM : Music {

		public VGM(string input, int newRate) : base(input) {
			base.sampleRate = newRate;
			base.channels = 2;
			readHeader();
		}
	
		private void readHeader() {
			// read four bytes
			byte[] h = new byte[4];
			FileStream temporary = new FileStream(input, FileMode.Open, FileAccess.Read);
			temporary.Read(h, 0, 4);
			temporary.Close();

			FileStream raw = new FileStream(input, FileMode.Open, FileAccess.Read);
			Stream stream;
			if (h[0] == 0x1f && h[1] == 0x8b) {
				stream = new GZipStream(raw, CompressionMode.Decompress, false);
			} else { // we can just assume that if it isn't GZIP, it's an uncompressed VGM file. If we didn't want to do that, we'd use the above check.
				stream = raw;
			}

			byte[] tmpb = new byte[0x18];
			stream.Read(tmpb, 0, 0x18);
		
			byte[] lengthB = new byte[4];
			stream.Read(lengthB, 0, 4);
			int length = BitConverter.ToInt32(lengthB, 0);

			stream.Read(new byte[0x4], 0, 4);

			byte[] loopSamplesB = new byte[4];
			stream.Read(loopSamplesB, 0, 4);
			int loopSamples = BitConverter.ToInt32(loopSamplesB, 0);

			byte[] rateB = new byte[4];
			stream.Read(rateB, 0, 4);
			int rate = BitConverter.ToInt32(rateB, 0);

			int loopStart = -1;
			if (loopSamples != 0) {
				loopStart = length - loopSamples;
			}
		
			// In case the VGM will be changed to a sample rate other than 44100, we need to do the math here
			double ratio = (double)base.sampleRate / 44100;
			if (loopStart >= 0) {
				loopStart = (int)(loopStart * ratio);
			}
			length = (int)(length * ratio);
		
			base.loopStart = loopStart;
			base.length = length;

		}
		private String hex(byte[] b) {
			String s = "";
			for (int i = 0; i < b.Count(); i++) {
				s += (b[i] & 0xff) + ",";
			}
			return s;
		}
	
		public override void convertToWav() {
			// write INI file
			String ini = "[General]\n" +
					"SampleRate = " + base.sampleRate + "\n" +
					"LogSound = 1\n" +
					"MaxLoops = 0x02\n" +
					"MaxLoopsCMF = 0x01\n";
			File.WriteAllText(Shared.VGMPLAY_DIR + Path.DirectorySeparatorChar + "VGMPlay.ini", ini);
		
			string temporaryCopy = Shared.TMP_DIR + Path.DirectorySeparatorChar + Path.GetFileName(input);
			File.Copy(input, temporaryCopy, true);
		
			Process dump = new VGMPlayProcess();
			dump.StartInfo.Arguments = temporaryCopy.quote();
			dump.Start();

			dump.WaitForExit();
			if (dump.ExitCode != 0) {
				throw new MusicFileException("VGMPlay.exe cannot read " + base.Input);
			}

			String path = temporaryCopy;
			File.Delete(path);
			base.wavFile = path.Substring(0, path.Count()-4) + ".wav";
			if (!File.Exists(base.wavFile)) {
				throw new MusicFileException("The file " + base.wavFile + " was put in the wrong folder.");
			}
		}

	}
}
