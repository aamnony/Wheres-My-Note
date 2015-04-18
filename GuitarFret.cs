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
    public partial class GuitarFret : UserControl
    {
        bool nutOrNot;
        int dots;
        public GuitarFret()
        {
            InitializeComponent();
            lbl1stString.BackColor = Color.Transparent;
            lbl2ndString.BackColor = Color.Transparent;
            lbl3rdString.BackColor = Color.Transparent;
            lbl4thString.BackColor = Color.Transparent;
            lbl5thString.BackColor = Color.Transparent;
            lbl6thString.BackColor = Color.Transparent;
        }

        public class GuitarEventArgs : EventArgs
        {
            private int stringNumber;
            private bool ctrlClicked, shiftClicked, altClicked;
            public GuitarEventArgs(int stringNumber, bool ctrlClicked, bool shiftClicked, bool altClicked)
            {
                this.stringNumber = stringNumber;
                this.ctrlClicked = ctrlClicked;
                this.shiftClicked = shiftClicked;
                this.altClicked = altClicked;
            }

            public bool ShiftClicked
            {
                get
                { return shiftClicked; }
            }

            public bool CtrlClicked
            {
                get
                { return ctrlClicked; }
            }

            public bool AltClicked
            {
                get
                { return altClicked; }
            }

            public int StringNumber
            {
                set { value = stringNumber; }
                get
                { return stringNumber; }
            }
        }

        public delegate void GuitarEventHandler(object sender, GuitarEventArgs e);

        public event GuitarEventHandler StringClicked;

        public event GuitarEventHandler StringMouseDown;

        public event GuitarEventHandler StringMouseUp;


        private int FirstStringNoteValue
        {
            get { return Convert.ToInt32(lbl1stString.Tag); }
            set
            { lbl1stString.Tag = value; }
        }
        private int SecondStringNoteValue
        {
            get { return Convert.ToInt32(lbl2ndString.Tag); }
            set
            { lbl2ndString.Tag = value; }
        }
        private int ThirdStringNoteValue
        {
            get { return Convert.ToInt32(lbl3rdString.Tag); }
            set
            { lbl3rdString.Tag = value; }
        }
        private int FourthStringNoteValue
        {
            get { return Convert.ToInt32(lbl4thString.Tag); }
            set
            { lbl4thString.Tag = value; }
        }
        private int FifthStringNoteValue
        {
            get { return Convert.ToInt32(lbl5thString.Tag); }
            set
            { lbl5thString.Tag = value; }
        }
        private int SixthStringNoteValue
        {
            get { return Convert.ToInt32(lbl6thString.Tag); }
            set
            { lbl6thString.Tag = value; }
        }

        [Description("Nut"),
         Category("Appearance"),
        ]
        public bool NutOrNot
        {
            get { return nutOrNot; }
            set
            {
                //nut
                nutOrNot = value;
                if (nutOrNot)
                {
                    picNut.Size = new Size(15, pnlFret.Height);
                    picFret.Visible = false;
                    picNut.Visible = true;
                }
                else
                {
                    picNut.Visible = false;
                    picFret.Visible = true;
                }
            }
        }

        [Description("Dots"),
         Category("Appearance"),
        ]
        public int Dots
        {
            get { return dots; }
            set
            {
                dots = value;
                if (dots == 0)
                {
                    picFret.BackgroundImage = global ::Wheres_My_Note.Properties.Resources.MapleFret;
                }
                else if (dots == 1)
                {
                    picFret.BackgroundImage = global ::Wheres_My_Note.Properties.Resources.MapleFret_Dot;
                }
                else if (dots == 2)
                {
                    picFret.BackgroundImage = global ::Wheres_My_Note.Properties.Resources.MapleFret_2Dots;
                }
            }
        }


        public void SetColor(Color color)
        {
            lbl1stString.BackColor = color;
            lbl2ndString.BackColor = color;
            lbl3rdString.BackColor = color;
            lbl4thString.BackColor = color;
            lbl5thString.BackColor = color;
            lbl6thString.BackColor = color;

        }

        public void SetColor(Color color, int stringNumber)
        {
            Label guitarString = new Label();
            switch (stringNumber)
            {
                case 1:
                    guitarString = lbl1stString;
                    break;
                case 2:
                    guitarString = lbl2ndString;
                    break;
                case 3:
                    guitarString = lbl3rdString;
                    break;
                case 4:
                    guitarString = lbl4thString;
                    break;
                case 5:
                    guitarString = lbl5thString;
                    break;
                case 6:
                    guitarString = lbl6thString;
                    break;
                default:
                    guitarString = lbl1stString;
                    break;
            }
            guitarString.BackColor = color;
        }

        public void SetCode(int stringNumber, int stringNoteValue)
        {
            switch (stringNumber)
            {
                case 0:
                    FirstStringNoteValue = stringNoteValue;
                    break;
                case 1:
                    SecondStringNoteValue = stringNoteValue;
                    break;
                case 2:
                    ThirdStringNoteValue = stringNoteValue;
                    break;
                case 3:
                    FourthStringNoteValue = stringNoteValue;
                    break;
                case 4:
                    FifthStringNoteValue = stringNoteValue;
                    break;
                case 5:
                    SixthStringNoteValue = stringNoteValue;
                    break;
                default:
                    FirstStringNoteValue = stringNoteValue;
                    break;
            }
        }

        public int GetCode(int stringNumber)
        {
            switch (stringNumber)
            {
                case 1:
                    return FirstStringNoteValue;
                case 2:
                    return SecondStringNoteValue;
                case 3:
                    return ThirdStringNoteValue;
                case 4:
                    return FourthStringNoteValue;
                case 5:
                    return FifthStringNoteValue;
                case 6:
                    return SixthStringNoteValue;
                default:
                    return FirstStringNoteValue;
            }
        }

        public Color GetColor(int stringNumber)
        {
            Label guitarString = new Label();
            switch (stringNumber)
            {
                case 1:
                    guitarString = lbl1stString;
                    break;
                case 2:
                    guitarString = lbl2ndString;
                    break;
                case 3:
                    guitarString = lbl3rdString;
                    break;
                case 4:
                    guitarString = lbl4thString;
                    break;
                case 5:
                    guitarString = lbl5thString;
                    break;
                case 6:
                    guitarString = lbl6thString;
                    break;
                default:
                    guitarString = lbl1stString;
                    break;
            }
            return guitarString.BackColor;
        }



        //----------------------------------------------------------------------------------
        //                          Change Background Image
        //----------------------------------------------------------------------------------

        public void ChangeBackImage(bool style)
        {
            //Maple
            if (style)
            {
                pnlFret.BackgroundImage = global::Wheres_My_Note.Properties.Resources.MapleFret;
                picFret.BackgroundImage = global::Wheres_My_Note.Properties.Resources.MapleSteel;
                picDot1.BackgroundImage = global::Wheres_My_Note.Properties.Resources.MapleDot;
                picDot2.BackgroundImage = global::Wheres_My_Note.Properties.Resources.MapleDot;
                picDot1.BackgroundImageLayout = ImageLayout.Stretch;
                picDot2.BackgroundImageLayout = ImageLayout.Stretch;

            }
            //Rosewood
            else if (!style)
            {
                pnlFret.BackgroundImage = global::Wheres_My_Note.Properties.Resources.RosewoodFret;
                picFret.BackgroundImage = global::Wheres_My_Note.Properties.Resources.RosewoodSteel;
                picDot1.BackgroundImage = global::Wheres_My_Note.Properties.Resources.RosewoodDot;
                picDot2.BackgroundImage = global::Wheres_My_Note.Properties.Resources.RosewoodDot;
                picDot1.BackgroundImageLayout = ImageLayout.Stretch;
                picDot2.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }



        //----------------------------------------------------------------------------------
        //                  Mouse actions
        //----------------------------------------------------------------------------------

        protected void GuitarString_Click(object sender, EventArgs e)
        {
            Label guitarString = (Label)sender;
            bool ctrlClicked, shiftClicked, altClicked;
            int stringNumber;
            if (ModifierKeys == Keys.Control)
            { ctrlClicked = true; }
            else
            { ctrlClicked = false; }

            if (ModifierKeys == Keys.Shift)
            { shiftClicked = true; }
            else
            { shiftClicked = false; }

            if (ModifierKeys == Keys.Alt)
            { altClicked = true; }
            else
            { altClicked = false; }

            stringNumber = Convert.ToInt32(guitarString.Name[3].ToString());

            GuitarEventArgs guitarArgs = new GuitarEventArgs(stringNumber, ctrlClicked, shiftClicked,altClicked);

            if (this.StringClicked != null)
            { this.StringClicked(this, guitarArgs); }


        }

        private void GuitarString_MouseEnter(object sender, EventArgs e)
        {
            Label guitarString = (Label)sender;
            if (guitarString.BackColor == Color.Transparent)
            { guitarString.BackColor = Color.Gainsboro; }
        }

        private void GuitarString_MouseLeave(object sender, EventArgs e)
        {
            Label guitarString = (Label)sender;
            if (guitarString.BackColor == Color.Gainsboro)
            { guitarString.BackColor = Color.Transparent; }
        }

        protected void GuitarString_MouseDown(object sender, MouseEventArgs e)
        {
            Label guitarString = (Label)sender;
            int stringNumber;
            GuitarEventArgs guitarArgs;
            stringNumber = Convert.ToInt32(guitarString.Name[3].ToString());

            if (ModifierKeys == Keys.Alt)
            {
                guitarArgs = new GuitarEventArgs(stringNumber, false, false, true);
            }
            else
            {
                guitarArgs = new GuitarEventArgs(stringNumber, false, false, false);
            }
            if (this.StringMouseDown != null)
            { this.StringMouseDown(this, guitarArgs); }
        }

        protected void GuitarString_MouseUp(object sender, MouseEventArgs e)
        {
            Label guitarString = (Label)sender;
            int stringNumber;
            stringNumber = Convert.ToInt32(guitarString.Name[3].ToString());

            GuitarEventArgs guitarArgs = new GuitarEventArgs(stringNumber, false, false, false);

            if (this.StringMouseUp != null)
            { this.StringMouseUp(this, guitarArgs); }
        }


        //----------------------------------------------------------------------------------
        //                          Resize and Relocate
        //----------------------------------------------------------------------------------

        private void RelocateStrings()
        {
            lbl1stString.Location = new Point(3, ((pnlFret.Height * 12) / 1000));
            lbl2ndString.Location = new Point(3, ((pnlFret.Height * 193) / 1000));
            lbl3rdString.Location = new Point(3, ((pnlFret.Height * 377) / 1000));
            lbl4thString.Location = new Point(3, ((pnlFret.Height * 562) / 1000));
            lbl5thString.Location = new Point(3, ((pnlFret.Height * 747) / 1000));
            lbl6thString.Location = new Point(3, ((pnlFret.Height * 924) / 1000));

        }

        private void ResizeStrings()
        {
            lbl1stString.Size = new Size((pnlFret.Width - 13), ((pnlFret.Height * 8) / 100) - 1);
            lbl2ndString.Size = lbl1stString.Size;
            lbl3rdString.Size = lbl1stString.Size;
            lbl4thString.Size = lbl1stString.Size;
            lbl5thString.Size = lbl1stString.Size;
            lbl6thString.Size = lbl1stString.Size;
        }

        private void ResizeDots()
        {
            //32
            //189
            picDot1.Height = (pnlFret.Height * 106) / 1000;
            picDot1.Width = picDot1.Height;
            picDot2.Width = picDot1.Width;
            picDot2.Height = picDot1.Height;
        }

        private void RelocateDots()
        {
            int dotX;
            dotX = (pnlFret.Width / 2) - (picDot1.Width / 2) - 3;
            if (dots == 1)
            {
                picDot1.Visible = true;
                picDot1.Location = new Point(dotX, ((pnlFret.Height * 450) / 1000));
            }
            else if (dots == 2)
            {
                picDot1.Location = new Point(dotX, ((pnlFret.Height * 85) / 1000));
                picDot2.Location = new Point(dotX, ((pnlFret.Height * 823) / 1000));
                picDot1.Visible = true;
                picDot2.Visible = true;
            }
            else
            {
                picDot1.Visible = false;
                picDot2.Visible = false;
            }
        }

        private void GuitarFret_Resize(object sender, EventArgs e)
        {
            RelocateStrings();
            ResizeStrings();
            ResizeDots();
            RelocateDots();
        }

    }
}
