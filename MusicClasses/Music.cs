using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace BRSTMConverter.MusicClasses {
	/// <summary>
	/// This class represents a particular music file to be converted.
	/// Some methods are implemented by subclasses, primarily the initializers
	/// (which set information like sample rate and number of channels) and the
	/// createTemporaryWavFile function responsible for converting the file
	/// to the WAV format that SoX can read.
	/// 
	/// This class also contains the create function, which is used to start the
	/// build process. Before create finishes, it passes control to the
	/// OutputFormat object that the given OptionSet has selected.
	/// </summary>
	public abstract class Music {

		public static bool Verbose = true;

		protected string input;

		/// <summary>
		/// A temporary file that SoX can read, made from the original input.
		/// Created by the createTemporaryWavFile function. This will be deleted
		/// and set back to null when the output is being built.
		/// </summary>
		protected string wavFile;

		protected int sampleRate;
		protected int loopStart;
		protected int length;
		protected int channels;
	
		protected Music(string input) {
			this.input = input;
			this.loopStart = -1; // this will be changed by LoopTxtReader
		
			// set to invalid values; these should be changed by the subclass or something else
			this.length = -1;
			this.sampleRate = -1;
			this.channels = -1;
		}

		/// <summary>
		/// Creates the temporary WAV file (wavFile), usually by calling another
		/// program to convert the input file (input) to WAV. This function sets
		/// the value of wavFile and creates a file at that path. wavFile will
		/// be deleted in the build function after it has been used.
		/// </summary>
		public abstract void convertToWav();

		public string Input {
			get {
				return input;
			}
		}
		public int SampleRate {
			get {
				return sampleRate;
			}
		}
		public int LoopStart {
			get {
				return loopStart;
			}
		}
		public int Length {
			get {
				return length;
			}
		}
		public int Channels {
			get {
				return channels;
			}
		}

		public bool Looping {
			get {
				return loopStart >= 0;
			}
		}

		public override string ToString() {
			return input;
		}

		/// <summary>
		/// Gets the filename, but replaces the extension with ".brstm".
		/// </summary>
		/// <returns>The input filename, but with the extension replaced with ".brstm".</returns>
		public String getOutputName() {
			return getOutputName("brstm");
		}

		/// <summary>
		/// Gets the filename, but replaces the extension with the one given.
		/// </summary>
		/// <param name="extension">The extension to use.</param>
		/// <returns>The input filename, but with the extension replaced with the given one.</returns>
		public String getOutputName(String extension) {
			return Path.GetFileName(input.Substring(0, input.LastIndexOf(".")+1)) + extension;
		}
	
		/// <summary>
		/// Creates a BRSTM from the input file.
		///
		/// Note: while this function handles the conversion to WAV and the modification of channels/sample rate/etc.,
		/// the conversion from WAV to BRSTM is handled by the build method.
		/// </summary>
		/// <param name="mainWindow">Can be null, or a ProgressBox that can be updated by this method and other methods that call it.</param>
		/// <param name="opts">An OptionSet to read parameters from.</param>
		/// <param name="outputFile">The file to output to.</param>
		///
		public bool create(TwoLineStatusBox mainWindow, OptionSet opts, string outputFile) {

			int newRate;
			if (opts.convertRate == OptionSet.RATE_RELATIVE) {
				newRate = (int)Math.Round(opts.rateFactor * this.SampleRate);
				if (newRate < opts.minimumRate) {
					newRate = opts.minimumRate; // Change to the minimum rate - this only needs to be checked if the rate is defined as a fraction
				}
			} else if (opts.convertRate == OptionSet.RATE_ABSOLUTE) {
				newRate = opts.defaultRate;
			} else {
				newRate = this.SampleRate;
			}

			string basename = Path.GetFileNameWithoutExtension(input).Replace(" ","_");

			ProgressWindow progressWindow = new ProgressWindow(mainWindow, outputFile, "Working...", false);
			progressWindow.Begin(0, 19245, 0);
			progressWindow.Location = mainWindow.PointToScreen(new Point(0, 100));

			if (mainWindow != null) {

				mainWindow.changeStatus("Current file: " + basename);
			
				if (newRate >= this.SampleRate) {
					newRate = this.SampleRate; // This will keep the below code from changing the sample rate for this Music.
				}
	
				int channels = this.Channels;
	
				String message = "";
	
				if (this.Looping) {
					message = message + "loop: " + this.LoopStart + "-" + this.Length + ", ";
				}
				if (opts.convertToMono && (channels > 1)) {
					message = message + "to mono, ";
				}
				if (opts.convertRate != OptionSet.RATE_NO_CONVERSION && this.SampleRate != newRate) {
					message = message + "new rate: " + newRate + ", ";
				}
				if (opts.ampType == OptionSet.AMPLITUDE_TYPE) {
					message = message + "amp: " + opts.ampAmount + "x, ";
				} else if (opts.ampType == OptionSet.DB_TYPE) {
					message = message + "amp: " + opts.ampAmount + " dB, ";
				} else if (opts.ampType == OptionSet.MAX_AMP_WITHOUT_CLIPPING) {
					message = message + "max amp w/o clipping, ";
				}
				if (message.Count() > 2) { // do this if the message is not empty
					message = message.Substring(0, message.Count() - 2); // remove last comma and space
					mainWindow.changeMessage(message);
				} else {
					mainWindow.changeMessage("");
				}
			}
			
			try { // this is where the magic happens!
				progressWindow.Caption = "Creating temporary WAV file...";
				progressWindow.Update();
				if (wavFile == null) convertToWav();

				progressWindow.Caption = "Converting to mono...";
				progressWindow.Update(4971);
				/**
				* WAV files after stereo/mono conversion.
				*/
				string step1wav;
				if (channels == 1) { // already mono
					step1wav = wavFile;
				} else {
					if (channels > 2) Console.WriteLine("This stream has more than two channels. Only using first two.");
					step1wav = Shared.TMP_DIR + Path.DirectorySeparatorChar + "step1_" + basename + ".wav";
					bool b;
					if (opts.convertToMono) { // not mono; converting to mono
						b = combineToMono(wavFile, step1wav); // this function uses only the first two channels
					} else { // not mono; converting to stereo if necessary
						b = combineToStereo(wavFile, step1wav);
					}
					if (b) {
						File.Delete(wavFile);
						wavFile = null;
					} else {
						throw new MusicFileException("convertToMono or convertToStereo failed.");
					}
				}

				progressWindow.Caption = "Converting sample rate...";
				progressWindow.Update(5610);
				/**
				* WAV files after sample rate conversion.
				*/
				string step2wav;
				if (opts.convertRate != OptionSet.RATE_NO_CONVERSION && newRate != this.SampleRate) {
					step2wav = Shared.TMP_DIR + Path.DirectorySeparatorChar + "step2_" + basename + ".wav";
					Process rate = new SoXProcess();
					rate.StartInfo.Arguments += step1wav + " -r " + newRate + " " + step2wav;
					rate.Start();
					rate.WaitForExit();
					File.Delete(step1wav);
				} else {
					step2wav = step1wav;
				}

				progressWindow.Caption = "Amplifying audio...";
				progressWindow.Update(7815);
				/**
				* WAV files after amplification.
				*/
				string step3wav;
				bool amplify = true;
				String[] soxOpts = new String[2];
				if (opts.ampType == OptionSet.NO_AMP) {
					amplify = false;
				} else if (opts.ampType == OptionSet.AMPLITUDE_TYPE) {
					soxOpts[0] = "vol";
					soxOpts[1] = opts.ampAmount + "amplitude";
				} else if (opts.ampType == OptionSet.DB_TYPE) {
					soxOpts[0] = "vol";
					soxOpts[1] = opts.ampAmount + "dB";
				} else if (opts.ampType == OptionSet.MAX_AMP_WITHOUT_CLIPPING) {
					soxOpts[0] = "gain";
					soxOpts[1] = "-n";
				}
				if (amplify) {
					step3wav = Shared.TMP_DIR + Path.DirectorySeparatorChar + "step3_" + basename + ".wav";
					Process amp = new SoXProcess();
					amp.StartInfo.UseShellExecute = false;
					amp.StartInfo.RedirectStandardError = true;
					amp.StartInfo.Arguments += step2wav + " " + step3wav + " " + soxOpts[0] + " " + soxOpts[1];
					amp.Start();
					amp.WaitForExit();
					File.Delete(step2wav);
				} else {
					step3wav = step2wav;
				}

				// make the new BRSTMs
				double ratio = (double)newRate / SampleRate;
				int newLoopStart = (int)(LoopStart * ratio);
				int newLength = (int)(Length * ratio);

				progressWindow.Caption = "Creating output...";
				progressWindow.Update(8181);
				opts.outputFormat.build(progressWindow, new SubRangeProgressTracker(8181, 19245, progressWindow),
					step3wav, outputFile, Looping, newLoopStart, newLength, opts.loopTrim);

				progressWindow.Caption = "Deleting temporary files...";
				progressWindow.Update(19245);
				File.Delete(step3wav);

				progressWindow.Finish();
				return true;
			
			} catch (Exception e) {
				// Exceptions are caught here, and then false is returned to the main method in Program.cs.
				Shared.errorDialog(e.Message);
				return false;
			}
		}

		/// <summary>
		/// Combines a WAV file (or any file SoX can handle) to one mono WAV file.
		/// If the file only has one channel, that file is returned.
		/// If the file has more than two channels, only the first two are used.
		/// </summary>
		/// <param name="wavFile">The path to a WAV file.</param>
		private static bool combineToMono(string wavFile, string outwav) {
			SoXProcess p = new SoXProcess();
			p.StartInfo.Arguments += wavFile.quote() + " " + outwav + " remix 1,2";
			p.Start();
			p.WaitForExit();
			return p.ExitCode == 0;
		}

		/// <summary>
		/// Combines a WAV file (or any file SoX can handle) to one stereo WAV file.
		/// If the file has more than two channels, only the first two are used.
		/// </summary>
		/// <param name="wavFile">The path to a WAV file.</param>
		private static bool combineToStereo(string wavFile, string outwav) {
			SoXProcess p = new SoXProcess();
			p.StartInfo.Arguments += wavFile.quote() + " " + outwav + " remix 1 2";
			p.Start();
			p.WaitForExit();
			return p.ExitCode == 0;
		}
		
		/*private string[] extractWAV(ProgressBox progressBox) {
			string[] wavFiles = new string[channels];
			for (int i=0; i<channels; i++) {
				wavFiles[i] = Shared.TMP_DIR + Path.DirectorySeparatorChar + "in" + i + ".wav";
				Process splitWav = new SoXProcess();
				splitWav.StartInfo.Arguments += wavFile.quote() + " " + wavFiles[i] + " remix " + (i+1);
				splitWav.Start();
				splitWav.WaitForExit();
				if (splitWav.ExitCode != 0) {
					throw new MusicFileException("Failed to split WAV files for " + this);
				}
			}
			return wavFiles;
		}*/

	}
}
