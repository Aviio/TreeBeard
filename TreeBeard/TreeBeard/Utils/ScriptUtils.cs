
using CSScriptLibrary;
using TreeBeard.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace TreeBeard.Utils
{
    internal static class ScriptUtils
    {
        private readonly static Dictionary<string, Evaluator> Evaluators = new Dictionary<string, Evaluator>();
        private readonly static Dictionary<Type, string> Locations = new Dictionary<Type, string>
            {
                { typeof(IInput), "Inputs" },
                { typeof(IFilter), "Filters" },
                { typeof(IOutput), "Outputs" }
            };

        public static IOutput ConstructOutput(string name, params string[] args)
        {
            return Construct<IOutput>(name, args);
        }

        public static IFilter ConstructFilter(string name, params string[] args)
        {
            return Construct<IFilter>(name, args);
        }

        public static IInput ConstructInput(string name, params string[] args)
        {
            return Construct<IInput>(name, args);
        }

        private static T Construct<T>(string name, params string[] args)
            where T : class, IInitializable
        {
            string fileName = string.Format(@".\Scripts\{0}\{1}.csx", Locations[typeof(T)], name);
            string code = File.ReadAllText(fileName);

            Evaluator evaluator = GetEvaluator(code, fileName);

            T result = evaluator.LoadCode<T>(code);

            result.Initialize(args);

            return result;
        }

        private static Evaluator GetEvaluator(string code, string fileName)
        {
            if (!Evaluators.ContainsKey(fileName))
            {
                Evaluator evaluator = CSScript.Evaluator.ReferenceAssembliesFromCode(code, Path.GetDirectoryName(fileName));
                Evaluators.Add(fileName, evaluator);
            }
            return Evaluators[fileName];
        }
    }
}
