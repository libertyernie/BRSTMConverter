using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BRSTMConverter {
    public class Shared {
        public const String PROGRAM_TITLE="BRSTM Converter 3.4.1";
	
	    public const String DEFAULT_LOOP_TXT = "loop.txt";
	
	    public const string OUTPUT_DIR = "output";
	    private const String TOOLS_DIR = "tools";
	    public static String SOX_DIR = TOOLS_DIR + Path.DirectorySeparatorChar + "sox";
	    public static String VGMSTREAM_DIR = TOOLS_DIR + Path.DirectorySeparatorChar + "vgmstream";
	    public static String VGMPLAY_DIR = TOOLS_DIR + Path.DirectorySeparatorChar + "VGMPlay";
		public static String VORBIS_TOOLS_DIR = TOOLS_DIR + Path.DirectorySeparatorChar + "vorbis-tools";
	    public const String TMP_DIR = "tmp";

	    public static bool isDspadpcmAvailable() {
		    return false;
	    }

	    public static bool isSbbAvailable() {
		    return true;
	    }

		public static bool isVorbisCommentAvailable() {
			return File.Exists(VORBIS_TOOLS_DIR + Path.DirectorySeparatorChar + "vorbiscomment.exe");
		}
	
	    public const String HELPMESSAGE = PROGRAM_TITLE + "\n" +
			    "Usage: java -jar \"BRSTM Converter.jar\" [options] [filenames]\n" +
			    "\n" +
			    "If you define any options, the option dialog will not appear. Similarily, if you define any filenames, the file selection dialog will not appear.\n" +
			    "Available options:\n" +
			    "-m: Convert the files to mono.\n" +
			    "-r [number]: Convert the sample rate of the files. A fractional value (e.g. 0.5 or 0.75) will be interpreted as a factor by which to change the current rate; an integer (e.g. 32000) will be taken as a new rate to use for all output files.\n" +
			    "-d [number]: The sample rate for rendering VGMs. If you use an absolute value for -r above, these two values will be the same and one will override the other.\n" +
			    "-a [number]: Amplify the audio by the given factor. Using a factor of 2.0, for example, would double the volume.\n" +
			    "-min [number]: Set a minimum sample rate. If the factor by which to lower the sample rate would lower it under this value, the audio will be converted to this rate instead.\n" +
				"-loop: Loop WAV, FLAC, and Ogg Vorbis input files (start to end, or as specified in loop.txt.) On by default.\n" +
				"-noloop: Don't loop WAV/FLAC/Ogg files.\n" +
				"-ask: Ask about WAV/FLAC/Ogg files, using the BRSTM converter dialog from BrawlLib. (BRSTM outputs only)\n" +
			    "-l [filename]: Specify the text file to read looping information from. The default is loop.txt. Implies -loop.\n" +
			    "-noopts: Don't show the options dialog. Not needed if you define other options on the command line.";
	
	    /// <summary>
	    /// Displays an error dialog using MessageBox.Show(s).
	    /// </summary>
	    /// <param name="s">The message to display.</param>
	    public static void errorDialog(String s) {
		    //JOptionPane.showMessageDialog(null, s, PROGRAM_TITLE, JOptionPane.ERROR_MESSAGE);
            MessageBox.Show(s);
	    }

    }
}
