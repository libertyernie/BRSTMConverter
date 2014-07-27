using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BRSTMConverter.MusicClasses;
using System.IO;

namespace BRSTMConverter {
	public partial class VGMQuery : Form {
		public VGMQuery() {
			InitializeComponent();

			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = FileExtensions.VgmFilter;
			ofd.Multiselect = false;
			DialogResult dr = ofd.ShowDialog();
			if (dr != DialogResult.OK) {
				Close();
			}
			VGM vgm = new VGM(ofd.FileName, 44100);

			label4.Text = vgm.LoopStart + "";
			label5.Text = (vgm.Length - vgm.LoopStart) + "";
			label6.Text = vgm.Length + "";
			name.Text = Path.GetFileName(ofd.FileName);
		}
	}
}
