//css_reference System.Reactive.Interfaces.dll
using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive;
using System.Reactive.Linq;
using TreeBeard;
using TreeBeard.Inputs;

/// <summary>
/// Read lines from file.
/// </summary>
/// <arg name="fileName" required="yes" example="C:\log.txt">Full path of log file</arg>
public class FileInput : AbstractInputWithPosition<long>, IDisposable
{
    private string _fileName;
    private FileSystemWatcher _watcher;

    public override IObservable<Event> Execute()
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

    public override void Dispose()
    {
        if (_watcher != null) _watcher.Dispose();
        base.Dispose();
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

    private IEnumerable<Event> SelectLines(EventPattern<FileSystemEventArgs> e)
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
                    dynamic ev = new Event(Type, Alias);
                    ev.Message = line;
                    yield return ev;
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