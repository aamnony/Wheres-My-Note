using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Wheres_My_Note
{
    public partial class BlackPianoKey : UserControl
    {
        public BlackPianoKey()
        {
            InitializeComponent();

        }

        public void SetColor(Color color)
        {
            this.BackColor = color;
        }

        public Color GetColor()
        {
            return this.BackColor;
        }

        //private void BlackPianoKey_Click(object sender, EventArgs e, Color color)
        //{
        //    if (this.BackColor == Color.DimGray)
        //        this.BackColor = color;
        //    else
        //        this.BackColor = Color.DimGray;
        //}

        private void BlackPianoKey_MouseEnter(object sender, EventArgs e)
        {
            if (this.BackColor == Color.Black)
            { this.BackColor = Color.DimGray; }
        }

        private void BlackPianoKey_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor == Color.DimGray)
            { this.BackColor = Color.Black; }
        }


    }
}
