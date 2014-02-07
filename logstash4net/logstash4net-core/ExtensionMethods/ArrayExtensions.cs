using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logstash4net.ExtensionMethods
{
    public static class ArrayExtensions
    {
        public static T[] SubArray<T>(this T[] data, int index)
        {
            return data.SubArray(index, data.Length - index);
        }

        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}
