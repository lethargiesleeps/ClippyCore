using ClippyCore.Interfaces;
using DoubleAgent.AxControl;
using DoubleAgent.Control;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClippyCore.EventManagement.Commands
{
    /// <summary>
    /// Command to be executed when Agent is hidden.
    /// </summary>
    /// <see cref="Command"/>
    internal class HideCommand : Command
    {
        public CtlHideEventHandler Handler { get; private set; }
        public CtlHideEvent LastEvent { get; private set; }
        private VisibilityCauseType _causeType;


        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Name of command.</param>
        /// <param name="action">Event it performs.</param>
        /// <param name="causeType">What caused the Hide command. Default is user hide. Taken from DoubleAgent.Control. Any 'Showed' type will default to UserHid.</param>
        public HideCommand(string name, Action action, VisibilityCauseType causeType = VisibilityCauseType.UserHid) : base(name, action)
        {
            EventType = EventType.Hide;
            switch(causeType)
            {
                case VisibilityCauseType.UserShowed:
                case VisibilityCauseType.OtherProgramShowed:
                case VisibilityCauseType.ProgramShowed:
                case VisibilityCauseType.NeverShown:
                    _causeType = VisibilityCauseType.UserHid;
                    break;
                default: _causeType = causeType; break;
            }
        }

        /// <summary>
        /// Attaches Event listener to Agent
        /// </summary>
        /// <param name="agent">Agent to perform Command.</param>
        public override void Attach(IAgentInternal agent)
        {
            base.Attach(agent);
            Handler = new CtlHideEventHandler(OnCommand);
            agent.Controller.CtlHide += Handler;
            
        }

        /// <summary>
        /// Detaches Event listener from Agent.
        /// </summary>
        /// <param name="agent">Agent to have Command removed from.</param>
        public override void Detach(IAgentInternal agent)
        {
            base.Detach(agent);
            if (Handler != null)
            {
                agent.Controller.CtlHide -= Handler;
                Handler = null;
                LastEvent = null;
            }
        }

        /// <summary>
        /// Event Handler.
        /// </summary>
        /// <param name="sender">What triggered the event.</param>
        /// <param name="e">Event data</param>
        private void OnCommand(object sender, CtlHideEvent e)
        {
            if(_causeType == e.Cause)
            {
                LastEvent = e;
                Execute();
            }
        }
    }
}
