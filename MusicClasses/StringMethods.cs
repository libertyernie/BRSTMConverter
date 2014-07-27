using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRSTMConverter.MusicClasses {
	public static class StringMethods {
		public static string quote(this string str) {
			return '"' + str + '"';
		}
	}
}
