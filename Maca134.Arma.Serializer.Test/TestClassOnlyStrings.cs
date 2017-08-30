namespace Maca134.Arma.Serializer.Test
{
    public class TestClassOnlyStrings
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
        
        public string VarA { get; set; }
        
        public string VarB { get; set; }

        public string VarC { get; set; }

        public string VarD { get; set; }
    }
}