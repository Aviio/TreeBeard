//css_reference logstash4net.dll;
using System;
using logstash4net.Outputs;
using logstash4net.Events;

public class ConsoleOutput : IOutput
{
    public void Execute(IEvent value)
    {
        Console.WriteLine(value.AsString());
    }	
}