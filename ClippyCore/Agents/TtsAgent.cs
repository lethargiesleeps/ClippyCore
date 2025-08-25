using DoubleAgent.AxControl;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClippyCore.Agents
{
    /// <summary>
    /// A type of IAgent that has TTS functionaility. a TTSId must be passed and is subsequently registered in AxControl. A list of common TTSIds can be found in Global.TtsIDs.cs.
    /// NOTE: Not all .acs files have TTS capabilities. I will log some in this project but agents outside the scope of this will require trial and error.
    /// EX: Clippy does not have TTS, Bonzi Buddy does.
    /// </summary>
    /// <see cref="Global.TtsIDs"/>
    internal class TtsAgent : Agent
    {
        public string TtsID { get; private set; }

        /// <summary>
        /// Constructor for a TtsAgent.
        /// </summary>
        /// <param name="acsPath">Path to ACS file.</param>
        /// <param name="agentName">Name of the agent used by AxControl.</param>
        /// <param name="agentType">Type of the Agent (precoded one or AgentType.Custom for your own.</param>
        /// <param name="controller">Controller that does bulk of the work.</param>
        /// <param name="ttsID">ID of TTSMode. Essentially the voice of the Agent.</param>
        public TtsAgent(string acsPath, string agentName,AgentType agentType, AxControl controller, string ttsID)
            : base(acsPath, agentName, agentType, controller)
        {
            TtsID = ttsID;
            Controller.Characters[AgentName].TTSModeID = TtsID;
        }
    }
}
