using System.Collections.Generic;

namespace Maca134.Arma.Serializer.Test
{
    public class TestClassSkipConvert
    {
        public static string ArmaArray { get; } = "[\"1\",[[1,1],[2,2],[3,3]]]";

        public static TestClassSkipConvert GetTestObject()
        {
            return new TestClassSkipConvert()
            {
                VarA = "1",
                VarB = "[[1,1],[2,2],[3,3]]",
            };
        }

        public string VarA { get; set; }

        [ArmaArraySkipConvert]
        public string VarB { get; set; }
    }
}
