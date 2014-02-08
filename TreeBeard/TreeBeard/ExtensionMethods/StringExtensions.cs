using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TreeBeard.ExtensionMethods
{
    public static class StringExtensions
    {
        public static DateTime GetTimeStamp(this string text, string regEx)
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
            return DateTime.Now;
        }
    }
}
