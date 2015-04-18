using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Wheres_My_Note
{
    public partial class frmMessage : Form
    {
        public frmMessage()
        {
            InitializeComponent();
        }

        public void AddLabel(string labelText, int labelNumber, Color labelColor,bool lastLabel)
        {
            this.SuspendLayout();
            Label lbl = new Label();
            lbl.AutoSize = true;
            lbl.Name = "lbl" + labelNumber;
            lbl.Location = new Point(btnOk.Location.X, (labelNumber * lbl.Height));
            lbl.Text = labelText;
            lbl.ForeColor = labelColor;
            lbl.Font = new Font("Arial", 14, FontStyle.Bold);
            lbl.Visible = true;
            lbl.Enabled = true;
            this.Controls.Add(lbl);
            if (lastLabel)
            {
                this.Height = lbl.Location.Y + (4 * lbl.Height);
                btnOk.Location = new Point(btnOk.Location.X, (this.Height - ((lbl.Height * 25)/10)));
            }

            this.ResumeLayout();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
