using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Toub.Sound.Midi;
using System.Diagnostics;

namespace Wheres_My_Note
{
    public partial class frmPiano : Form
    {
        string noteValue;
        Stopwatch timer = new Stopwatch();
        public frmPiano()
        {
            InitializeComponent();
            this.Width = Screen.PrimaryScreen.Bounds.Width - 25;
            ResizeAll(this, EventArgs.Empty);
        }

//------Prevent moving form out of screen bounds-----------------
        private const int WM_MOVING = 0x216;

        private void WriteTheRect(IntPtr dest, Rectangle rect)
        {
            System.Runtime.InteropServices.Marshal.WriteInt32(dest, 0, rect.Left);
            System.Runtime.InteropServices.Marshal.WriteInt32(dest, 4, rect.Top);
            System.Runtime.InteropServices.Marshal.WriteInt32(dest, 8, rect.Right);
            System.Runtime.InteropServices.Marshal.WriteInt32(dest, 12, rect.Bottom);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_MOVING)
            {
                // RECT structure pointed to by lParam: left, top, right, bottom

                Rectangle r = Rectangle.FromLTRB(System.Runtime.InteropServices.Marshal.ReadInt32(m.LParam, 0),
                                                 System.Runtime.InteropServices.Marshal.ReadInt32(m.LParam, 4),
                                                 System.Runtime.InteropServices.Marshal.ReadInt32(m.LParam, 8),
                                                 System.Runtime.InteropServices.Marshal.ReadInt32(m.LParam, 12)
                                                 );

                Rectangle allowed = Rectangle.FromLTRB(0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

                if (r.Left <= allowed.Left || r.Top <= allowed.Top || r.Right >= allowed.Right || r.Bottom >= allowed.Bottom)
                {
                    int offset_x = r.Left < allowed.Left ? (allowed.Left - r.Left) : (r.Right > allowed.Right ? (allowed.Right - r.Right) : (0));
                    int offset_y = r.Top < allowed.Top ? (allowed.Top - r.Top) : (r.Bottom > allowed.Bottom ? (allowed.Bottom - r.Bottom) : (0));

                    r.Offset(offset_x, offset_y);

                    WriteTheRect(m.LParam, r);
                }
            }
            base.WndProc(ref m);
        }
//---------------------------------------------------------------


        private frmMain frmMaster = null;

        public frmPiano(frmMain callingForm)
        {
            frmMaster = callingForm;
        }

        public void CreateCallingForm(frmMain callingForm)
        {
            frmMaster = callingForm;
            this.Location = new Point(15, 700);
        }




        //
        //   --- R E S I Z E   &   R E L O C A T E ---   //
        //
        private void ResizeBlackKeys()
        {
            //white keys resize automaticaly via control's code
            int blackKeyWidth, blackKeyHeight;
            blackKeyWidth = pianoKey1.BlackWidthKey + pianoKey2.BlackWidthLeftSide;
            blackKeyHeight = pianoKey1.BlackHeight;
            foreach (Control blackKey in pnlKeyboard.Controls)
            {
                if (blackKey is BlackPianoKey)
                {
                    string blackKeyNumber = null;
                    int i, num;
                    WhitePianoKey leftWhiteKey = new WhitePianoKey();
                    WhitePianoKey rightWhiteKey = new WhitePianoKey();
                    //i = blackKey.Name.Length - 8; number of digits in the key number

                    for (i = 8; i < blackKey.Name.Length; i++)
                    {
                        blackKeyNumber += blackKey.Name[i].ToString();
                    }
                    //blackKeyNumber = blackKey.Name[blackKey.Name.Length - i].ToString();
                    num = Convert.ToInt32(blackKeyNumber);

                    //detemine left and right white keys of this black key
                    foreach (Control whiteKey in pnlKeyboard.Controls)
                    {
                        if (whiteKey.Name == "pianoKey" + num)
                            leftWhiteKey = (WhitePianoKey)whiteKey;
                        if (whiteKey.Name == "pianoKey" + (num + 1))
                            rightWhiteKey = (WhitePianoKey)whiteKey;
                    }

                    blackKey.Height = blackKeyHeight;
                    blackKey.Width = blackKeyWidth;
                    //black key position

                    if (leftWhiteKey.KeyType == WhitePianoKey.PianoKeyType.Left)
                    {
                        blackKey.Location = new Point
                         (rightWhiteKey.BlackPositionLeftEnd + rightWhiteKey.Location.X - blackKey.Width, 0);
                    }
                    else if (rightWhiteKey.KeyType == WhitePianoKey.PianoKeyType.Right)
                    {
                        blackKey.Location = new Point
                         (leftWhiteKey.BlackPositionRightStart + leftWhiteKey.Location.X, 1);
                    }
                    else if ((leftWhiteKey.KeyType == WhitePianoKey.PianoKeyType.Middle)
                        && (rightWhiteKey.KeyType == WhitePianoKey.PianoKeyType.Middle))
                    {
                        blackKey.Location = new Point
                         (leftWhiteKey.BlackPositionRightStart + leftWhiteKey.Location.X, 0);
                    }
                }
            }
        }

        private void ResizeAll(object sender, EventArgs e)
        {
            int whitePianoKeyWidth, whitePianoKeysCounter;
            whitePianoKeyWidth = (this.Width * 10) / 315;
            //form width/3.15 = x.y, when y > 5, then increase whitePianoKeyWidth by 1
            if (((this.Width * 10) % 315) > 161)
            {
                whitePianoKeyWidth++;
            }
            whitePianoKeysCounter = 0;
            pnlKeyboard.Height = whitePianoKeyWidth * 4;
            foreach (Control whiteKey in pnlKeyboard.Controls)
            {
                if (whiteKey is WhitePianoKey)
                {
                    whiteKey.Width = whitePianoKeyWidth;
                    whitePianoKeysCounter++;
                }
            }
            ResizeBlackKeys();

            //this.Width = whitePianoKeyWidth * whitePianoKeysCounter + 10;
            pnlKeyboard.Width = whitePianoKeyWidth * whitePianoKeysCounter+10;
            this.Height = pnlKeyboard.Height + pnlKeyboard.Location.Y + 35;
            pnlKeyboard.Width = this.Width;

        }

        //
        //   --- G R A P H I C S ---   //
        //
        private void Clear(object sender, EventArgs e)
        {
            foreach (Control key in pnlKeyboard.Controls)
            {
                if (key is BlackPianoKey)
                { ((BlackPianoKey)key).SetColor(Color.Black); }
                if (key is WhitePianoKey)
                { ((WhitePianoKey)key).SetColor(Color.White); }
            }
        }

        //
        //   --- F U N C T I O N A L I T Y ---   //
        //
        private void BlackKey_Click(object sender, EventArgs e)
        {
            if (ModifierKeys != Keys.Alt) //if alt was held dont register note
            {
                BlackPianoKey key = (BlackPianoKey)sender;
                int noteCode;
                Color noteColor;
                noteCode = Convert.ToInt32(key.Tag);

                if (key.GetColor() == Color.DimGray)
                {
                    frmMaster.GetAllNotes().Add(noteCode, 1, timer.ElapsedMilliseconds);
                    noteColor = frmMaster.GetAllNotes().GetColor(noteCode);
                    key.SetColor(noteColor);
                    frmMaster.AddNote(this, noteCode);
                }
                else
                {
                    if (frmMaster.chkOverrideNotes.Checked)
                    {
                        frmMaster.GetAllNotes().AddAnother(noteCode, timer.ElapsedMilliseconds);
                    }
                    else
                    {
                        key.SetColor(Color.DimGray);
                        frmMaster.GetAllNotes().Remove(noteCode);
                        frmMaster.RemoveNote(this, noteCode);
                    }
                }
            }
        }

        private void WhiteKey_Click(object sender, EventArgs e)
        {
            if (ModifierKeys != Keys.Alt) //if alt was held dont register note
            {
                WhitePianoKey key = (WhitePianoKey)sender;
                int noteCode;
                Color noteColor;
                noteCode = Convert.ToInt32(key.Tag);

                if (key.GetColor() == Color.Gainsboro)
                {
                    frmMaster.GetAllNotes().Add(noteCode, 1, timer.ElapsedMilliseconds);
                    noteColor = frmMaster.GetAllNotes().GetColor(noteCode);
                    key.SetColor(noteColor);
                    frmMaster.AddNote(this, noteCode);
                }
                else
                {
                    if (frmMaster.chkOverrideNotes.Checked)
                    {
                        frmMaster.GetAllNotes().AddAnother(noteCode, timer.ElapsedMilliseconds);
                    }
                    else
                    {
                        key.SetColor(Color.Gainsboro);
                        frmMaster.GetAllNotes().Remove(noteCode);
                        frmMaster.RemoveNote(this, noteCode);
                    }
                }
            }
        }

        public void DyeKeysWithCode(int code, Color color)
        {
            foreach (Control key in pnlKeyboard.Controls)
            {
                if ((key is BlackPianoKey)&&(key.Tag.ToString()==code.ToString()))
                {
                    ((BlackPianoKey)key).SetColor(color);
                }
                if ((key is WhitePianoKey) && (key.Tag.ToString() == code.ToString()))
                {
                    ((WhitePianoKey)key).SetColor(color);
                }
            }
        }

        public void ClearKeysWithCode(int code)
        {
            foreach (Control key in pnlKeyboard.Controls)
            {
                if ((key is BlackPianoKey) && (key.Tag.ToString() == code.ToString()))
                {
                    ((BlackPianoKey)key).SetColor(Color.Black);
                }
                if ((key is WhitePianoKey) && (key.Tag.ToString() == code.ToString()))
                {
                    ((WhitePianoKey)key).SetColor(Color.White);
                }
            }
        }

        public void ClearAll()
        {
            foreach (Control key in pnlKeyboard.Controls)
            {
                if (key is BlackPianoKey)
                { ((BlackPianoKey)key).SetColor(Color.Black); }
                if (key is WhitePianoKey)
                { ((WhitePianoKey)key).SetColor(Color.White); }
            }
        }



        private void WhiteKey_MouseUp(object sender, EventArgs e)
        {
            MidiPlayer.Play(new NoteOff(0, 1, noteValue, 127));
            timer.Stop();
        }

        private void WhiteKey_MouseDown(object sender, EventArgs e)
        {
            WhitePianoKey key = (WhitePianoKey)sender;
            noteValue = Note.ConvertCodeToNotation(Convert.ToInt32(key.Tag));
            MidiPlayer.Play(new ProgramChange(0, 1, GeneralMidiInstruments.AcousticGrand));
            MidiPlayer.Play(new NoteOn(0, 1, noteValue, 127));
            timer.Reset();
            timer.Start();

        }

        private void BlackKey_MouseDown(object sender, MouseEventArgs e)
        {
            BlackPianoKey key = (BlackPianoKey)sender;
            noteValue = Note.ConvertCodeToNotation(Convert.ToInt32(key.Tag));
            MidiPlayer.Play(new ProgramChange(0, 1, GeneralMidiInstruments.AcousticGrand));
            MidiPlayer.Play(new NoteOn(0, 1, noteValue, 127));
            timer.Reset();
            timer.Start();
        }

        private void BlackKey_MouseUp(object sender, MouseEventArgs e)
        {
            MidiPlayer.Play(new NoteOff(0, 1, noteValue, 127));
            timer.Stop();
        }

   }
}
