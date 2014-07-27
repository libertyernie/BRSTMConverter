using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRSTMConverter.MusicClasses {
	public class MusicFileException : Exception {
		public MusicFileException() {
		}
		public MusicFileException(String message)
			: base(message) {
		}
	}
}
