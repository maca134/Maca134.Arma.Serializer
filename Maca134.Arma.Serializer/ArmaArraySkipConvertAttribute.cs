using System;

namespace Maca134.Arma.Serializer
{
    /// <summary>
    /// An attribute to keep certain parts of an array as a string. Only for deserialization
    /// </summary>
    public class ArmaArraySkipConvertAttribute : Attribute
    {
    }
}
