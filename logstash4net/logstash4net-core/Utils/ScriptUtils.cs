
using System;
using System.Collections.Generic;
using CSScriptLibrary;
using logstash4net.Filters;
using logstash4net.Inputs;
using logstash4net.Outputs;

namespace logstash4net.Utils
{
    public static class ScriptUtils
    {
        private readonly static Dictionary<Type, string> Locations = new Dictionary<Type, string>
            {
                { typeof(IInput), "Inputs" },
                { typeof(IFilter), "Filters" },
                { typeof(IOutput), "Outputs" }
            };

        public static IOutput ConstructOutput(string name, params object[] args)
        {
            return Construct<IOutput>(name, args);
        }

        public static T Construct<T>(string name, params object[] args)
            where T : class
        {
            T result = CSScript.Evaluator.LoadFile<T>(string.Format(@".\Scripts\{0}\{1}.cs", Locations[typeof(T)], name));

            // TODO inject args somehow!?!

            return result;
        }
    }
}
