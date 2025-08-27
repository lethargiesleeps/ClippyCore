using System;
using System.Collections.Generic;
using System.Text;

namespace ClippyCore.EventManagement
{
    /// <summary>
    /// Enum of all possible types of events to listen for.
    /// 'NoEvent' represents a generic command, i.e a Command with no event attached to it.
    /// </summary>
    /// <see cref="Command"/>
    public enum EventType
    {
        NoEvent,
        Click,
        DoubleClick,
        ContextMenu,
        Hide,
        Show,
        Move,
        DragStart,
        DragEnd
    }
}
