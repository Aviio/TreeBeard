
using System;

namespace TreeBeard.Interfaces
{
    public interface IEvent
    {
        string Source { get; }
        string Message { get; }
        DateTime TimeStamp { get; }

        string AsString();
    }
}
