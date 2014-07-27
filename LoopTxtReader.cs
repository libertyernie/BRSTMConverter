using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using BRSTMConverter.MusicClasses;

namespace BRSTMConverter {
	public class LoopTxtReader {
		private List<string> filenames;
		private List<int> loopStarts;
		private List<int> loopEnds;
		private bool loopDefault;

		public LoopTxtReader(bool loopDefault, string filename = null) {
			filenames = new List<string>();
			loopStarts = new List<int>();
			loopEnds = new List<int>();
			this.loopDefault = loopDefault;
			if (filename != null && File.Exists(filename)) {
				StreamReader reader = new StreamReader(filename);
				string line = reader.ReadLine();
				while (line != null) {
					line = line.Replace("[ \t]+", " ");
					if (line.Count() > 0 && line[0] != '#' && line.Contains(' ')) {
						try {
							int loopStart = Int32.Parse(line.Substring(0, line.IndexOf(" ")));
							line = line.Substring(line.IndexOf(" ") + 1);
							int loopEnd = Int32.Parse(line.Substring(0, line.IndexOf(" ")));
							line = line.Substring(line.IndexOf(" ") + 1);
							String inputName = line;

							if (loopStart % 14336 != 0) {
								int difference = 14336 - (loopStart % 14336);
								loopStart += difference;
								loopEnd += difference;
							}

							filenames.Add(inputName);
							loopStarts.Add(loopStart);
							loopEnds.Add(loopEnd);
						} catch (FormatException) {
							Console.Error.WriteLine("Could not parse line: " + line);
						}
					}
					line = reader.ReadLine();
				}
			}
		}

		public override string ToString() {
			string s = string.Empty;
			for (int i = 0; i < filenames.Count(); i++) {
				s += filenames[i] + ": " + loopStarts[i] + " to " + loopEnds[i] + "\n";
			}
			return s;
		}

		public void loopsFor(string original_filename, out int loopStart, out int loopEnd) {
			int index = filenames.IndexOf(Path.GetFileName(original_filename));
			if ((index > -1) && (loopStarts[index] > -1)) {
				loopStart = loopStarts[index];
				loopEnd = loopEnds[index];
			} else {
				loopStart = loopDefault ? 0 : -1;
				loopEnd = -1;
			}
		}

	}
}
