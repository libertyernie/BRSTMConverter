using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BRSTMConverter {
	public partial class TwoLineStatusBox : Form {
		private bool _shouldClose;

		public TwoLineStatusBox() {
			_shouldClose = false;
			InitializeComponent();
		}
		public void changeMessage(string message) {
			label2.Text = message;
		}
		public void changeStatus(string message) {
			label1.Text = message;
		}
		public void changeTitle(string title) {
			Text = title;
		}

		protected override void OnFormClosing(FormClosingEventArgs e) {
			_shouldClose = true;
		}

		public bool ShouldClose {
			get {
				return _shouldClose;
			}
		}

		private void ProgressBox_Load(object sender, EventArgs e) {

		}
	}
}
