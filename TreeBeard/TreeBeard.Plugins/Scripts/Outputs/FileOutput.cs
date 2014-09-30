﻿using System;
using System.IO;
using TreeBeard;
using TreeBeard.Outputs;

public class FileOutput : AbstractOutput
{
    private static Object Sync = new Object();

    private string _fileName;
    private string _format;

    public override void Execute(Event value)
    {
        string text = GetText(value);
        lock (Sync)
        {
            File.AppendAllText(_fileName, text + Environment.NewLine);
        }
    }

    public override void Initialize(params string[] args)
    {
        _fileName = args[0];
        _format = (args.Length > 1) ? args[1] : string.Empty;
    }

    private string GetText(Event value)
    {
        switch (_format)
        {
            case "json": return value.AsJson(true);
            case "xml": return value.AsXml(true);
            default: return value.AsString();
        }
    }
}

