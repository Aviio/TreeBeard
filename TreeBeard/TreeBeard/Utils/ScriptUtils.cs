
using CSScriptLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive;
using System.Reactive.Linq;
using System.Reflection;
using TreeBeard.Interfaces;

namespace TreeBeard.Utils
{
    internal static class ScriptUtils
    {
        private readonly static Dictionary<Type, string> TypeDescriptions = new Dictionary<Type, string>
            {
                { typeof(IInput), "Input" },
                { typeof(IFilter), "Filter" },
                { typeof(IOutput), "Output" }
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
            IInput input = Construct<IInput>(name.Split(':')[0], args);
            input.SetSource(name);

            return input;
        }

        private static T Construct<T>(string name, params string[] args)
            where T : class, IInitializable
        {
            string typeDesciption = TypeDescriptions[typeof(T)];

            string fileName = string.Format(@".\Scripts\{0}s\{1}.csx", typeDesciption, name);
            string typeName = name + typeDesciption;

            T result = ConstructFromScript<T>(fileName, typeName);

            result.Initialize(args);

            return result;
        }

        private static T ConstructFromScript<T>(string fileName, string typeName)
            where T : class
        {
            string code = File.ReadAllText(fileName);
            
            T result = CSScript.LoadCode(code).CreateObject(typeName).AlignToInterface<T>();

            return result;
        }

        
    }
}
