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
    public partial class frmGuitar : Form
    {
        string noteValue;
        Stopwatch timer = new Stopwatch();
        public frmGuitar()
        {
            InitializeComponent();
            this.Width = Screen.PrimaryScreen.Bounds.Width - 25;
            //cmbTunings.SelectedIndex = 0;
            ResizeAll(this, EventArgs.Empty);
            ChangeGuitarStyle("Maple");
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

        public frmGuitar(frmMain callingForm)
        {
            frmMaster = callingForm;
        }

        public void CreateCallingForm(frmMain callingForm)
        {
            frmMaster = callingForm;
            this.Location = new Point(15, 300);
        }



        private int[] FretPositionCalculator(int fretNumber, int scaleLength)
        {
            int[] nutToFret = new int[22];
            int[] bridgeToFret = new int[22];
            int n;
            for (n = 0; n <= 21; n++)
            {
                if (n == 0)
                {
                    nutToFret[n] = scaleLength / 18;
                }
                else
                {
                    bridgeToFret[n - 1] = scaleLength - nutToFret[n - 1];
                    nutToFret[n] = bridgeToFret[n - 1] / 18 + nutToFret[n - 1];
                }
            }
            return nutToFret;
        }

        public void ClearAll()
        {
            foreach (Control fret in pnlGuitar.Controls)
            {
                if (fret is GuitarFret)
                { ((GuitarFret)fret).SetColor(Color.Transparent); }
            }
        }


        private void Clear(object sender, EventArgs e)
        {
            
        }

        //private void cmbTunings_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    TuneStrings(cmbTunings.SelectedIndex);
        //    btnClear.Focus();
        //    //notes.Clear();
        //}

        private void TuneFrets(int[] stringsNotes)
        {
            int stringNumber;
            int fretNumber;
            //GuitarFret fret = (GuitarFret)this.Controls["guitarFret" + fretNumber.ToString()];
            for (fretNumber = 0; fretNumber <= 22; fretNumber++)
            {
                if (fretNumber == 0)
                {
                    for (stringNumber = 0; stringNumber <= 5; stringNumber++)
                    {
                        //open strings
                        GuitarFret fret = (GuitarFret)pnlGuitar.Controls["guitarFret0"];
                        fret.SetCode(stringNumber, stringsNotes[stringNumber]);

                        stringsNotes[stringNumber]++;
                        if ((stringsNotes[stringNumber] % 100) == 13) //get 1st+2nd digits (note)
                        {
                            stringsNotes[stringNumber] = stringsNotes[stringNumber] + 100 - 12; //up octave/pitch , reset note
                        }
                    }
                }
                else
                {
                    GuitarFret fret = (GuitarFret)pnlGuitar.Controls["guitarFret" + fretNumber.ToString()];
                    for (stringNumber = 0; stringNumber <= 5; stringNumber++)
                    {
                        fret.SetCode(stringNumber, stringsNotes[stringNumber]);

                        stringsNotes[stringNumber]++;
                        if ((stringsNotes[stringNumber] % 100) == 13) //get 1st+2nd digits (note)
                        {
                            stringsNotes[stringNumber] = stringsNotes[stringNumber] + 100 - 12; //up octave/pitch , reset note
                        }
                    }
                }
            }
        }

        public void TuneStrings(int index)
        {
            int[] guitarTuning;
            guitarTuning = Tunings.Tune(index);
            TuneFrets(guitarTuning);
           
        }


        private void FretClicked(object sender, GuitarFret.GuitarEventArgs e)
        {
            if (!e.AltClicked) ////if alt was held dont register note
            {
                GuitarFret fret = (GuitarFret)sender;
                int noteCode;
                Color noteColor;
                noteCode = fret.GetCode(e.StringNumber);
                //---------------------------------------------------------------------------------------------------------
                //--------------------Fret Not Clicked Yet-----------------------------------------------------------------
                //---------------------------------------------------------------------------------------------------------            
                if (fret.GetColor(e.StringNumber) == Color.Gainsboro)
                {
                    frmMaster.GetAllNotes().Add(noteCode, e.StringNumber,timer.ElapsedMilliseconds);
                    noteColor = frmMaster.GetAllNotes().GetColor(noteCode);
                    fret.SetColor(noteColor, e.StringNumber);
                    frmMaster.AddNote(this, noteCode);


                    //if shift key was held then dye all other same frets
                    if (e.ShiftClicked)
                    {
                        foreach (Control f in pnlGuitar.Controls)
                        {
                            if (f is GuitarFret)
                            {
                                int stringNumber;
                                for (stringNumber = 1; stringNumber <= 6; stringNumber++)
                                {
                                    if (((GuitarFret)f).GetCode(stringNumber) == noteCode)
                                    { ((GuitarFret)f).SetColor(noteColor, stringNumber); }
                                }
                            }
                        }
                    }
                }
                //-------------------------------------------------------------------------------------------------------------------------
                //-------------------------Fret Already Clicked----------------------------------------------------------------------------
                //-------------------------------------------------------------------------------------------------------------------------
                else
                {
                    //SHIFT+CLICK = Remove frets with same code
                    if (e.ShiftClicked)
                    {
                        foreach (Control f in pnlGuitar.Controls)
                        {
                            if (f is GuitarFret)
                            {
                                int stringNumber;
                                for (stringNumber = 1; stringNumber <= 6; stringNumber++)
                                {
                                    if ((((GuitarFret)f).GetCode(stringNumber) == noteCode) && (stringNumber != e.StringNumber))
                                    { ((GuitarFret)f).SetColor(Color.Transparent, stringNumber); }
                                }
                            }
                        }
                    }


                    //CTRL+CLICK = remove clicked fret (if there are frets with same code)
                    else if (e.CtrlClicked)
                    {
                        bool otherFrets;
                        otherFrets = false;
                        foreach (Control f in pnlGuitar.Controls)
                        {
                            //other frets = no need to continue searching, exit loop
                            if (otherFrets)
                            { break; }
                            //check if there are other frets with same code that are clicked
                            if (f is GuitarFret)
                            {
                                int stringNumber;
                                for (stringNumber = 1; stringNumber <= 6; stringNumber++)
                                {
                                    if ((((GuitarFret)f).GetCode(stringNumber) == noteCode)
                                        && (stringNumber != e.StringNumber) && (((GuitarFret)f).GetColor(stringNumber) != Color.Transparent))
                                    { otherFrets = true; }
                                }
                            }
                        }
                        if (otherFrets)
                        { fret.SetColor(Color.Gainsboro, e.StringNumber); }
                    }

                    //CLICK = Remove all frets with same code from array and uncolor them
                    //OR if checkbox is true override the note
                    else
                    {
                        if (frmMaster.chkOverrideNotes.Checked)
                        {
                            frmMaster.GetAllNotes().AddAnother(noteCode, timer.ElapsedMilliseconds);
                            noteColor = frmMaster.GetAllNotes().GetColor(noteCode);
                            //if shift key was held then dye all other same frets
                            if (e.ShiftClicked)
                            {
                                foreach (Control f in pnlGuitar.Controls)
                                {
                                    if (f is GuitarFret)
                                    {
                                        int stringNumber;
                                        for (stringNumber = 1; stringNumber <= 6; stringNumber++)
                                        {
                                            if (((GuitarFret)f).GetCode(stringNumber) == noteCode)
                                            { ((GuitarFret)f).SetColor(noteColor, stringNumber); }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            frmMaster.GetAllNotes().Remove(noteCode);
                            frmMaster.RemoveNote(this, noteCode);
                            foreach (Control f in pnlGuitar.Controls)
                            {
                                if (f is GuitarFret)
                                {
                                    int stringNumber;
                                    for (stringNumber = 1; stringNumber <= 6; stringNumber++)
                                    {

                                        if (((GuitarFret)f).GetCode(stringNumber) == noteCode)
                                        { ((GuitarFret)f).SetColor(Color.Transparent, stringNumber); }
                                    }
                                }
                            }
                            fret.SetColor(Color.Gainsboro, e.StringNumber);
                        }
                    }
                }
            }
        }

        private void ResizeAll(object sender, EventArgs e)
        {
            pnlGuitar.Width = this.Width - 10;
            pnlGuitar.Height = pnlGuitar.Width / 7;
            this.Height = pnlGuitar.Height + 50;

            int[] distancesFromNut = new int[22];
            distancesFromNut = FretPositionCalculator(22, this.Width*135/100);

            foreach (Control fret in pnlGuitar.Controls)
            {
                if ((fret is GuitarFret)&&(fret.Name!="guitarFret0"))
                {
                    char[] trimChars;
                    int fretNumber;
                    trimChars = "guitarFret".ToCharArray();
                    fretNumber = Convert.ToInt32(fret.Name.TrimStart(trimChars));
                    if (fretNumber == 1)
                    {
                        fret.Width = distancesFromNut[fretNumber - 1];
                    }
                    else
                    {
                        fret.Width = distancesFromNut[fretNumber - 1] - distancesFromNut[fretNumber - 2];
                    }
                }
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            
        }

        public void ChangeGuitarStyle(string style)
        {
            bool mapleRosewood;
            mapleRosewood = true;
            if (style == "Maple")
            { mapleRosewood = true; }
            else if (style == "Rosewood")
            { mapleRosewood = false; }

            foreach (Control fret in pnlGuitar.Controls)
            {
                if (fret is GuitarFret)
                {
                    ((GuitarFret)fret).ChangeBackImage(mapleRosewood);
                }
            }
        }

        //private void btnFindNote_Click(object sender, EventArgs e)
        //{
        //    int pitch, code, stringNumber;
        //    string note;
        //    Color noteColor = new Color();
        //    note = cmbNote.Text;
        //    pitch = Convert.ToInt32(cmbPitch.Text);
        //    code = Note.ConvertNotationToCode(note, pitch);

        //    frmMaster.GetAllNotes().Add(code, 1);
        //    noteColor = frmMaster.GetAllNotes().GetColor(code);

        //    foreach (Control fret in pnlGuitar.Controls)
        //    {
        //        if (fret is GuitarFret)
        //        { 
        //            for (stringNumber=1;stringNumber<=6;stringNumber++)
        //            {
        //                if (((GuitarFret)fret).GetCode(stringNumber) == code)
        //                {
        //                    ((GuitarFret)fret).SetColor(noteColor, stringNumber);
        //                }
        //            }
        //        }
        //    }
        //}
 
        public void DyeFretsWithCode(int code, Color color)
        {
            foreach (Control fret in pnlGuitar.Controls)
            {
                if (fret is GuitarFret)
                {
                    int stringNumber;
                    for (stringNumber = 1; stringNumber <= 6; stringNumber++)
                    {
                        if (((GuitarFret)fret).GetCode(stringNumber) == code)
                        {
                            ((GuitarFret)fret).SetColor(color, stringNumber);
                        }
                    }
                }
            }
        }

        public Notes GetDyedNotes()
        {
            Notes dyedNotes = new Notes();
            Color color;
            foreach (Control fret in pnlGuitar.Controls)
            {
                if (fret is GuitarFret)
                {
                    int stringNumber;
                    for (stringNumber = 1; stringNumber <= 6; stringNumber++)
                    {
                        color = ((GuitarFret)fret).GetColor(stringNumber);
                        if (color !=Color.Transparent)
                        {
                            dyedNotes.Add(((GuitarFret)fret).GetCode(stringNumber), stringNumber, color,timer.ElapsedMilliseconds);
                        }
                    }
                }
            }
            return dyedNotes;
        }

        public void DyeFrets(Notes notes)
        {
            Color color;
            int code;
            int i, j;
            foreach (Control fret in pnlGuitar.Controls)
            {
                if (fret is GuitarFret)
                {
                    int stringNumber;
                    for (i = 0, j = notes.GetCount(); i < j; i++)
                    {
                        for (stringNumber = 1; ((stringNumber <= 6)&&j>0); stringNumber++)
                        {
                            code = ((GuitarFret)fret).GetCode(stringNumber);
                            if ((notes.GetAll()[i].GetCode() == code) && (notes.GetAll()[i].GetGuitarString() == stringNumber))
                            {
                                color = notes.GetAll()[i].GetColor();
                                ((GuitarFret)fret).SetColor(color, stringNumber);
                                //notes.Remove(code);
                                //j = notes.GetCount();
                            }
                        }
                    }
                }
            }
        }

        private void Guitar_StringMouseDown(object sender, GuitarFret.GuitarEventArgs e)
        {
            GuitarFret fret = (GuitarFret)sender;
            noteValue = Note.ConvertCodeToNotation(fret.GetCode(e.StringNumber));
            timer.Reset();
            MidiPlayer.Play(new ProgramChange(0, 1, GeneralMidiInstruments.CleanElectricGuitar));
            MidiPlayer.Play(new NoteOn(0,1,noteValue,127));
            timer.Start();
            
        }

        private void Guitar_StringMouseUp(object sender, GuitarFret.GuitarEventArgs e)
        {
            GuitarFret fret = (GuitarFret)sender;
            try
            {
                MidiPlayer.Play(new NoteOff(0, 1, noteValue, 127));
                timer.Stop();
            }
            catch
            {
                throw;
            }
            
        }


    }
}
