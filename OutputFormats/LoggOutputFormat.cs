using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

using BRSTMConverter.MusicClasses;

namespace BRSTMConverter.OutputFormats {
	public class LoggOutputFormat : OutputFormat {
		public LoggOutputFormat(String displayName, String ext, bool canLoop)
			: base(displayName, ext, canLoop) { }

		public override void build(Form parent, IProgressTracker tracker, string inwav, string output, bool looping, int loopStart, int length, bool loopTrim) {
			string output_renamed = output.Substring(0, output.Count() - 5) + ".ogg";
			OutputFormat.soxConvert(inwav, output_renamed, length);
			Process p = new Process();
			p.StartInfo.FileName = Shared.VORBIS_TOOLS_DIR + Path.DirectorySeparatorChar + "vorbiscomment.exe";
			p.StartInfo.Arguments = "-a " + output_renamed.quote() + " -t \"LOOPSTART=" + loopStart + "\" -t \"LOOPLENGTH=" + (length-loopStart) + "\"";
//			p.StartInfo.UseShellExecute = false;
//			p.StartInfo.RedirectStandardError = true;
//			p.StartInfo.RedirectStandardOutput = true;
			p.Start();
			p.WaitForExit();
			if (p.ExitCode != 0) {
				throw new MusicFileException("Could not run vorbiscomment.exe. Is it present in the " + Shared.VORBIS_TOOLS_DIR + " folder?");
//				MessageBox.Show(p.StartInfo.Arguments);
//				MessageBox.Show(p.StandardOutput.ReadToEnd());
			}
			File.Move(output_renamed, output);
		}
	}
}
