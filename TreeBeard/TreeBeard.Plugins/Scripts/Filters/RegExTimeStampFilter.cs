using System;
using TreeBeard;
using TreeBeard.Extensions;
using TreeBeard.Filters;

/// <summary>
/// Updates Event.TimeStamp from specified property on Event by using a regular expression.
/// </summary>
/// <arg name="regEx" required="yes" example="^[\d]{4}-[\d]{2}-[\d]{2} [\d]{2}:[\d]{2}:[\d]{2}">Regular expression used to capture TimeStamp from property.</arg>
/// <arg name="property" required="yes" example="Message">Name of property to execute regular expression against.</arg>
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