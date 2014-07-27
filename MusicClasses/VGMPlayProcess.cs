using System.Diagnostics;
using System.IO;

namespace BRSTMConverter.MusicClasses {
	class VGMPlayProcess : Process {

		public VGMPlayProcess() {
			StartInfo.FileName = Shared.VGMPLAY_DIR + Path.DirectorySeparatorChar + "VGMPlay.exe";
			if (!Music.Verbose) {
				StartInfo.CreateNoWindow = true;
				StartInfo.UseShellExecute = false;
			}
		}
	}
}
