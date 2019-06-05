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
                Assert.AreEqual(Test2.Values.Length, new IDictionary<int>.nKeyValuePair(0, new Generic[] { new Generic("Help") }).Values.Length);
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
                Assert.AreEqual(Test2.Values.Length, new IDictionary<int>.nKeyValuePair(0, new Generic[] { new Generic("Help"), new Generic("Me") }).Values.Length);
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
                Assert.AreSame("Test".GetType(), t.GetType());
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }
        [TestMethod]
        public void IntTest()
        {
            try
            {
                var t = new Generic(110);
                Assert.AreSame(110.GetType(), t.GetType());
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }
        [TestMethod]
        public void ObjectTest()
        {
            try
            {
                var t = new Generic(StaticDictionary.ExpectedDictionary);
                Assert.AreEqual(StaticDictionary.ExpectedDictionary.GetType(), t.GetType());
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
                Assert.AreEqual(true, Test2);
                Test2 = Test1.ContainsValue("No");
                Assert.AreEqual(false, Test2);
                Test2 = Test1.ContainsValue(0);
                Assert.AreEqual(false, Test2);
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
                Assert.AreEqual(true, Test2);
                Test2 = Test1.ContainsValue("Help", 2);
                Assert.AreEqual(false, Test2);
                Test2 = Test1.ContainsValue("No", 1);
                Assert.AreEqual(false, Test2);
                Test2 = Test1.ContainsValue(0);
                Assert.AreEqual(false, Test2);
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
                Assert.AreEqual(true, Test2);
                Test2 = Test1.ContainsValue("Help", new int[2] { 1, 2 });
                Assert.AreEqual(true, Test2);
                Test2 = Test1.ContainsValue("No", new int[1] { 1 });
                Assert.AreEqual(false, Test2);
                Test2 = Test1.ContainsValue(0);
                Assert.AreEqual(false, Test2);
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
                Assert.AreEqual(true, Test2);
                Test2 = Test1.ContainsValue("No");
                Assert.AreEqual(false, Test2);
                Test2 = Test1.ContainsValue(0);
                Assert.AreEqual(false, Test2);
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
                Assert.AreEqual(true, Test2);
                Test2 = Test1.ContainsValue("Me", 1);
                Assert.AreEqual(false, Test2);
                Test2 = Test1.ContainsValue("No", 1);
                Assert.AreEqual(false, Test2);
                Test2 = Test1.ContainsValue(0);
                Assert.AreEqual(false, Test2);
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
                Assert.AreEqual(true, Test2);
                Test2 = Test1.ContainsValue("Help", new int[2] { 1, 2 });
                Assert.AreEqual(true, Test2);
                Test2 = Test1.ContainsValue("No", new int[1] { 1 });
                Assert.AreEqual(false, Test2);
                Test2 = Test1.ContainsValue(0);
                Assert.AreEqual(false, Test2);
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
                    Assert.AreEqual(1, Test2);
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
                    Assert.AreEqual("nDictionary.IBaseDictonary`1+nKeyCollection[System.Int32]", Test6.ToString());
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
                    Assert.AreEqual(1, Test2);
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
                    Assert.AreEqual("nDictionary.IBaseDictonary`1+nKeyCollection[System.Int32]", Test6.ToString());
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
                    Assert.AreEqual(1, Test2);
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
                    Assert.AreEqual("nDictionary.IBaseDictonary`1+nValueCollection[System.Int32]", Test6.ToString());
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
                    Assert.AreEqual(1, Test2);
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
                    Assert.AreEqual("nDictionary.IBaseDictonary`1+nValueCollection[System.Int32]", Test6.ToString());
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
                    Assert.AreEqual(0, Test2);
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
                    Assert.AreEqual(0, Test2);
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
                    Test2.Add(entry.Values[0].Cast<string>());
                }
                Assert.AreEqual(2, Test2.Count);
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
                    Test2.Add(entry.Values[0].Cast<string>());
                }
                Assert.AreEqual(2, Test2.Count);
                return;
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }

        [TestClass]
        public class SerializableTest
        {
            [TestMethod]
            public void SerializeTest1()
            {
                var Test1 = new nDictionary<int, string>();
                Test1.Add(0, "Help");
                Test1.Add(1, "Me");
                Test1.Add(2, "Please");
                string fileName = "SerializeTest1.myData";
                IFormatter formatter = new BinaryFormatter();
                try
                {
                    FileStream s = new FileStream(fileName, FileMode.Create);
                    formatter.Serialize(s, Test1);
                    s.Close();
                }
                catch (Exception e)
                {
                    Assert.Fail("Failed to serialize. Reason: " + e.Message);
                }
            }

            [TestMethod]
            public void DeserializeTest1()
            {
                var Test1 = new nDictionary<int, string>();
                Test1.Add(0, "Help");
                Test1.Add(1, "Me");
                Test1.Add(2, "Please");
                string fileName = "SerializeTest1.myData";
                IFormatter formatter = new BinaryFormatter();
                try
                {
                    FileStream s = new FileStream(fileName, FileMode.Open);
                    nDictionary<int, string> t = (nDictionary<int, string>)formatter.Deserialize(s);
                    Assert.AreEqual(3, t.Count);
                    s.Close();
                }
                catch (Exception e)
                {
                    Assert.Fail("Failed to serialize. Reason: " + e.Message);
                }
            }
            [TestMethod]
            public void SerializeTest2()
            {
                var Test1 = new nDictionary<int, string, string>();
                Test1.Add(0, "Help");
                Test1.Add(1, "Me");
                Test1.Add(2, "Please");
                string fileName = "SerializeTest2.myData";
                IFormatter formatter = new BinaryFormatter();
                try
                {
                    FileStream s = new FileStream(fileName, FileMode.Create);
                    formatter.Serialize(s, Test1);
                    s.Close();
                }
                catch (Exception e)
                {
                    Assert.Fail("Failed to serialize. Reason: " + e.Message);
                }
            }

            [TestMethod]
            public void DeserializeTes2t()
            {
                var Test1 = new nDictionary<int, string>();
                Test1.Add(0, "Help");
                Test1.Add(1, "Me");
                Test1.Add(2, "Please");
                string fileName = "SerializeTest2.myData";
                IFormatter formatter = new BinaryFormatter();
                try
                {
                    FileStream s = new FileStream(fileName, FileMode.Open);
                    nDictionary<int, string, string> t = (nDictionary<int, string, string>)formatter.Deserialize(s);
                    Assert.AreEqual(3, t.Count);
                    s.Close();
                }
                catch (Exception e)
                {
                    Assert.Fail("Failed to serialize. Reason: " + e.Message);
                }
            }
        }

        [TestClass]
        public class RemoveTest
        {
            [TestMethod]
            public void RemoveTest1()
            {
                var Test1 = new nDictionary<int, string>();
                Test1.Add(0, "Help");
                Test1.Add(1, "Me");
                Test1.Add(2, "Please");
                try
                {
                    bool test = Test1.Remove(0);
                    Assert.IsTrue(test);
                    Assert.AreEqual(2, Test1.Count);
                }
                catch (Exception ex) { Assert.Fail(ex.Message); }
            }
            [TestMethod]
            public void RemoveTest2()
            {
                var Test1 = new nDictionary<int, string>();
                Test1.Add(0, "Help");
                Test1.Add(1, "Me");
                Test1.Add(2, "Please");
                try
                {
                    bool test = Test1.Remove(10);
                    Assert.IsFalse(test);
                    Assert.AreEqual(3, Test1.Count);
                }
                catch (Exception ex) { Assert.Fail(ex.Message); }
            }

            [TestMethod]
            public void RemoveTest3()
            {
                var Test1 = new nDictionary<int, string, string>();
                Test1.Add(0, "Help", "Help");
                Test1.Add(1, "Me", "Me");
                Test1.Add(2, "Please", "Please");
                try
                {
                    bool test = Test1.Remove(0);
                    Assert.IsTrue(test);
                    Assert.AreEqual(2, Test1.Count);
                }
                catch (Exception ex) { Assert.Fail(ex.Message); }
            }
            [TestMethod]
            public void RemoveTest4()
            {
                var Test1 = new nDictionary<int, string, string>();
                Test1.Add(0, "Help", "Help");
                Test1.Add(1, "Me", "Me");
                Test1.Add(2, "Please", "Please");
                try
                {
                    bool test = Test1.Remove(10);
                    Assert.IsFalse(test);
                    Assert.AreEqual(3, Test1.Count);
                }
                catch (Exception ex) { Assert.Fail(ex.Message); }
            }
        }


        [TestClass]
        public class TryGetValueTest
        {
            [TestMethod]
            public void TryGetValueTest1()
            {
                var Test1 = new nDictionary<int, string>();
                Test1.Add(0, "Help");
                Test1.Add(1, "Me");
                Test1.Add(2, "Please");
                try
                {
                    nDictionary<int, string>.nKeyValuePair value;
                    bool test = Test1.TryGetValue(0, out value);
                    Assert.IsTrue(test);
                    string v = value.Values[0].Cast<string>();
                    Assert.AreEqual("Help", v);
                }
                catch (Exception ex) { Assert.Fail(ex.Message); }
            }
            [TestMethod]
            public void TryGetValueTest2()
            {
                var Test1 = new nDictionary<int, string>();
                Test1.Add(0, "Help");
                Test1.Add(1, "Me");
                Test1.Add(2, "Please");
                try
                {
                    nDictionary<int, string>.nKeyValuePair value;
                    bool test = Test1.TryGetValue(10, out value);
                    Assert.IsFalse(test);
                    //string v = value.Value[0].Cast<string>();
                    //Assert.AreNotEqual("Help", v);
                }
                catch (Exception ex) { Assert.Fail(ex.Message); }
            }

            [TestMethod]
            public void TryGetValueTest3()
            {
                var Test1 = new nDictionary<int, string, string>();
                Test1.Add(0, "Help", "Help");
                Test1.Add(1, "Me", "Me");
                Test1.Add(2, "Please", "Please");
                try
                {
                    nDictionary<int, string, string>.nKeyValuePair value;
                    bool test = Test1.TryGetValue(0, out value);
                    Assert.IsTrue(test);
                    string v = value.Values[0].Cast<string>();
                    Assert.AreEqual("Help", v);
                }
                catch (Exception ex) { Assert.Fail(ex.Message); }
            }
            [TestMethod]
            public void TryGetValueTest4()
            {
                var Test1 = new nDictionary<int, string, string>();
                Test1.Add(0, "Help", "Help");
                Test1.Add(1, "Me", "Me");
                Test1.Add(2, "Please", "Please");
                try
                {
                    nDictionary<int, string, string>.nKeyValuePair value;
                    bool test = Test1.TryGetValue(10, out value);
                    Assert.IsFalse(test);
                    //string v = value.Value[0].Cast<string>();
                    //Assert.AreNotEqual("Help", v);
                }
                catch (Exception ex) { Assert.Fail(ex.Message); }
            }
        }
    }
}
