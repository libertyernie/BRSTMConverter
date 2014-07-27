using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BRSTMConverter.OutputFormats;

/*****************************************************************************
 * Copyright (C) 2012 Isaac Schemm
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 2 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 ****************************************************************************/

namespace BRSTMConverter
{

    public class OptionSet {

        public bool convertToMono { get; set; }

        public int convertRate { get; set; }
	    public const int RATE_ABSOLUTE = 1;
	    public const int RATE_RELATIVE = 2;
	    public const int RATE_NO_CONVERSION = 3;

        public double ampAmount { get; set; }
        public double rateFactor { get; set; }
	    public int defaultRate {get;set;}

        public int ampType { get; set; }
	    public const int NO_AMP = -1;
	    public const int AMPLITUDE_TYPE = 0;
	    public const int DB_TYPE = 2;
	    public const int MAX_AMP_WITHOUT_CLIPPING = 3;

		public const int LOOP = 0;
		public const int LOOP_NONE = -1;
		public const int LOOP_ASK = -2;
	    /**
	     * Whether to loop WAV/FLAC/OGG files that are not listed in loop.txt from start to end.
	     */
        public int loopWav { get; set; }
        public int minimumRate { get; set; }

	    public string loopTxt { get; set; }

        public OutputFormat outputFormat { get; set; }
        public bool loopTrim { get; set; }
	
	    public override string ToString() {
		    string sb = "OptionSet: ";
		    sb += ("default rendering rate: " + defaultRate + ", ");
		    if (convertToMono) sb += ("to mono, ");
		    if (convertRate == RATE_ABSOLUTE) sb += ("to rate " + defaultRate + ", ");
		    if (convertRate == RATE_RELATIVE) sb += ("to " + (rateFactor * 100.0) + "% of old rate, ");
		    if (ampType == AMPLITUDE_TYPE) {
			    if (ampAmount != 1.0) sb += ("amplification " + ampAmount + ", ");
		    } else if (ampType == DB_TYPE) {
			    if (ampAmount != 0.0) sb += ("amplification " + ampAmount + " dB, ");			
		    } else if (ampType == MAX_AMP_WITHOUT_CLIPPING) {
			    sb += ("maximum amplification without clipping, ");
		    }
		    if (minimumRate > 0) sb += ("minimum rate " + minimumRate + ", ");
		    if (loopWav == LOOP) {
			    sb += ("loop WAVs not in " + loopTxt + ", ");
		    } else if (loopWav == LOOP_ASK) {
			    sb += ("ask to loop WAVs not in " + loopTxt + ", ");
		    } else {
			    sb += ("don't loop WAVs not in " + loopTxt + ", ");
		    }
		    sb += ("outputFormat = \"" + outputFormat + "\" (" + outputFormat.ext + ")");
		    if (loopTrim) {
			    sb += (" (trim to end of loop), ");
		    } else {
			    sb += (", ");
		    }
		    return sb.Substring(0, sb.Length-2);
	    }
	
	    public OptionSet() {
		    // Define variable defaults. Some of these, such as rateChange and newRateGlobal, will not be used unless they are user-defined.
			// If OptionDialog is used, these will be replaced, so the OptionDialog defaults should probably match these.
		    convertToMono = false;
		    convertRate = RATE_NO_CONVERSION;
		    defaultRate = 32000;
		    rateFactor = 1.0;
		    ampAmount = 1.0;
		    ampType = NO_AMP;
		    loopWav = LOOP;
		    minimumRate = 0; // default should not be used except to check if one has been defined
            loopTxt = "loop.txt";
		    outputFormat = OutputFormat.array[0];
	    }

    }

}
