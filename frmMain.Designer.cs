namespace Wheres_My_Note
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnNotes = new System.Windows.Forms.Button();
            this.btnFindNote = new System.Windows.Forms.Button();
            this.cmbPitch = new System.Windows.Forms.ComboBox();
            this.cmbNote = new System.Windows.Forms.ComboBox();
            this.grbFind = new System.Windows.Forms.GroupBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.rbtnRosewood = new System.Windows.Forms.RadioButton();
            this.rbtnMaple = new System.Windows.Forms.RadioButton();
            this.cmbGuitarTunings = new System.Windows.Forms.ComboBox();
            this.grbGuitarStyle = new System.Windows.Forms.GroupBox();
            this.grbTuning = new System.Windows.Forms.GroupBox();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.chkOverrideNotes = new System.Windows.Forms.CheckBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPlayback = new System.Windows.Forms.Button();
            this.grbPlayback = new System.Windows.Forms.GroupBox();
            this.lblPlaybackNormal = new System.Windows.Forms.Label();
            this.lblPlaybackSlowest = new System.Windows.Forms.Label();
            this.cmbInstrument = new System.Windows.Forms.ComboBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.saveFile1 = new System.Windows.Forms.SaveFileDialog();
            this.openFile1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grbFind.SuspendLayout();
            this.grbGuitarStyle.SuspendLayout();
            this.grbTuning.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.grbPlayback.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Location = new System.Drawing.Point(145, 147);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(112, 109);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Clear";
            this.toolTip1.SetToolTip(this.btnClear, "Clear all selected Notes");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnNotes
            // 
            this.btnNotes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNotes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNotes.Location = new System.Drawing.Point(6, 61);
            this.btnNotes.Name = "btnNotes";
            this.btnNotes.Size = new System.Drawing.Size(204, 35);
            this.btnNotes.TabIndex = 1;
            this.btnNotes.Text = "Shown Notes";
            this.toolTip1.SetToolTip(this.btnNotes, "Show all previously selected Notes");
            this.btnNotes.UseVisualStyleBackColor = true;
            this.btnNotes.Click += new System.EventHandler(this.btnNotes_Click);
            // 
            // btnFindNote
            // 
            this.btnFindNote.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFindNote.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFindNote.Location = new System.Drawing.Point(135, 25);
            this.btnFindNote.Name = "btnFindNote";
            this.btnFindNote.Size = new System.Drawing.Size(75, 31);
            this.btnFindNote.TabIndex = 26;
            this.btnFindNote.Text = "Find";
            this.btnFindNote.UseVisualStyleBackColor = true;
            this.btnFindNote.Click += new System.EventHandler(this.btnFindNote_Click);
            // 
            // cmbPitch
            // 
            this.cmbPitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbPitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPitch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbPitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPitch.FormattingEnabled = true;
            this.cmbPitch.Items.AddRange(new object[] {
            "",
            "All",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cmbPitch.Location = new System.Drawing.Point(75, 25);
            this.cmbPitch.Name = "cmbPitch";
            this.cmbPitch.Size = new System.Drawing.Size(54, 28);
            this.cmbPitch.TabIndex = 25;
            this.toolTip1.SetToolTip(this.cmbPitch, "Select desired Octave");
            // 
            // cmbNote
            // 
            this.cmbNote.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbNote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNote.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNote.FormattingEnabled = true;
            this.cmbNote.Items.AddRange(new object[] {
            "",
            "C",
            "C#",
            "D",
            "D#",
            "E",
            "F",
            "F#",
            "G",
            "G#",
            "A",
            "A#",
            "B"});
            this.cmbNote.Location = new System.Drawing.Point(6, 25);
            this.cmbNote.Name = "cmbNote";
            this.cmbNote.Size = new System.Drawing.Size(63, 28);
            this.cmbNote.TabIndex = 24;
            this.toolTip1.SetToolTip(this.cmbNote, "Select desired Pitch");
            // 
            // grbFind
            // 
            this.grbFind.Controls.Add(this.btnFindNote);
            this.grbFind.Controls.Add(this.cmbPitch);
            this.grbFind.Controls.Add(this.cmbNote);
            this.grbFind.Controls.Add(this.btnNotes);
            this.grbFind.Location = new System.Drawing.Point(263, 147);
            this.grbFind.Name = "grbFind";
            this.grbFind.Size = new System.Drawing.Size(212, 109);
            this.grbFind.TabIndex = 29;
            this.grbFind.TabStop = false;
            this.grbFind.Text = "Note";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Monotype Corsiva", 72F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(120, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(854, 147);
            this.lblTitle.TabIndex = 30;
            this.lblTitle.Text = "Where\'s My Note?";
            this.toolTip1.SetToolTip(this.lblTitle, "Created by Asaf Amnony");
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Location = new System.Drawing.Point(3, 47);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(114, 29);
            this.btnExit.TabIndex = 31;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMinimize.Location = new System.Drawing.Point(3, 3);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(112, 38);
            this.btnMinimize.TabIndex = 32;
            this.btnMinimize.Text = "Minimize";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // rbtnRosewood
            // 
            this.rbtnRosewood.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnRosewood.BackColor = System.Drawing.Color.SaddleBrown;
            this.rbtnRosewood.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnRosewood.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnRosewood.FlatAppearance.CheckedBackColor = System.Drawing.Color.SaddleBrown;
            this.rbtnRosewood.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SandyBrown;
            this.rbtnRosewood.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SaddleBrown;
            this.rbtnRosewood.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbtnRosewood.ForeColor = System.Drawing.Color.White;
            this.rbtnRosewood.Location = new System.Drawing.Point(87, 18);
            this.rbtnRosewood.Name = "rbtnRosewood";
            this.rbtnRosewood.Size = new System.Drawing.Size(84, 88);
            this.rbtnRosewood.TabIndex = 1;
            this.rbtnRosewood.Text = "Rosewood";
            this.rbtnRosewood.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnRosewood.UseVisualStyleBackColor = false;
            this.rbtnRosewood.CheckedChanged += new System.EventHandler(this.GuitarStyleChanged);
            // 
            // rbtnMaple
            // 
            this.rbtnMaple.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnMaple.BackColor = System.Drawing.Color.Cornsilk;
            this.rbtnMaple.Checked = true;
            this.rbtnMaple.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnMaple.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnMaple.FlatAppearance.CheckedBackColor = System.Drawing.Color.Khaki;
            this.rbtnMaple.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Beige;
            this.rbtnMaple.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this.rbtnMaple.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbtnMaple.ForeColor = System.Drawing.Color.Black;
            this.rbtnMaple.Location = new System.Drawing.Point(3, 18);
            this.rbtnMaple.Name = "rbtnMaple";
            this.rbtnMaple.Size = new System.Drawing.Size(84, 88);
            this.rbtnMaple.TabIndex = 0;
            this.rbtnMaple.TabStop = true;
            this.rbtnMaple.Text = "Maple";
            this.rbtnMaple.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnMaple.UseVisualStyleBackColor = false;
            this.rbtnMaple.CheckedChanged += new System.EventHandler(this.GuitarStyleChanged);
            // 
            // cmbGuitarTunings
            // 
            this.cmbGuitarTunings.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbGuitarTunings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbGuitarTunings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGuitarTunings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbGuitarTunings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGuitarTunings.FormattingEnabled = true;
            this.cmbGuitarTunings.IntegralHeight = false;
            this.cmbGuitarTunings.ItemHeight = 20;
            this.cmbGuitarTunings.Items.AddRange(new object[] {
            "Standard (EADGBE)",
            "Drop D (DADGBE)",
            "Half-Step Down (D#G#C#F#A#D#)",
            "Full-Step Down (DGCFAD)",
            "DADGAD",
            "Open D (DADF#AD)",
            "Open G (DGDGBD)",
            "Open C (CGCGCE)"});
            this.cmbGuitarTunings.Location = new System.Drawing.Point(7, 44);
            this.cmbGuitarTunings.Margin = new System.Windows.Forms.Padding(4);
            this.cmbGuitarTunings.Name = "cmbGuitarTunings";
            this.cmbGuitarTunings.Size = new System.Drawing.Size(227, 28);
            this.cmbGuitarTunings.TabIndex = 34;
            this.toolTip1.SetToolTip(this.cmbGuitarTunings, "Select the tuning for the Guitar\r\n*When selecting different tunings, some Notes m" +
                    "ay disappear from guitar");
            this.cmbGuitarTunings.SelectedIndexChanged += new System.EventHandler(this.TuneGuitar);
            // 
            // grbGuitarStyle
            // 
            this.grbGuitarStyle.Controls.Add(this.rbtnRosewood);
            this.grbGuitarStyle.Controls.Add(this.rbtnMaple);
            this.grbGuitarStyle.Location = new System.Drawing.Point(492, 147);
            this.grbGuitarStyle.Name = "grbGuitarStyle";
            this.grbGuitarStyle.Size = new System.Drawing.Size(181, 109);
            this.grbGuitarStyle.TabIndex = 36;
            this.grbGuitarStyle.TabStop = false;
            this.grbGuitarStyle.Text = "Guitar Style";
            // 
            // grbTuning
            // 
            this.grbTuning.Controls.Add(this.cmbGuitarTunings);
            this.grbTuning.Location = new System.Drawing.Point(679, 147);
            this.grbTuning.Name = "grbTuning";
            this.grbTuning.Size = new System.Drawing.Size(245, 109);
            this.grbTuning.TabIndex = 37;
            this.grbTuning.TabStop = false;
            this.grbTuning.Text = "Guitar Tuning";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.btnHelp);
            this.pnlLeft.Controls.Add(this.chkOverrideNotes);
            this.pnlLeft.Controls.Add(this.btnLoad);
            this.pnlLeft.Controls.Add(this.btnSave);
            this.pnlLeft.Controls.Add(this.btnExit);
            this.pnlLeft.Controls.Add(this.btnMinimize);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(120, 389);
            this.pnlLeft.TabIndex = 38;
            // 
            // btnHelp
            // 
            this.btnHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHelp.Location = new System.Drawing.Point(3, 96);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(112, 38);
            this.btnHelp.TabIndex = 36;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // chkOverrideNotes
            // 
            this.chkOverrideNotes.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkOverrideNotes.AutoSize = true;
            this.chkOverrideNotes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkOverrideNotes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkOverrideNotes.Location = new System.Drawing.Point(3, 268);
            this.chkOverrideNotes.Name = "chkOverrideNotes";
            this.chkOverrideNotes.Size = new System.Drawing.Size(114, 27);
            this.chkOverrideNotes.TabIndex = 35;
            this.chkOverrideNotes.Text = "Override Notes";
            this.toolTip1.SetToolTip(this.chkOverrideNotes, "When Enabled:  Clicks on colored Notes will add them again to history\r\nWhen Disab" +
                    "led: Clicks on colored Notes will remove them from history");
            this.chkOverrideNotes.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoad.Location = new System.Drawing.Point(3, 215);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(112, 38);
            this.btnLoad.TabIndex = 34;
            this.btnLoad.Text = "Load";
            this.toolTip1.SetToolTip(this.btnLoad, "Load a \"Where\'s My Note\" file");
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Location = new System.Drawing.Point(3, 162);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 38);
            this.btnSave.TabIndex = 33;
            this.btnSave.Text = "Save";
            this.toolTip1.SetToolTip(this.btnSave, "Save this as a \"Where\'s My Note\" file");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPlayback
            // 
            this.btnPlayback.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlayback.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPlayback.Location = new System.Drawing.Point(6, 21);
            this.btnPlayback.Name = "btnPlayback";
            this.btnPlayback.Size = new System.Drawing.Size(169, 37);
            this.btnPlayback.TabIndex = 39;
            this.btnPlayback.Text = "Playback";
            this.btnPlayback.UseVisualStyleBackColor = true;
            this.btnPlayback.Click += new System.EventHandler(this.btnPlayback_Click);
            // 
            // grbPlayback
            // 
            this.grbPlayback.Controls.Add(this.lblPlaybackNormal);
            this.grbPlayback.Controls.Add(this.lblPlaybackSlowest);
            this.grbPlayback.Controls.Add(this.cmbInstrument);
            this.grbPlayback.Controls.Add(this.trackBar1);
            this.grbPlayback.Controls.Add(this.btnPlayback);
            this.grbPlayback.Location = new System.Drawing.Point(930, 147);
            this.grbPlayback.Name = "grbPlayback";
            this.grbPlayback.Size = new System.Drawing.Size(284, 109);
            this.grbPlayback.TabIndex = 40;
            this.grbPlayback.TabStop = false;
            this.grbPlayback.Text = "Playback";
            // 
            // lblPlaybackNormal
            // 
            this.lblPlaybackNormal.AutoSize = true;
            this.lblPlaybackNormal.Location = new System.Drawing.Point(223, 74);
            this.lblPlaybackNormal.Name = "lblPlaybackNormal";
            this.lblPlaybackNormal.Size = new System.Drawing.Size(53, 17);
            this.lblPlaybackNormal.TabIndex = 44;
            this.lblPlaybackNormal.Text = "Normal";
            // 
            // lblPlaybackSlowest
            // 
            this.lblPlaybackSlowest.AutoSize = true;
            this.lblPlaybackSlowest.Location = new System.Drawing.Point(223, 25);
            this.lblPlaybackSlowest.Name = "lblPlaybackSlowest";
            this.lblPlaybackSlowest.Size = new System.Drawing.Size(56, 17);
            this.lblPlaybackSlowest.TabIndex = 43;
            this.lblPlaybackSlowest.Text = "Slowest";
            // 
            // cmbInstrument
            // 
            this.cmbInstrument.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbInstrument.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInstrument.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbInstrument.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbInstrument.FormattingEnabled = true;
            this.cmbInstrument.Location = new System.Drawing.Point(6, 68);
            this.cmbInstrument.Name = "cmbInstrument";
            this.cmbInstrument.Size = new System.Drawing.Size(169, 28);
            this.cmbInstrument.TabIndex = 42;
            this.toolTip1.SetToolTip(this.cmbInstrument, "Select playback instrument");
            this.cmbInstrument.SelectedIndexChanged += new System.EventHandler(this.cmbInstrument_SelectedIndexChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(181, 18);
            this.trackBar1.Maximum = 5;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(47, 84);
            this.trackBar1.TabIndex = 41;
            this.toolTip1.SetToolTip(this.trackBar1, "Select playback speed");
            // 
            // saveFile1
            // 
            this.saveFile1.Filter = "\"Where\'s My Note File\"|*.txt";
            this.saveFile1.InitialDirectory = "C:\\";
            this.saveFile1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFile1_FileOk);
            // 
            // openFile1
            // 
            this.openFile1.Filter = "\"Where\'s My Note File\"|*.txt";
            this.openFile1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFile1_FileOk);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 389);
            this.Controls.Add(this.grbPlayback);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.grbGuitarStyle);
            this.Controls.Add(this.grbTuning);
            this.Controls.Add(this.grbFind);
            this.Cursor = System.Windows.Forms.Cursors.Help;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Where\'s My Note?";
            this.grbFind.ResumeLayout(false);
            this.grbGuitarStyle.ResumeLayout(false);
            this.grbTuning.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.grbPlayback.ResumeLayout(false);
            this.grbPlayback.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnNotes;
        private System.Windows.Forms.Button btnFindNote;
        private System.Windows.Forms.ComboBox cmbPitch;
        private System.Windows.Forms.ComboBox cmbNote;
        private System.Windows.Forms.GroupBox grbFind;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.RadioButton rbtnRosewood;
        private System.Windows.Forms.RadioButton rbtnMaple;
        private System.Windows.Forms.ComboBox cmbGuitarTunings;
        private System.Windows.Forms.GroupBox grbGuitarStyle;
        private System.Windows.Forms.GroupBox grbTuning;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Button btnPlayback;
        private System.Windows.Forms.GroupBox grbPlayback;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog saveFile1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TrackBar trackBar1;
        public System.Windows.Forms.CheckBox chkOverrideNotes;
        private System.Windows.Forms.OpenFileDialog openFile1;
        private System.Windows.Forms.ComboBox cmbInstrument;
        private System.Windows.Forms.Label lblPlaybackNormal;
        private System.Windows.Forms.Label lblPlaybackSlowest;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnHelp;
    }
}