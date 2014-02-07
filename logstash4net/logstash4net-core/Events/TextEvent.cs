using logstash4net.ExtensionMethods;
using logstash4net.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace logstash4net.Events
{
    public class TextEvent : IEvent
    {
        private readonly string _text;

        public TextEvent(string text, DateTime timeStamp)
        {
            _text = text;
            TimeStamp = timeStamp;
        }

        public TextEvent(string text, string timeStampRegEx)
            : this(text, text.GetTimeStamp(timeStampRegEx))
        {
        }

        public TextEvent(string text)
            : this(text, DateTime.Now)
        {         
        }

        public DateTime TimeStamp { get; private set; }

        public string AsString()
        {
            return string.Format("[{0}] {1}", TimeStamp, _text);
        }
    }
}
