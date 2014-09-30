﻿using System;
using TreeBeard.Extensions;
using TreeBeard.Interfaces;

namespace TreeBeard.Inputs
{
    public class ConfigurationInput : AbstractInput
    {
        private IInput _input;

        public override string Type
        {
            get { return (_input != null) ? _input.Type : string.Empty; }
            set { throw new NotImplementedException(); }
        }

        public override string Alias
        {
            get { return (_input != null) ? _input.Alias : string.Empty; }
            set { throw new NotImplementedException(); } 
        }

        public override IObservable<Event> Execute()
        {
            return _input.Execute();
        }

        public override void Initialize(params string[] args)
        {
            _input = args[0].ConstructInput(args[1], args.SubArray(2));
        }

        public override void Dispose()
        {
            if (_input != null) _input.Dispose();
            base.Dispose();
        }
    }
}
