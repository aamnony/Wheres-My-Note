using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Wheres_My_Note
{
    public class Note
    {
        private int code;
        private Color color;
        private int guitarString;
        private long duration;


        public Note()
        {
            this.code = 1;
            this.color = Color.Red;
            this.guitarString = 1;
            this.duration = 1;
        }

        public Note(int code, Color color, int guitarString, long duration)
        {
            this.code = code;
            this.color = color;
            this.guitarString = guitarString;
            this.duration = duration;
        }

        public int GetCode()
        {
            return this.code;
        }

        public Color GetColor()
        {
            return this.color;
        }

        public long GetDuration()
        {
            return this.duration;
        }

        public int GetGuitarString()
        {
            return this.guitarString;
        }

        public static string ConvertCodeToNotation(int code)
        {
            string output, n;
            int pitch, note;
            string p;
            //pitch
            pitch = code / 100;
            p = Convert.ToString(pitch);
            //note
            note = code - (pitch * 100);

            //note table
            switch (note)
            {
                case 1: n = "C";
                    break;
                case 2: n = "C#";
                    break;
                case 3: n = "D";
                    break;
                case 4: n = "D#";
                    break;
                case 5: n = "E";
                    break;
                case 6: n = "F";
                    break;
                case 7: n = "F#";
                    break;
                case 8: n = "G";
                    break;
                case 9: n = "G#";
                    break;
                case 10: n = "A";
                    break;
                case 11: n = "A#";
                    break;
                case 12: n = "B";
                    break;
                default: n = "C";
                    break;
            }

            output = n + p;

            return output;
        }

        public static string GetCodeNote(int code)
        {
            string n;
            int pitch, note;
            if (code == 0)
            { return ""; }
            else
            {
                //pitch
                pitch = code / 100;
                //note
                note = code - (pitch * 100);

                //note table
                switch (note)
                {
                    case 1: n = "C";
                        break;
                    case 2: n = "C#";
                        break;
                    case 3: n = "D";
                        break;
                    case 4: n = "D#";
                        break;
                    case 5: n = "E";
                        break;
                    case 6: n = "F";
                        break;
                    case 7: n = "F#";
                        break;
                    case 8: n = "G";
                        break;
                    case 9: n = "G#";
                        break;
                    case 10: n = "A";
                        break;
                    case 11: n = "A#";
                        break;
                    case 12: n = "B";
                        break;
                    default: n = "C";
                        break;
                }

                return n;
            }
        }

        public static string GetCodePitch(int code)
        {
            int pitch;
            string p;
            if (code == 0)
            { return ""; }
            else
            {
                //pitch
                pitch = code / 100;
                p = Convert.ToString(pitch);

                return p;
            }
        }

        public static int ConvertNotationToCode(string note, int pitch)
        {
            int output;
            int p, n;
            //pitch
            p = pitch * 100;
            //note table
            switch (note)
            {
                case "C": n = 1;
                    break;
                case "C#": n = 2;
                    break;
                case "D": n = 3;
                    break;
                case "D#": n = 4;
                    break;
                case "E": n = 5;
                    break;
                case "F": n = 6;
                    break;
                case "F#": n = 7;
                    break;
                case "G": n = 8;
                    break;
                case "G#": n = 9;
                    break;
                case "A": n = 10;
                    break;
                case "A#": n = 11;
                    break;
                case "B": n = 12;
                    break;
                default: n = 1;
                    break;
            }

            output = n + p;

            return output;
        }

        public static int ConvertNotationToCode(string noteName)
        {
            int output;
            int p, n;
            string name;

            if (noteName.Length == 3)
            {
                name = noteName[0].ToString() + noteName[1].ToString();
                p = Convert.ToInt32(noteName[2].ToString());
            }
            else
            {
                name = noteName[0].ToString();
                p = Convert.ToInt32(noteName[1].ToString());
            }
            
            //note table
            switch (name)
            {
                case "C": n = 1;
                    break;
                case "C#": n = 2;
                    break;
                case "D": n = 3;
                    break;
                case "D#": n = 4;
                    break;
                case "E": n = 5;
                    break;
                case "F": n = 6;
                    break;
                case "F#": n = 7;
                    break;
                case "G": n = 8;
                    break;
                case "G#": n = 9;
                    break;
                case "A": n = 10;
                    break;
                case "A#": n = 11;
                    break;
                case "B": n = 12;
                    break;
                default: n = 1;
                    break;
            }

            output = n + (p * 100);

            return output;
        }

    }
}
