using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib.IO;
using System.Runtime.InteropServices;

namespace BRSTMConverter {
	public static class FileMapWriter {

		public static void write(FileMap audioData, String output, FileMode mode) {
			using (FileStream stream = new FileStream(output, FileMode.Create)) {
				stream.Write(audioData.Address, audioData.Length);
			}
		}

	}
}
