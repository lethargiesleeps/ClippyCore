using ClippyCore.Agents;
using DoubleAgent.AxControl;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClippyCore.Interfaces
{
    /// <summary>
    /// Interace contract for all Agents and derived classes.
    /// Agent implements IAgent, and other derivites inherit from Agent
    /// Base implementation is Agent.cs
    /// </summary>
    /// <see cref="Agent"/>
    public interface IAgent
    {
        string AgentName { get; }
        AgentType AgentType { get; }
        ICommandable Commands { get; }
        void Speak(string phrase);
        void Speak(List<string> phrases);
        void Speak(Dictionary<uint, string> phrases, uint key);
        void Speak(string[] phrases);
        void Speak(Dictionary<string, string> phrases, string key);
        void Play(string animation);
        void Play(Animation animation);
        void Play(byte animationKey);
        void Stop();
        void Show();
        void Hide();
        void MoveTo(int x, int y, int speed = 0);
        void MoveTo(short x, short y, int speed = 0);
        string[] GetAnimationNames();
        System.Collections.IDictionary GetAnimations(bool useStringKey = false);
        Animation GetAnimation(string animationName);
        Animation GetAnimation(byte key);

    }
}
