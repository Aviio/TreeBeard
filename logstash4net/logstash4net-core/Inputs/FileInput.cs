using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive;
using System.Reactive.Linq;
using logstash4net.Events;

namespace logstash4net.Inputs
{
    public class FileInput : IInput
    {
        private readonly string _fileName;
        private readonly string _timeStampRegEx;
        private readonly FileSystemWatcher _watcher;
        private long _position;

        public FileInput(string fullFileName)
        {
            _fileName = fullFileName;

            string directory = Path.GetDirectoryName(fullFileName) ?? string.Empty;
            string fileName = Path.GetFileName(fullFileName) ?? string.Empty;
            _watcher = new FileSystemWatcher(directory, fileName);
            _watcher.NotifyFilter = NotifyFilters.Size;
            _watcher.EnableRaisingEvents = true;

            _position = GetEndPosition();
        }

        public FileInput(string fullFileName, string timeStampRegEx)
            : this(fullFileName)
        {
            _timeStampRegEx = timeStampRegEx;
        }

        public IDisposable Subscribe(IObserver<IEvent> observer)
        {
            return Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(action => { _watcher.Changed += action; }, action => { _watcher.Changed -= action; })
                .Throttle(TimeSpan.FromSeconds(1))      
                .SelectMany(SelectLines)
                .Subscribe(observer);
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
                        yield return new TextEvent(line, _timeStampRegEx);
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
}
