using ClippyCore.Interfaces;
using DoubleAgent.AxControl;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClippyCore.EventManagement.Commands
{
    /// <summary>
    /// Command to be executed when assigned option is selected on an Agent's Context Menu (right clicking on the agent). This Command type can only be attached to an Agent. Attaching it to other controls is potentially possible but not supported.
    /// </summary>
    /// <see cref="Command"/>
    internal class ContextMenuCommand : Command
    {
        private CtlCommandEventHandler _eventHandler;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Name of command.</param>
        /// <param name="action">Event it performs.</param>
        public ContextMenuCommand(string name, Action action) : base(name, action)
        {
            EventType = EventType.ContextMenu;
        }

        /// <summary>
        /// Attaches Event listener to Agent
        /// </summary>
        /// <param name="agent">Agent to perform Command.</param>
        public override void Attach(IAgentInternal agent)
        {
            base.Attach(agent);
            agent.Controller.Characters[agent.AgentName].Commands.Add(Name, DisplayName, null, true, true);
            _eventHandler = new CtlCommandEventHandler(OnCommand);
            agent.Controller.CtlCommand += _eventHandler;
        }

        /// <summary>
        /// Detaches Event listener from Agent.
        /// </summary>
        /// <param name="agent">Agent to have Command removed from.</param>
        public override void Detach(IAgentInternal agent)
        {
            base.Detach(agent);
            try
            {
                agent.Controller.Characters[agent.AgentName].Commands.Remove(Name);
            }
            catch
            {
                //TODO: Handle event not existing
            }

            if (_eventHandler != null)
            {
                agent.Controller.CtlCommand -= _eventHandler;
                _eventHandler = null;
            }
        }

        /// <summary>
        /// Event Handler.
        /// </summary>
        /// <param name="sender">What triggered the event.</param>
        /// <param name="e">Event data</param>
        private void OnCommand(object sender, CtlCommandEvent e)
        {
            if (e.UserInput.Name == Name)
            {
                Execute();
            }
        }

    }
}
