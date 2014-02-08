using TreeBeard.Exceptions;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TreeBeard.Utils
{
    internal static class ReflectionUtils
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

        public static object Construct(Type type, params object[] args)
        {
            object result = Activator.CreateInstance(type, args);
            if (result == null)
            {
                throw new TypeConstructionException(type);
            }
            return result;
        }

        //public static void LoadReferencedAssemblies()
        //{
        //    var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
        //    var loadedPaths = loadedAssemblies.Select(a => a.Location).ToArray();

        //    var referencedPaths = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");
        //    var toLoad = referencedPaths.Where(r => !loadedPaths.Contains(r, StringComparer.InvariantCultureIgnoreCase)).ToList();
        //    toLoad.ForEach(path => loadedAssemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(path))));
        //}
    }
}
