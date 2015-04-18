namespace Wheres_My_Note
{
    partial class WhitePianoKey
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlUpper = new System.Windows.Forms.Panel();
            this.pnlLower = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlUpper
            // 
            this.pnlUpper.BackColor = System.Drawing.Color.White;
            this.pnlUpper.Location = new System.Drawing.Point(0, 0);
            this.pnlUpper.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlUpper.Name = "pnlUpper";
            this.pnlUpper.Size = new System.Drawing.Size(49, 129);
            this.pnlUpper.TabIndex = 7;
            this.pnlUpper.MouseLeave += new System.EventHandler(this.pnl_MouseLeave);
            this.pnlUpper.Click += new System.EventHandler(this.pnl_Click);
            this.pnlUpper.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_MouseDown);
            this.pnlUpper.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnl_MouseUp);
            this.pnlUpper.MouseEnter += new System.EventHandler(this.pnl_MouseEnter);
            // 
            // pnlLower
            // 
            this.pnlLower.BackColor = System.Drawing.Color.White;
            this.pnlLower.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLower.Location = new System.Drawing.Point(0, 127);
            this.pnlLower.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlLower.Name = "pnlLower";
            this.pnlLower.Size = new System.Drawing.Size(67, 119);
            this.pnlLower.TabIndex = 8;
            this.pnlLower.MouseLeave += new System.EventHandler(this.pnl_MouseLeave);
            this.pnlLower.Click += new System.EventHandler(this.pnl_Click);
            this.pnlLower.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_MouseDown);
            this.pnlLower.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnl_MouseUp);
            this.pnlLower.MouseEnter += new System.EventHandler(this.pnl_MouseEnter);
            // 
            // WhitePianoKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnlUpper);
            this.Controls.Add(this.pnlLower);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "WhitePianoKey";
            this.Size = new System.Drawing.Size(67, 246);
            this.Resize += new System.EventHandler(this.PianoKey_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlUpper;
        private System.Windows.Forms.Panel pnlLower;


    }
}
