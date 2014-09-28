
using System;

namespace TreeBeard.Utils
{
    internal static class Log
    {
        private static bool _isDebug = false;

        internal static bool IsDebug()
        {
            return _isDebug;
        }

        internal static void Information(string message, params object[] args)
        {
            if (_isDebug) Console.WriteLine(message, args);
        }

        internal static void Information(string name, string method, object value)
        {
            Information("[{0}] {1}({2})", name, method, value);
        }
    }
}
