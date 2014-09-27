
using BinaryRage;

namespace TreeBeard.Utils
{
    internal static class KeyStore
    {
        private static bool _isInitialized;
        private static string _location;

        internal static void SetLocation(string location)
        {
            _location = location;
            _isInitialized = !string.IsNullOrWhiteSpace(location);
        }

        internal static void Insert<T>(string key, T id)
        {
            if (_isInitialized) DB.Insert<T>(key, id, _location);
        }

        internal static T Get<T>(string key)
        {
            return (_isInitialized) ? DB.Get<T>(key, _location) : default(T);
        }

        internal static bool Exists(string key)
        {
            return (_isInitialized) ? DB.Exists(key, _location) : false;
        }
    }
}
