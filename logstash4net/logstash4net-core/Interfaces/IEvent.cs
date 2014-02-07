
using System;

namespace logstash4net.Interfaces
{
    public interface IEvent
    {
        DateTime TimeStamp { get; }
        string AsString();
    }
}
