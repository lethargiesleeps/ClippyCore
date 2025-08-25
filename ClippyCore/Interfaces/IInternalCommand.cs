using System;
using System.Collections.Generic;
using System.Text;

namespace ClippyCore.Interfaces
{
    /// <summary>
    /// Internal interface for Command. Hides specific methods from being accessed externally while still exposing required members.
    /// </summary>
    internal interface IInternalCommand : ICoreCommand
    {
        void Attach(IAgentInternal agent);
        void Detach(IAgentInternal agent);
        void OverrideDisplayName(string displayName);
        void SetDescription(string description);
    }
}
