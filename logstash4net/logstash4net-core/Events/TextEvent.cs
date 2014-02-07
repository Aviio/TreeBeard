using System;
using System.Text.RegularExpressions;

namespace logstash4net.Events
{
    public class TextEvent : IEvent
    {
        private readonly string _text;

        public TextEvent(string text, string timeStampRegEx)
        {
            _text = text;

            TimeStamp = GetTimeStamp(text, timeStampRegEx);
        }

        public TextEvent(string text)
            : this(text, string.Empty)
        {         
        }

        public DateTime TimeStamp { get; private set; }

        public string AsString()
        {
            return string.Format("[{0}] {1}", TimeStamp, _text);
        }

        private DateTime GetTimeStamp(string text, string timeStampRegEx)
        {  
            if (!string.IsNullOrEmpty(timeStampRegEx))
            {
                Regex regex = new Regex(timeStampRegEx);
                Match match = regex.Match(text);
                if (match.Success)
                {
                    DateTime timeStamp;
                    if (DateTime.TryParse(match.Groups[0].Value, out timeStamp))
                    {
                        return timeStamp;
                    }
                }
            }
            return DateTime.Now;
        }
    }
}
