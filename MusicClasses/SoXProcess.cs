using System.Diagnostics;
using System.IO;

namespace BRSTMConverter.MusicClasses {
	class SoXProcess : Process {
		public SoXProcess() {
			StartInfo.FileName = Shared.SOX_DIR + Path.DirectorySeparatorChar + "sox.exe";
			if (!Music.Verbose) {
				StartInfo.CreateNoWindow = true;
				StartInfo.UseShellExecute = false;
			} else {
				StartInfo.Arguments = "-S ";
			}
		}
	}
}
