using System;
using System.Collections.Generic;
using System.Text;

namespace ClippyCore.EventManagement.Inputs
{
    [Flags]
    public enum MouseButton
    {
        None = 0,
        Left = 1, //&H0001
        Right = 2, //&H0002
        Middle = 4, //&H0004
        AnyButton = Left | Right | Middle
    }
}
