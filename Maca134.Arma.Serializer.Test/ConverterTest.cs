using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maca134.Arma.Serializer.Test
{
    [TestClass]
    public class ConverterTest
    {
        [TestMethod]
        public void TestClassOnlyStringsToArmaArray()
        {
            Assert.AreEqual(TestClassOnlyStrings.ArmaArray, Converter.SerializeObject(TestClassOnlyStrings.GetTestObject()));
        }

        [TestMethod]
        public void TestClassOnlyStringsToObject()
        {
            var obj = Converter.DeserializeObject<TestClassOnlyStrings>(TestClassOnlyStrings.ArmaArray);
            obj.ShouldBeEquivalentTo(TestClassOnlyStrings.GetTestObject());
        }

        [TestMethod]
        public void TestClassOnlyIntsToArmaArray()
        {
            Assert.AreEqual(TestClassOnlyInts.ArmaArray, Converter.SerializeObject(TestClassOnlyInts.GetTestObject()));
        }

        [TestMethod]
        public void TestClassOnlyIntsToObject()
        {
            var obj = Converter.DeserializeObject<TestClassOnlyInts>(TestClassOnlyInts.ArmaArray);
            obj.ShouldBeEquivalentTo(TestClassOnlyInts.GetTestObject());
        }

        [TestMethod]
        public void TestClassMixedToArmaArray()
        {
            Assert.AreEqual(TestClassMixed.ArmaArray, Converter.SerializeObject(TestClassMixed.GetTestObject()));
        }

        [TestMethod]
        public void TestClassMixedToObject()
        {
            var obj = Converter.DeserializeObject<TestClassMixed>(TestClassMixed.ArmaArray);
            obj.ShouldBeEquivalentTo(TestClassMixed.GetTestObject());
        }

        [TestMethod]
        public void TestClassNestedToArmaArray()
        {
            Assert.AreEqual(TestClassNested.ArmaArray, Converter.SerializeObject(TestClassNested.GetTestObject()));
        }

        [TestMethod]
        public void TestClassNestedToObject()
        {
            var obj = Converter.DeserializeObject<TestClassNested>(TestClassNested.ArmaArray);
            obj.ShouldBeEquivalentTo(TestClassNested.GetTestObject());
        }

        [TestMethod]
        public void TestClassNullToArmaArray()
        {
            Assert.AreEqual(TestClassNull.ArmaArray, Converter.SerializeObject(TestClassNull.GetTestObject()));
        }

        [TestMethod]
        public void TestClassNullToObject()
        {
            var obj = Converter.DeserializeObject<TestClassNull>(TestClassNull.ArmaArray);
            obj.ShouldBeEquivalentTo(TestClassNull.GetTestObject());
        }

        [TestMethod]
        public void PrimativesToArmaArray()
        {
            Assert.AreEqual("1", Converter.SerializeObject(1));
            Assert.AreEqual("1.23", Converter.SerializeObject(1.23f));
            Assert.AreEqual("\"hello\"\"world\"\"\"", Converter.SerializeObject("hello\"world\""));
            Assert.AreEqual("true", Converter.SerializeObject(true));
        }

        [TestMethod]
        public void PrimativesToObject()
        {
            Assert.AreEqual(1, Converter.DeserializeObject<int>("1"));
            Assert.AreEqual(1.23f, Converter.DeserializeObject<float>("1.23"));
            Assert.AreEqual("hello\"world\"", Converter.DeserializeObject<string>("\"hello\"\"world\"\"\""));
            Assert.AreEqual(true, Converter.DeserializeObject<bool>("true"));
        }

        [TestMethod]
        public void ArraysToArmaArray()
        {
            Assert.AreEqual("[1,2,3,4]", Converter.SerializeObject(new[] { 1, 2, 3, 4 }));
            Assert.AreEqual("[1,2,3,4]", Converter.SerializeObject(new List<int> { 1, 2, 3, 4 }));
            Assert.AreEqual("[\"A\",\"B\",\"C\"]", Converter.SerializeObject(new[] { "A", "B", "C" }));
        }

        [TestMethod]
        public void ArraysToObject()
        {
            var arr1 = Converter.DeserializeObject<int[]>("[1,2,3,4]");
            arr1.ShouldBeEquivalentTo(new[] { 1, 2, 3, 4 });
            var arr2 = Converter.DeserializeObject<List<int>>("[1,2,3,4]");
            arr2.ShouldBeEquivalentTo(new List<int> { 1, 2, 3, 4 });
            var arr3 = Converter.DeserializeObject<string[]>("[\"A\",\"B\",\"C\"]");
            arr3.ShouldBeEquivalentTo(new[] { "A", "B", "C" });
        }

        [TestMethod]
        public void TestWrongLengthArmaArrays()
        {
            var arr1 = Converter.DeserializeObject<TestClassOnlyInts>("[1]");
            arr1.ShouldBeEquivalentTo(new TestClassOnlyInts
            {
                VarA = 1
            });
            var arr2 = Converter.DeserializeObject<TestClassOnlyInts>("[1,2,3,4,5,6,7,8,9]");
            arr2.ShouldBeEquivalentTo(new TestClassOnlyInts
            {
                VarA = 1,
                VarB = 2,
                VarC = 3,
            });
        }

        [TestMethod]
        public void TestClassWithJsonPropertiesToArmaArray()
        {
            Assert.AreEqual(TestClassWithJsonProperties.ArmaArray, Converter.SerializeObject(TestClassWithJsonProperties.GetTestObject()));
        }

        [TestMethod]
        public void TestClassWithJsonPropertiesToObject()
        {
            var obj = Converter.DeserializeObject<TestClassWithJsonProperties>(TestClassWithJsonProperties.ArmaArray);
            obj.ShouldBeEquivalentTo(TestClassWithJsonProperties.GetTestObject());
        }

        [TestMethod]
        public void TestClassSkipConvertToObject()
        {
            var obj = Converter.DeserializeObject<TestClassSkipConvert>(TestClassSkipConvert.ArmaArray);
            obj.ShouldBeEquivalentTo(TestClassSkipConvert.GetTestObject());
        }

        [TestMethod]
        public void TestDictionaryToArmaArray()
        {
            Assert.AreEqual("[[\"1\",2],[\"3\",4],[\"5\",6]]", Converter.SerializeObject(new Dictionary<int, int>
            {
                {1, 2},
                {3, 4},
                {5, 6}
            }));
        }

        [TestMethod]
        public void TestDictionaryToObject()
        {
            var obj = Converter.DeserializeObject<Dictionary<int, int>> ("[[\"1\",2],[\"3\",4],[\"5\",6]]");
            obj.ShouldBeEquivalentTo(new Dictionary<int, int>
            {
                {1, 2},
                {3, 4},
                {5, 6}
            });
        }
    }
}
