using System;
using TreeBeard.Events;
using TreeBeard.Interfaces;

namespace TreeBeard.Utils
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
