using System.Collections.Generic;

namespace Maca134.Arma.Serializer.Test
{
    public class TestClassNested
    {
        public static string ArmaArray { get; } = $"[{TestClassOnlyInts.ArmaArray},{TestClassOnlyStrings.ArmaArray},[{TestClassOnlyInts.ArmaArray},{TestClassOnlyInts.ArmaArray}],[{TestClassOnlyInts.ArmaArray},{TestClassOnlyInts.ArmaArray}]]";

        public static TestClassNested GetTestObject()
        {
            return new TestClassNested
            {
                VarA = TestClassOnlyInts.GetTestObject(),
                VarB = TestClassOnlyStrings.GetTestObject(),
                VarC = new List<TestClassOnlyInts>
                {
                    TestClassOnlyInts.GetTestObject(),
                    TestClassOnlyInts.GetTestObject()
                },
                VarD = new []
                {
                    TestClassOnlyInts.GetTestObject(),
                    TestClassOnlyInts.GetTestObject()
                }
            };
        }
        
        public TestClassOnlyInts VarA { get; set; }
        
        public TestClassOnlyStrings VarB { get; set; }
        
        public List<TestClassOnlyInts> VarC { get; set; }
        
        public TestClassOnlyInts[] VarD { get; set; }

    }
}
