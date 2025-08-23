using DoubleAgent.AxControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClippyCore.Global;
using ClippyCore.Agents;
using ClippyCore.Interfaces;
using System.Diagnostics;

namespace ClippyDesktop.Forms
{
    public partial class Main : Form
    {
        private int _agentPosX;
        private int _agentPosY;
        private IAgent _bonzi;
        private IAgent _shrek;
        private IAgent _clippy;

        public Main()
        {
            InitializeComponent();
            Hide();
            _agentPosX = Screen.PrimaryScreen.Bounds.Right - 600;
            _agentPosY = Screen.PrimaryScreen.Bounds.Bottom - 450;
            AxControl axControl = new AxControl();
            axControl.CreateControl();
            _shrek = AgentManager.CreateAgent(axControl, AgentType.Shrek);
            _bonzi = AgentManager.CreateAgent(axControl, AgentType.Bonzi);
            _clippy = AgentManager.CreateAgent(axControl, AgentType.Clippy);

            _bonzi.Show();
            _bonzi.Play("POOOPOOO");

        }

        public void HelloWorldDemo()
        {
            //Some example code to get started
            //Similar code can be found @ ClippyDesktop.Forms.Main.cs at HelloWorldDemo()
            
            //With ClippyCore
            AxControl axControl = new AxControl();
            axControl.CreateControl(); //This is what uses the Control class from Windows.System.Forms
            IAgent clippy = AgentManager.CreateAgent(axControl, AgentType.Clippy);
            clippy.Show();
            clippy.Play(Animations.Clippy.Wave);
            clippy.Speak("Hello World!");
            clippy.Hide();

            //With AxControl directly
            
            AxControl axControl2 = new AxControl();
            string agentName = "BonziVine";
            axControl2.CreateControl();
            axControl2.Characters.Load(agentName, "../some/path/to/an/acsfile.acs");
            axControl2.Characters[agentName].TTSModeID = "{some-tts-id}"; //Required for some agents for Text to speech to work
            axControl2.Characters[agentName].Show();
            axControl2.Characters[agentName].Play("Wave");
            axControl2.Characters[agentName].Speak("Hello World!");
            axControl2.Characters[agentName].Hide();

        }
        public void SpeakPhotographLyrics()
        {
            _bonzi.Speak("this is a photograph");
            _bonzi.Speak("every time i do it makes me laugh");
            _bonzi.Speak("how did our eyes get so red");
            _bonzi.Speak("and what the hell is on joey's head");
            _shrek.Play("ClubTuki"); // Called after 4 lines

            _bonzi.Speak("and this is where i grew up");
            _bonzi.Speak("i think the present owner fixed it up");
            _bonzi.Speak("i never knew we'd ever went without");
            _bonzi.Speak("the second floor is hard for sneaking out");
            _shrek.Play("ClubTuki"); // Called after 4 lines

            _bonzi.Speak("and this is where i went to school");
            _bonzi.Speak("most of the time had better things to do");
            _bonzi.Speak("criminal record says i broke in twice");
            _bonzi.Speak("i must have done it half a dozen times");
            _shrek.Play("ClubTuki"); // Called after 4 lines

            _bonzi.Speak("i wonder if it's too late");
            _bonzi.Speak("should i go back and try to graduate");
            _bonzi.Speak("life's better now than it was back then");
            _bonzi.Speak("if i was them i wouldn't let me in");
            _shrek.Play("ClubTuki"); // Called after 4 lines

            _bonzi.Speak("every memory of looking out the back door");
            _bonzi.Speak("i had the photo album spread out on my bedroom floor");
            _bonzi.Speak("it's hard to say it, time to say it");
            _bonzi.Speak("goodbye, goodbye");
            _shrek.Play("ClubTuki"); // Called after 4 lines

            _bonzi.Speak("every memory of walking out the front door");
            // The final line (line 25) doesn't have 3 others to make a group of 4, so no ClubTuki after it.
        }
    }
}
