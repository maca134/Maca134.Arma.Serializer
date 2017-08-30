namespace Maca134.Arma.Serializer.Test
{
    public class TestClassNull
    {
        public static string ArmaArray { get; } = "[nil,nil,\"set\"]";

        public static TestClassNull GetTestObject()
        {
            return new TestClassNull()
            {
                VarA = null,
                VarB = null,
                VarC = "set",
            };
        }

        public string VarA { get; set; }

        public string VarB { get; set; }

        public string VarC { get; set; }
    }
}
