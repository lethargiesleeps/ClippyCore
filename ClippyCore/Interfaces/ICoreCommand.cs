using ClippyCore.Agents;
using ClippyCore.EventManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ClippyCore.Interfaces
{
    /// <summary>
    /// Public facing interface for a Command. All properties here can be accessed externally.
    /// </summary>
    /// <see cref="Command"/>
    public interface ICoreCommand
    {
        string Name { get; }
        string DisplayName { get; }
        string Description { get; }
        int TimesFired { get; }
        EventType EventType { get; }
        void Execute();

    }
}
