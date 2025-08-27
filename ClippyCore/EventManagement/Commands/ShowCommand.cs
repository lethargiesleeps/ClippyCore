using ClippyCore.Interfaces;
using DoubleAgent.AxControl;
using DoubleAgent.Control;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClippyCore.EventManagement.Commands
{
    /// <summary>
    /// Command to be executed when Agent is shown.
    /// </summary>
    /// <see cref="Command"/>
    internal class ShowCommand : Command
    {
        public CtlShowEventHandler Handler { get; private set; }
        public CtlShowEvent LastEvent { get; private set; }
        private VisibilityCauseType _causeType;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Name of command.</param>
        /// <param name="action">Event it performs.</param>
        /// <param name="causeType">What caused the Hide command. Default is user hide. Taken from DoubleAgent.Control. Any 'Hide' type will default to UserShowed</param>
        public ShowCommand(string name, Action action, VisibilityCauseType causeType = VisibilityCauseType.UserShowed) : base(name, action)
        {
            EventType = EventType.Show;
            switch(causeType)
            {
                case VisibilityCauseType.UserHid:
                case VisibilityCauseType.ProgramHid:
                case VisibilityCauseType.OtherProgramHid:
                case VisibilityCauseType.NeverShown:
                    _causeType = VisibilityCauseType.UserShowed;
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
            Handler = new CtlShowEventHandler(OnCommand);
            agent.Controller.CtlShow += Handler;

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
                agent.Controller.CtlShow -= Handler;
                Handler = null;
                LastEvent = null;
            }
        }

        /// <summary>
        /// Event Handler.
        /// </summary>
        /// <param name="sender">What triggered the event.</param>
        /// <param name="e">Event data</param>
        private void OnCommand(object sender, CtlShowEvent e)
        {
            if (_causeType == e.Cause)
            {
                LastEvent = e;
                Execute();
            }
        }
    }
}
