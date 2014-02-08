using System;
using TreeBeard.Interfaces;

namespace TreeBeard.Events
{
    public class Event : IEvent
    {
        public Event(string source, string message, DateTime timeStamp)
        {
            Source = source;
            Message = message;
            TimeStamp = timeStamp;
        }

        public Event(string source, string message)
            : this(source, message, DateTime.Now)
        {         
        }

        public string Source { get; set; }
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual string AsString()
        {
            return string.Format("[{0}] [{1}] {2}", TimeStamp, Source, Message);
        }
    }
}
