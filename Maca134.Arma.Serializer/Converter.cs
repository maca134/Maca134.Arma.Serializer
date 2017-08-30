using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Maca134.Arma.Serializer
{
    public class Converter
    {
        /// <summary>
        /// Convert an object into an ARMA array.
        /// </summary>
        /// <param name="value">The object to serialize.</param>
        /// <returns>An ARMA array representation of the object.</returns>
        public static string SerializeObject(object value)
        {
            var json = JsonConvert.SerializeObject(value, new ArmaJsonConverter());
            json = json.Replace(@"\""", @"""""");
            var replaceNullPattern = new Regex("([\x5b,]?)null([\x5d,]+)");
            json = replaceNullPattern.Replace(json, "$1nil$2");
            return json;
        }

        /// <summary>
        /// Convert an ARMA array into an object.
        /// </summary>
        /// <typeparam name="T">The type of the object to deserialize to</typeparam>
        /// <param name="value">The ARMA array to deserialize</param>
        /// <returns>The deserialized object from the ARMA array.</returns>
        public static T DeserializeObject<T>(string value)
        {
            value = value.Replace(@"""""", @"\""");
            var replaceNullPattern = new Regex("([\x5b,]?)nil([\x5d,]+)");
            value = replaceNullPattern.Replace(value, "$1null$2");
            return JsonConvert.DeserializeObject<T>(value, new ArmaJsonConverter());
        }
    }
}
