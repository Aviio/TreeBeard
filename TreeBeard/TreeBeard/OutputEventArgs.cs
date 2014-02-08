using System;
using TreeBeard.Events;
using TreeBeard.Interfaces;

namespace TreeBeard
{
    internal class OutputEventArgs : EventArgs
    {
        public IEvent Event { get; private set; }

        public OutputEventArgs(IEvent e)
        {
            Event = e;
        }
    }
}
