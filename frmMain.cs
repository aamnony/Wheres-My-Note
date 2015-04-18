using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Toub.Sound.Midi;
using System.Threading;
using System.Diagnostics;

namespace Wheres_My_Note
{
    public partial class frmMain : Form
    {
        frmPiano piano = new frmPiano();
        frmGuitar guitar = new frmGuitar();
        Notes notes = new Notes();
        int playbackRunning = 0;
        public frmMain()
        {
            InitializeComponent();

            MidiPlayer.OpenMidi();
           
            cmbInstrument.Items.AddRange(System.Enum.GetNames(typeof(GeneralMidiInstruments)));
            cmbInstrument.SelectedIndex = 0;

            this.Location = new Point(0, 0);
            //this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            //lblTitle.Left = (this.Width - lblTitle.Width) / 2;
            //lblTitle.Location = new Point(((this.Width / 2) - (lblTitle.Width/2)), 2);
            cmbGuitarTunings.SelectedIndex = 0;
            rbtnMaple.Checked = true;

            piano.CreateCallingForm(this);
            guitar.CreateCallingForm(this);
            guitar.Show(this);
            piano.Show(this);
        }

        public Notes GetAllNotes()
        {
            return notes;
        }

        public void AddNote(Form sender, int code)
        {
            ChangeLastNote();
            if (sender is frmPiano)
            {
                DyeFretByCode(code);
            }
            if (sender is frmGuitar)
            {
                DyeKeyByCode(code);
            }
        }

        public void RemoveNote(Form sender, int code)
        {
            ChangeLastNote();
            if (sender is frmPiano)
            {
                RemoveFretByCode(code);
            }
            if (sender is frmGuitar)
            {
                RemoveKeyByCode(code);
            }
        }

        private void RemoveFretByCode(int code)
        {
            guitar.DyeFretsWithCode(code, Color.Transparent);
        }

        private void RemoveKeyByCode(int code)
        {
            piano.ClearKeysWithCode(code);
        }

        private void DyeFretByCode(int code)
        { 
            Color color;
            color = notes.GetColor(code);
            guitar.DyeFretsWithCode(code, color);
        }

        private void DyeKeyByCode(int code)
        {
            Color color;
            color = notes.GetColor(code);
            piano.DyeKeysWithCode(code, color);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            notes.Clear();
            guitar.ClearAll();
            piano.ClearAll();
            cmbNote.Text = "";
            cmbPitch.Text = "";
            lblTitle.Focus();
        }

        private void btnNotes_Click(object sender, EventArgs e)
        {
            Note[] note = this.notes.GetAll();
            int i;
            string name;
            Color color = new Color();
            string[] shown = new string[note.Length];

            if (note.Length == 0)
            { MessageBox.Show("There are no notes shown!", "Notes"); }
            else
            {
                bool last;
                last = false;
                frmMessage msgBox = new frmMessage();
                
                for (i = 0; i < note.Length; i++)
                {
                    if (i == note.Length - 1)
                    { last = true; }
                    name = Note.ConvertCodeToNotation(note[i].GetCode());
                    color = note[i].GetColor();
                    msgBox.AddLabel(name, i, color, last);
                }
                msgBox.ShowDialog(this);
            }
            lblTitle.Focus();
        }

        private void btnFindNote_Click(object sender, EventArgs e)
        {
            int pitch, code;
            string note;
            Color noteColor = new Color();
            MidiPlayer.Play(new ProgramChange(0, 1, GeneralMidiInstruments.AcousticGrand));

            if ((cmbNote.Text == "") || (cmbPitch.Text == ""))
            {
                MessageBox.Show("Please select note and pitch", "Error");
            }
            else if (cmbPitch.Text == "All")
            {
                int i;
                int[] codes = { 0, 0, 0, 0, 0 };
                note = cmbNote.Text;
                for (i = 2; i <= 6; i++)
                {
                    codes[i-2] = Note.ConvertNotationToCode(note, i);
                    MidiPlayer.Play(new NoteOn(0, 1, (note + i.ToString()), 127));
                    this.notes.Add(codes[i-2], 1, 500);
                    noteColor = this.notes.GetColor(codes[i-2]);
                    guitar.DyeFretsWithCode(codes[i-2], noteColor);
                    piano.DyeKeysWithCode(codes[i-2], noteColor);
                }
            }
            else
            {
                note = cmbNote.Text;
                pitch = Convert.ToInt32(cmbPitch.Text);
                code = Note.ConvertNotationToCode(note, pitch);

                MidiPlayer.Play(new NoteOn(0, 1, (note + cmbPitch.Text), 127));

                if (notes.HasCode(code))
                {
                    string color;
                    color = notes.GetColor(code).Name;
                    MessageBox.Show("This Note is already selected!\nIt is colored " + color);
                }
                else
                {
                    this.notes.Add(code, 1, 500);
                    noteColor = this.notes.GetColor(code);

                    guitar.DyeFretsWithCode(code, noteColor);
                    piano.DyeKeysWithCode(code, noteColor);
                }
            }
            lblTitle.Focus();
        }

        private void ChangeLastNote()
        {
            //change last note entered
            int lastCode;
            lastCode = this.notes.GetLastNoteCode();
            cmbNote.Text = Note.GetCodeNote(lastCode);
            cmbPitch.Text = Note.GetCodePitch(lastCode);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            MidiPlayer.CloseMidi();
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            lblTitle.Focus();
        }

        private void GuitarStyleChanged(object sender, EventArgs e)
        {
            if ((rbtnMaple.Checked)&&(!rbtnRosewood.Checked))
            {
                guitar.ChangeGuitarStyle("Maple");
            }
            else if ((!rbtnMaple.Checked) && (rbtnRosewood.Checked))
            {
                guitar.ChangeGuitarStyle("Rosewood");
            }
            else
            {
                MessageBox.Show("Something wrong happened... :O", "Serious Error");
            }
        }

        private void DyeFrets(Notes notes)
        {
            guitar.DyeFrets(notes);
        }

        private void TuneGuitar(object sender, EventArgs e)
        {
            Notes dyedNotes = new Notes();
            dyedNotes = guitar.GetDyedNotes();

            guitar.ClearAll();
            
            guitar.TuneStrings(((ComboBox)sender).SelectedIndex);
            guitar.Text = "Guitar - " + ((ComboBox)sender).Text + " Tuning";

            DyeFrets(dyedNotes);
            lblTitle.Focus();
        }

        private void btnPlayback_Click(object sender, EventArgs e)
        {
            Note[] note = this.notes.GetAll();
            int i, duration;
            string name;
            string[] shown = new string[note.Length];
            bool last;
            playbackRunning++; //=1
            Stopwatch timer = new Stopwatch();
            GeneralMidiInstruments instrument;
            instrument = (GeneralMidiInstruments)System.Enum.Parse(typeof(GeneralMidiInstruments), cmbInstrument.Text);
            MidiPlayer.Play(new ProgramChange(0, 1, instrument));
            btnPlayback.Text = "Stop";
            for (i = 0; i < note.Length; i++)
            {
                if (playbackRunning != 1)
                { break; };
                if (i == note.Length - 1)
                { last = true; }
                name = Note.ConvertCodeToNotation(note[i].GetCode());
                duration = (Convert.ToInt32(note[i].GetDuration()) + 100) * (trackBar1.Value +1); 

                guitar.ClearAll();
                piano.ClearAll();

                DyeFretByCode(note[i].GetCode());
                DyeKeyByCode(note[i].GetCode());

                if (name.Length == 3)
                {
                    //#
                    cmbNote.Text = name[0].ToString() + name[1].ToString();
                    cmbPitch.Text = name[2].ToString();
                }
                else
                {
                    cmbNote.Text = name[0].ToString();
                    cmbPitch.Text = name[1].ToString();
                }

                try
                {
                    MidiPlayer.Play(new NoteOn(0, 1, name, 127));
                    timer.Start();
                    
                    while (timer.ElapsedMilliseconds < duration)
                    {
                        Application.DoEvents();
                    }
                    timer.Stop();
                    timer.Reset();
                    MidiPlayer.Play(new NoteOff(0, 1, name, 127));
                    Thread.Sleep(100);
                }
                catch
                {
                    this.Close();
                }
            }

            //show playback button again
            btnPlayback.Text = "Playback";
            playbackRunning = 0;

            //show all notes again
            foreach (Note n in notes.GetAll())
            {
                DyeFretByCode(n.GetCode());
                DyeKeyByCode(n.GetCode());
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveFile1.ShowDialog(this);

            //Note[] note = this.notes.GetAll();
            //string name, duration, color;
            //int i;
            //List<string> lines = new List<string>();
            //for (i = 0; i < note.Length; i++)
            //{
            //    name = Note.ConvertCodeToNotation(note[i].GetCode());
            //    duration = (note[i].GetDuration()).ToString();
            //    color = note[i].GetColor().Name;
            //    lines.Add(name + " " + duration + " " + color);

            //}
            //System.IO.File.WriteAllLines(@"C:\NotesLog.txt", lines.ToArray());
            ////System.IO.File.WriteAllText(@"C:\Wheres My Note.txt", text);


        }

        private void saveFile1_FileOk(object sender, CancelEventArgs e)
        {
            //writeFile
            Note[] note = this.notes.GetAll();
            string name, duration, color;
            int i;
            List<string> lines = new List<string>();
            for (i = 0; i < note.Length; i++)
            {
                name = Note.ConvertCodeToNotation(note[i].GetCode());
                duration = (note[i].GetDuration()).ToString();
                color = note[i].GetColor().Name;
                lines.Add(name + " " + duration + " " + color);

            }
            System.IO.File.WriteAllLines(saveFile1.FileName, lines.ToArray());

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            openFile1.ShowDialog(this);
            //Notes loadedNotes = new Notes();
            //string[] lines;
            //int i;
            //string name, durationName, colorName;
            //int code;
            //long duration;
            //Color color;
            //lines = System.IO.File.ReadAllLines(@"C:\NotesLog.txt");

            //for (i = 0; i < lines.Length; i++)
            //{
            //    string[] text = lines[i].Split(' ');
            //    name = text[0];
            //    durationName = text[1];
            //    colorName = text[2];

            //    code = Note.ConvertNotationToCode(name);
            //    duration = (long)Convert.ToDouble(durationName);
            //    color = Color.FromName(colorName);

            //    loadedNotes.Add(code, 1, color, duration);
            //}
            //notes = loadedNotes;
            //foreach (Note note in notes.GetAll())
            //{
            //    DyeFretByCode(note.GetCode());
            //    DyeKeyByCode(note.GetCode());
            //}
        }

        private void openFile1_FileOk(object sender, CancelEventArgs e)
        {
            Notes loadedNotes = new Notes();
            string[] lines;
            int i;
            string name, durationName, colorName;
            int code;
            long duration;
            Color color;
            lines = System.IO.File.ReadAllLines(openFile1.FileName);

            for (i = 0; i < lines.Length; i++)
            {
                string[] text = lines[i].Split(' ');
                name = text[0];
                durationName = text[1];
                colorName = text[2];

                code = Note.ConvertNotationToCode(name);
                duration = (long)Convert.ToDouble(durationName);
                color = Color.FromName(colorName);

                loadedNotes.Add(code, 1, color, duration);
            }
            notes = loadedNotes;
            foreach (Note note in notes.GetAll())
            {
                DyeFretByCode(note.GetCode());
                DyeKeyByCode(note.GetCode());
            }
        }

        private void cmbInstrument_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string help;
            help = "When alt key is held:\n-Notes will not be added to history\n";
            help += "When ctrl key is held:\n-If you click on a colored Note in the Guitar, the Note will be uncolored if there are other locations on the Guitar where the Note can be played\n";
            help += "When shift key is held:\n-If you click on a colored Note in the Guitar, all other locations on the Guitar where the Note can be played, will be uncolored\n";
            help += "-If you click on an uncolored Note in the Guitar, all other locations on the Guitar where the Note can be played will also be colored\n";
            help += " (just like when selecting a Piano-Key or finding a Note via the Find button)";

            MessageBox.Show(this, help, "Help");
        }

    }
}
