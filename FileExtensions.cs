using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRSTMConverter {
    class FileExtensions {
        /**
	     *  All input formats supported by SoX; includes mp3
	     */
	    public static string[] SOX = {"mp3", "ogg", "8svx", "aif", "aifc", "aiff", "aiffc", "al", "amb", "amr-nb", "amr-wb", "anb", "au", "avr", "awb", "caf", "cdda", "cdr", "cvs", "cvsd", "cvu", "dat", "dvms", "f32", "f4", "f64", "f8", "fap", "flac", "fssd", "gsm", "gsrt", "hcom", "htk", "ima", "ircam", "la", "lpc", "lpc10", "lu", "mat", "mat4", "mat5", "maud", "mp2", "nist", "ogg", "paf", "prc", "pvf", "raw", "s1", "s16", "s2", "s24", "s3", "s32", "s4", "s8", "sb", "sd2", "sds", "sf", "sl", "smp", "snd", "sndfile", "sndr", "sndt", "sou", "sox", "sph", "sw", "txw", "u1", "u16", "u2", "u24", "u3", "u32", "u4", "u8", "ub", "ul", "uw", "vms", "voc", "vorbis", "vox", "w64", "wav", "wavpcm", "wv", "wve", "xa", "xi"};
	    /**
	     *  All input formats supported by test.exe including logg
	     */
	    public static string[] VGMSTREAM = {"2dx9", "aaap", "aax", "acm", "adp", "adpcm", "ads", "adx", "afc", "agsc", "ahx", "aifc", "aiff", "aix", "amts", "as4", "asd", "asf", "asr", "ass", "ast", "aud", "aus", "baf", "baka", "bar", "bg00", "bgw", "bh2pcm", "bmdx", "bns", "bnsf", "bo2", "brstm", "caf", "capdsp", "ccc", "cfn", "cnk", "dcs", "dcsw", "ddsp", "de2", "dmsg", "dsp", "dvi", "dxh", "eam", "emff", "enth", "fag", "filp", "fsb", "gca", "gcm", "gcsw", "gcw", "genh", "gms", "gsp", "hgc1", "his", "hps", "hwas", "idsp", "idvi", "ikm", "ild", "int", "isd", "ish", "ivaud", "ivb", "joe", "kces", "kcey", "khv", "kraw", "leg", "logg", "lps", "lsf", "lwav", "matx", "mcg", "mi4", "mib", "mic", "mihb", "mpdsp", "msa", "mss", "msvp", "mus", "musc", "musx", "mwv", "myspd", "ndp", "npsf", "nwa", "p3d", "pcm", "pdt", "pnb", "pos", "psh", "psw", "raw", "rkv", "rnd", "rrds", "rsd", "rsf", "rstm", "rwar", "rwav", "rws", "rwsd", "rwx", "rxw", "s14", "sab", "sad", "sap", "sc", "scd", "sd9", "sdt", "seg", "sfl", "sfs", "sl3", "sli", "smp", "smpl", "snd", "sng", "sns", "spd", "sps", "spsd", "spt", "spw", "ss2", "ss7", "ssm", "sss", "ster", "sth", "stm", "stma", "str", "strm", "sts", "stx", "svag", "svs", "swav", "swd", "tec", "thp", "tk5", "tydsp", "um3", "vag", "vas", "vgs", "vig", "vjdsp", "voi", "vpk", "vs", "vsf", "waa", "wac", "wad", "wam", "was", "wavm", "wb", "wii", "wp2", "wsd", "wsi", "wvs", "xa", "xa2", "xa30", "xmu", "xss", "xvas", "xwav", "xwb", "ydsp", "ymf", "zsd", "zwdsp"};

        /**
         * VGM formats
         */
        public static string[] VGM = { "vgm", "vgz" };

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
            get {
                string filter = "All supported audio formats|";
                filter += "*." + SOX[0];
                for (int i = 1; i < SOX.Count(); i++) {
                    filter += ";*." + SOX[i];
                }
                for (int i = 0; i < VGMSTREAM.Count(); i++) {
                    filter += ";*." + VGMSTREAM[i];
                }
                for (int i = 0; i < VGM.Count(); i++) {
                    filter += ";*." + VGM[i];
                }
                return filter;
            }
        }
    }
}
