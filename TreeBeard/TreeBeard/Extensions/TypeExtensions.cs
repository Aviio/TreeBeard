using System;
using TreeBeard.Exceptions;

namespace TreeBeard.Extensions
{
    public static class TypeExtensions
    {
        public static T Construct<T>(this Type type, params object[] args)
            where T : class
        {
            T result = Activator.CreateInstance(type, args) as T;
            if (result == null)
            {
                throw new TypeConstructionException(type);
            }
            return result;
        }

        public static object Construct(this Type type, params object[] args)
        {
            object result = Activator.CreateInstance(type, args);
            if (result == null)
            {
                throw new TypeConstructionException(type);
            }
            return result;
        }
    }
}
