using ClippyCore.EventManagement.Commands;
using ClippyCore.EventManagement.Inputs;
using ClippyCore.Interfaces;
using DoubleAgent.Control;
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
        private EventType _eventType = EventType.NoEvent;
        private VisibilityCauseType _visibilityCauseType;
        private ClickFilter _clickFilter = new ClickFilter();
        private MoveCauseType _moveCauseType = MoveCauseType.UserMoved;
        private int _moveX = -1;
        private int _moveY = -1;

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
        /// Type of Mouse button input required to run command.
        /// </summary>
        /// <param name="button">Mouse button input.</param>
        /// <see cref="MouseButton"/>
        /// <returns>Current instance of builder.</returns>
        public CommandBuilder WithMouseButton(MouseButton button) { _clickFilter.MouseButton = button; return this; }

        /// <summary>
        /// Type of modifier key input required to run command.
        /// </summary>
        /// <param name="modifiers">Modifier key input.</param>
        /// <see cref="ModKeys"/>
        /// <returns>Current instance of builder.</returns>
        public CommandBuilder WithModifierKeys(ModKeys modifiers) { _clickFilter.ModifierKeys = modifiers; return this; }

        /// <summary>
        /// Type of inputs required to run command.
        /// </summary>
        /// <param name="filter">Filter parameters for command's event to fire.</param>
        /// <see cref="ClickFilter"/>
        /// <returns>Current instance of builder.</returns>
        public CommandBuilder WithClickFilter(ClickFilter filter) { _clickFilter = filter; return this; }

        /// <summary>
        /// Specific Hide or Show event required to run command.
        /// </summary>
        /// <param name="visibilityCauseType">What caused the hide or show.</param>
        /// <returns>Current instance of builder.</returns>
        public CommandBuilder WithVisibilityCauseType(VisibilityCauseType visibilityCauseType) { _visibilityCauseType = visibilityCauseType; return this; }

        /// <summary>
        /// Specific parameters for Move, DragStart or DragEnd Commands.
        /// </summary>
        /// <param name="moveCauseType">What caused the Agent to be moved.</param>
        /// <param name="x">What X position is required to trigger Command.</param>
        /// <param name="y">What Y position is required to trigger Command.</param>
        /// <returns></returns>
        public CommandBuilder WithMovementParameters(MoveCauseType moveCauseType, int x = -1, int y = -1)
        {
            _moveCauseType = moveCauseType;
            _moveX = x;
            _moveY = y;
            return this;
        }
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
                case EventType.NoEvent: concreteCommand = new Command(_name, _action); break;
                case EventType.Click: concreteCommand = new ClickCommand(_name, _action, _clickFilter); break;
                case EventType.DoubleClick: concreteCommand = new DoubleClickCommand(_name, _action); break;
                case EventType.ContextMenu: concreteCommand = new ContextMenuCommand(_name, _action); break;
                case EventType.Hide: 
                    switch(_visibilityCauseType)
                    {
                        case VisibilityCauseType.NeverShown:
                        case VisibilityCauseType.UserShowed:
                        case VisibilityCauseType.ProgramShowed:
                        case VisibilityCauseType.OtherProgramShowed:
                            _visibilityCauseType = VisibilityCauseType.UserHid;
                            //TODO: Log invalid cause type
                            break;
                    }
                    concreteCommand = new HideCommand(_name, _action, _visibilityCauseType); break;
                case EventType.Show:
                    switch (_visibilityCauseType)
                    {
                        case VisibilityCauseType.NeverShown:
                        case VisibilityCauseType.UserHid:
                        case VisibilityCauseType.ProgramHid:
                        case VisibilityCauseType.OtherProgramHid:
                            _visibilityCauseType = VisibilityCauseType.UserShowed;
                            //TODO: Log invalid cause type
                            break;
                    }
                    concreteCommand = new ShowCommand(_name, _action, _visibilityCauseType); break;
                case EventType.Move:
                    concreteCommand = new MoveCommand(_name, _action, _moveCauseType, _moveX, _moveY); break;
                default: throw new InvalidOperationException("Please use correct EventType. Can be set with .WithType()");
            }

            if (!string.IsNullOrEmpty(_displayName)) concreteCommand.OverrideDisplayName(_displayName);
            if (!string.IsNullOrEmpty(_description)) concreteCommand.SetDescription(_description);
            return concreteCommand;
        }
    }
}
