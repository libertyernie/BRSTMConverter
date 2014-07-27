using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BRSTMConverter.OutputFormats {
	public class SoXOutputFormat : OutputFormat {
		public SoXOutputFormat(String displayName, String ext, bool canLoop)
			: base(displayName, ext, canLoop) { }

		public override void build(Form parent, IProgressTracker tracker, string inwav, string output, bool looping, int loopStart, int length, bool loopTrim) {
			if (loopTrim) {
				OutputFormat.soxConvert(inwav, output, length);
			} else {
				OutputFormat.soxConvert(inwav, output);
			}
		}
	}
}
