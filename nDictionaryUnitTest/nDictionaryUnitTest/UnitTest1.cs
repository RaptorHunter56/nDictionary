﻿using nDictionary;
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
    }
}
