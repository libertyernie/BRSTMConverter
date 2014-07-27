namespace BRSTMConverter {
	partial class LicenseDialog {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.label1 = new System.Windows.Forms.Label();
			this.licenseButton = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.sourceButton = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.MaximumSize = new System.Drawing.Size(290, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "label1";
			// 
			// licenseButton
			// 
			this.licenseButton.Location = new System.Drawing.Point(133, 3);
			this.licenseButton.Name = "licenseButton";
			this.licenseButton.Size = new System.Drawing.Size(90, 23);
			this.licenseButton.TabIndex = 1;
			this.licenseButton.Text = "View License";
			this.licenseButton.UseVisualStyleBackColor = true;
			this.licenseButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button2.Location = new System.Drawing.Point(229, 3);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(60, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Close";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// sourceButton
			// 
			this.sourceButton.Location = new System.Drawing.Point(3, 3);
			this.sourceButton.Name = "sourceButton";
			this.sourceButton.Size = new System.Drawing.Size(75, 23);
			this.sourceButton.TabIndex = 3;
			this.sourceButton.Text = "Source";
			this.sourceButton.UseVisualStyleBackColor = true;
			this.sourceButton.Click += new System.EventHandler(this.sourceButton_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.sourceButton);
			this.panel1.Controls.Add(this.licenseButton);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 245);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(292, 28);
			this.panel1.TabIndex = 4;
			// 
			// LicenseDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label1);
			this.Name = "LicenseDialog";
			this.Text = "LicenseDialog";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button licenseButton;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button sourceButton;
		private System.Windows.Forms.Panel panel1;
	}
}