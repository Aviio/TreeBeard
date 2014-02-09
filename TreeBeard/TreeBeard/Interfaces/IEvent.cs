
using System;

namespace TreeBeard.Interfaces
{
    public interface IEvent
    {
        string Type { get; set; }
        string Id { get; set; }
        string Message { get; set; }
        DateTime TimeStamp { get; set; }

        string AsString();
    }
}
