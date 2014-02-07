
using System;

namespace logstash4net.Events
{
    public interface IEvent
    {
        DateTime TimeStamp { get; }
        string AsString();
    }
}
