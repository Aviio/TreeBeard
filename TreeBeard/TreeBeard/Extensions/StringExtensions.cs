using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace TreeBeard.Extensions
{
    public static class StringExtensions
    {
        private static Regex _csvSplit = new Regex("(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)", RegexOptions.Compiled);

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

            LambdaExpression expression = System.Linq.Dynamic.DynamicExpression.ParseLambda(typeof(TInput), typeof(TOutput), predicate);

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
    }
}
