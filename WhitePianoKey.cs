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
    public partial class WhitePianoKey : UserControl
    {
        PianoKeyType outputKeyType = new PianoKeyType();
        public WhitePianoKey()
        {
            InitializeComponent();
        }

        public event EventHandler KeyClicked;

        public event EventHandler KeyMouseDown;

        public event EventHandler KeyMouseUp;

        public enum PianoKeyType
        { Left, Middle, Right}

        [Description("Choose piano key type"),
         Category("Appearance"),     
        ]
        public PianoKeyType KeyType
        {
            get { return outputKeyType; }
            set
            {
                outputKeyType = value;
                ResizeByType(value);
            }
        }


        public int BlackPositionLeftEnd
        {
            get { return pnlUpper.Location.X + 1; }
            set
            {
                
            }
        }

        public int BlackPositionRightStart
        {
            get { return (pnlUpper.Location.X + pnlUpper.Width); }
            set
            {
                
            }
        }

        public int BlackHeight
        {
            get { return (pnlUpper.Height - 1); }
            set
            {

            }
        }

        public int BlackWidthLeftSide
        {
            get { return (pnlUpper.Location.X); }
            set
            {

            }
        }

        public int BlackWidthRightSide
        {
            get { return (this.Width - pnlUpper.Width - pnlUpper.Location.X); }
            set
            {

            }
        }

        public int BlackWidthKey
        {
            get { return (this.Width - pnlUpper.Width); }
            set { }
        }

      

        private void ResizeByType (PianoKeyType keyType)
        {
            pnlLower.Width = this.Width;
            switch (keyType)
            {
                case PianoKeyType.Left:
                    pnlUpper.Width = this.Width * 7 / 10 - 2;
                    pnlUpper.Location = new Point(0, 0);
                    break;
                case PianoKeyType.Right:
                    pnlUpper.Width = this.Width * 7 / 10;
                    pnlUpper.Location = new Point(pnlUpper.Width / 2, 0);
                    break;
                case PianoKeyType.Middle:
                    pnlUpper.Width = this.Width * 7 / 20; // (width*7/10)/2
                    pnlUpper.Location = new Point(pnlUpper.Width, 0);
                    break;
            }
        }

        public void SetColor(Color color)
        {
            pnlUpper.BackColor = color;
            pnlLower.BackColor = color;
        }


        public Color GetColor()
        {
            return pnlLower.BackColor;
        }

//----------------------------------------------------------------------------------
//                  Raise event when clicked
//----------------------------------------------------------------------------------
        protected void pnl_Click(object sender, EventArgs e)
        {
            if (this.KeyClicked != null)
            { this.KeyClicked(this, e); }
        }


//----------------------------------------------------------------------------------
//                  Change key color when mouse enter and leave
//----------------------------------------------------------------------------------

        private void pnl_MouseEnter(object sender, EventArgs e)
        {
            if (pnlLower.BackColor == Color.White)
            //{ SetColor(Color.Gainsboro); }
            {
                pnlLower.BackColor = Color.Gainsboro;
                pnlUpper.BackColor = Color.Gainsboro;
            }
        }

        private void pnl_MouseLeave(object sender, EventArgs e)
        {
            if (pnlLower.BackColor == Color.Gainsboro)
            //{ SetColor(Color.White); }
            {
                pnlLower.BackColor = Color.White;
                pnlUpper.BackColor = Color.White;
            }
        }
//------------------------------------------------------------------------------------
        private void PianoKey_Resize(object sender, EventArgs e)
        {
            //height ( y )
            double totalHeight, lowerPartHeight;
            totalHeight = Convert.ToDouble(this.Height);
            lowerPartHeight = totalHeight / 2.34;
            pnlLower.Height = Convert.ToInt32(lowerPartHeight);
            pnlUpper.Height = this.Height - pnlLower.Height;

            //width ( x )
            ResizeByType(this.KeyType);
        }

        private void pnl_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.KeyMouseDown != null)
            { this.KeyMouseDown(this, e); }
        }

        private void pnl_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.KeyMouseUp != null)
            { this.KeyMouseUp(this, e); }
        }
    }
}
