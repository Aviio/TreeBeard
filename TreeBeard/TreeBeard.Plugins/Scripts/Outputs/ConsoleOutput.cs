using System;
using TreeBeard;
using TreeBeard.Extensions;
using TreeBeard.Outputs;

public class ConsoleOutput : AbstractOutput
{
    public override void Execute(Event value)
    {
        this.Log().Info("Execute");
        Console.WriteLine(value.AsString());
    }

    public override void Initialize(params string[] args)
    {
        this.Log().Info("Initialize");
    }
}