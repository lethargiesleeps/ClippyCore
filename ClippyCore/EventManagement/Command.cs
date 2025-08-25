using ClippyCore.Agents;
using ClippyCore.Interfaces;
using DoubleAgent.AxControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ClippyCore.EventManagement
{
    /// <summary>
    /// Base implementation of ICoreCommand and IInternalCommand. Has EventType.NoEvent unless explicityly overridden.
    /// Mostly used internally, can also be used to Trigger generic Commands with no event attached to it (ex: TriggerCommand("my_command", () => doSomething())
    /// Distinction between Command and Event: A Command is a physical interaction. It houses the data for an Event which is what happens when the interaction occurs.
    /// </summary>
    /// <see cref="ICoreCommand"/>
    /// <see cref="IInternalCommand"/>
    internal class Command : IInternalCommand
    {
        public string Name { get; }
        public string DisplayName { get; private set; }
        public string Description { get; set; }
        public EventType EventType { get; protected set; }
        public int TimesFired { get; protected set; }
        protected Action _action;

        /// <summary>
        /// Base constructor for Command.
        /// </summary>
        /// <param name="name">Name of Command.</param>
        /// <param name="action">Event the Command fires/listens for.</param>
        public Command(string name, Action action)
        {
            Name = name;
            DisplayName = name; //TODO: DisplayName formatting... i.e Name = "READ_TEXT", DisplayName = "Read Text"
            _action = action;
            EventType = EventType.NoEvent;

        }
        /// <summary>
        /// Override constructor for Command. Can override EventType using this if required.
        /// Only used internally via CommandBuilder.
        /// </summary>
        /// <param name="name">Name of command.</param>
        /// <param name="action">Event the Command/listens for.</param>
        /// <param name="eventType">Override what type of event the Command will fire from.</param>
        public Command(string name, Action action, EventType eventType)
        {
            Name = name;
            DisplayName = name; //TODO: DisplayName formatting... i.e Name = "READ_TEXT", DisplayName = "Read Text"
            _action = action;
            EventType = eventType;

        }

        /// <summary>
        /// Fire the command.
        /// </summary>
        public virtual void Execute()
        {
            TimesFired++;
            _action?.Invoke();
        }

        /// <summary>
        /// Generic Commands do not require attachment as they are not tied with an event, and are Execucuted either via Execute() or CommandManager.TriggerEvent()
        /// </summary>
        /// <param name="agent"></param>
        public virtual void Attach(IAgentInternal agent)
        {
            //TODO: Default implementation. Log that using is pointless on generic command.
        }

        /// <summary>
        /// Generic Commands do not require detachment as they are not tied with an event, and are Execucuted either via Execute() or CommandManager.TriggerEvent()
        /// </summary>
        /// <param name="agent"></param>
        public virtual void Detach(IAgentInternal agent)
        {
            //TODO: Default implementation Log that using is pointless on generic command.
        }
        /// <summary>
        /// Used to override DisplayName, otherwise it is set programatically when creating a new Command.
        /// Only really used in CommandBuilder.
        /// </summary>
        /// <param name="displayName">Overriding vale.</param>
        /// <see cref="CommandBuilder"/>
        public void OverrideDisplayName(string displayName) => DisplayName = displayName;
        /// <summary>
        /// Sets a description for a Command. Description isn't really used, but can be set via CommandBuilder for internal programming purposes.
        /// </summary>
        /// <param name="description">Description to set.</param>
        public void SetDescription(string description) => Description = description;
    }
}
