namespace BRSTMConverter
{
    partial class OptionDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.mono = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.no_amp = new System.Windows.Forms.RadioButton();
			this.db_amp = new System.Windows.Forms.RadioButton();
			this.factor_amp = new System.Windows.Forms.RadioButton();
			this.db_amp_amt = new System.Windows.Forms.TextBox();
			this.factor_amp_amt = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.loop = new System.Windows.Forms.ComboBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.min_rate_amt = new System.Windows.Forms.TextBox();
			this.min_rate = new System.Windows.Forms.CheckBox();
			this.rate_factor_amt = new System.Windows.Forms.TextBox();
			this.rate_factor = new System.Windows.Forms.RadioButton();
			this.rate_abs = new System.Windows.Forms.RadioButton();
			this.rate_none = new System.Windows.Forms.RadioButton();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.default_rate = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.simpleBRSTMWAVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.vGMQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.forThisDialogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.websiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.licensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bRSTMConverterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.brawlLibToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.soXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.libmaddllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.vgmstreamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.testexeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.libmpg123ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.libvorbisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.libg7221decodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.vorbiscommentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.extraControlsPanel = new System.Windows.Forms.Panel();
			this.showHide = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.extraControlsPanel.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mono
			// 
			this.mono.AutoSize = true;
			this.mono.Location = new System.Drawing.Point(12, 3);
			this.mono.Name = "mono";
			this.mono.Size = new System.Drawing.Size(104, 17);
			this.mono.TabIndex = 0;
			this.mono.Text = "Convert to mono";
			this.mono.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(147, 26);
			this.label4.TabIndex = 5;
			this.label4.Text = "For WAV/MP3/etc input files,\r\nwhen not listed in loop.txt";
			// 
			// no_amp
			// 
			this.no_amp.AutoSize = true;
			this.no_amp.Checked = true;
			this.no_amp.Location = new System.Drawing.Point(6, 19);
			this.no_amp.Name = "no_amp";
			this.no_amp.Size = new System.Drawing.Size(129, 17);
			this.no_amp.TabIndex = 8;
			this.no_amp.TabStop = true;
			this.no_amp.Text = "Don\'t adjust amplitude";
			this.no_amp.UseVisualStyleBackColor = true;
			// 
			// db_amp
			// 
			this.db_amp.AutoSize = true;
			this.db_amp.Location = new System.Drawing.Point(6, 43);
			this.db_amp.Name = "db_amp";
			this.db_amp.Size = new System.Drawing.Size(107, 17);
			this.db_amp.TabIndex = 9;
			this.db_amp.Text = "Adjustment in dB:";
			this.db_amp.UseVisualStyleBackColor = true;
			// 
			// factor_amp
			// 
			this.factor_amp.AutoSize = true;
			this.factor_amp.Location = new System.Drawing.Point(6, 66);
			this.factor_amp.Name = "factor_amp";
			this.factor_amp.Size = new System.Drawing.Size(70, 17);
			this.factor_amp.TabIndex = 10;
			this.factor_amp.Text = "Factor of:";
			this.factor_amp.UseVisualStyleBackColor = true;
			// 
			// db_amp_amt
			// 
			this.db_amp_amt.Location = new System.Drawing.Point(119, 42);
			this.db_amp_amt.Name = "db_amp_amt";
			this.db_amp_amt.Size = new System.Drawing.Size(40, 20);
			this.db_amp_amt.TabIndex = 11;
			// 
			// factor_amp_amt
			// 
			this.factor_amp_amt.Location = new System.Drawing.Point(82, 65);
			this.factor_amp_amt.Name = "factor_amp_amt";
			this.factor_amp_amt.Size = new System.Drawing.Size(77, 20);
			this.factor_amp_amt.TabIndex = 12;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.no_amp);
			this.groupBox1.Controls.Add(this.factor_amp_amt);
			this.groupBox1.Controls.Add(this.db_amp);
			this.groupBox1.Controls.Add(this.db_amp_amt);
			this.groupBox1.Controls.Add(this.factor_amp);
			this.groupBox1.Location = new System.Drawing.Point(12, 26);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(165, 92);
			this.groupBox1.TabIndex = 13;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Amplitude";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.loop);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Location = new System.Drawing.Point(12, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(165, 80);
			this.groupBox2.TabIndex = 14;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Looping (defaults)";
			// 
			// loop
			// 
			this.loop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.loop.FormattingEnabled = true;
			this.loop.Location = new System.Drawing.Point(6, 53);
			this.loop.Name = "loop";
			this.loop.Size = new System.Drawing.Size(153, 21);
			this.loop.TabIndex = 6;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.min_rate_amt);
			this.groupBox4.Controls.Add(this.min_rate);
			this.groupBox4.Controls.Add(this.rate_factor_amt);
			this.groupBox4.Controls.Add(this.rate_factor);
			this.groupBox4.Controls.Add(this.rate_abs);
			this.groupBox4.Controls.Add(this.rate_none);
			this.groupBox4.Location = new System.Drawing.Point(183, 3);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(197, 133);
			this.groupBox4.TabIndex = 16;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Sample Rate Adjustment";
			// 
			// min_rate_amt
			// 
			this.min_rate_amt.Location = new System.Drawing.Point(129, 104);
			this.min_rate_amt.Name = "min_rate_amt";
			this.min_rate_amt.Size = new System.Drawing.Size(62, 20);
			this.min_rate_amt.TabIndex = 18;
			// 
			// min_rate
			// 
			this.min_rate.AutoSize = true;
			this.min_rate.Location = new System.Drawing.Point(23, 106);
			this.min_rate.Name = "min_rate";
			this.min_rate.Size = new System.Drawing.Size(100, 17);
			this.min_rate.TabIndex = 3;
			this.min_rate.Text = "Don\'t go below:";
			this.min_rate.UseVisualStyleBackColor = true;
			// 
			// rate_factor_amt
			// 
			this.rate_factor_amt.Location = new System.Drawing.Point(84, 80);
			this.rate_factor_amt.Name = "rate_factor_amt";
			this.rate_factor_amt.Size = new System.Drawing.Size(107, 20);
			this.rate_factor_amt.TabIndex = 3;
			// 
			// rate_factor
			// 
			this.rate_factor.AutoSize = true;
			this.rate_factor.Location = new System.Drawing.Point(7, 80);
			this.rate_factor.Name = "rate_factor";
			this.rate_factor.Size = new System.Drawing.Size(70, 17);
			this.rate_factor.TabIndex = 2;
			this.rate_factor.Text = "Factor of:";
			this.rate_factor.UseVisualStyleBackColor = true;
			// 
			// rate_abs
			// 
			this.rate_abs.AutoSize = true;
			this.rate_abs.Location = new System.Drawing.Point(7, 43);
			this.rate_abs.Name = "rate_abs";
			this.rate_abs.Size = new System.Drawing.Size(150, 30);
			this.rate_abs.TabIndex = 1;
			this.rate_abs.Text = "Adjust to absolute value\r\n(uses \"default rate\" below)";
			this.rate_abs.UseVisualStyleBackColor = true;
			// 
			// rate_none
			// 
			this.rate_none.AutoSize = true;
			this.rate_none.Checked = true;
			this.rate_none.Location = new System.Drawing.Point(7, 19);
			this.rate_none.Name = "rate_none";
			this.rate_none.Size = new System.Drawing.Size(138, 17);
			this.rate_none.TabIndex = 0;
			this.rate_none.TabStop = true;
			this.rate_none.Text = "Don\'t adjust sample rate";
			this.rate_none.UseVisualStyleBackColor = true;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.label2);
			this.groupBox5.Controls.Add(this.default_rate);
			this.groupBox5.Controls.Add(this.label1);
			this.groupBox5.Location = new System.Drawing.Point(183, 3);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(197, 62);
			this.groupBox5.TabIndex = 17;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Sample Rate";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(124, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "samples/sec";
			// 
			// default_rate
			// 
			this.default_rate.Location = new System.Drawing.Point(10, 37);
			this.default_rate.Name = "default_rate";
			this.default_rate.Size = new System.Drawing.Size(108, 20);
			this.default_rate.TabIndex = 1;
			this.default_rate.Text = "32000";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(182, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Default rate: (used for vgm rendering)";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(183, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 13);
			this.label3.TabIndex = 18;
			this.label3.Text = "Output as:";
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(245, 69);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(135, 21);
			this.comboBox1.TabIndex = 19;
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.Location = new System.Drawing.Point(102, 101);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 20;
			this.button1.Text = "Cancel";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button2.Location = new System.Drawing.Point(183, 101);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 21;
			this.button2.Text = "OK";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(306, 107);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(74, 17);
			this.checkBox1.TabIndex = 22;
			this.checkBox1.Text = "show SoX";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(392, 24);
			this.menuStrip1.TabIndex = 23;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simpleBRSTMWAVToolStripMenuItem,
            this.vGMQueryToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.toolsToolStripMenuItem.Text = "&Tools";
			// 
			// simpleBRSTMWAVToolStripMenuItem
			// 
			this.simpleBRSTMWAVToolStripMenuItem.Name = "simpleBRSTMWAVToolStripMenuItem";
			this.simpleBRSTMWAVToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
			this.simpleBRSTMWAVToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
			this.simpleBRSTMWAVToolStripMenuItem.Text = "Simple WAV>&BRSTM";
			this.simpleBRSTMWAVToolStripMenuItem.ToolTipText = "The BRSTM converter dialog from BrawlLib.";
			this.simpleBRSTMWAVToolStripMenuItem.Click += new System.EventHandler(this.simpleBRSTMWAVToolStripMenuItem_Click);
			// 
			// vGMQueryToolStripMenuItem
			// 
			this.vGMQueryToolStripMenuItem.Name = "vGMQueryToolStripMenuItem";
			this.vGMQueryToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
			this.vGMQueryToolStripMenuItem.Text = "VGM Query";
			this.vGMQueryToolStripMenuItem.ToolTipText = "Check the loop start and end points of a VGM file.";
			this.vGMQueryToolStripMenuItem.Click += new System.EventHandler(this.vGMQueryToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.forThisDialogToolStripMenuItem,
            this.websiteToolStripMenuItem,
            this.toolStripMenuItem1,
            this.licensesToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// forThisDialogToolStripMenuItem
			// 
			this.forThisDialogToolStripMenuItem.Name = "forThisDialogToolStripMenuItem";
			this.forThisDialogToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
			this.forThisDialogToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.forThisDialogToolStripMenuItem.Text = "Help";
			this.forThisDialogToolStripMenuItem.Click += new System.EventHandler(this.forThisDialogToolStripMenuItem_Click);
			// 
			// websiteToolStripMenuItem
			// 
			this.websiteToolStripMenuItem.Name = "websiteToolStripMenuItem";
			this.websiteToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.websiteToolStripMenuItem.Text = "Website";
			this.websiteToolStripMenuItem.Click += new System.EventHandler(this.websiteToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(111, 6);
			// 
			// licensesToolStripMenuItem
			// 
			this.licensesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bRSTMConverterToolStripMenuItem,
            this.brawlLibToolStripMenuItem,
            this.toolStripMenuItem2,
            this.soXToolStripMenuItem,
            this.libmaddllToolStripMenuItem,
            this.vgmstreamToolStripMenuItem,
            this.vorbiscommentToolStripMenuItem});
			this.licensesToolStripMenuItem.Name = "licensesToolStripMenuItem";
			this.licensesToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.licensesToolStripMenuItem.Text = "&Licenses";
			// 
			// bRSTMConverterToolStripMenuItem
			// 
			this.bRSTMConverterToolStripMenuItem.Name = "bRSTMConverterToolStripMenuItem";
			this.bRSTMConverterToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
			this.bRSTMConverterToolStripMenuItem.Text = "BRSTM Converter";
			this.bRSTMConverterToolStripMenuItem.Click += new System.EventHandler(this.bRSTMConverterToolStripMenuItem_Click);
			// 
			// brawlLibToolStripMenuItem
			// 
			this.brawlLibToolStripMenuItem.Name = "brawlLibToolStripMenuItem";
			this.brawlLibToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
			this.brawlLibToolStripMenuItem.Text = "BrawlLib";
			this.brawlLibToolStripMenuItem.Click += new System.EventHandler(this.brawlLibToolStripMenuItem_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(156, 6);
			// 
			// soXToolStripMenuItem
			// 
			this.soXToolStripMenuItem.Name = "soXToolStripMenuItem";
			this.soXToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
			this.soXToolStripMenuItem.Text = "SoX";
			this.soXToolStripMenuItem.Click += new System.EventHandler(this.soXToolStripMenuItem_Click);
			// 
			// libmaddllToolStripMenuItem
			// 
			this.libmaddllToolStripMenuItem.Name = "libmaddllToolStripMenuItem";
			this.libmaddllToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
			this.libmaddllToolStripMenuItem.Text = "libmad.dll";
			this.libmaddllToolStripMenuItem.Click += new System.EventHandler(this.libmaddllToolStripMenuItem_Click);
			// 
			// vgmstreamToolStripMenuItem
			// 
			this.vgmstreamToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testexeToolStripMenuItem,
            this.libmpg123ToolStripMenuItem,
            this.libvorbisToolStripMenuItem,
            this.libg7221decodeToolStripMenuItem});
			this.vgmstreamToolStripMenuItem.Name = "vgmstreamToolStripMenuItem";
			this.vgmstreamToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
			this.vgmstreamToolStripMenuItem.Text = "vgmstream";
			// 
			// testexeToolStripMenuItem
			// 
			this.testexeToolStripMenuItem.Name = "testexeToolStripMenuItem";
			this.testexeToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.testexeToolStripMenuItem.Text = "Main program";
			this.testexeToolStripMenuItem.Click += new System.EventHandler(this.testexeToolStripMenuItem_Click);
			// 
			// libmpg123ToolStripMenuItem
			// 
			this.libmpg123ToolStripMenuItem.Name = "libmpg123ToolStripMenuItem";
			this.libmpg123ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.libmpg123ToolStripMenuItem.Text = "libmpg123";
			this.libmpg123ToolStripMenuItem.Click += new System.EventHandler(this.libmpg123ToolStripMenuItem_Click);
			// 
			// libvorbisToolStripMenuItem
			// 
			this.libvorbisToolStripMenuItem.Name = "libvorbisToolStripMenuItem";
			this.libvorbisToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.libvorbisToolStripMenuItem.Text = "libogg, libvorbis";
			this.libvorbisToolStripMenuItem.Click += new System.EventHandler(this.libvorbisToolStripMenuItem_Click);
			// 
			// libg7221decodeToolStripMenuItem
			// 
			this.libg7221decodeToolStripMenuItem.Name = "libg7221decodeToolStripMenuItem";
			this.libg7221decodeToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.libg7221decodeToolStripMenuItem.Text = "libg7221_decode";
			this.libg7221decodeToolStripMenuItem.Click += new System.EventHandler(this.libg7221decodeToolStripMenuItem_Click);
			// 
			// vorbiscommentToolStripMenuItem
			// 
			this.vorbiscommentToolStripMenuItem.Name = "vorbiscommentToolStripMenuItem";
			this.vorbiscommentToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
			this.vorbiscommentToolStripMenuItem.Text = "vorbiscomment";
			this.vorbiscommentToolStripMenuItem.Click += new System.EventHandler(this.vorbiscommentToolStripMenuItem_Click);
			// 
			// extraControlsPanel
			// 
			this.extraControlsPanel.Controls.Add(this.mono);
			this.extraControlsPanel.Controls.Add(this.groupBox1);
			this.extraControlsPanel.Controls.Add(this.groupBox4);
			this.extraControlsPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.extraControlsPanel.Location = new System.Drawing.Point(0, 24);
			this.extraControlsPanel.Name = "extraControlsPanel";
			this.extraControlsPanel.Size = new System.Drawing.Size(392, 142);
			this.extraControlsPanel.TabIndex = 24;
			this.extraControlsPanel.Visible = false;
			// 
			// showHide
			// 
			this.showHide.Dock = System.Windows.Forms.DockStyle.Top;
			this.showHide.Location = new System.Drawing.Point(0, 166);
			this.showHide.Name = "showHide";
			this.showHide.Size = new System.Drawing.Size(392, 23);
			this.showHide.TabIndex = 25;
			this.showHide.Text = "Show Volume/Quality Controls";
			this.showHide.UseVisualStyleBackColor = true;
			this.showHide.Click += new System.EventHandler(this.showHide_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Controls.Add(this.groupBox5);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.checkBox1);
			this.panel1.Controls.Add(this.comboBox1);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 53);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(392, 130);
			this.panel1.TabIndex = 26;
			// 
			// OptionDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(392, 183);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.showHide);
			this.Controls.Add(this.extraControlsPanel);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "OptionDialog";
			this.Text = "BRSTM Converter .NET";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.extraControlsPanel.ResumeLayout(false);
			this.extraControlsPanel.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.CheckBox mono;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton no_amp;
        private System.Windows.Forms.RadioButton db_amp;
        private System.Windows.Forms.RadioButton factor_amp;
        private System.Windows.Forms.TextBox db_amp_amt;
        private System.Windows.Forms.TextBox factor_amp_amt;
        private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox rate_factor_amt;
        private System.Windows.Forms.RadioButton rate_factor;
        private System.Windows.Forms.RadioButton rate_abs;
        private System.Windows.Forms.RadioButton rate_none;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox default_rate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox min_rate_amt;
        private System.Windows.Forms.CheckBox min_rate;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ComboBox loop;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem simpleBRSTMWAVToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem forThisDialogToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem licensesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem bRSTMConverterToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem brawlLibToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem soXToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem vgmstreamToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem vorbiscommentToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem libmaddllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem testexeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem libmpg123ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem libvorbisToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem libg7221decodeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem vGMQueryToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem websiteToolStripMenuItem;
		private System.Windows.Forms.Panel extraControlsPanel;
		private System.Windows.Forms.Button showHide;
		private System.Windows.Forms.Panel panel1;
    }
}

