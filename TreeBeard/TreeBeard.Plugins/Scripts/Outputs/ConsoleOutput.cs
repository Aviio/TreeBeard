using System;
using TreeBeard;
using TreeBeard.Extensions;
using TreeBeard.Outputs;

/// <summary>
/// Writes events to Console. Format is: "[TimeStamp] [Type(:Id)] {0}" where {0} is all dynamic properties converted to JSON.
/// </summary>
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