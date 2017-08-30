using System.Collections.Generic;

namespace Maca134.Arma.Serializer.Test
{
    public class TestClassMixed
    {
        public static string ArmaArray { get; } = @"[""1"",2,3.2,4.5,[""a"",""b"",""c""],[1,2,3],[""a"",""b"",""c""],[[1,1],[2,2],[3,3]]]";

        public static TestClassMixed GetTestObject()
        {
            return new TestClassMixed()
            {
                VarA = "1",
                VarB = 2,
                VarC = 3.2f,
                VarD = 4.5M,
                VarE = new[] { "a", "b", "c" },
                VarF = new[] { 1, 2, 3 },
                VarG = new List<string> { "a", "b", "c" },
                VarH = new [,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                }
            };
        }
        
        public string VarA { get; set; }
        
        public int VarB { get; set; }
        
        public float VarC { get; set; }
        
        public decimal VarD { get; set; }
        
        public string[] VarE { get; set; }
        
        public int[] VarF { get; set; }
        
        public List<string> VarG { get; set; }
        
        public int[,] VarH { get; set; }
    }
}
