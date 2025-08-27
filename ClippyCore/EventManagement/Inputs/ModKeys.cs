using System;
using System.Collections.Generic;
using System.Text;

namespace ClippyCore.EventManagement.Inputs
{
    [Flags]
    public enum ModKeys
    {
        None = 0,
        Shift = 1,      // &H0001
        Control = 2,    // &H0002
        Alt = 4,        // &H0004
        AnyModifier = Shift | Control | Alt
    }
}
