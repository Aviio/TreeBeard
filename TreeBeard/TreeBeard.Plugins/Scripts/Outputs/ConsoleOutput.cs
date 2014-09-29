using System;
using TreeBeard;
using TreeBeard.Outputs;

public class ConsoleOutput : AbstractOutput
{
    public override void Execute(Event value)
    {
        Console.WriteLine(value.AsString());
    }

    public override void Initialize(params string[] args)
    {
    }
}