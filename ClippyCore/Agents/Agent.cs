using ClippyCore.EventManagement;
using ClippyCore.Global;
using ClippyCore.Helpers;
using ClippyCore.Interfaces;
using DoubleAgent.AxControl;
using DoubleAgent.Control;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;


namespace ClippyCore.Agents
{
    /// <summary>
    /// Base implementation of IAgent.
    /// Abstracts the use of AxControl from other clients.
    /// To create and dispose of Agents, use public AgentManager.
    /// Uses a CommandManager to execute and manage events/
    /// <see cref="AgentManager"/>
    /// <see cref="CommandManager"/>
    /// </summary>
    public class Agent : IAgent, IAgentInternal
    {
        public string AgentName { get; private set; }
        public AgentType AgentType { get; private set; }
        public Dictionary<byte, Animation> Animations { get; private set; } = new Dictionary<byte, Animation>();
        public bool IsTtsEnabled { get; protected set; }
        protected string AcsPath { get; private set; }
        public ICommandable Commands { get; private set; }
        internal AxControl Controller { get; private set; }

        AxControl IAgentInternal.Controller => Controller;

        

        private readonly Dictionary<string, ICoreCommand> _commands = new Dictionary<string, ICoreCommand>();
        private readonly Dictionary<string, Delegate> _eventHandlers = new Dictionary<string, Delegate>();

        /// <summary>
        /// Base constructor for an MS Agent.
        /// </summary>
        /// <param name="acsPath">Path to the ACS file.</param>
        /// <param name="agentName">Name of the agent, required for use in AxControl since 1 control can utilize multiple Agents.</param>
        /// <param name="agentType">Type of the agent. If using your own agent you must pass AgentType.Custom</param>
        /// <param name="axController">Must pass an AxControl that .CreateControl() was called on.</param>
        internal Agent(string acsPath, string agentName, AgentType agentType, AxControl axController)
        {
            AcsPath = acsPath;
            AgentName = agentName;
            AgentType = agentType;
            Controller = axController;
            Controller.Characters.Load(AgentName, AcsPath);
            

            //Create animation dictioary
            for(int i = 0; i < Controller.Characters[AgentName].Animations.Length; i++)
            {
                try
                {
                    byte key = checked((byte)i);
                    Animations.Add(key, Animation.Create(Controller.Characters[AgentName].Animations[i], this));
                }
                catch(OverflowException) 
                {
                    Logger.Log($"Animation count surpassed limit of 255 when creating the agent '{AgentName}'");
                }
            }

            Commands = new CommandManager(this);

        }

        #region AxControlManagement
        /// <summary>
        /// Implemented from IAgentInternal.
        /// Returns AxControl for use within API to attach/dettach event handlers.
        /// </summary>
        /// <returns>Current AxControl tied to agent.</returns>
        internal AxControl GetAxControl() => Controller;

        /// <summary>
        /// Hides the agent from the screen, but is still running in background.
        /// </summary>
        public void Hide()
        {
            Controller.Characters[AgentName].Stop();
        }

        /// <summary>
        /// Moves agent to specified position. Use this version if using int values, like would be the case when using Screen.PrimaryScreen.Bounds
        /// or Windows.Forms Controls or Rectangles
        /// </summary>
        /// <param name="x">X position relative to 0,0</param>
        /// <param name="y">Y position relative to 0,0</param>
        /// <param name="speed">Speed at which agent moves in miliseconds. 0 is instant.</param>
        public void MoveTo(int x, int y, int speed = 0)
        {
            Controller.Characters[AgentName].MoveTo(Convert.ToInt16(x), Convert.ToInt16(y), speed);
        }

        /// <summary>
        /// Moves agent to specified position. Use this version if knowingly passing 'shorts'. AxControl uses shorts as X,Y arguments natively.
        /// </summary>
        /// <param name="x">X position relative to 0,0</param>
        /// <param name="y">Y position relative to 0,0</param>
        /// <param name="speed">Speed at which agent moves in miliseconds. 0 is instant.</param>
        public void MoveTo(short x, short y, int speed = 0)
        {
            Controller.Characters[AgentName].MoveTo(x, y, speed);
        }

        /// <summary>
        /// Plays an animation by passing a string (if you know it).
        /// You can call GetAnimationNames() to get a full list of available animations for each agent.
        /// </summary>
        /// <param name="animation">Name of the animation.</param>
        public void Play(string animation)
        {
            try
            {
                Controller.Characters[AgentName].Play(animation);
            }
            catch(System.Runtime.InteropServices.COMException e)
            {
                Logger.Log(e.Message);
            }
        }

        /// <summary>
        /// Plays an animation by passing an Animation instance.
        /// </summary>
        /// <param name="animation">The Animation</param>
        public void Play(Animation animation)
        {
            try
            {
                Controller.Characters[AgentName].Play(animation.Name);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                
                Logger.Log(e.Message);
            }
        }

        /// <summary>
        /// Play an animation by passing a byte.
        /// Example usage: _bonzi.Play(Animations.Bonzi.Aknowledge)
        /// </summary>
        /// <see cref="Global.Animations"/>
        /// <param name="animationKey"></param>
        public void Play(byte animationKey)
        {
            try
            {
                Controller.Characters[AgentName].Play(Animations[animationKey].Name);
            }
            catch (KeyNotFoundException e)
            {
                Logger.Log(e.Message);
            }
            
        }

        /// <summary>
        /// Shows the agent on the screen.
        /// </summary>
        public void Show()
        {
            Controller.Characters[AgentName].Show();
        }

        /// <summary>
        /// Makes the agent speak (speech bubble).
        /// </summary>
        /// <param name="phrase">What the agent will say.</param>
        public void Speak(string phrase)
        {
            Controller.Characters[AgentName].Speak(phrase);
        }

        /// <summary>
        /// Make the agent say multiple things in sequence.
        /// Can be used with Dictionaries of TKey,string by doing phrases.Values.ToList etc...
        /// </summary>
        /// <param name="phrases">List of phrases for the agent to speak, one at a time.</param>
        public void Speak(List<string> phrases)
        {
            //TODO: Error stuff
            foreach(string phrase in phrases)
            {
                Controller.Characters[AgentName].Speak(phrase);
            }
        }

        /// <summary>
        /// Make the agent say multiple things in sequence.
        /// Can be used with Dictionaries of TKey,string using phrases.Values.ToArray etc...
        /// </summary>
        /// <param name="phrases">Array of string for the agent to speak.</param>
        public void Speak(string[] phrases)
        {
            //TODO: Error stuff
            foreach (string phrase in phrases)
            {
                Controller.Characters[AgentName].Speak(phrase);
            }
        }

        /// <summary>
        /// Make agent speak specific phrase in a dictionary.
        /// </summary>
        /// <param name="phrases">Phrase dictionary.</param>
        /// <param name="key">Key of phrase value to speak</param>
        public void Speak(Dictionary<string, string> phrases, string key)
        {
            //TODO: Error stuff
            Controller.Characters[AgentName].Speak(phrases[key]);
        }

        /// <summary>
        /// Make agent speak specific phrase in a dictionary.
        /// </summary>
        /// <param name="phrases">Phrase dictionary.</param>
        /// <param name="key">Key of phrase value to speak</param>
        public void Speak(Dictionary<uint, string> phrases, uint key)
        {
            //TODO: Error stuff
            Controller.Characters[AgentName].Speak(phrases[key]);
        }

        /// <summary>
        /// Force stop an Agent animation.
        /// </summary>
        public void Stop()
        {
            Controller.Characters[AgentName].Stop();
        }

        /// <summary>
        /// Get a list of all available animations for the specific agent.
        /// </summary>
        /// <returns>Animation names as strings in an array.</returns>
        public string[] GetAnimationNames() => Controller.Characters[AgentName].Animations;

        /// <summary>
        /// Returns all available Animations for agent as dictionary.
        /// </summary>
        /// <param name="useStringKey">If true, returns the dictionary with string keys where the key is the animation name.</param>
        /// <returns>Dictionary where values are all Animation objects.</returns>
        public IDictionary GetAnimations(bool useStringKey = false)
        {
            if(useStringKey)
            {
                Dictionary<string, Animation> animations = new Dictionary<string, Animation>();
                foreach(Animation animation in Animations.Values)
                {
                    animations.Add(animation.Name, animation);
                }
                return animations;
            }
            return Animations;
        }

        /// <summary>
        /// Returns animation object based on its name.
        /// </summary>
        /// <param name="animationName">Name of the animation obj to return/</param>
        /// <returns>Desired Animation obj</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="KeyNotFoundException"></exception>
        public Animation GetAnimation(string animationName)
        {
            if (string.IsNullOrEmpty(animationName))
                throw new ArgumentException("Animation name cannot be null or empty");

            Animation animation = Animations.Values.FirstOrDefault(anim =>
                anim.Name.Equals(animationName, StringComparison.OrdinalIgnoreCase));

            return animation ?? throw new KeyNotFoundException($"Animation '{animationName}' not found");
        }
        /// <summary>
        /// Returns Animation Obj based on its Animations key.
        /// Example usage: GetAnimation(Animations.Bonzi.Aknowledge)
        /// </summary>
        /// <param name="key">Key of animation in dictionary, as byte.</param>
        /// <returns>The Animation obj</returns>
        public Animation GetAnimation(byte key)
        {
            //TODO: Error stuff, key not found or overflow
            return Animations[key];
        }

        AxControl IAgentInternal.GetAxControl()
        {
            return GetAxControl();
        }
        #endregion

    }
}
