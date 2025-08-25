using ClippyCore.Interfaces;
using DoubleAgent.AxControl;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClippyCore.EventManagement.Commands
{
    /// <summary>
    /// Command type representing a double click event (on the control it's being attached to, typically an Agent but can be used with other ActiveX Controlrs)
    /// </summary>
    /// <see cref="Command"/>
    internal class DoubleClickCommand : Command
    {
        private CtlDblClickEventHandler _eventHandler;
        private IEnumerable<ICoreCommand> _commands;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Name of command.</param>
        /// <param name="action">Event it performs.</param>
        public DoubleClickCommand(string name, Action action) : base(name, action)
        {
            EventType = EventType.DoubleClick;
        }

        /// <summary>
        /// Attaches Event listener to Agent
        /// </summary>
        /// <param name="agent">Agent to perform Command.</param>
        public override void Attach(IAgentInternal agent)
        {
            base.Attach(agent);
            _commands = agent.Commands.GetCommands(EventType.DoubleClick);
            _eventHandler = new CtlDblClickEventHandler(OnCommand);
            agent.Controller.CtlDblClick += _eventHandler;
        }

        /// <summary>
        /// Detaches Event listener from Agent.
        /// </summary>
        /// <param name="agent">Agent to have Command removed from.</param>
        public override void Detach(IAgentInternal agent)
        {
            base.Detach(agent);
            if (_eventHandler != null)
            {
                agent.Controller.CtlDblClick -= _eventHandler;
                _eventHandler = null;
            }
        }

        /// <summary>
        /// Event Handler.
        /// </summary>
        /// <param name="sender">What triggered the event.</param>
        /// <param name="e">Event data</param>
        private void OnCommand(object sender, CtlDblClickEvent e)
        {
            // Execute all double-click commands
            foreach (var command in _commands)
            {
                command.Execute();
            }
        }
    }
}
