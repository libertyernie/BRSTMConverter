using System.Diagnostics;
using System.IO;

namespace BRSTMConverter.MusicClasses {
	class VgmstreamProcess : Process {
		public VgmstreamProcess() {
			StartInfo.FileName = Shared.VGMSTREAM_DIR + Path.DirectorySeparatorChar + "test.exe";
			if (!Music.Verbose) {
				StartInfo.CreateNoWindow = true;
				StartInfo.UseShellExecute = false;
			}
		}
	}
}
