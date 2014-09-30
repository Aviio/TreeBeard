using System;
using TreeBeard;
using TreeBeard.Extensions;
using TreeBeard.Filters;

public class RegExTimeStampFilter : AbstractFilter
{
    private string _regEx;
    private string _property;

    public override Event Execute(Event value)
    {
        DateTime? timeStamp = value.GetMember(_property).ToString().GetTimeStamp(_regEx);
        if (timeStamp != null)
        {
            value.EventTimeStamp = timeStamp.Value;
        }
        return value;
    }

    public override void Initialize(params string[] args)
    {
        _regEx = args[0];
        _property = args[1];
    }
}