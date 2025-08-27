using ClippyCore.Interfaces;
using DoubleAgent.AxControl;
using DoubleAgent.Control;
using System;

namespace ClippyCore.EventManagement.Commands
{
    /// <summary>
    /// Command to be executed when agent moves.
    /// </summary>
    /// <see cref="Command"/>
    internal class MoveCommand : Command
    {
        public CtlMoveEventHandler Handler { get; private set; }
        public CtlMoveEvent LastEvent { get; private set; }

        private readonly MoveCauseType _causeType;
        private readonly short _x;
        private readonly short _y;
        private readonly bool _checkPosition;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Name of command.</param>
        /// <param name="action">Event it performs.</param>
        /// <param name="causeType">What caused the Move command. Default is user. Taken from DoubleAgent.Control.</param>
        /// <param name="atX">X coordinate to filter by (-1 for any position)</param>
        /// <param name="atY">Y coordinate to filter by (-1 for any position)</param>
        public MoveCommand(string name, Action action, MoveCauseType causeType = MoveCauseType.UserMoved, short atX = -1, short atY = -1) : base(name, action)
        {
            EventType = EventType.Move;
            _causeType = causeType;
            _x = atX;
            _y = atY;
            _checkPosition = atX >= 0 && atY >= 0;
        }

        /// <summary>
        /// Constructor with int coordinates for convenience.
        /// </summary>
        /// <param name="name">Name of command.</param>
        /// <param name="action">Event it performs.</param>
        /// <param name="causeType">What caused the Move command.</param>
        /// <param name="atX">X coordinate to filter by (-1 for any position)</param>
        /// <param name="atY">Y coordinate to filter by (-1 for any position)</param>
        public MoveCommand(string name, Action action, MoveCauseType causeType = MoveCauseType.UserMoved, int atX = -1, int atY = -1)
            : this(name, action, causeType,
                  atX < 0 ? (short)-1 : Convert.ToInt16(atX),
                  atY < 0 ? (short)-1 : Convert.ToInt16(atY))
        {
            // Conversion logic handled in the base constructor call
        }

        /// <summary>
        /// Attaches Event listener to Agent
        /// </summary>
        /// <param name="agent">Agent to perform Command.</param>
        public override void Attach(IAgentInternal agent)
        {
            Handler = new CtlMoveEventHandler(OnCommand);
            agent.Controller.CtlMove += Handler;
        }

        /// <summary>
        /// Detaches Event listener from Agent.
        /// </summary>
        /// <param name="agent">Agent to have Command removed from.</param>
        public override void Detach(IAgentInternal agent)
        {
            if (Handler != null)
            {
                agent.Controller.CtlMove -= Handler;
                Handler = null;
                LastEvent = null;
            }
        }

        /// <summary>
        /// Event Handler.
        /// </summary>
        /// <param name="sender">What triggered the event.</param>
        /// <param name="e">Event data</param>
        private void OnCommand(object sender, CtlMoveEvent e)
        {
            if (ShouldExecuteForEvent(e))
            {
                LastEvent = e;
                Execute();
            }
        }

        /// <summary>
        /// Determines if the command should execute based on the move event.
        /// </summary>
        /// <param name="e">The move event data</param>
        /// <returns>True if the command should execute</returns>
        private bool ShouldExecuteForEvent(CtlMoveEvent e)
        {
            if (_causeType != e.Cause)
                return false;

            if (_checkPosition)
            {
                const short tolerance = 5;
                bool xMatches = Math.Abs(e.X - _x) <= tolerance;
                bool yMatches = Math.Abs(e.Y - _y) <= tolerance;

                if (!xMatches || !yMatches)
                    return false;
            }

            return true;
        }
    }
}