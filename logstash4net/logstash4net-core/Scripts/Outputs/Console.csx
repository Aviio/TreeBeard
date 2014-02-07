using System;
using logstash4net.Interfaces;

public class Console : IOutput
{
    public void Execute(IEvent value)
    {
        Console.WriteLine(value.AsString());
    }

    public void Initialize(params string[] args)
    {
    }	
}