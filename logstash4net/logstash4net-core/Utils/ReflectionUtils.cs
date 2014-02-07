

using System;
using logstash4net.Exceptions;

namespace logstash4net.Utils
{
    public static class ReflectionUtils
    {
        public static T Construct<T>(params object[] args)
            where T : class
        {
            return Construct<T>(typeof (T), args);
        }

        public static T Construct<T>(Type type, params object[] args)
            where T : class
        {
            T result = Activator.CreateInstance(type, args) as T;
            if (result == null)
            {
                throw new TypeConstructionException(type);
            }
            return result;
        }
    }
}
