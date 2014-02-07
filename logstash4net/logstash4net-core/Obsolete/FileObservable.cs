using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive;
using System.Reactive.Linq;

namespace logstash4net.Obsolete
{
    internal class FileObservable : IObservable<string>, IDisposable
    {
        private FileSystemWatcher _watcher;
        private FileStream _fs;
        private StreamReader _sr;
        private long _position;

        public FileObservable(string filePath, string fileName)
        {
            _watcher = new FileSystemWatcher(filePath, fileName);
            _watcher.NotifyFilter = NotifyFilters.Size;
            _watcher.EnableRaisingEvents = true;

            string fullPath = Path.Combine(filePath, fileName);
            _fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            _sr = new StreamReader(_fs, true);
            _sr.ReadToEnd();
            _position = _fs.Position;
        }

        public IDisposable Subscribe(IObserver<string> observer)
        {
            return Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(AddHandler, RemoveHandler)
                      .Throttle(TimeSpan.FromSeconds(1))
                      .SelectMany(SelectLines)
                      .Subscribe(observer);
        }

        private void AddHandler(FileSystemEventHandler action)
        {
            _watcher.Changed += action;
        }

        private void RemoveHandler(FileSystemEventHandler action)
        {
            _watcher.Changed -= action;
        }

        private List<string> SelectLines(EventPattern<FileSystemEventArgs> e)
        {
            var currentSize = new FileInfo(e.EventArgs.FullPath).Length;
            if (currentSize < _position)
            {
                _fs.Seek(0, SeekOrigin.Begin);
            }
            var lines = new List<string>();
            string line;
            while ((line = _sr.ReadLine()) != null)
            {
                lines.Add(line);
            }
            _position = _fs.Position;
            return lines;
        }

        public void Dispose()
        {
            if (_sr != null)
            {
                _sr.Dispose();
            }
            if (_fs != null)
            {
                _fs.Dispose();
            }
            if (_watcher != null)
            {
                _watcher.Dispose();
            }
        }
    }
}
