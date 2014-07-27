using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BrawlLib.IO;
using BRSTMConverter.MusicClasses;
using System.Audio;
using BrawlLib.Wii.Audio;

namespace BRSTMConverter.OutputFormats {

	public class BrstmOutputFormat : OutputFormat {
		public BrstmOutputFormat(String displayName, String ext, bool canLoop)
			: base(displayName, ext, canLoop) { }

		public override void build(Form parent, IProgressTracker tracker, string tmpwav, string output, bool looping, int loopStart, int length, bool loopTrim) {
			FileMap audioData;
			if (loopStart == -2) {
				BrstmConverterDialog bcd = new BrstmConverterDialog();
				bcd.AudioSource = tmpwav;
				bcd.ShowDialog(parent);
				if (bcd.DialogResult != DialogResult.OK) {
					throw new MusicFileException("Build cancelled.");
				}
				audioData = bcd.AudioData;
			} else {
				IAudioStream audioStream = WAV.FromFile(tmpwav);
				audioStream.IsLooping = looping;
				audioStream.LoopStartSample = loopStart;
				audioStream.LoopEndSample = length;
				//if (tracker == null) tracker = new ProgressWindow(parent, Shared.PROGRAM_TITLE, "Encoding, please wait...", false);
				audioData = RSTMConverter.Encode(audioStream, tracker);
				audioStream.Dispose();
			}
			FileMapWriter.write(audioData, output, FileMode.Create);
			audioData.Dispose();
		}
	}

}
