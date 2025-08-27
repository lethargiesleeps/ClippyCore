using ClippyCore.EventManagement.Inputs;
using ClippyCore.Helpers;
using ClippyCore.Interfaces;
using DoubleAgent.AxControl;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClippyCore.EventManagement.Commands
{
    /// <summary>
    /// Command to be executed when Agent is clicked. Uses ClickFilter to determine button+key presses and combos.
    /// </summary>
    /// <see cref="Command"/>
    /// <see cref="ClickFilter"/>
    internal class ClickCommand : Command
    {
        public CtlClickEvent LastEvent { get; private set; }

        private readonly ClickFilter _filter;
        public CtlClickEventHandler _handler;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Name of command.</param>
        /// <param name="action">Event it performs.</param>
        /// <param name="filter">Filter parameters for event.</param>
        public ClickCommand(string name, Action action, ClickFilter filter = null) : base(name, action)
        {
            EventType = EventType.Click;
            _filter = filter ?? ClickFilter.AnyClick;
        }

        /// <summary>
        /// Attaches Event listener to Agent
        /// </summary>
        /// <param name="agent">Agent to perform Command.</param>
        public override void Attach(IAgentInternal agent)
        {
            base.Attach(agent);
            _handler = new CtlClickEventHandler(OnCommand);
            agent.Controller.CtlClick += _handler;

        }

        /// <summary>
        /// Detaches Event listener from Agent.
        /// </summary>
        /// <param name="agent">Agent to have Command removed from.</param>
        public override void Detach(IAgentInternal agent)
        {
            base.Detach(agent);
            if (_handler != null)
            {
                agent.Controller.CtlClick -= _handler;
                _handler = null;
                LastEvent = null;
            }
        }

        /// <summary>
        /// Event _handler.
        /// </summary>
        /// <param name="sender">What triggered the event.</param>
        /// <param name="e">Event data.</param>
        private void OnCommand(object sender, CtlClickEvent e)
        {
            if (ShouldExecuteForEvent(e))
            {
                LastEvent = e;
                Execute();
            }

        }

        /// <summary>
        /// Determines if event should be executed when specific mouse button/modifier key is pressed.
        /// </summary>
        /// <param name="e">Event data.</param>
        /// <returns>Bool whether or not to execute event</returns>
        private bool ShouldExecuteForEvent(CtlClickEvent e)
        {
            bool buttonMatches = _filter.MouseButton.HasFlag(EventHelper.GetMousePress(e.Button));
            bool modifierKeyMatches = _filter.ModifierKeys.HasFlag(EventHelper.GetModifierKeyPress(e.Shift));
            return buttonMatches && modifierKeyMatches;
        }
    }
}
