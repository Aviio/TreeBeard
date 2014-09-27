//css_reference System.Reactive.Interfaces.dll
using TreeBeard.Events;
using TreeBeard.Inputs;
using TreeBeard.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive;
using System.Reactive.Linq;

public class FileInput : AbstractInputWithPosition<long>
{
    private string _fileName;
    private FileSystemWatcher _watcher;

    public override IObservable<IEvent> Execute()
    {
        Initialize();

        return Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(action => { _watcher.Changed += action; }, action => { _watcher.Changed -= action; })
            .Throttle(TimeSpan.FromSeconds(1))
            .SelectMany(SelectLines);
    }

    public override void Initialize(params string[] args)
    {
        _fileName = args[0];
    }

    private void Initialize()
    {
        string directory = Path.GetDirectoryName(_fileName) ?? string.Empty;
        string fileName = Path.GetFileName(_fileName) ?? string.Empty;
        _watcher = new FileSystemWatcher(directory, fileName);
        _watcher.NotifyFilter = NotifyFilters.Size;
        _watcher.EnableRaisingEvents = true;

        InitPosition(GetEndPosition());
    }

    private IEnumerable<IEvent> SelectLines(EventPattern<FileSystemEventArgs> e)
    {
        var currentSize = new FileInfo(e.EventArgs.FullPath).Length;
        if (currentSize < GetPosition())
        {
            SetPosition(0);
        }
        using (FileStream fs = new FileStream(_fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            using (StreamReader sr = new StreamReader(fs, true))
            {
                fs.Seek(GetPosition(), SeekOrigin.Begin);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    yield return new Event(Type, Id, line);
                }
                SetPosition(fs.Position);
            }
        }
    }

    private long GetEndPosition()
    {
        using (FileStream fs = new FileStream(_fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            using (StreamReader sr = new StreamReader(fs, true))
            {
                sr.ReadToEnd();
                return fs.Position;
            }
        }
    }
}