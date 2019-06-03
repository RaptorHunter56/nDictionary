using nDictionary;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

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

        
        [TestMethod]
        public void nDictionary_IndexersTest1()
        {
            try
            {
                var Test1 = new nDictionary<int, string>();
                Test1.Add(0, "Help");
                var Test2 = Test1[0];
                Assert.AreEqual(Test2.Key, new IDictionary<int>.nKeyValuePair(0, new Generic[] { new Generic("Help") }).Key);
                Assert.AreEqual(Test2.Value.Length, new IDictionary<int>.nKeyValuePair(0, new Generic[] { new Generic("Help") }).Value.Length);
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
                var Test2 = Test1[0];
                Assert.AreEqual(Test2.Key, new IDictionary<int>.nKeyValuePair(0, new Generic[] { new Generic("Help"), new Generic("Me") }).Key);
                Assert.AreEqual(Test2.Value.Length, new IDictionary<int>.nKeyValuePair(0, new Generic[] { new Generic("Help"), new Generic("Me") }).Value.Length);
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

        [TestMethod]
        public void nDictionary_ContainsKeyTest1()
        {
            try
            {
                var Test1 = new nDictionary<int, string>();
                Test1.Add(0, "Help");
                var Test2 = Test1.ContainsKey(0);
                Assert.AreEqual(Test2, true);
                Test2 = Test1.ContainsKey(1);
                Assert.AreEqual(Test2, false);
                return;
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }
        [TestMethod]
        public void nDictionary_ContainsKeyTest2()
        {
            try
            {
                var Test1 = new nDictionary<int, string, string>();
                Test1.Add(0, "Help", "Me");
                var Test2 = Test1.ContainsKey(0);
                Assert.AreEqual(Test2, true);
                Test2 = Test1.ContainsKey(1);
                Assert.AreEqual(Test2, false);
                return;
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }

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
    [TestClass]
    public class ContainsValueTest
    {

        [TestMethod]
        public void nDictionary_ContainsValueTest1()
        {
            try
            {
                var Test1 = new nDictionary<int, string>();
                Test1.Add(0, "Help");
                var Test2 = Test1.ContainsValue("Help");
                Assert.AreEqual(Test2, true);
                Test2 = Test1.ContainsValue("No");
                Assert.AreEqual(Test2, false);
                Test2 = Test1.ContainsValue(0);
                Assert.AreEqual(Test2, false);
                return;
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }

        [TestMethod]
        public void nDictionary_ContainsValueTest2()
        {
            try
            {
                var Test1 = new nDictionary<int, string>();
                Test1.Add(0, "Help");
                var Test2 = Test1.ContainsValue("Help", 1);
                Assert.AreEqual(Test2, true);
                Test2 = Test1.ContainsValue("Help", 2);
                Assert.AreEqual(Test2, false);
                Test2 = Test1.ContainsValue("No", 1);
                Assert.AreEqual(Test2, false);
                Test2 = Test1.ContainsValue(0);
                Assert.AreEqual(Test2, false);
                return;
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }

        [TestMethod]
        public void nDictionary_ContainsValueTest3()
        {
            try
            {
                var Test1 = new nDictionary<int, string>();
                Test1.Add(0, "Help");
                var Test2 = Test1.ContainsValue("Help", new int[1] { 1 });
                Assert.AreEqual(Test2, true);
                Test2 = Test1.ContainsValue("Help", new int[2] { 1, 2 });
                Assert.AreEqual(Test2, true);
                Test2 = Test1.ContainsValue("No", new int[1] { 1 });
                Assert.AreEqual(Test2, false);
                Test2 = Test1.ContainsValue(0);
                Assert.AreEqual(Test2, false);
                return;
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }

        [TestMethod]
        public void nDictionary_ContainsValueTest4()
        {
            try
            {
                var Test1 = new nDictionary<int, string, string>();
                Test1.Add(0, "Help", "Me");
                var Test2 = Test1.ContainsValue("Me");
                Assert.AreEqual(Test2, true);
                Test2 = Test1.ContainsValue("No");
                Assert.AreEqual(Test2, false);
                Test2 = Test1.ContainsValue(0);
                Assert.AreEqual(Test2, false);
                return;
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }
        [TestMethod]
        public void nDictionary_ContainsValueTest5()
        {
            try
            {
                var Test1 = new nDictionary<int, string, string>();
                Test1.Add(0, "Help", "Me");
                var Test2 = Test1.ContainsValue("Me", 2);
                Assert.AreEqual(Test2, true);
                Test2 = Test1.ContainsValue("Me", 1);
                Assert.AreEqual(Test2, false);
                Test2 = Test1.ContainsValue("No", 1);
                Assert.AreEqual(Test2, false);
                Test2 = Test1.ContainsValue(0);
                Assert.AreEqual(Test2, false);
                return;
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }
        [TestMethod]
        public void nDictionary_ContainsValueTest6()
        {
            try
            {
                var Test1 = new nDictionary<int, string, string>();
                Test1.Add(0, "Help", "Me");
                var Test2 = Test1.ContainsValue("Me", new int[1] { 2 });
                Assert.AreEqual(Test2, true);
                Test2 = Test1.ContainsValue("Help", new int[2] { 1, 2 });
                Assert.AreEqual(Test2, true);
                Test2 = Test1.ContainsValue("No", new int[1] { 1 });
                Assert.AreEqual(Test2, false);
                Test2 = Test1.ContainsValue(0);
                Assert.AreEqual(Test2, false);
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

        [TestMethod]
        public void GetEnumeratorTest1()
        {
            try
            {
                var Test1 = new nDictionary<int, string>();
                Test1.Add(0, "Help");
                Test1.Add(1, "Me");
                var Test2 = new List<string>();
                foreach (nDictionary<int, string>.nKeyValuePair entry in Test1)
                {
                    Test2.Add(entry.Value[0].Cast<string>());
                }
                Assert.AreEqual(Test2.Count, 2);
                return;
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }
        [TestMethod]
        public void GetEnumeratorTest2()
        {
            try
            {
                var Test1 = new nDictionary<int, string, string>();
                Test1.Add(0, "Help", "Help");
                Test1.Add(1, "Me", "Me");
                var Test2 = new List<string>();
                foreach (nDictionary<int, string, string>.nKeyValuePair entry in Test1)
                {
                    Test2.Add(entry.Value[0].Cast<string>());
                }
                Assert.AreEqual(Test2.Count, 2);
                return;
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }

        [TestClass]
        public class SerializableTest
        {
            //[TestMethod]
            //public void SerializeTest()
            //{
            //    var Test1 = new nDictionary<int, string>();
            //    Test1.Add(0, "Help");
            //    Test1.Add(1, "Me");
            //    Test1.Add(2, "Please");
            //    FileStream fs = new FileStream("DataFile.dat", FileMode.Create);
            //    BinaryFormatter formatter = new BinaryFormatter();
            //    try
            //    {
            //        formatter.Serialize(fs, Test1);
            //    }
            //    catch (SerializationException e)
            //    {
            //        Assert.Fail("Failed to serialize. Reason: " + e.Message);
            //    }
            //    finally
            //    {
            //        fs.Close();
            //    }
            //}

            //[TestMethod]
            //public void DeserializeTest()
            //{
            //    nDictionary<int, string> Test1 = null;
            //    FileStream fs = new FileStream("DataFile.dat", FileMode.Open);
            //    try
            //    {
            //        BinaryFormatter formatter = new BinaryFormatter();
            //        Test1 = (nDictionary<int, string>)formatter.Deserialize(fs);
            //    }
            //    catch (SerializationException e)
            //    {
            //        Assert.Fail("Failed to deserialize. Reason: " + e.Message);
            //    }
            //    finally
            //    {
            //        fs.Close();
            //    }
            //    foreach (nDictionary<int, string>.nKeyValuePair de in Test1)
            //    {
            //        Console.WriteLine("{0} lives at {1}.", de.Key, de.Value);
            //    }
            //}
        }
    }
}
