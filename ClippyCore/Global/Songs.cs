using ClippyCore.SongStudio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClippyCore.Global
{
    public static class Songs
    {
        public static class Shared
        {
            /// <summary>
            /// Builder for a song.
            /// </summary>
            /// <returns>All-Star by Smash Mouth</returns>
            public static SongBuilder AllStar()
            {
                Notes.ResetNotes();
                var speed = 100;
                var lowerG = Notes.G.DecreaseOctave();
                var lowerE = Notes.E.DecreaseOctave();
                var song = new SongBuilder("All-Star").SetInitialSpeed(500).AddNote(lowerG, "Some").AddSpeed(speed)
                    .AddNote(Notes.D, "bah").AddNote(Notes.B, "dee").SubtractSpeed(speed).AddNote(Notes.B, "once")
                    .AddSpeed(speed).AddNote(Notes.A, "told").AddNote(lowerG, "me").AddNote(lowerG, "the")
                    .SubtractSpeed(speed).AddNote(Notes.C, "world").AddSpeed(speed).AddNote(Notes.B, "is")
                    .AddNote(Notes.B, "gun")
                    .AddNote(Notes.A, "nah").AddNote(lowerG, "roll").AddNote(lowerG, "me");

                song.AddNote(lowerG, $"She").AddNote(Notes.D, "ain't").AddNote(Notes.B, "the")
                    .AddNote(Notes.B, "shar").AddNote(Notes.A, "pest").AddNote(Notes.A, "tool")
                    .AddNote(lowerG, "in").AddNote(lowerG, "the").SubtractSpeed(speed).AddPause(500).AddNote(lowerE, "shed.");

                return song;
            }

            public static SongBuilder BetterOffAlone()
            {
                Notes.ResetNotes();
                var lowerGSharp = new Note(NoteType.GSharp).DecreaseOctave();
                var lowerASharp = new Note(NoteType.ASharp).DecreaseOctave();
                var lowerFSharp = new Note(NoteType.FSharp).DecreaseOctave();

                var song = new SongBuilder("Better Off Alone").SetInitialSpeed(300)
                    .AddNote(Notes.B, "dee").AddPause(100).AddNote(Notes.B, "dee").AddPause(250).AddNote(lowerGSharp, "doo").AddPause(250)
                    .AddNote(Notes.B, "dee").AddPause(250).AddNote(Notes.B, "dee").AddPause(250).AddNote(lowerASharp, "doo").AddPause(250)
                    .AddNote(lowerFSharp, "doo").AddPause(100).AddNote(Notes.FSharp, "dee").AddNote(Notes.FSharp, "dee").AddNote(Notes.DSharp, "doo").AddPause(500)
                    .AddNote(Notes.B, "dee").AddPause(100).AddNote(Notes.B, "dee").AddPause(250).AddNote(lowerGSharp, "doo").AddPause(250)
                    .AddNote(Notes.B, "dee").AddPause(250).AddNote(Notes.B, "dee").AddPause(250).AddNote(lowerASharp, "doo").AddPause(250)
                    .AddNote(lowerFSharp, "doo").AddPause(100).AddNote(Notes.E, "dee").AddNote(Notes.E, "dee").AddNote(Notes.DSharp, "doo").AddPause(500)
                     .AddNote(Notes.B, "dee").AddPause(100).AddNote(Notes.B, "dee").AddPause(250).AddNote(lowerGSharp, "doo").AddPause(250)
                    .AddNote(Notes.B, "dee").AddPause(250).AddNote(Notes.B, "dee").AddPause(250).AddNote(lowerASharp, "doo").AddPause(250)
                    .AddNote(lowerFSharp, "doo").AddPause(100).AddNote(Notes.FSharp, "dee").AddNote(Notes.FSharp, "dee").AddNote(Notes.DSharp, "doo").AddPause(500)
                    .AddNote(Notes.B, "dee").AddPause(100).AddNote(Notes.B, "dee").AddPause(250).AddNote(lowerGSharp, "doo").AddPause(250)
                    .AddNote(Notes.B, "dee").AddPause(250).AddNote(Notes.B, "dee").AddPause(250).AddNote(lowerASharp, "doo").AddPause(250)
                    .AddNote(lowerFSharp, "doo").AddPause(100).AddNote(Notes.E, "dee").AddNote(Notes.E, "dee").AddNote(Notes.DSharp, "doo").AddPause(500)

                     .AddNote(Notes.B, "Do you").AddPause(100).AddNote(Notes.B, "tink").AddPause(250).AddNote(lowerGSharp, "you're").AddPause(250)
                    .AddNote(Notes.B, "bet").AddPause(250).AddNote(Notes.B, "ter").AddPause(250).AddNote(lowerASharp, "off").AddPause(250)
                    .AddNote(lowerFSharp, "ahh").AddPause(100).AddNote(Notes.FSharp, "loooo").AddNote(Notes.FSharp, "ow").AddNote(Notes.DSharp, "ohn").AddPause(500)
                    .AddNote(Notes.B, "Doo").AddPause(100).AddNote(Notes.B, "youuu").AddPause(250).AddNote(lowerGSharp, "think").AddPause(250)
                    .AddNote(Notes.B, "you").AddPause(250).AddNote(Notes.B, "are").AddPause(250).AddNote(lowerASharp, "bett").AddPause(250)
                    .AddNote(lowerFSharp, "tur").AddPause(100).AddNote(Notes.E, "off").AddNote(Notes.E, "ahhh").AddNote(Notes.DSharp, "loan").AddPause(500);
                return song;
            }
            /// <summary>
            /// Builder for a song.
            /// </summary>
            /// <returns>Mary Had a Little Lamb.</returns>
            public static SongBuilder MaryHadALittleLamb(string name)
            {
                Notes.ResetNotes();
                return new SongBuilder($"Bonzi Had A Little {name}").SetInitialSpeed(120).AddNote(Notes.E, "Bonzi")
                    .AddNote(Notes.D, "had").AddNote(Notes.C, "a").AddNote(Notes.D, "little")
                    .AddNote(Notes.E, $"{name}.")
                    .AddPause(300).AddNote(Notes.D, "Little").AddNote(Notes.D, $"{name}.").AddPause(300)
                    .AddNote(Notes.E, "Little").AddNote(Notes.G, $"{name}!")
                    .AddNote(Notes.E, "Bonzi").AddNote(Notes.D, "had").AddNote(Notes.C, "a")
                    .AddNote(Notes.D, "little").AddNote(Notes.E, $"{name},")
                    .AddNote(Notes.E, "their").AddNote(Notes.E, "wool").AddNote(Notes.D, "was")
                    .AddNote(Notes.E, "white").AddNote(Notes.D, "as").SubtractSpeed(50).AddNote(Notes.C, "snow!");
            }

            /// <summary>
            /// Builder for Alice Deejay's "Better Off Alone"
            /// </summary>
            /// <returns>Better Off Alone by Alice Deejay but DeepSeek's response using the Song</returns>
            public static SongBuilder BetterOffAloneBad()
            {
                Notes.ResetNotes();
                var song = new SongBuilder("Better Off Alone")
                    .SetInitialSpeed(130); // Typical trance/house tempo

                // Get lower octave notes for the bassline
                var lowerC = Notes.C.DecreaseOctave();
                var lowerD = Notes.D.DecreaseOctave();
                var lowerE = Notes.E.DecreaseOctave();
                var lowerF = Notes.F.DecreaseOctave();
                var lowerG = Notes.G.DecreaseOctave();

                // Iconic intro synth melody: "dee dee doo dee dee doo dee"
                // This is the main synth riff (approximated)
                song.AddNote(Notes.G, "dee").AddNote(Notes.G, "dee")
                    .AddNote(Notes.FSharp, "doo").AddNote(Notes.G, "dee")
                    .AddNote(Notes.G, "dee").AddNote(Notes.FSharp, "doo")
                    .AddNote(Notes.G, "dee").AddPause(200);

                // Repeat the riff
                song.AddNote(Notes.G, "dee").AddNote(Notes.G, "dee")
                    .AddNote(Notes.FSharp, "doo").AddNote(Notes.G, "dee")
                    .AddNote(Notes.G, "dee").AddNote(Notes.FSharp, "doo")
                    .AddNote(Notes.G, "dee").AddPause(400);

                // Build up to the vocals with some atmospheric notes
                song.AddNote(Notes.C, "~").AddNote(Notes.E, "~")
                    .AddNote(Notes.G, "~").AddPause(300);

                // First verse: "Do you think you're better off alone..."
                // Slower, more melodic delivery for the vocals
                song.ChangeSpeed(100) // Slow down for vocals
                    .AddNote(Notes.E, "Do").AddNote(Notes.G, "you")
                    .AddNote(Notes.A, "think").AddNote(Notes.G, "you're")
                    .AddNote(Notes.E, "bet-").AddNote(Notes.D, "ter")
                    .AddNote(Notes.C, "off").AddNote(Notes.D, "a-")
                    .AddNote(Notes.E, "lone...").AddPause(500);

                // Repeat with slight variation
                song.AddNote(Notes.E, "Do").AddNote(Notes.G, "you")
                    .AddNote(Notes.A, "think").AddNote(Notes.G, "you're")
                    .AddNote(Notes.E, "bet-").AddNote(Notes.D, "ter")
                    .AddNote(Notes.C, "off").AddNote(Notes.D, "a-")
                    .AddNote(Notes.E, "loooone...").AddPause(600);

                // Bring back the synth riff between verses
                song.ChangeSpeed(130) // Back to original tempo
                    .AddNote(Notes.G, "dee").AddNote(Notes.G, "dee")
                    .AddNote(Notes.FSharp, "doo").AddNote(Notes.G, "dee")
                    .AddNote(Notes.G, "dee").AddNote(Notes.FSharp, "doo")
                    .AddNote(Notes.G, "dee").AddPause(300);

                // Second verse (optional - can extend as needed)
                song.ChangeSpeed(100)
                    .AddNote(Notes.E, "Talk").AddNote(Notes.G, "to")
                    .AddNote(Notes.A, "me").AddNote(Notes.G, "ba-")
                    .AddNote(Notes.E, "by...").AddPause(400);

                // Final synth riff outro
                song.ChangeSpeed(130)
                    .AddNote(Notes.G, "dee").AddNote(Notes.G, "dee")
                    .AddNote(Notes.FSharp, "doo").AddNote(Notes.G, "dee")
                    .AddNote(Notes.G, "dee").AddNote(Notes.FSharp, "doo")
                    .AddNote(Notes.G, "dee").AddPause(200)
                    .AddNote(Notes.G, "dee").AddNote(Notes.G, "dee")
                    .AddNote(Notes.FSharp, "doo").AddNote(Notes.G, "dee")
                    .AddNote(Notes.G, "dee").AddNote(Notes.FSharp, "doo")
                    .AddNote(Notes.G, "dee").AddPause(1000);

                return song;
            }
        }
    }
}
