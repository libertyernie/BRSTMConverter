using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BRSTMConverter.MusicClasses;
using BRSTMConverter.OutputFormats;

namespace BRSTMConverter {
    static class Program {
        [STAThread]
        static int Main(String[] args) {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!Directory.Exists(Shared.TMP_DIR)) {
                if (File.Exists(Shared.TMP_DIR)) {
                    Shared.errorDialog("There is a file named \"tmp\". Please move this file so the program can create a \"tmp\" directory.");
                    return 1;
                } else {
                    Directory.CreateDirectory(Shared.TMP_DIR);
                }
            }

            // If there are certain files that don't exist, tell the user about them.
            List<String> errors = new List<String>();
            if (!File.Exists(Shared.VGMSTREAM_DIR + Path.DirectorySeparatorChar + "test.exe")) {
                errors.Add("test.exe is not present in the \"" + Shared.VGMSTREAM_DIR + "\" folder.\nYou can get test.exe from:\nhttp://hcs64.com/vgmstream.html");
            }
            if (!File.Exists(Shared.SOX_DIR + Path.DirectorySeparatorChar + "sox.exe")) {
                errors.Add("sox.exe is not present in the \"" + Shared.SOX_DIR + "\" folder.\nYou can download SoX from: http://sourceforge.net/projects/sox/files/sox-win/\n(Get the .zip file, not the installer.)");
            }
            // Continue only if there are no errors.
            if (errors.Count > 0) {
                String errorString;
                if (errors.Count < 3) {
                    errorString = errors[0];
                    for (int i = 1; i < errors.Count; i++) errorString += "\n" + errors[i];
                } else {
                    errorString = "There are more than 3 file-not-found errors.\nMake sure that the Rate Converter JAR file is in the right directory (with the \"tools\" and \"sox\" folders.)";
                }
                Shared.errorDialog(errorString);
                return 1;
            }

            if (!File.Exists(Shared.SOX_DIR + Path.DirectorySeparatorChar + "libmad.dll")) {
                MessageBox.Show("libmad.dll is not present in the \"" + Shared.SOX_DIR + "\" folder.\nYou will not be able to decode MP3 files without it.");
            }

            string[] inputFiles = null; // for files that exist
            bool cmdLineOptions = false; // for arguments that aren't filenames
            OptionSet opts = new OptionSet(); // will be replaced if the user uses the option dialog

			// This section is for parsing command-line arguments
            if (args.Length > 0) {
                List<string> foundFiles = new List<string>();
                List<string> notFoundFiles = new List<string>();
		        for (int i=0; i<args.Length; i++) {
			        if (args[i][0] == '-') {
				        cmdLineOptions = true; // Set to true so the options dialog doesn't appear
				        char first = args[i][1];
				        // Arguments defined here
				        if ((first == 'm') && (args[i].Count() == 2)) {
					        opts.convertToMono = true;
				        } else if ((first == 'd') && (args[i].Count() == 2)) {
					        i++; // Skip to next argument - it should be a number
					        try {
						        int num = Int32.Parse(args[i]);
						        opts.defaultRate = num;
					        } catch (FormatException) {
						        Console.Error.WriteLine(args[i] + " is not a number.");
					        }
				        } else if ((first == 'r') && (args[i].Count() == 2)) {
					        i++; // Skip to next argument - it should be a number
					        try {
						        double num = Double.Parse(args[i]);
						        if (num % 1 != 0.0) { // If the number is not an integer
							        opts.convertRate = (OptionSet.RATE_RELATIVE);
							        opts.rateFactor = (num);
						        } else { // If it is an integer
							        opts.convertRate = (OptionSet.RATE_ABSOLUTE);
							        opts.defaultRate = ((int)num);
						        }
					        } catch (FormatException) {
						        Console.Error.WriteLine(args[i] + " is not a number.");
					        }
				        } else if ((first == 'a') && (args[i].Count() == 2)) {
					        i++; // Skip to next argument - it should be a number
					        try {
						        double num = Double.Parse(args[i]);
						        opts.ampAmount = (num); // Will not be set if Double.parseDouble throws an exception
					        } catch (FormatException) {
						        Console.Error.WriteLine(args[i] + " is not a number.");
					        }
				        } else if (args[i] == ("min")) {
					        i++; // Skip to next argument - it should be a number
					        try {
						        int num = Int32.Parse(args[i]);
						        opts.minimumRate = (num); // Will not be set if Integer.parseInt throws an exception
					        } catch (FormatException) {
						        Console.Error.WriteLine(args[i] + " is not a number.");
					        }
				        } else if (args[i] == ("-loop")) {
					        opts.loopWav = 0;
				        } else if (args[i] == ("-noloop")) {
							opts.loopWav = -1;
						} else if (args[i] == ("-ask")) {
							opts.loopWav = -2;
				        } else if ((first == 'l') && (args[i].Count() == 2)) {
					        i++; // Next argument - it should be a filename
					        if (File.Exists(args[i])) {
						        opts.loopTxt = (args[i]);
					        } else {
						        Console.Error.WriteLine(args[i] + " does not exist.");
					        }
				        } else if (args[i] == ("-noopts")) {
					        // Do nothing except set cmdLineOptions to true (which is done above) so the options dialog doesn't show up
				        } else if (args[i] == ("--help")) {
					        Console.WriteLine(Shared.HELPMESSAGE);
                            return 0;
				        } else {
					        Console.Error.WriteLine("Unrecognized argument: " + args[i] + "\n\n" + Shared.HELPMESSAGE);
                            return 1;
				        }
			        } else {
				        // For arguments that are input filenames
				        if (File.Exists(args[i])) {
					        foundFiles.Add(args[i]);
				        } else {
					        notFoundFiles.Add(args[i]);
				        }
			        }
		        }
                if (notFoundFiles.Count() > 0) {
                    System.Console.Error.WriteLine("Not found: " + notFoundFiles);
                }
                if (foundFiles.Count() > 0) {
                    inputFiles = foundFiles.ToArray();
                }
            }

            if (!cmdLineOptions) {
                OptionDialog f = new OptionDialog();
                f.ShowDialog();
                if (f.DialogResult == DialogResult.OK) {
                    try {
                        opts = f.getOptionSet();
                    } catch (FormatException e) {
                        MessageBox.Show(e.Message);
                        return 1;
                    }
                } else {
                    return 1;
                }
            }

			// LOOP_ASK (-2) only works with BrstmOutputFormat
			if (opts.loopWav == OptionSet.LOOP_ASK && !(opts.outputFormat is BrstmOutputFormat)) {
				opts.loopWav = OptionSet.LOOP;
			}

            if ((inputFiles == null) || (inputFiles.Count() == 0)) {
                OpenFileDialog ofd = new OpenFileDialog();
				ofd.Filter = FileExtensions.AllFilter
					+ "|" + FileExtensions.SoXFilter
                    + "|" + FileExtensions.VgmstreamFilter
                    + "|" + FileExtensions.VgmFilter
                    + "|" + "All files (*.*)|*.*";
                ofd.Multiselect = true;
                DialogResult dr = ofd.ShowDialog();
				if (dr != DialogResult.OK) {
					return 0;
				}
				inputFiles = ofd.FileNames;
            }

			if (!Directory.Exists(Shared.OUTPUT_DIR)) {
				Directory.CreateDirectory(Shared.OUTPUT_DIR);
			}

			LoopTxtReader loopReader;
			try {
				loopReader = new LoopTxtReader(opts.loopTxt);
			} catch (Exception) {
				loopReader = new LoopTxtReader(); // Make an empty LoopTxtReader that returns the defaults for all songs
			}

			// This array will be used for input files
			Music[] inputMusics = new Music[inputFiles.Count()];
			// A list of files that could not be converted
			List<string> couldNotConvert = new List<string>();
			// The current file
			string file = null;
			for (int i = 0; i < inputMusics.Count(); i++) {
				file = inputFiles[i];
				String ext = file.Substring(file.LastIndexOf('.') + 1).ToLower();
				if (FileExtensions.SOX.Contains(ext)) {
					SoX w = new SoX(inputFiles[i]);
					loopReader.setLoops(w, opts.loopWav); // Will run setLoop as appropriate
					inputMusics[i] = w;
				} else if (FileExtensions.VGM.Contains(ext)) {
					inputMusics[i] = new VGM(inputFiles[i], opts.defaultRate);
				} else {
					// handled by vgmstream
					inputMusics[i] = new Vgmstream(inputFiles[i]);
				}
			}

			List<string> filesMade = new List<string>(); // A list of files converted

			// not sure if this section is needed or not anymore
			int readableBrstms = inputMusics.Count();
			/*Music[] newInputArray = new Music[readableBrstms];
			int count = 0; // newInputArray counter
			for (int j = 0; j < inputMusics.Count(); j++) {
				if (inputMusics[j] != null) { // Don't copy null elements
					newInputArray[count] = inputMusics[j];
					count++;
				}
			}
			inputMusics = newInputArray;*/

			string[] outputFiles = new string[readableBrstms];

			TwoLineStatusBox mainWindow = new TwoLineStatusBox();
			mainWindow.changeStatus("Loading...");
			mainWindow.changeMessage("Loading...");
			mainWindow.Show();
			mainWindow.Activate();

			bool cont = true;
			for (int i = 0; (i < inputMusics.Count()) && (cont); i++) if (inputMusics[i] != null) {
				Music input = inputMusics[i];

				outputFiles[i] = Shared.OUTPUT_DIR + Path.DirectorySeparatorChar + input.getOutputName(opts.outputFormat.ext);

				if (input.create(mainWindow, opts, outputFiles[i])) {
					filesMade.Add(outputFiles[i]);
				} else {
					couldNotConvert.Add(input.getOutputName());
				}

				if (mainWindow.ShouldClose) {
					cont = false;
				}
			}

			string filesMadeString = "Files made:\n";
			int filesMadeSize = filesMade.Count();
			for (int j = 0; j < filesMadeSize; j++) {
				filesMadeString += (filesMade[j]);
				if (j < filesMadeSize - 1) {
					filesMadeString += (", ");
				} else {
					filesMadeString += ("\n");
				}
			}
			String cannotConvert;
			if (couldNotConvert.Count() > 0) {
				cannotConvert = "Files NOT made:\n";
				cannotConvert += (couldNotConvert[0]);
				for (int j = 1; j < couldNotConvert.Count(); j++) {
					cannotConvert += (", ");
					cannotConvert += (couldNotConvert[j]);
				}
				cannotConvert += ("\n");
			} else {
				cannotConvert = "";
			}

			mainWindow.changeTitle("Complete!");
			MessageBox.Show(mainWindow, filesMadeString + cannotConvert);

            return 0;
        }
    }
}
