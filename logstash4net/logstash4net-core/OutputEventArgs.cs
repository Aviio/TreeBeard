using System;
using logstash4net.Events;
using logstash4net.Interfaces;

namespace logstash4net
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
