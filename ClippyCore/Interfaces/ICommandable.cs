using ClippyCore.EventManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClippyCore.Interfaces
{
    /// <summary>
    /// Public facing interface for ActiveX Controls that require event handling.
    /// Used to generalize scriptable commands.
    /// Could work with non-Agent controls, but not tested.
    /// </summary>
    /// <see cref="Command"/>
    public interface ICommandable
    {
        void AddCommand(ICoreCommand command);
        void RemoveCommand(string commandName);
        void TriggerCommand(string commandName);
        void TriggerCommand(ICoreCommand command);
        void TriggerCommand(Action action);
        IEnumerable<ICoreCommand> GetCommands();
        IEnumerable<ICoreCommand> GetCommands(EventType eventType);
        void RemoveAllCommands();

        // Specific menu operations
        void AddToContextMenu(string name, string displayName);
        void RemoveFromContextMenu(string commandName);
        void ClearContextMenu();
    }
}
