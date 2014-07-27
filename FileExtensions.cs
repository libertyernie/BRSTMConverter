using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace BRSTMConverter {
    class FileExtensions {
        /**
	     *  All input formats supported by SoX 14.4.1 Windows build; includes mp3
	     */
		private static string[] SOX = { "flac", "8svx", "aif", "aifc", "aiff", "aiffc", "al", "amb", "amr-nb", "amr-wb", "anb", "au", "avr", "awb", "cdda", "cdr", "cvs", "cvsd", "cvu", "dat", "dvms", "f32", "f4", "f64", "f8", "fssd", "gsm", "gsrt", "hcom", "htk", "ima", "ircam", "la", "lpc", "lpc10", "lu", "maud", "mp2", "mp3", "nist", "ogg", "prc", "raw", "s1", "s16", "s2", "s24", "s3", "s32", "s4", "s8", "sb", "sf", "sl", "sln", "smp", "snd", "sndr", "sndt", "sou", "sox", "sph", "sw", "txw", "u1", "u16", "u2", "u24", "u3", "u32", "u4", "u8", "ub", "ul", "uw", "vms", "voc", "vorbis", "vox", "wav", "wavpcm", "wv", "wve", "xa" };
		/**
	     *  All input formats supported by test.exe r1007 including logg.
		 *  Input formats not in any of these lists will be handled by vgmstream anyways.
	     */
		private static string[] VGMSTREAM = { ".2dx9", ".aaap", ".aax", ".acm", ".adp", ".adpcm", ".ads", ".adx", ".afc", ".agsc", ".ahx", ".aifc", ".aiff", ".aix", ".amts", ".as4", ".asd", ".asf", ".asr", ".ass", ".ast", ".aud", ".aus", ".baf", ".baka", ".bar", ".bg00", ".bgw", ".bh2pcm", ".bmdx", ".bns", ".bnsf", ".bo2", ".brstm", ".caf", ".capdsp", ".ccc", ".cfn", ".cnk", ".dcs", ".dcsw", ".ddsp", ".de2", ".dmsg", ".dsp", ".dvi", ".dxh", ".eam", ".emff", ".enth", ".fag", ".filp", ".fsb", ".gca", ".gcm", ".gcsw", ".gcw", ".genh", ".gms", ".gsp", ".hgc1", ".his", ".hps", ".hwas", ".idsp", ".idvi", ".ikm", ".ild", ".int", ".isd", ".ish", ".ivaud", ".ivb", ".joe", ".kces", ".kcey", ".khv", ".kraw", ".leg", ".logg", ".lps", ".lsf", ".lwav", ".matx", ".mcg", ".mi4", ".mib", ".mic", ".mihb", ".mpdsp", ".msa", ".mss", ".msvp", ".mus", ".musc", ".musx", ".mwv", ".myspd", ".ndp", ".npsf", ".nwa", ".ogg", ".p3d", ".pcm", ".pdt", ".pnb", ".pos", ".ps2stm", ".psh", ".psw", ".raw", ".rkv", ".rnd", ".rrds", ".rsd", ".rsf", ".rstm", ".rwar", ".rwav", ".rws", ".rwsd", ".rwx", ".rxw", ".s14", ".sab", ".sad", ".sap", ".sc", ".scd", ".sd9", ".sdt", ".seg", ".sfl", ".sfs", ".sl3", ".sli", ".smp", ".smpl", ".snd", ".sng", ".sns", ".spd", ".sps", ".spsd", ".spt", ".spw", ".ss2", ".ss7", ".ssm", ".sss", ".ster", ".sth", ".stm", ".stma", ".str", ".strm", ".sts", ".stx", ".svag", ".svs", ".swav", ".swd", ".tec", ".thp", ".tk5", ".tydsp", ".um3", ".vag", ".vas", ".vgs", ".vig", ".vjdsp", ".voi", ".vpk", ".vs", ".vsf", ".waa", ".wac", ".wad", ".wam", ".was", ".wav", ".wavm", ".wb", ".wii", ".wp2", ".wsd", ".wsi", ".wvs", ".xa", ".xa2", ".xa30", ".xmu", ".xss", ".xvas", ".xwav", ".xwb", ".ydsp", ".ymf", ".zsd", ".zwdsp" };

        /**
         * VGM formats
         */
		private static string[] VGM = { "vgm", "vgz" };

		public static ReadOnlyCollection<string> SOX_ro = Array.AsReadOnly<string>(SOX);
//		public static ReadOnlyCollection<string> VGMSTREAM_ro = Array.AsReadOnly<string>(VGMSTREAM);
		public static ReadOnlyCollection<string> VGM_ro = Array.AsReadOnly<string>(VGM);

        public static string SoXFilter {
            get {
                string filter = "Inputs supported by SoX|";
                filter += "*." + SOX[0];
                for (int i = 1; i < SOX.Count(); i++) {
                    filter += ";*." + SOX[i];
                }
                return filter;
            }
        }
        public static string VgmstreamFilter {
            get {
                string filter = "Inputs supported by vgmstream|";
                filter += "*." + VGMSTREAM[0];
                for (int i = 1; i < VGMSTREAM.Count(); i++) {
                    filter += ";*." + VGMSTREAM[i];
                }
                return filter;
            }
        }
        public static string VgmFilter {
            get {
                string filter = "VGM audio|";
                filter += "*." + VGM[0];
                for (int i = 1; i < VGM.Count(); i++) {
                    filter += ";*." + VGM[i];
                }
                return filter;
            }
        }
		public static string AllFilter {
			get;
			private set;
		}

		static FileExtensions() {
			AllFilter = "All supported audio formats|";
			AllFilter += "*." + SOX[0];
			for (int i = 1; i < SOX.Count(); i++) {
				AllFilter += ";*." + SOX[i];
			}
			for (int i = 0; i < VGMSTREAM.Count(); i++) {
				AllFilter += ";*." + VGMSTREAM[i];
			}
			for (int i = 0; i < VGM.Count(); i++) {
				AllFilter += ";*." + VGM[i];
			}
		}
    }
}
