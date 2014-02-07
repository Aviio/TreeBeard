using System;
using logstash4net.Events;

namespace logstash4net
{
    public class OutputEventArgs : EventArgs
    {
        public IEvent Event { get; private set; }

        public OutputEventArgs(IEvent e)
        {
            Event = e;
        }
    }
}
