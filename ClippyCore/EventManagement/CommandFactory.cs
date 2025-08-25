using ClippyCore.EventManagement.Commands;
using ClippyCore.Interfaces;
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
        /// <returns>The Command itself.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static ICoreCommand CreateCommand(EventType eventType, string name, Action action)
        {
            switch(eventType)
            {
                case EventType.NoEvent:
                    return new Command(name, action);
                case EventType.DoubleClick:
                    return new DoubleClickCommand(name, action);
                case EventType.ContextMenu:
                    return new ContextMenuCommand(name, action);
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
        /// Creates a Command to be added to DoubleClick event.
        /// </summary>
        /// <param name="name">Name of the command.</param>
        /// <param name="action">Action to occur when Agent is double clicked</param>
        /// <returns>DoubleClickCommand Object.</returns>
        public static ICoreCommand CreateDoubleClickCommand(string name, Action action) => new DoubleClickCommand(name, action);
    }
}
