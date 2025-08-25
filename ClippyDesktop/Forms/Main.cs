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


            //3. Script your commands
            //Using CommandFactory (simple)
            ICoreCommand greetCommand = CommandFactory.CreateContextMenuCommand("Greet", () => bonzi.Speak("I'm here to help you."));

            //Using CommandBuilder (more flexibility)
            ICoreCommand jokeCommand = new CommandBuilder()
                .WithEventType(EventType.ContextMenu)
                .WithName("TellJoke")
                .WithDisplayName("Tell Joke")
                .WithDescription("Bonzi tells a joke haha.")
                .WithAction( () => bonzi.Speak("Why don't scientists trust atoms? Because they make up everything!"))
                .Build();


            // 4. Attach commands
            bonzi.Commands.AddCommand(greetCommand);
            bonzi.Commands.AddCommand(jokeCommand);

            //5. Dettach a command
            bonzi.Commands.RemoveCommand("Greet");

            //6. Update commands with new one
            ICoreCommand weatherCommand = CommandFactory.CreateContextMenuCommand("Weather", () => bonzi.Speak("Let me check the weather for you..."));
            bonzi.Commands.AddCommand(weatherCommand);

            //7. Show and do some stuff.
            bonzi.Show();

            bonzi.Play(Animations.Bonzi.Wave); //Pre programmed animations
            bonzi.Play("Wink"); //Pass animation name
            bonzi.GetAnimation("Wink").Play(bonzi); //Alternative way to play animation
            bonzi.Speak("Hello there! My name is Bonzi Buddy");

            //8. Runs command not associated with an event. Stored internally for later use as well.
            bonzi.Commands.TriggerCommand("Greet");




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
