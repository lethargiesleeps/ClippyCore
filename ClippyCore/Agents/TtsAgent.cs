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

        public TtsAgent(string acsPath, string agentName,AgentType agentType, AxControl controller, string ttsID)
            : base(acsPath, agentName, agentType, controller)
        {
            TtsID = ttsID;
            Controller.Characters[AgentName].TTSModeID = TtsID;
        }
    }
}
