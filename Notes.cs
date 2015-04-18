using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace Wheres_My_Note
{
    public class Notes
    {
        private List<Note> notes = new List<Note>();
        private List<Color> availableColors = new List<Color>();
        private Color[] allColors = { Color.Red, Color.Blue, Color.Lime, Color.Yellow, Color.Cyan, Color.Orange,Color.DeepPink,
                                    Color.Gray,Color.Purple,Color.SaddleBrown,Color.Salmon,Color.Navy,Color.Green,Color.DarkKhaki,
                                    Color.Teal,Color.Gold,Color.Pink,Color.LightGray,Color.Violet,Color.Goldenrod,Color.PaleGreen,
                                    Color.DarkGreen,Color.LightBlue,Color.MediumVioletRed,Color.OrangeRed,Color.SteelBlue,Color.YellowGreen};

        public Notes()
        {
            this.availableColors = allColors.ToList();
        }

        public void AddAnother(int code, long duration)
        {
            foreach (Note n in notes)
            {
                if (code == n.GetCode())
                {
                    Note note = new Note(code, n.GetColor(), n.GetGuitarString(), duration);
                    notes.Add(note);
                    break;
                }
            }
            
        }

        public void Add(int code, int guitarString,long duration)
        {
            Random randomColor = new Random();
            Color color = new Color();
            int i;
            i = randomColor.Next(0, availableColors.Count);
            try
            {
                color = availableColors[i];
            }
            catch
            { 
                
            }
            this.availableColors.Remove(color);

            Note newNote = new Note(code, color, guitarString, duration);
            notes.Add(newNote);

        }

        public void Add(int code, int guitarString, Color color, long duration)
        {
            Note newNote = new Note(code, color, guitarString,duration);
            notes.Add(newNote);
        }

        public void Add(Note note)
        {
            notes.Add(note);
            this.availableColors.Remove(note.GetColor());
        }

        public void Remove(int code)
        {
            foreach (Note n in notes)
            {
                if (n.GetCode() == code)
                {
                    this.availableColors.Add(n.GetColor());
                    notes.Remove(n);
                    break;
                }
            }
        }

        public Note[] GetAll()
        {
            return notes.ToArray();
        }

        public void Clear()
        {
            notes.Clear();
            this.availableColors = allColors.ToList();
        }

        public Color GetColor(int code)
        {
            Color color = new Color();
            foreach (Note n in notes)
            {
                if (n.GetCode() == code)
                {
                    color = n.GetColor();
                }
            }
            return color;
        }

        public int GetLastNoteCode()
        {
            int index, code;
            if (notes.Count == 0)
            { return 0; }
            else
            {
                index = notes.Count - 1;
                code = notes[index].GetCode();
                return code;
            }
        }

        public bool HasCode(int code)
        {
            foreach (Note note in notes)
            {
                if (note.GetCode() == code)
                { return true; }
            }
            return false;
        }

        public int GetCount()
        {
            return notes.Count();
        }


    }
}
