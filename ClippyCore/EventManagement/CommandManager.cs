using ClippyCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClippyCore.EventManagement
{
    /// <summary>
    /// CommandManager used by an IAgent/IAgentInternal.
    /// Responsible for event attachment, and managing an Agent's Commands collection.
    /// </summary>
    /// <see cref="ICommandable"/>
    public class CommandManager : ICommandable
    {
        private readonly IAgentInternal _agent;
        private readonly Dictionary<string, ICoreCommand> _commands = new Dictionary<string, ICoreCommand>();

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="agent">Agent who's Commands need to be managed.</param>
        internal CommandManager(IAgentInternal agent)
        {
            _agent = agent;
        }

        /// <summary>
        /// Add and attach a Command to the agent.
        /// Passing a generic command will do nothing except store it in the command collection, to execute generic commands see TriggerCommand().
        /// </summary>
        /// <param name="command">Command to be added.</param>
        /// <exception cref="ArgumentException"></exception>
        public void AddCommand(ICoreCommand command)
        {
            if (_commands.ContainsKey(command.Name))
                throw new ArgumentException($"Command '{command.Name}' already exists");

            _commands[command.Name] = command;
            if (command is IInternalCommand internalCommand)
            {
                internalCommand.Attach(_agent);
            }
        }

        /// <summary>
        /// Remove and detach a Command from the Agent.
        /// Passing a generic command will detach no event, but this can still be used to remove it from the Command collection
        /// </summary>
        /// <param name="commandName">Command to be removed.</param>
        public void RemoveCommand(string commandName)
        {
            if (_commands.TryGetValue(commandName, out var command))
            {
                if (command is IInternalCommand internalCommand)
                {
                    internalCommand.Detach(_agent);
                }
                _commands.Remove(commandName);
            }
        }

        /// <summary>
        /// Fires a command by it's name if it has previously been added to the collection.
        /// </summary>
        /// <param name="commandName">Name of command to execute.</param>
        public void TriggerCommand(string commandName)
        {
            if (_commands.TryGetValue(commandName, out var command))
            {
                command.Execute();
            }
        }

        /// <summary>
        /// Fires the passed Command instance.
        /// Can be used with any CommandType. Useful when needed to pass same actions as an event without needing the event to be fired.
        /// </summary>
        /// <param name="command">Command who's action to fire.</param>
        public void TriggerCommand(ICoreCommand command)
        {
            command.Execute();
        }

        /// <summary>
        /// Pass a lambda directly using this function to fire the passed action.
        /// Same as command.Execute()
        /// </summary>
        /// <param name="action">Code to execute.</param>
        public void TriggerCommand(Action action)
        {
            action?.Invoke();
        }

        /// <summary>
        /// Get all Commands currently stored in memory (added via AddCommand)
        /// </summary>
        /// <returns>Enumerable collection of stored Commands.</returns>
        public IEnumerable<ICoreCommand> GetCommands() => _commands.Values;

        /// <summary>
        /// Get all commands of specified type stored in memory.
        /// </summary>
        /// <param name="eventType">Type of event commands should have.</param>
        /// <returns>Enumerable collection of stored Commands.</returns>
        public IEnumerable<ICoreCommand> GetCommands(EventType eventType) => _commands.Values.Where(c => c.EventType == eventType);

        /// <summary>
        /// Deletes and detaches all Commands in memory.
        /// </summary>
        public void RemoveAllCommands()
        {
            foreach(var command in _commands.Values)
            {
                if (command is IInternalCommand internalCommand)
                {
                    internalCommand.Detach(_agent);
                }
            }

            _commands.Clear();

        }

        /// <summary>
        /// This is already handled in the ContextMenuCommand. Will fix this.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="displayName"></param>
        public void AddToContextMenu(string name, string displayName)
        {
            _agent.Controller.Characters[_agent.AgentName].Commands.Add(name, displayName, null, true, true);
        }

        /// <summary>
        /// Removes the command from being accessible via the Context Menu, but command is still in memory and can be triggered outside of the menu.
        /// </summary>
        /// <param name="commandName">Command to remove.</param>
        public void RemoveFromContextMenu(string commandName)
        {
            try
            {
                _agent.Controller.Characters[_agent.AgentName].Commands.Remove(commandName);
            }
            catch
            {
                // Command might not exist
            }
        }

        /// <summary>
        /// Clears the entire context menu. Does not detach events or remove them from Commands collection, Commands are still accessible via TriggerCommand.
        /// </summary>
        public void ClearContextMenu()
        {
            var menuCommands = GetCommands(EventType.ContextMenu);
            foreach (var command in menuCommands)
            {
                RemoveFromContextMenu(command.Name);
            }
        }
    }
}
