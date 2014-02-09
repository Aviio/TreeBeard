using System;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace TreeBeard.ExtensionMethods
{
    public static class StringExtensions
    {
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
    }
}
