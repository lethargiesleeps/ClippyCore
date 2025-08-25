using ClippyCore.EventManagement.Commands;
using ClippyCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClippyCore.EventManagement
{
    /// <summary>
    /// Builder class for creating Commands.
    /// WithName, WithAction and WithType are required.
    /// Call Build() to return the newly created ICoreCommand
    /// </summary>
    /// <see cref="Command"/>
    /// <see cref="ICoreCommand"/>
    public class CommandBuilder
    {
        private string _name;
        private string _displayName;
        private string _description;
        private Action _action;
        private EventType _eventType = EventType.Generic;

        /// <summary>
        /// Required. Gives Command a name
        /// </summary>
        /// <param name="name">Name of Command instance.</param>
        /// <returns>Current instance of builder.</returns>
        public CommandBuilder WithName(string name) { _name = name; return this; }
        /// <summary>
        /// Optional. Sets DisplayName of Command (likely a formatted version of Name).
        /// </summary>
        /// <param name="displayName">New DisplayName for Command.</param>
        /// <returns>Current instance of builder.</returns>
        public CommandBuilder WithDisplayName(string displayName) { _displayName = displayName; return this; }
        /// <summary>
        /// Optional. Sets Description of Command.
        /// </summary>
        /// <param name="description"></param>
        /// <returns>Current instance of builder.</returns>
        public CommandBuilder WithDescription(string description) { _description = description; return this; }
        /// <summary>
        /// Required. Action/function to execute on fire.
        /// </summary>
        /// <param name="action">Code to execute if Command is triggered.</param>
        /// <returns>Current instance of builder.</returns>
        public CommandBuilder WithAction(Action action) { _action = action; return this; }
        /// <summary>
        /// Required. Type of event to attach to Command.
        /// </summary>
        /// <param name="eventType">TEventType of event to build.</param>
        /// <see cref="EventType"/>
        /// <returns>Current instance of builder.</returns>
        public CommandBuilder WithEventType(EventType eventType) { _eventType = eventType; return this; }

        /// <summary>
        /// Build the Command.
        /// </summary>
        /// <returns>Built Command.</returns>
        /// <exception cref="InvalidOperationException">Thrown if required fields are missing.</exception>
        public ICoreCommand Build()
        {
            //TODO: Proper error handling and logging for this
            if(string.IsNullOrEmpty(_name))
            {

                throw new InvalidOperationException("Must use WithName()");
            }

            if (_action is null)
            {
                throw new InvalidOperationException("Must use WithAction()");
            }

            IInternalCommand concreteCommand;

            switch(_eventType)
            {
                case EventType.Generic: concreteCommand = new Command(_name, _action); break;
                case EventType.DoubleClick: concreteCommand = new DoubleClickCommand(_name, _action); break;
                case EventType.ContextMenu: concreteCommand = new ContextMenuCommand(_name, _action); break;
                default: throw new InvalidOperationException("Please use correct EventType. Can be set with .WithType()");
            }

            if (!string.IsNullOrEmpty(_displayName)) concreteCommand.OverrideDisplayName(_displayName);
            if (!string.IsNullOrEmpty(_description)) concreteCommand.SetDescription(_description);
            return concreteCommand;
        }
    }
}
