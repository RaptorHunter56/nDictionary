﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace nDictionary
{
    internal partial class BaseDictonary<TKey> : IBaseDictonary<TKey>
    {
        #region Parameters
        public Dictionary<int, Type> Types = new Dictionary<int, Type>();
        public Dictionary<int, Dictionary<TKey, Generic>> Dictionarys = new Dictionary<int, Dictionary<TKey, Generic>>();
        public IEqualityComparer<TKey> Comparer => Dictionarys[0].Comparer;
        #endregion

        #region Constructors
        public BaseDictonary(params Type[] types) { types.ToList().ForEach(x => Types.Add(Types.Count, x)); }
        #endregion

        #region Methods
        public bool ReFactor()
        {
            try
            {
                Dictionarys = new Dictionary<int, Dictionary<TKey, Generic>>();
                Types.ToList().ForEach(x => Dictionarys.Add(x.Key, new Dictionary<TKey, Generic>()));
                return true;
            }
            catch (Exception ex) { return false; }
        }
        public bool ReFactor(int capacity)
        {
            try
            {
                Dictionarys = new Dictionary<int, Dictionary<TKey, Generic>>();
                Types.ToList().ForEach(x => Dictionarys.Add(x.Key, new Dictionary<TKey, Generic>(capacity)));
                return true;
            }
            catch (Exception ex) { return false; }
        }
        public bool ReFactor(IEqualityComparer<TKey> comparer)
        {
            try
            {
                Dictionarys = new Dictionary<int, Dictionary<TKey, Generic>>();
                Types.ToList().ForEach(x => Dictionarys.Add(x.Key, new Dictionary<TKey, Generic>(comparer)));
                return true;
            }
            catch (Exception ex) { return false; }
        }
        public bool ReFactor(int capacity, IEqualityComparer<TKey> comparer)
        {
            try
            {
                Dictionarys = new Dictionary<int, Dictionary<TKey, Generic>>();
                Types.ToList().ForEach(x => Dictionarys.Add(x.Key, new Dictionary<TKey, Generic>(capacity, comparer)));
                return true;
            }
            catch (Exception ex) { return false; }
        }

        internal Generic[] GetnDictionary(TKey key)
        {
            List<Generic> temp = new List<Generic>();
            foreach (var item in Dictionarys)
            {
                temp.Add(item.Value[key]);
            }
            return temp.ToArray();
            //Dictionarys.ToList().Select(x => x.Value.Where(y => !EqualityComparer<TKey>.Default.Equals(y.Key, key)).FirstOrDefault().Value).ToArray();
        }

        internal void Add(TKey key, dynamic[] vs)
        {
            var list = vs.ToList();
            list.ForEach(x => Dictionarys[list.IndexOf(x)].Add(key, new Generic(x)));
        }
        internal void Clear()
        {
            foreach (var item in Dictionarys) item.Value.Clear();
        }
        #endregion
    }
}
