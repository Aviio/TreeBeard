using System;
using TreeBeard;
using TreeBeard.Interfaces;

public class ConsoleOutput : IOutput
{
    public void Execute(Event value)
    {
        Console.WriteLine(value.AsString());
    }

    public void Initialize(params string[] args)
    {
    }
}