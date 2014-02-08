//css_reference System.Reactive.Interfaces.dll
using TreeBeard.Events;
using TreeBeard.Inputs;
using TreeBeard.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive;
using System.Reactive.Linq;

public class FileInput : AbstractInput
{
    private string _fileName;
    private string _timeStampRegEx;
    private FileSystemWatcher _watcher;
    private long _position;

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
        if (args.Length > 1)
        {
            _timeStampRegEx = args[1];
        }
    }

    private void Initialize()
    {
        string directory = Path.GetDirectoryName(_fileName) ?? string.Empty;
        string fileName = Path.GetFileName(_fileName) ?? string.Empty;
        _watcher = new FileSystemWatcher(directory, fileName);
        _watcher.NotifyFilter = NotifyFilters.Size;
        _watcher.EnableRaisingEvents = true;

        _position = GetEndPosition();
    }

    private IEnumerable<IEvent> SelectLines(EventPattern<FileSystemEventArgs> e)
    {
        var currentSize = new FileInfo(e.EventArgs.FullPath).Length;
        if (currentSize < _position)
        {
            _position = 0;
        }
        using (FileStream fs = new FileStream(_fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            using (StreamReader sr = new StreamReader(fs, true))
            {
                fs.Seek(_position, SeekOrigin.Begin);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    yield return new Event(Source, line, _timeStampRegEx);
                }
                _position = fs.Position;
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