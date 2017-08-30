namespace Maca134.Arma.Serializer.Test
{
    public class TestClassOnlyInts
    {
        public static string ArmaArray { get; } = "[1,2,3]";

        public static TestClassOnlyInts GetTestObject()
        {
            return new TestClassOnlyInts()
            {
                VarA = 1,
                VarB = 2,
                VarC = 3,
            };
        }
        
        public int VarA { get; set; }

        public int VarB { get; set; }
        
        public int VarC { get; set; }
    }
}
