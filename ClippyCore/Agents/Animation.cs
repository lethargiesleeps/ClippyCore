using ClippyCore.Helpers;
using ClippyCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClippyCore.Agents
{
    /// <summary>
    /// Class with basic data about an Agent's available animations
    /// </summary>
    public class Animation
    {
        public string Name { get; }
        public string DisplayName { get; }

        private Animation(string name, string displayName = null)
        {
            Name = name;
            DisplayName = displayName ?? name;
        }

        /// <summary>
        /// Factory to create new Animations.
        /// </summary>
        /// <param name="name">Name of the animation</param>
        /// <param name="agent">Instance of Agent to attach animations to.</param>
        /// <returns>The newly instantiated Animation</returns>
        public static Animation Create(string name, IAgent agent, string displayName = null)
        {
            //TODO: error stuff
            string[] validAnimations = agent.GetAnimationNames();
            if(!validAnimations.Contains(name))
            {
                Logger.Log($"Animate '{name}' not found in agent.");
            }
            return new Animation(name, displayName);
        }

        /// <summary>
        /// Extra way to play an animation. Not super useful but there anyways if needed.
        /// Could be used if you're crafty and have multiple Agents interacting with each other or if some Agents share common animations...
        /// Ex: var myAnim = Animation.Create("Aknowledge", _bonzi); myAnim.Play(_bonzi);
        /// </summary>
        /// <param name="agent">Agent to perform the animation.</param>
        public void Play(IAgent agent) => agent.Play(Name);
    }

}
