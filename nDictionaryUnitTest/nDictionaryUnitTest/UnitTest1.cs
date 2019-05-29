using nDictionary;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace nDictionaryUnitTest
{
    public static class StaticDictionary
    {
        public static Dictionary<int, string> ExpectedDictionary = new Dictionary<int, string>() { { 0, "Zero" }, { 1, "One" }, { 2, "Two" } };
        public static nDictionary<int, string> TestDictionary2 = new nDictionary<int, string>();//{ { 0, "Zero" }, { 1, "One" }, { 2, "Two" } };
        public static nDictionary<string, string> TestDictionary2s = new nDictionary<string, string>();//{ { "0", "Zero" }, { "1", "One" }, { "2", "Two" } };
        public static nDictionary<int, string, bool> TestDictionary3 = new nDictionary<int, string, bool>();//{ { 0, "Zero", true }, { 1, "One", false }, { 2, "Two", false } };
        public static nDictionary<string, string, bool> TestDictionary3s = new nDictionary<string, string, bool>();//{ { "0", "Zero", true }, { "1", "One", false }, { "2", "Two", false } };
    }
    [TestClass]
    public class ConstructorsTest
    {
        [TestMethod]
        public void nDictionary_ConstructorsTest1()
        {
            try
            {
                var Test1 = new nDictionary<int, string>();
                return;
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }
        [TestMethod]
        public void nDictionary_ConstructorsTest2()
        {
            try
            {
                var Test2 = new nDictionary<int, string>(3);
                return;
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }
        [TestMethod]
        public void nDictionary_ConstructorsTest3()
        {
            try
            {
                var Test3 = new nDictionary<int, string>(StaticDictionary.TestDictionary2);
                return;
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }
        [TestMethod]
        public void nDictionary_ConstructorsTest4()
        {
            try
            {
                var Test3 = new nDictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                return;
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }
        [TestMethod]
        public void nDictionary_ConstructorsTest5()
        {
            try
            {
                var Test3 = new nDictionary<string, string>(3, StringComparer.OrdinalIgnoreCase);
                return;
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }
        [TestMethod]
        public void nDictionary_ConstructorsTest6()
        {
            try
            {
                var Test3 = new nDictionary<string, string>(StaticDictionary.TestDictionary2s, StringComparer.OrdinalIgnoreCase);
                return;
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }

        [TestMethod]
        public void nDictionary_ConstructorsTest7()
        {
            try
            {
                var Test1 = new nDictionary<int, string, bool>();
                return;
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }
        [TestMethod]
        public void nDictionary_ConstructorsTest8()
        {
            try
            {
                var Test2 = new nDictionary<int, string, bool>(3);
                return;
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }
        [TestMethod]
        public void nDictionary_ConstructorsTest9()
        {
            try
            {
                var Test3 = new nDictionary<int, string, bool>(StaticDictionary.TestDictionary3);
                return;
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }
        [TestMethod]
        public void nDictionary_ConstructorsTest10()
        {
            try
            {
                var Test3 = new nDictionary<string, string, bool>(StringComparer.OrdinalIgnoreCase);
                return;
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }
        [TestMethod]
        public void nDictionary_ConstructorsTest11()
        {
            try
            {
                var Test3 = new nDictionary<string, string, bool>(3, StringComparer.OrdinalIgnoreCase);
                return;
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }
        [TestMethod]
        public void nDictionary_ConstructorsTest12()
        {
            try
            {
                var Test3 = new nDictionary<string, string, bool>(StaticDictionary.TestDictionary3s, StringComparer.OrdinalIgnoreCase);
                return;
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }

        [TestClass]
        public class GenericTest
        {
            [TestMethod]
            public void StringTest()
            {
                try
                {
                    var t = new Generic("Test");
                    Assert.AreSame(t.GetType(), "Test".GetType());
                }
                catch (Exception ex) { Assert.Fail(ex.Message); }
            }
            [TestMethod]
            public void IntTest()
            {
                try
                {
                    var t = new Generic(110);
                    Assert.AreSame(t.GetType(), 110.GetType());
                }
                catch (Exception ex) { Assert.Fail(ex.Message); }
            }
            [TestMethod]
            public void ObjectTest()
            {
                try
                {
                    var t = new Generic(StaticDictionary.ExpectedDictionary);
                    Assert.AreEqual(t.GetType(), StaticDictionary.ExpectedDictionary.GetType());
                }
                catch (Exception ex) { Assert.Fail(ex.Message); }
            }
        }

        [TestMethod]
        public void nDictionary_IndexersTest1()
        {
            try
            {
                var Test1 = new nDictionary<int, string>();
                Test1.Add(0, "Help");
                var Test2 = Test1[0];
                Assert.AreEqual(Test2, new IDictionary<int>.nKeyValuePair(0, new Generic[] { new Generic("Help") }));
                return;
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }
        [TestMethod]
        public void nDictionary_IndexersTest2()
        {
            try
            {
                var Test1 = new nDictionary<int, string, string>();
                Test1.Add(0, "Help", "Me");
                Assert.AreEqual(Test1[0], new nDictionary<int, string, string>.nKeyValuePair(0, new dynamic[] { "Help", "Me" }));
                return;
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }



        [TestMethod]
        public void nDictionary_CountTest1()
        {
            try
            {
                var Test1 = new nDictionary<int, string>();
                Test1.Add(0, "Help");
                var Test2 = Test1.Count;
                Assert.AreEqual(Test2, 1);
                return;
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }
        [TestMethod]
        public void nDictionary_CountTest2()
        {
            try
            {
                var Test1 = new nDictionary<int, string, string>();
                Test1.Add(0, "Help", "Me");
                var Test2 = Test1.Count;
                Assert.AreEqual(Test2, 1);
                return;
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }
    }

    [TestClass]
    public class IBaseDictonaryTest
    {
        [TestClass]
        public class KeysTest
        {
            [TestMethod]
            public void KeysTest1()
            {
                try
                {
                    var Test1 = new nDictionary<int, string>();
                    Test1.Add(0, "Help");
                    Test1.Keys.CopyTo(new int[1], 0);
                    return;
                }
                catch (Exception ex) { Assert.Fail(ex.Message); }
            }
            [TestMethod]
            public void KeysTest2()
            {
                try
                {
                    var Test1 = new nDictionary<int, string>();
                    Test1.Add(0, "Help");
                    var Test2 = Test1.Keys.Count;
                    Assert.AreEqual(Test2, 1);
                }
                catch (Exception ex) { Assert.Fail(ex.Message); }
            }
            [TestMethod]
            public void KeysTest3()
            {
                try
                {
                    var Test1 = new nDictionary<int, string>();
                    Test1.Add(0, "Help");
                    var Test6 = Test1.Keys.ToString();
                    Assert.AreEqual(Test6.ToString(), "nDictionary.IBaseDictonary`1+nKeyCollection[System.Int32]");
                }
                catch (Exception ex) { Assert.Fail(ex.Message); }
            }

            [TestMethod]
            public void KeysTest4()
            {
                try
                {
                    var Test1 = new nDictionary<int, string, string>();
                    Test1.Add(0, "Help", "Me");
                    Test1.Keys.CopyTo(new int[1], 0);
                    return;
                }
                catch (Exception ex) { Assert.Fail(ex.Message); }
            }
            [TestMethod]
            public void KeysTest5()
            {
                try
                {
                    var Test1 = new nDictionary<int, string, string>();
                    Test1.Add(0, "Help", "Me");
                    var Test2 = Test1.Keys.Count;
                    Assert.AreEqual(Test2, 1);
                }
                catch (Exception ex) { Assert.Fail(ex.Message); }
            }
            [TestMethod]
            public void KeysTest6()
            {
                try
                {
                    var Test1 = new nDictionary<int, string, string>();
                    Test1.Add(0, "Help", "Me");
                    var Test6 = Test1.Keys.ToString();
                    Assert.AreEqual(Test6.ToString(), "nDictionary.IBaseDictonary`1+nKeyCollection[System.Int32]");
                }
                catch (Exception ex) { Assert.Fail(ex.Message); }
            }
        }

        [TestClass]
        public class ValuesTest
        {
            [TestMethod]
            public void ValuesTest1()
            {
                try
                {
                    var Test1 = new nDictionary<int, string>();
                    Test1.Add(0, "Help");
                    Test1.Values[0].CopyTo(new string[1], 0);
                    return;
                }
                catch (Exception ex) { Assert.Fail(ex.Message); }
            }
            [TestMethod]
            public void ValuesTest2()
            {
                try
                {
                    var Test1 = new nDictionary<int, string>();
                    Test1.Add(0, "Help");
                    var Test2 = Test1.Values[0].Count;
                    Assert.AreEqual(Test2, 1);
                }
                catch (Exception ex) { Assert.Fail(ex.Message); }
            }
            [TestMethod]
            public void ValuesTest3()
            {
                try
                {
                    var Test1 = new nDictionary<int, string>();
                    Test1.Add(0, "Help");
                    var Test6 = Test1.Values[0].ToString();
                    Assert.AreEqual(Test6.ToString(), "nDictionary.IBaseDictonary`1+nValueCollection[System.Int32]");
                }
                catch (Exception ex) { Assert.Fail(ex.Message); }
            }

            [TestMethod]
            public void ValuesTest4()
            {
                try
                {
                    var Test1 = new nDictionary<int, string, string>();
                    Test1.Add(0, "Help", "Me");
                    Test1.Values[1].CopyTo(new string[1], 0);
                    return;
                }
                catch (Exception ex) { Assert.Fail(ex.Message); }
            }
            [TestMethod]
            public void ValuesTest5()
            {
                try
                {
                    var Test1 = new nDictionary<int, string, string>();
                    Test1.Add(0, "Help", "Me");
                    var Test2 = Test1.Values[1].Count;
                    Assert.AreEqual(Test2, 1);
                }
                catch (Exception ex) { Assert.Fail(ex.Message); }
            }
            [TestMethod]
            public void ValuesTest6()
            {
                try
                {
                    var Test1 = new nDictionary<int, string, string>();
                    Test1.Add(0, "Help", "Me");
                    var Test6 = Test1.Values[1].ToString();
                    Assert.AreEqual(Test6.ToString(), "nDictionary.IBaseDictonary`1+nValueCollection[System.Int32]");
                }
                catch (Exception ex) { Assert.Fail(ex.Message); }
            }
        }

        [TestClass]
        public class ClearTest
        {
            [TestMethod]
            public void ClearTest1()
            {
                try
                {
                    var Test1 = new nDictionary<int, string>();
                    Test1.Add(0, "Help");
                    Test1.Clear();
                    var Test2 = Test1.Values[0].Count;
                    Assert.AreEqual(Test2, 0);
                    return;
                }
                catch (Exception ex) { Assert.Fail(ex.Message); }
            }
            [TestMethod]
            public void ClearTest2()
            {
                try
                {
                    var Test1 = new nDictionary<int, string, string>();
                    Test1.Add(0, "Help", "Me");
                    Test1.Clear();
                    var Test2 = Test1.Values[0].Count;
                    Assert.AreEqual(Test2, 0);
                    return;
                }
                catch (Exception ex) { Assert.Fail(ex.Message); }
            }
        }
    }
}
