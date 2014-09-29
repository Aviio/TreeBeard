﻿using System;
using System.Windows.Forms;
using TreeBeard.Interfaces;

namespace TreeBeard.Gui.Views
{
    public partial class InputView : UserControl
    {
        IDisposable _subscription;
        IInput _input;

        public InputView()
        {
            InitializeComponent();

            this.Disposed += InputView_Disposed;
        }

        private void InputView_Disposed(object sender, EventArgs e)
        {
            OnDisposed();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            uclConsole.Clear();

            _input = uclInput.GetInput();
            if (_input != null)
            {
                Console.WriteLine("Starting...");
                Subscribe(_input.Execute(), OutputToConsole);
                Console.WriteLine("Started");
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Stopping...");
            OnDisposed();
            Console.WriteLine("Stopped");
        }

        private void Subscribe(IObservable<Event> source, Action<Event> handler)
        {
            _subscription = source.Subscribe(handler);
        }

        private void OutputToConsole(Event e)
        {
            Console.WriteLine(e.AsString());
        }

        private void OnDisposed()
        {
            if (_subscription != null) _subscription.Dispose();
            if (_input != null) _input.Dispose();
        }

        private void gbxMain_Resize(object sender, EventArgs e)
        {
            int buttonWidth = (Width - 18) / 2;
            btnStart.Left = 6;
            btnStart.Width = buttonWidth;
            btnStop.Left = btnStart.Right + 6;
            btnStop.Width = buttonWidth;
        }
    }
}
