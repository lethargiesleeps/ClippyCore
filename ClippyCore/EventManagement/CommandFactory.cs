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
    /// Simple static class for building commands.
    /// </summary>
    public static class CommandFactory
    {
        //TODO: Error handling and logging

        /// <summary>
        /// Creates a new Command to be executed or registered.
        /// </summary>
        /// <param name="eventType">Kind of Command to create.</param>
        /// <param name="name">Name of Command.</param>
        /// <param name="action">What the Command does.</param>
        /// <param name="clickFilter">Run command only if it matches the click filter. Optional: Used with Click or DoubleClick commands.</param>
        /// <param name="visibilityCauseType">Cause of Agent showing or hiding. Optional: Used with Show or Hide Commands.</param>
        /// <param name="moveCauseType">Cause of Agent moving. Optional: Used with MoveCommands.</param>
        /// <param name="x">Cause of Agent showing or hiding. Optional: Used with Move/Drag Commands</param>
        /// <param name="visibilityCauseType">Cause of Agent showing or hiding. Optiona: Used with Move/Drag Commands.</param>
        /// <returns>The Command itself.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static ICoreCommand CreateCommand(EventType eventType, string name, Action action,
            ClickFilter clickFilter = null, VisibilityCauseType visibilityCauseType = VisibilityCauseType.NeverShown,
            MoveCauseType moveCauseType = MoveCauseType.UserMoved, int x = -1, int y = 1)
        {
            switch(eventType)
            {
                case EventType.NoEvent:
                    return new Command(name, action);
                case EventType.Click:
                    return new ClickCommand(name, action, clickFilter);
                case EventType.DoubleClick:
                    return new DoubleClickCommand(name, action, clickFilter);
                case EventType.ContextMenu:
                    return new ContextMenuCommand(name, action);
                case EventType.Hide:
                    return new HideCommand(name, action, visibilityCauseType);
                case EventType.Show:
                    return new ShowCommand(name, action, visibilityCauseType);
                case EventType.Move:
                    return new MoveCommand(name, action, moveCauseType, x, y);
                
                default:
                    throw new ArgumentException("EventType not supported");
            }
        }

        /// <summary>
        /// Creates a generic command, who's action is not tied to a specific UI Event. Can be executed at any point.
        /// </summary>
        /// <param name="name">Name of the command.</param>
        /// <param name="action">Action to occur.</param>
        /// <returns>Command object.</returns>
        public static ICoreCommand CreateCommand(string name, Action action) => new Command(name, action);

        /// <summary>
        /// Creates a Command to be added to the Agent's right-click menu.
        /// </summary>
        /// <param name="name">Name of the command.</param>
        /// <param name="action">Action to occur when option is selected from menu.</param>
        /// <returns>ContextMenuCommand Object.</returns>
        public static ICoreCommand CreateContextMenuCommand(string name, Action action) => new ContextMenuCommand(name, action);

        /// <summary>
        /// Creates a Command executed when click occurs on Agent.
        /// </summary>
        /// <param name="name">Name of the command.</param>
        /// <param name="action">Action to occur when Agent is double clicked</param>
        /// <param name="filter">Only execute command based on mouse/mod key action.</param>
        /// <see cref="ClickFilter"/>
        /// <returns>DoubleClickCommand Object.</returns>
        public static ICoreCommand CreateClickCommand(string name, Action action, ClickFilter filter = null) => new ClickCommand(name, action, filter);

        /// <summary>
        /// Creates a Command executed when double click occurs on Agent.
        /// </summary>
        /// <param name="name">Name of the command.</param>
        /// <param name="action">Action to occur when Agent is double clicked</param>
        /// <param name="filter">Only execute command based on mouse/mod key action.</param>
        /// <see cref="ClickFilter"/>
        /// <returns>DoubleClickCommand Object.</returns>
        public static ICoreCommand CreateDoubleClickCommand(string name, Action action, ClickFilter filter = null) => new DoubleClickCommand(name, action, filter);

        /// <summary>
        /// Creates a Command executed when Agent is hidden.
        /// </summary>
        /// <param name="name">Name of the command.</param>
        /// <param name="action">Action to occur when Agent is hiddendouble clicked</param>
        /// <param name="visibilityCauseType">Cause of Agent showing or hiding. Optional.</param>
        /// <returns>DoubleClickCommand Object.</returns>
        public static ICoreCommand CreateHideCommand(string name, Action action, VisibilityCauseType visibilityCauseType = VisibilityCauseType.UserHid) => new HideCommand(name, action, visibilityCauseType);

        /// <summary>
        /// Creates a Command executed when Agent is hidden.
        /// </summary>
        /// <param name="name">Name of the command.</param>
        /// <param name="action">Action to occur when Agent is hiddendouble clicked</param>
        /// <param name="visibilityCauseType">Cause of Agent showing or hiding. Optional.</param>
        /// <returns>DoubleClickCommand Object.</returns>
        public static ICoreCommand CreateShowCommand(string name, Action action, VisibilityCauseType visibilityCauseType = VisibilityCauseType.UserShowed) => new ShowCommand(name, action, visibilityCauseType);

        /// <summary>
        /// Creates a Command executed when agent moves.
        /// </summary>
        /// <param name="name">Name of the command.</param>
        /// <param name="action">Action to occur when agent moves</param>
        /// <param name="causeType">Type of movement that triggers the command</param>
        /// <param name="x">X coordinate to filter by (-1 for any position)</param>
        /// <param name="y">Y coordinate to filter by (-1 for any position)</param>
        /// <returns>MoveCommand Object.</returns>
        public static ICoreCommand CreateMoveCommand(string name, Action action,
            MoveCauseType causeType = MoveCauseType.UserMoved, int x = -1, int y = -1)
            => new MoveCommand(name, action, causeType, x, y);

        /// <summary>
        /// Creates a Command executed when agent moves to a specific position.
        /// </summary>
        /// <param name="name">Name of the command.</param>
        /// <param name="action">Action to occur when agent moves to position</param>
        /// <param name="x">X coordinate position</param>
        /// <param name="y">Y coordinate position</param>
        /// <param name="causeType">Type of movement that triggers the command</param>
        /// <returns>MoveCommand Object.</returns>
        public static ICoreCommand CreateMoveToCommand(string name, Action action,
            int x, int y, MoveCauseType causeType = MoveCauseType.UserMoved)
            => new MoveCommand(name, action, causeType, x, y);
    }
}
