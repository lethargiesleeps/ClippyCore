using ClippyCore.Global;
using ClippyCore.Interfaces;
using DoubleAgent.AxControl;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClippyCore.Agents
{
    /// <summary>
    /// Static class that properly Creates and Disposes of agents created at runtime.
    /// Abstracts other projects from creating Agent objects directly.
    /// Use this in projects to create Agents
    /// </summary>
    public static class AgentManager
    {
        /// <summary>
        /// Creates and agent. Multiple agents can be created and used at any given time using one axControl.
        /// </summary>
        /// <param name="axControl">AxControl for Agent to use. (should only ever be one at any given time)</param>
        /// <param name="agentType">Enum used to determine what values to set when instantiating a new Agent.</param>
        /// <see cref="AgentType"/>
        /// <returns>A class that implements IAgent, to be used during program execution.</returns>
        public static Agent CreateAgent(AxControl axControl, AgentType agentType)
        {

            switch(agentType)
            {
                case AgentType.Bonzi:
                    return new TtsAgent(Paths.BONZI, AgentNames.BONZI, agentType, axControl, TtsIDs.BONZI);
                case AgentType.Clippy:
                    return new Agent(Paths.CLIPPY, AgentNames.CLIPPY, agentType, axControl);
                case AgentType.Shrek:
                    return new Agent(Paths.SHREK, AgentNames.SHREK, agentType, axControl);
                default:
                    return null;
            }
        }

        /// <summary>
        /// Creates a custom agent (not preimplemented by ClippyCire)
        /// </summary>
        /// <param name="axControl">AxControl for Agent to use. Defined at startup.</param>
        /// <param name="agentName">Name of the Agent.t</param>
        /// <param name="acsPath">Path to the Agent's ACS file.</param>
        /// <param name="ttsID">If provided, returns a TTS enabled Agent.</param>
        /// <returns>The custom Agent.</returns>
        public static Agent CreateCustomAgent(AxControl axControl, string agentName, string acsPath, string ttsID = null) =>
            string.IsNullOrEmpty(ttsID)
            ? new Agent(acsPath, agentName, AgentType.Custom, axControl)
            : new TtsAgent(acsPath, agentName, AgentType.Custom, axControl, ttsID);

    }
}
