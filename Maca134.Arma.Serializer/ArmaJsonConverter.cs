using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Maca134.Arma.Serializer
{
    public class ArmaJsonConverter : JsonConverter
    {
        private static readonly Dictionary<Type, ObjectProperty[]> ObjectPropertiesCache = new Dictionary<Type, ObjectProperty[]>();

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            ParseToArma(JToken.FromObject(value), serializer, value.GetType()).WriteTo(writer);
        }

        private static JToken ParseToArma(JToken token, JsonSerializer serializer, Type type)
        {
            var jsonContract = serializer.ContractResolver.ResolveContract(type);
            var jsonObjectContract = jsonContract as JsonObjectContract;
            if (jsonObjectContract != null)
            {
                var array = new JArray();
                var i = 0;

                foreach (var v1 in token.Children())
                {
                    foreach (var v2 in v1.Children())
                    {
                        array.Add(ParseToArma(v2, serializer, jsonObjectContract.Properties[i++].PropertyType));
                    }
                }
                return array;
            }

            var jsonArrayContract = jsonContract as JsonArrayContract;
            if (jsonArrayContract != null)
            {
                var array = new JArray();
                foreach (var v1 in token.Children())
                {
                    array.Add(ParseToArma(v1, serializer, jsonArrayContract.CollectionItemType));
                }
                return array;
            }

            var jsonDictionaryContract = jsonContract as JsonDictionaryContract;
            if (jsonDictionaryContract != null)
            {
                var array = new JArray();
                foreach (var v1 in token.Children())
                {
                    foreach (var v2 in v1.Children())
                    {
                        array.Add(new JArray(
                            ParseToArma(((JProperty)v1).Name, serializer, jsonDictionaryContract.DictionaryKeyType),
                            ParseToArma(v2, serializer, jsonDictionaryContract.DictionaryValueType)
                           ));
                    }
                }
                return array;
            }
            return token;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                return ParseFromArma(JToken.ReadFrom(reader), objectType, serializer).ToObject(objectType);
            }
            catch (JsonReaderException ex)
            {
                throw new ArmaJsonConverterException(ex.Message, ex);
            }
        }

        private static JToken ParseFromArma(JToken token, Type objectType, JsonSerializer serializer)
        {
            var contract = serializer.ContractResolver.ResolveContract(objectType);
            switch (contract.GetType().FullName)
            {
                case "Newtonsoft.Json.Serialization.JsonObjectContract":
                    {
                        var obj = new JObject();
                        var properties = GetTypeProperties(objectType);
                        var i = 0;
                        foreach (var t in token)
                        {
                            if (i >= properties.Length)
                                break;
                            var property = properties[i++];
                            obj.Add(property.JsonPropertyName, !property.SkipConvert ? ParseFromArma(t, property.Type, serializer) : t.ToString(Formatting.None));
                        }
                        return obj;
                    }
                case "Newtonsoft.Json.Serialization.JsonDictionaryContract":
                    {
                        var obj = new JObject();
                        foreach (var t in token)
                        {
                            var arr = (JArray)t;
                            obj.Add(arr[0].ToObject<string>(), arr[1]);
                        }
                        return obj;
                    }
                case "Newtonsoft.Json.Serialization.JsonArrayContract":
                    {
                        var array = new JArray();
                        foreach (var child in token.Children())
                        {
                            array.Add(ParseFromArma(child, ((JsonArrayContract)contract).CollectionItemType, serializer));
                        }
                        return array;
                    }
                default:
                    {
                        return token;
                    }
            }
        }

        private static ObjectProperty[] GetTypeProperties(Type objectType)
        {
            if (ObjectPropertiesCache.ContainsKey(objectType))
                return ObjectPropertiesCache[objectType];
            var objectProperties = new List<ObjectProperty>();
            var i = 0;
            foreach (var property in objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var jsonPropertyAttribute = property.GetCustomAttributes(typeof(JsonPropertyAttribute), true).FirstOrDefault() as JsonPropertyAttribute;
                var skipConvertAttribute = property.GetCustomAttributes(typeof(ArmaArraySkipConvertAttribute), true).FirstOrDefault() as ArmaArraySkipConvertAttribute;
                objectProperties.Add(new ObjectProperty
                {
                    Index = i++,
                    JsonPropertyName = jsonPropertyAttribute?.PropertyName ?? property.Name,
                    PropertyName = property.Name,
                    Type = property.PropertyType,
                    SkipConvert = skipConvertAttribute != null
                });
            }
            ObjectPropertiesCache[objectType] = objectProperties.ToArray();
            return ObjectPropertiesCache[objectType];
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
