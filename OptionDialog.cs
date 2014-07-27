using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BRSTMConverter.OutputFormats;
using BRSTMConverter.MusicClasses;
using System.IO;

namespace BRSTMConverter
{
	public partial class OptionDialog : Form {
		private const string LOOP = "Loop start to end";
		private const string LOOP_NONE = "Don't loop";
		private const string LOOP_ASK = "Ask every time (BRSTM only)";

		public OptionDialog() {
			InitializeComponent();
			this.Text = Shared.PROGRAM_TITLE;
			this.comboBox1.Items.AddRange(OutputFormat.array);
			this.comboBox1.SelectedIndex = 0;
			this.loop.Items.Add(LOOP);
			this.loop.Items.Add(LOOP_NONE);
			this.loop.Items.Add(LOOP_ASK);
			this.loop.SelectedIndex = 0;
		}

		public OptionSet getOptionSet() {
			OptionSet os = new OptionSet();
			os.convertToMono = mono.Checked;
			string loop = this.loop.Text;
			if (loop == LOOP) {
				os.loopWav = OptionSet.LOOP;
			} else if (loop == LOOP_NONE) {
				os.loopWav = OptionSet.LOOP_NONE;
			} else {
				os.loopWav = OptionSet.LOOP_ASK;
			}
			if (no_amp.Checked) {
				os.ampType = OptionSet.NO_AMP;
			} else if (db_amp.Checked) {
				os.ampType = OptionSet.DB_TYPE;
				try { os.ampAmount = Double.Parse(db_amp_amt.Text); } catch { throw new FormatException("The value entered for the amplification amount is not a number."); }
			} else {
				os.ampType = OptionSet.AMPLITUDE_TYPE;
				try { os.ampAmount = Double.Parse(factor_amp_amt.Text); } catch { throw new FormatException("The value entered for the amplification amount is not a number."); }
			}
			if (rate_none.Checked) {
				os.convertRate = OptionSet.RATE_NO_CONVERSION;
			} else if (rate_abs.Checked) {
				os.convertRate = OptionSet.RATE_ABSOLUTE;
			} else {
				os.convertRate = OptionSet.RATE_RELATIVE;
				try { os.rateFactor = Double.Parse(rate_factor_amt.Text); } catch (FormatException) { throw new FormatException("The value entered for the rate conversion factor is not a number."); }
				if (min_rate.Checked) {
					try { os.minimumRate = Int32.Parse(min_rate_amt.Text); } catch { throw new FormatException("The value entered for the minimum rate is not an integer."); }
				}
			}
			try { os.defaultRate = Int32.Parse(default_rate.Text); } catch { throw new FormatException("The value entered for the default sample rate is not an integer."); }

			if (comboBox1.SelectedItem is OutputFormat) {
				os.outputFormat = (OutputFormat)comboBox1.SelectedItem;
			} else {
				string s = comboBox1.Text;
				os.outputFormat = new SoXOutputFormat(s, s, false);
			}
			return os;
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e) {
			Music.Verbose = checkBox1.Checked;
		}

		private void simpleBRSTMWAVToolStripMenuItem_Click(object sender, EventArgs e) {
			BrstmConverterDialog bcd = new BrstmConverterDialog();
			bcd.ShowDialog(this);
		}

		private void forThisDialogToolStripMenuItem_Click(object sender, EventArgs e) {
			HTMLViewer h = new HTMLViewer("help.html");
			h.Text = Shared.PROGRAM_TITLE + " - Help";
			h.ShowDialog(this);
		}

		private void bRSTMConverterToolStripMenuItem_Click(object sender, EventArgs e) {
			LicenseDialog ld = new LicenseDialog(Shared.PROGRAM_TITLE + "\n" +
			"Copyright (C) 2012 Isaac Schemm\n\n" +

				"Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the \"Software\"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:\n\n" +

				"The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.\n\n" +

				"THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.",
				"MIT License", null,
				"http://lakora.us/brawl/brstm/source");
			ld.Height = 410;
			ld.ShowDialog(this);
		}

		private void brawlLibToolStripMenuItem_Click(object sender, EventArgs e) {
			new LicenseDialog("Copyright © 2009 - 2012 Bryan Moulton and BlackJax96\n\n" +
			"This program is provided as-is without any warranty, implied or otherwise." +
			" By using this program, the end user agrees to take full responsibility regarding its proper and lawful use." +
			" The authors/hosts/distributors cannot be held responsible for any damage resulting in the use of this program," +
			" nor can they be held accountable for the manner in which it is used.",
			"BrawlLib disclaimer", null, "http://forums.kc-mm.com/index.php?topic=17547.0")
			.ShowDialog(this);
		}

		private void soXToolStripMenuItem_Click(object sender, EventArgs e) {
			new LicenseDialog("Copyright 1998−2011 Chris Bagwell and SoX Contributors.\n" +
			"Copyright 1991 Lance Norskog and Sundry Contributors.\n\n" +

			"This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2, or (at your option) any later version.\n\n" +

			"This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.",
				"GNU General Public License", "http://www.gnu.org/copyleft/gpl", "http://sourceforge.net/projects/sox/files/sox/14.4.0")
				.ShowDialog(this);
		}

		private void libmaddllToolStripMenuItem_Click(object sender, EventArgs e) {
			new LicenseDialog("mad - MPEG audio decoder\n" +
			"Copyright (C) 2000-2001 Robert Leslie\n\n" +

			"This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2, or (at your option) any later version.\n\n" +

			"This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.",
				"GNU General Public License", "http://www.gnu.org/copyleft/gpl", null)
				.ShowDialog(this);
		}

		private void testexeToolStripMenuItem_Click(object sender, EventArgs e) {
			new LicenseDialog("Copyright (c) 2008-2010 Adam Gashlin, Fastelbja, Ronny Elfert\n\n" +

			"Portions Copyright (c) 2004-2008, Marko Kreen\n" +
			"Portions Copyright 2001-2007  jagarl / Kazunori Ueno <jagarl@creator.club.ne.jp>\n" +
			"Portions Copyright (c) 1998, Justin Frankel/Nullsoft Inc.\n" +
			"Portions Copyright (C) 2006 Nullsoft, Inc\n." +
			"Portions Copyright (c) 2005-2007 Paul Hsieh\n" +
			"Portions Public Domain originating with Sun Microsystems\n\n" +

			"Click \"Show License\" for details.",
			"MIT License",
			Shared.VGMSTREAM_DIR + Path.DirectorySeparatorChar + "COPYING",
			"http://www.hcs64.com/vgmstream.html")
			.ShowDialog(this);
		}

		private void libmpg123ToolStripMenuItem_Click(object sender, EventArgs e) {
			new LicenseDialog("Main message:\n\n" +

			"	Code is copyrighted by Michael Hipp, who made it free software under the terms of the LGPL 2.1.\n\n" +

			"But that is not all of it.\n" +
			"mpg123 is licensed under the GNU General Lesser Public License, version 2.1, and in parts under the GNU General Public License, version 2.\n" +
			"That means that _all_ of mpg123 is licensed under GPL and the major part also under the LGPL.\n\n" +

			"Actually, the \"major part\" currently is the whole distributed package of mpg123. There are some files (old alsa output, libao output) that you get from our svn repository and that do not fall under LGPL.",
			"GPL / LGPL", Shared.VGMSTREAM_DIR + Path.DirectorySeparatorChar + "mpg123-1.4.3.COPYING.txt",
			"http://sourceforge.net/projects/mpg123/files/mpg123/1.4.3")
			.ShowDialog(this);
		}

		private void libvorbisToolStripMenuItem_Click(object sender, EventArgs e) {
			new LicenseDialog("Copyright (c) 2002-2004 Xiph.org Foundation\n\n" +

				"Click \"Show License\" for details.",
				"3-clause BSD License",
				Shared.VGMSTREAM_DIR + Path.DirectorySeparatorChar + "libvorbis-1.2.0.COPYING.txt",
				"http://downloads.xiph.org/releases/vorbis/")
				.ShowDialog(this);
		}

		private void libg7221decodeToolStripMenuItem_Click(object sender, EventArgs e) {
			new LicenseDialog("ITU-T SOFTWARE TOOLS' GENERAL PUBLIC LICENSE\n\n" +
				"Click \"Show License\" for details.",
				"ITU-T SOFTWARE TOOLS' GENERAL PUBLIC LICENSE",
				Shared.VGMSTREAM_DIR + Path.DirectorySeparatorChar + "g7221-gen-lic.txt",
				null).ShowDialog(this);
		}

		private void vorbiscommentToolStripMenuItem_Click(object sender, EventArgs e) {
			new LicenseDialog("libvorbis 1.2.0\n" +
				"Copyright (c) 2002-2004 Xiph.Org Foundation\n\n" +

				"libogg 1.1.3\n" +
				"Copyright (c) 2002, Xiph.Org Foundation\n\n" +

				"libflac 1.2.1\n" +
				"Copyright (C) 2000,2001,2002,2003,2004,2005,2006,2007  Josh Coalson\n\n" +

				"libvorbis, libogg and libflac are distributed under the terms of the " +
				"revised 3-clause BSD license.\n\n" +

				"vorbis-tools 1.2.0\n" +
				"Copyright (c) 2008 Xiph.Org Foundation\n\n" +

				"vorbis-tools is distributed under the terms of the GNU General Public License.",
				"3-clause BSD / GPL",
				Shared.VORBIS_TOOLS_DIR + Path.DirectorySeparatorChar + "LICENSE",
				"http://downloads.xiph.org/releases/vorbis/")
				.ShowDialog(this);
		}

		private void vGMQueryToolStripMenuItem_Click(object sender, EventArgs e) {
			new VGMQuery().ShowDialog(this);
		}

		private void websiteToolStripMenuItem_Click(object sender, EventArgs e) {
			System.Diagnostics.Process.Start("http://lakora.us/brawl/brstm");
		}

		private void showHide_Click(object sender, EventArgs e) {
			if (extraControlsPanel.Visible) {
				extraControlsPanel.Visible = false;
				showHide.Text = showHide.Text.Replace("Hide", "Show");
				Height = 210;
			} else {
				extraControlsPanel.Visible = true;
				showHide.Text = showHide.Text.Replace("Show", "Hide");
				if (Height < 350) {
					Height = 350;
				}
			}
		}

	}
}

