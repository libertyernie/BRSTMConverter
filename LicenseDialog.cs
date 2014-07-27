using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BRSTMConverter {
	public partial class LicenseDialog : Form {
		private string licenseUrl, sourceLink;

		public LicenseDialog(string text, string title, string licenseUrl, string sourceLink) {
			InitializeComponent();
			this.Text = title;
			label1.Text = text;
			this.licenseUrl = licenseUrl;
			if (licenseUrl == null) {
				licenseButton.Visible = false;
			}
			this.sourceLink = sourceLink;
			if (sourceLink == null) {
				sourceButton.Visible = false;
			}
		}

		private void button1_Click(object sender, EventArgs e) {
			HTMLViewer h = new HTMLViewer(licenseUrl);
			h.Text = this.Text;
			h.Size = new Size(600, 400);
			h.ShowDialog(this);
		}

		private void sourceButton_Click(object sender, EventArgs e) {
			System.Diagnostics.Process.Start(sourceLink);
		}
	}
}
