using System;
using TreeBeard.Interfaces;

public class ConsoleOutput : IOutput
{
    public void Execute(IEvent value)
    {
        Console.WriteLine(value.AsString());
    }

    public void Initialize(params string[] args)
    {
    }	
}