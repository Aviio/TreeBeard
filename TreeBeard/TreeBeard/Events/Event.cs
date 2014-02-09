using System;
using TreeBeard.Interfaces;

namespace TreeBeard.Events
{
    public class Event : IEvent
    {
        public Event(string type, string id, string message, DateTime timeStamp)
        {
            Type = type;
            Id = id;
            Message = message;
            TimeStamp = timeStamp;
        }

        public Event(string type, string id, string message)
            : this(type, id, message, DateTime.Now)
        {         
        }

        public string Type { get; set; }
        public string Id { get; set; }
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual string AsString()
        {
            string source = Type;
            if (!string.IsNullOrEmpty(Id)) source += ":" + Id;
            return string.Format("[{0}] [{1}] {2}", TimeStamp, source, Message);
        }
    }
}
