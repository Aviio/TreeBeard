
using BinaryRage;

namespace TreeBeard.Utils
{
    internal static class KeyStore
    {
        private static string _location;

        internal static void SetLocation(string location)
        {
            _location = location;
        }

        internal static void Insert<T>(string key, T id)
        {
            DB.Insert<T>(key, id, _location);
        }

        internal static T Get<T>(string key)
        {
            return DB.Get<T>(key, _location);
        }

        internal static bool Exists(string key)
        {
            return DB.Exists(key, _location);
        }
    }
}
