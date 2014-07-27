using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.IO;
using System.IO;

namespace BRSTMConverter {
	public static class FileMapWriter {

		public unsafe static void write(FileMap audioData, String output, FileMode mode) {
			using (FileStream stream = new FileStream(output, FileMode.Create)) {
				using (BinaryWriter writer = new BinaryWriter(stream)) {
					byte* b = (byte*)audioData.Address;
					for (int i = 0; i < audioData.Length; i++) {
						writer.Write(b[i]);
					}
				}
			}
		}

	}
}
