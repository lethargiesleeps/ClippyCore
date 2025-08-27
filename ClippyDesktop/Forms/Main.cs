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
using ClippyCore.EventManagement;
using ClippyCore.EventManagement.Commands;
using ClippyCore.EventManagement.Inputs;

namespace ClippyDesktop.Forms
{
    public partial class Main : Form
    {

        private Agent _bonzi;
        private IAgent _shrek;
        private IAgent _clippy;

        public Main()
        {
            InitializeComponent();
            Hide();

            HelloWorldDemo();


        }

        

        public void HelloWorldDemo()
        {
            //1. Create new agent
            AxControl axControl = new AxControl();
            axControl.CreateControl();
            IAgent bonzi = AgentManager.CreateAgent(axControl, AgentType.Bonzi);

            //2. Move agent and Show
            int agentPosX = Screen.PrimaryScreen.Bounds.Right - 600;
            int agentPosY = Screen.PrimaryScreen.Bounds.Bottom - 450;
            bonzi.MoveTo(agentPosX, agentPosY);

            bonzi.Show();

            ICoreCommand leftClick = CommandFactory.CreateClickCommand("LeftClick", () => bonzi.Speak("Left"), new ClickFilter(MouseButton.Left));
            ICoreCommand shiftRight = CommandFactory.CreateClickCommand("ShiftRight", () => bonzi.Speak("Shift Right"), new ClickFilter(MouseButton.Right, ModKeys.Shift));
   
            bonzi.Speak(Songs.Shared.BetterOffAlone().ToString());




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
