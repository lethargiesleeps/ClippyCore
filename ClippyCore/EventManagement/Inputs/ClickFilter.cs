using System;
using System.Collections.Generic;
using System.Text;

namespace ClippyCore.EventManagement.Inputs
{
    /// <summary>
    /// Filter for click events. Prevents a Command's event from firing unless it matches the parameters set in this filter.
    /// </summary>
    public class ClickFilter
    {
        public MouseButton MouseButton { get; set; }
        public ModKeys ModifierKeys { get; set; }

        /// <summary>
        /// Base default constructor.
        /// </summary>
        public ClickFilter() { }

        /// <summary>
        /// Constructor with filter parameters set.
        /// </summary>
        /// <param name="mouseButton">Mouse button to filter.</param>
        /// <param name="modifierKeys">Modifier key (Shift, Ctl, Alt) to filter.</param>
        public ClickFilter(MouseButton mouseButton, ModKeys modifierKeys = ModKeys.None)
        {
            MouseButton = mouseButton;
            ModifierKeys = modifierKeys;
        }

        /// <summary>
        /// A default click. Any button, no/any mod keys.
        /// </summary>
        public static ClickFilter AnyClick => new ClickFilter(MouseButton.AnyButton, ModKeys.AnyModifier);
    }
}
