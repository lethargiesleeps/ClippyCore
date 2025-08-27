using System;
using System.Collections.Generic;
using System.Text;

namespace ClippyCore.SongStudio
{
    /// <summary>
    /// This class contains static Note objects with their pitch set to their corresponding letter note values.
    /// </summary>
    public static class Notes
    {
        public static Note GSharp = new Note(NoteType.GSharp);
        public static Note G = new Note(NoteType.G);
        public static Note F = new Note(NoteType.F);
        public static Note FSharp = new Note(NoteType.FSharp);
        public static Note E = new Note(NoteType.E);
        public static Note D = new Note(NoteType.D);
        public static Note DSharp = new Note(NoteType.DSharp);
        public static Note C = new Note(NoteType.C);
        public static Note CSharp = new Note(NoteType.CSharp);
        public static Note B = new Note(NoteType.B);
        public static Note A = new Note(NoteType.A);
        public static Note ASharp = new Note(NoteType.ASharp);
        public static List<Note> CustomNotes = new List<Note>();


        /// <summary>
        /// Resets all the Notes in this class to their initial value. Should be used if pitch is ever adjusted during song
        /// building.
        /// </summary>
        public static void ResetNotes()
        {
            GSharp = new Note(NoteType.GSharp);
            G = new Note(NoteType.G);
            F = new Note(NoteType.F);
            FSharp = new Note(NoteType.FSharp);
            E = new Note(NoteType.E);
            D = new Note(NoteType.D);
            DSharp = new Note(NoteType.DSharp);
            C = new Note(NoteType.C);
            CSharp = new Note(NoteType.CSharp);
            B = new Note(NoteType.B);
            A = new Note(NoteType.A);
            ASharp = new Note(NoteType.ASharp);
        }
    }
}
