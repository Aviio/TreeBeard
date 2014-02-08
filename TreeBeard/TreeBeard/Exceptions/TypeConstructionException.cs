using System;


namespace TreeBeard.Exceptions
{
    public class TypeConstructionException : Exception
    {
        public TypeConstructionException(Type type)
            : base(GetMessage(type))
        {
        }

        public TypeConstructionException(Type type, Exception innerException)
            : base(GetMessage(type), innerException)
        {
        }

        private static string GetMessage(Type type)
        {
            return string.Format("Failed to construct input type: {0}", type.FullName);
        }
    }
}
