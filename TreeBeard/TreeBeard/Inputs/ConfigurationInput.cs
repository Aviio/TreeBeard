using System;
using TreeBeard.Extensions;
using TreeBeard.Interfaces;
using TreeBeard.Utils;

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

        public override string Id
        {
            get { return (_input != null) ? _input.Id : string.Empty; }
            set { throw new NotImplementedException(); } 
        }

        public override IObservable<IEvent> Execute()
        {
            return _input.Execute();
        }

        public override void Initialize(params string[] args)
        {
            _input = ScriptUtils.ConstructInput(args[0], args[1], args.SubArray(2));
        }
    }
}
