# Maca134.Arma.Serializer - [Download](https://www.nuget.org/packages/Maca134.Arma.Serializer)
Convert C# data and ARMA arrays

```PM> Install-Package Maca134.Arma.Serializer```

```csharp
public class TestClass
{
    public string Var1 { get; set; }

    public string[] Var1A { get; set; }

    public int Var2 { get; set; }

    public float Var3 { get; set; }

    public bool Var4 { get; set; }

    public TestClassInner Var5 { get; set; }

    public List<string> Var1B { get; set; }
}

public class TestClassInner
{
    public string Var1 { get; set; }

    public int Var2 { get; set; }

    public float Var3 { get; set; }

    public bool Var4 { get; set; }
}

var testData = new TestClass
{
    Var1 = "he\"llo",
    Var1A = new[] {"1", "2", "3"},
    Var1B = new List<string> { "1", "2", "3" },
    Var2 = 1,
    Var3 = 1.2f,
    Var4 = false,
    Var5 = new TestClassInner
    {
        Var1 = "h\"ello",
        Var2 = 1,
        Var3 = 1.2f,
        Var4 = false,
    }
};

/* Returns: ["he""llo",["1","2","3"],1,1.2,false,["h""ello",1,1.2,false],["1","2","3"]] */
var str = ArmaArrayConvert.SerializeObject(testData);

/* Returns the reconstructed object */
var obj = ArmaArrayConvert.DeserializeObject<TestClass>(str);
```
