using CSScriptLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using TreeBeard.Interfaces;

namespace TreeBeard.Extensions
{
    public static class StringExtensions
    {
        private readonly static Dictionary<Type, string> TypeDescriptions = new Dictionary<Type, string>
            {
                { typeof(IInput), "Input" },
                { typeof(IFilter), "Filter" },
                { typeof(IOutput), "Output" }
            };

        private readonly static Regex _csvSplit = new Regex("(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)", RegexOptions.Compiled);

        public static DateTime? GetTimeStamp(this string text, string regEx)
        {
            if (!string.IsNullOrEmpty(regEx))
            {
                Regex regex = new Regex(regEx);
                Match match = regex.Match(text);
                if (match.Success)
                {
                    DateTime timeStamp;
                    if (DateTime.TryParse(match.Groups[0].Value, out timeStamp))
                    {
                        return timeStamp;
                    }
                }
            }
            return null;
        }

        public static Func<TInput, TOutput> GetFunc<TInput, TOutput>(this string predicate)
        {
            if (string.IsNullOrWhiteSpace(predicate)) return null;

            LambdaExpression expression = DynamicExpression.ParseLambda(typeof(TInput), typeof(TOutput), predicate);

            Func<TInput, TOutput> func = x => (TOutput)expression.Compile().DynamicInvoke(x);

            return func;
        }

        public static string[] SplitCsv(this string text)
        {
            return _csvSplit.Matches(text)
                .Cast<Match>()
                .Select(m => Regex.Unescape(m.Value.TrimStart(',').Trim(' ', '"')))
                .ToArray();
        }

        public static IOutput ConstructOutput(this string type, params string[] args)
        {
            return Construct<IOutput>(type, args);
        }

        public static IFilter ConstructFilter(this string type, string predicate, params string[] args)
        {
            IFilter filter = Construct<IFilter>(type, args);
            filter.Predicate = predicate.GetFunc<Event, bool>();

            return filter;
        }

        public static IInput ConstructInput(this string type, string alias, params string[] args)
        {
            IInput input = Construct<IInput>(type, args);
            input.Type = type;
            input.Alias = alias;

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
