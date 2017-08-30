using System;
using System.Runtime.Serialization;

namespace Maca134.Arma.Serializer
{
    [Serializable]
    internal class ArmaJsonConverterException : Exception
    {
        public ArmaJsonConverterException()
        {
        }

        public ArmaJsonConverterException(string message) : base(message)
        {
        }

        public ArmaJsonConverterException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ArmaJsonConverterException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}