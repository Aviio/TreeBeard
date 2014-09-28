using System;
using TreeBeard.Extensions;
using TreeBeard.Filters;
using TreeBeard.Interfaces;

namespace TreeBeard.Scripts.Filters
{
    public class RegExTimeStampFilter : AbstractFilter
    {
        private string _regEx;

        public override IEvent Execute(IEvent value)
        {
            DateTime? timeStamp = value.Message.GetTimeStamp(_regEx);
            if (timeStamp != null)
            {
                value.TimeStamp = timeStamp.Value;
            }
            return value;
        }

        public override void Initialize(params string[] args)
        {
            _regEx = args[0];
        }
    }
}
