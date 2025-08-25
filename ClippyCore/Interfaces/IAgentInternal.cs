using DoubleAgent.AxControl;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClippyCore.Interfaces
{
    /// <summary>
    /// Internal interface for IAgent. Fields/methods that should not be accessed externally can be added here and implemented in Agent.
    /// </summary>
    /// <see cref="Agents.Agent"/>
    /// <see cref="IAgent"/>
    internal interface IAgentInternal : IAgent
    {
        AxControl Controller { get; }
        AxControl GetAxControl();
    }
}
