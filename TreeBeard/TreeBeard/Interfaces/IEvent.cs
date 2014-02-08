
using System;

namespace TreeBeard.Interfaces
{
    public interface IEvent
    {
        string Source { get; set; }
        string Message { get; set; }
        DateTime TimeStamp { get; set; }

        string AsString();
    }
}
