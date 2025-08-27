using ClippyCore.EventManagement.Inputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClippyCore.Helpers
{

    /// <summary>
    /// Helper class for helping with Command/Event data.
    /// </summary>
    internal static class EventHelper
    {
        /// <summary>
        /// Returns flag based on event button.
        /// </summary>
        /// <param name="buttonValue">Bit representing which mouse button was pressed to fire event.</param>
        /// <returns>MouseButton flag.</returns>
        /// <see cref="MouseButton"/>
        internal static MouseButton GetMousePress(short buttonValue)
        {
            switch (buttonValue)
            {
                case 1: return MouseButton.Left;
                case 2: return MouseButton.Right;
                case 4: return MouseButton.Middle;
                default: return MouseButton.None;
            }
        }

        /// <summary>
        /// Returns flag based on event button.
        /// </summary>
        /// <param name="keyValue">Bit representing which mouse button was pressed to fire event.</param>
        /// <returns>MouseButton flag.</returns>
        /// <see cref="MouseButton"/>
        internal static ModKeys GetModifierKeyPress(short keyValue)
        {
            ModKeys modifiers = ModKeys.None;

            if ((keyValue & 1) != 0) modifiers |= ModKeys.Shift;     // Bit 0: Shift
            if ((keyValue & 2) != 0) modifiers |= ModKeys.Control;   // Bit 1: Control  
            if ((keyValue & 4) != 0) modifiers |= ModKeys.Alt;       // Bit 2: Alt

            return modifiers;
        }
    }
}
