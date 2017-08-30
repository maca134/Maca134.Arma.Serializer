using Newtonsoft.Json;

namespace Maca134.Arma.Serializer.Test
{
    public class TestClassWithJsonProperties
    {
        public static string ArmaArray { get; } = "[\"A\",\"B\",\"C\",\"hello \"\"world\"\"\"]";

        public static TestClassOnlyStrings GetTestObject()
        {
            return new TestClassOnlyStrings()
            {
                VarA = "A",
                VarB = "B",
                VarC = "C",
                VarD = "hello \"world\"",
            };
        }

        [JsonProperty("varA")]
        public string VarA { get; set; }

        [JsonProperty("varB")]
        public string VarB { get; set; }

        [JsonProperty("varC")]
        public string VarC { get; set; }

        [JsonProperty("varD")]
        public string VarD { get; set; }
    }
}
