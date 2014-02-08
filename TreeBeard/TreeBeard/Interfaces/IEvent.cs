
using System;

namespace TreeBeard.Interfaces
{
    public interface IEvent
    {
        DateTime TimeStamp { get; }
        string AsString();
    }
}
