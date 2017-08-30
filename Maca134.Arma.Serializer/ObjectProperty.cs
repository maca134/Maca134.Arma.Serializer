using System;

namespace Maca134.Arma.Serializer
{
    public struct ObjectProperty
    {
        public int Index { get; set; }
        public string PropertyName { get; set; }
        public string JsonPropertyName { get; set; }
        public Type Type { get; set; }
        public bool SkipConvert { get; set; }
    }
}