﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive;
using System.Reactive.Linq;
using TreeBeard.Events;
using TreeBeard.Inputs;
using TreeBeard.Interfaces;

namespace TreeBeard.Scripts.Inputs
{
    public class FileInput : AbstractInput
    {
        private string _fileName;
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
                        yield return new Event(Type, Id, line);
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
