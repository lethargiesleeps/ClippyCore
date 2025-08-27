using System;
using System.Collections.Generic;
using System.Text;

namespace ClippyCore.SongStudio
{
    /// <summary>
    /// A note to be played when creating a song.
    /// Syllable represents what is said while the note is sang.
    /// </summary>
    /// <see cref="SongBuilder" />
    public class Note
    {

        public int Pitch { get; private set; }
        public string Syllable { get; private set; } = string.Empty;

        /// <summary>
        /// Constructor used when creating predetermined notes.
        /// </summary>
        /// <param name="note">The note type.</param>
        /// <see cref="Notes" />
        /// <seealso cref="NoteType" />
        public Note(NoteType note)
        {
            SetPitch(note);
        }

        /// <summary>
        /// Constructor when adding a new note to a song with a syllable.
        /// </summary>
        /// <param name="note">The note type.</param>
        /// <param name="syllable">What displays in the speech bubble when Note is sang.</param>
        /// <see cref="Notes" />
        /// <seealso cref="NoteType" />
        public Note(NoteType note, string syllable)
        {
            SetPitch(note);
            Syllable = syllable;
        }

        /// <summary>
        /// Manually sets the syllable if its needs to change.
        /// </summary>
        /// <param name="syllable">What displays in the speech bubble.</param>
        /// <returns>The current note object.</returns>
        public Note SetSyllable(string syllable)
        {
            Syllable = syllable;
            return this;
        }

        /// <summary>
        /// Resets the note to it's original value.a
        /// </summary>
        /// <param name="note">The type of note to reset.</param>
        /// <returns>The current note object.</returns>
        public Note ResetPitch(NoteType note)
        {
            SetPitch(note);
            return this;
        }

        /// <summary>
        /// Adjusts the note's pitch.
        /// WARNING: This might affect predetermined notes permanently.
        /// Use ResetPitch(NoteType note) after using this method.
        /// </summary>
        /// <param name="value">Value to increment or decrement.</param>
        /// <returns>The current note object.</returns>
        public Note AdjustPitch(int value)
        {
            Pitch += value;
            return this;
        }

        /// <summary>
        /// Increases octave of a note.
        /// </summary>
        /// <returns>Returns note at increased octave.</returns>
        public Note IncreaseOctave()
        {
            Pitch *= 2;
            return this;
        }

        /// <summary>
        /// Decreases octave of a note.
        /// </summary>
        /// <returns>Returns note at decreased octave.</returns>
        public Note DecreaseOctave()
        {
            Pitch /= 2;
            return this;
        }

        /// <summary>
        /// Sets the Note's pitch the numerical value of pitch representing the actual letter notes.
        /// These are the values for highest octave available from TTS engine.
        /// The Magic Numbers represent the numerical value of the pitch/note and are not just some randome numbers.
        /// </summary>
        /// <param name="note">The note to adjust.</param>
        /// <exception cref="ArgumentOutOfRangeException">Throws if invalid argument is used.</exception>
        /// <see cref="Notes" />
        private void SetPitch(NoteType note)
        {
            switch (note)
            {
                case NoteType.GSharp: Pitch = 208; break;
                case NoteType.A: Pitch = 220; break;
                case NoteType.ASharp: Pitch = 233; break;
                case NoteType.B: Pitch = 247; break;
                case NoteType.C: Pitch = 262; break;
                case NoteType.CSharp: Pitch = 277; break;
                case NoteType.D: Pitch = 294; break;
                case NoteType.DSharp: Pitch = 311; break;
                case NoteType.E: Pitch = 330; break;
                case NoteType.F: Pitch = 349; break;
                case NoteType.FSharp: Pitch = 370; break;
                case NoteType.G: Pitch = 392; break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(note), note, null);
            }
        }

        /// <summary>
        /// Returns the note data to be added to the Song's TTS string.
        /// </summary>
        /// <returns>A string containing TTS note data.</returns>
        public override string ToString()
        {
            return $"\\Pit={Pitch}\\{Syllable}";
        }
    }
}
