using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BRSTMConverter {
	public partial class HTMLViewer : Form {
		public HTMLViewer(string url) {
			InitializeComponent();
			string curDir = Directory.GetCurrentDirectory();
			if (!url.StartsWith("http://")) {
				this.webBrowser1.Url = new Uri(String.Format("file:///{0}/" + url, curDir));
			} else {
				this.webBrowser1.Url = new Uri(url);
			}
		}
	}
}
