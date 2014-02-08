using TreeBeard.ExtensionMethods;
using TreeBeard.Interfaces;
using System;
using System.Text.RegularExpressions;

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

        public Event(string source, string message, string timeStampRegEx)
            : this(source, message, message.GetTimeStamp(timeStampRegEx))
        {
        }

        public Event(string source, string message)
            : this(source, message, DateTime.Now)
        {         
        }

        public string Source { get; private set; }
        public string Message { get; private set; }
        public DateTime TimeStamp { get; private set; }

        public virtual string AsString()
        {
            return string.Format("[{0}] [{1}] {2}", TimeStamp, Source, Message);
        }
    }
}
