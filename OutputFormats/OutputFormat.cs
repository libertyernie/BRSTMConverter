using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;
using BRSTMConverter.MusicClasses;
using System.Audio;
using System.Windows.Forms;
using BrawlLib.IO;
using BrawlLib.Wii.Audio;
using System.Threading;

namespace BRSTMConverter.OutputFormats {
	/// <summary>
	/// An abstract class representing an output format. Subclasses must implement
	/// a build method that converts a WAV file to its own format (i.e. Brstm.)
	/// </summary>
    public abstract class OutputFormat {

       	private String displayName;
	    private String m_ext;
	    private bool m_canLoop;

        public String ext {
            get {
                return m_ext;
            }
        }
        public bool canLoop {
            get {
                return m_canLoop;
            }
        }
	
	    public OutputFormat(String displayName, String ext, bool canLoop) {
		    this.displayName = displayName;
		    this.m_ext = ext;
		    this.m_canLoop = canLoop;
	    }
	
	    public override String ToString() {
		    return displayName;
	    }

		/// <summary>
		/// The last step of the build process: use a given WAV file to generate a given output file.
		/// </summary>
		/// <param name="parent">The parent form of any dialogs that might pop up (null for none.)</param>
		/// <param name="tracker">A progress tracker implementing BrawlLib's IProgressTracker interface (null for none.)</param>
		/// <param name="inwav">The input WAV file.</param>
		/// <param name="output">The output file.</param>
		/// <param name="looping">Whether to loop the output file.</param>
		/// <param name="loopStart">Start of the loop, in samples.</param>
		/// <param name="length">Length, in samples.</param>
		/// <param name="loopTrim">Whether to trim to the parameter given for "length".</param>
		public abstract void build(Form parent, IProgressTracker tracker, string inwav, string output, bool looping, int loopStart, int length, bool loopTrim);

	    private static List<OutputFormat> m_list;

		/// <summary>
		/// A read-only List containing all the OutputFormat(s) that this program supports.
		/// </summary>
        public static OutputFormat[] array {
            get {
                return m_list.ToArray<OutputFormat>();
            }
        }

		// This static initializer is equivalent to "static { ... }" code in Java.
	    static OutputFormat() {
		    m_list =  new List<OutputFormat>(6);
			m_list.Add(new BrstmOutputFormat("BRSTM (Wii)", "brstm", true));
			if (Shared.isVorbisCommentAvailable()) {
				m_list.Add(new LoggOutputFormat("LOGG (looping Ogg)", "logg", true));
			}
		    if (File.Exists(Shared.SOX_DIR + Path.DirectorySeparatorChar + "libmp3lame.dll")) {
				m_list.Add(new SoXOutputFormat("MP3", "mp3", false));
		    }
			m_list.Add(new SoXOutputFormat("Ogg Vorbis", "ogg", false));
			m_list.Add(new SoXOutputFormat("FLAC", "flac", false));
			m_list.Add(new SoXOutputFormat("WAV", "wav", false));
	    }

		///
		///<summary>Convert one format to another with SoX.</summary>
		///<param name="inf">The input file.</param>
		///<param name="outf">The output file. This file will be overwritten if it exists.</param>
		///
		public static void soxConvert(string inf, string outf) {
			//Console.WriteLine("Converting format with SoX...");
			Process p = new SoXProcess();
			p.StartInfo.Arguments += inf.quote() + " " + outf.quote();
			p.Start();
			p.WaitForExit();
		
			if (p.ExitCode != 0) {
				throw new MusicFileException("Creating the file "+outf+" was unsuccessful. It's possible that SoX doesn't support this format.");
			}
		}

		///
		///<summary>Convert one format to another with SoX, trimming to a certain point.</summary>
		///<param name="inf">The input file.</param>
		///<param name="outf">The output file. This file will be overwritten if it exists.</param>
		///<param name="length">The length to trim to, in samples.</param>
		///
		public static void soxConvert(string inf, string outf, int length) {
			//Console.WriteLine("Converting format with SoX...");
			Process p = new SoXProcess();
			p.StartInfo.Arguments += inf.quote() + " " + outf.quote() + " trim 0 " + length + "s";
			p.Start();
			p.WaitForExit();
		
			if (p.ExitCode != 0) {
				throw new MusicFileException("SoX conversion was unsuccessful");
			}
		}
	
/*		///<summary>Converts two mono WAV files representing the left and right
		///channels to a single stereo WAV file.</summary>
		///<param name="l">A WAV file representing the left channel.</param>
		///<param name="r">A WAV file representing the right channel.</param>
		///<param name="output">The File object representing the output file.
		///This file will be overwritten if it does not exist.</param>
		///<param name="loopTrim">Whether to trim the file to the loop end point.
		///.logg uses this; .brstm doesn't need to (BrawlLib handles it.)</param>
		///<param name="length">The length to trim to if loopTrim is true.</param>
		private static void monoWavToStereo(string l, string r, string output, bool loopTrim, int length) {
			Process p = new SoXProcess();
			p.StartInfo.Arguments += "-M " + l + " " + r + " " + output;
			p.Start();
			p.WaitForExit();

			if (p.ExitCode != 0) {
				throw new MusicFileException("Error converting two mono WAVs to one stereo WAV with SoX.");
			}
		}

		///<summary>Converts two mono WAV files representing the left and right
		///channels to a single stereo WAV file.</summary>
		///<param name="l">A WAV file representing the left channel.</param>
		///<param name="r">A WAV file representing the right channel.</param>
		///<param name="output">The File object representing the output file.
		///This file will be overwritten if it does not exist.</param>
		public static void monoWavToStereo(string l, string r, string output) {
			monoWavToStereo(l, r, output, false, -1);
		}

		///<summary>Converts two mono WAV files representing the left and right
		///channels to a single stereo WAV file.</summary>
		///<param name="l">A WAV file representing the left channel.</param>
		///<param name="r">A WAV file representing the right channel.</param>
		///<param name="output">The File object representing the output file.
		///This file will be overwritten if it does not exist.</param>
		///<param name="length">The length to trim to, in samples.</param>
		public static void monoWavToStereo(string l, string r, string output, int length) {
			monoWavToStereo(l, r, output, true, length);
		}*/
    }

}
