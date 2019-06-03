﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace nDictionary
{
    //[Serializable]
    internal partial class BaseDictonary<TKey> : IBaseDictonary<TKey>//, ISerializable
    {
        #region Parameters
        public Dictionary<int, Type> Types = new Dictionary<int, Type>();
        public Dictionary<int, Dictionary<TKey, Generic>> Dictionarys = new Dictionary<int, Dictionary<TKey, Generic>>();
        public IEqualityComparer<TKey> Comparer => Dictionarys[0].Comparer;
        #endregion

        #region Constructors
        public BaseDictonary(params Type[] types) { types.ToList().ForEach(x => Types.Add(Types.Count, x)); }
        //protected BaseDictonary(SerializationInfo info, StreamingContext context)
        //{
        //    //List<IDictionary<TKey>.nKeyValuePair> temp = new List<IDictionary<TKey>.nKeyValuePair>();
        //    //foreach (var item in Dictionarys[0])
        //    //{
        //    //    List<Generic> temp2 = new List<Generic>(Dictionarys[0].Count);
        //    //    Dictionarys.ToList().ForEach(x => temp2.Add(x.Value[item.Key]));
        //    //    temp.Add(new IDictionary<TKey>.nKeyValuePair(item.Key, temp2.ToArray()));
        //    //}
        //    //info.AddValue("values", temp.ToArray(), typeof(IDictionary<TKey>.nKeyValuePair[]));

        //    var temp = (IDictionary<TKey>.nKeyValuePair[])info.GetValue("values", typeof(IDictionary<TKey>.nKeyValuePair[]));
        //    foreach (var item in temp)
        //    {

        //    }
        //}
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
                temp.Add(item.Value[key]);
            return temp.ToArray();
        }

        internal void Add(TKey key, dynamic[] vs)
        {
            var list = vs.ToList();
            var postion = -1;
            foreach (var x in list)
            {
                postion++;
                Dictionarys[postion].Add(key, new Generic(x));
            }
        }
        internal void Clear()
        {
            foreach (var item in Dictionarys) item.Value.Clear();
        }

        internal bool ContainsValue<T>(T value, int[] position)
        {
            bool temp = false;
            int temp2 = 1;
            foreach (var item in Dictionarys)
            {
                if (position.Contains(temp2))
                {
                    bool temp3 = item.Value.Values.ToList().Select(x => x.Equals(new Generic(value))).Where(x => x == true).Count() > 0;
                    if (temp3) temp = true;
                }
                temp2++;
            }
            return temp;
        }

        //public void GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //    List<IDictionary<TKey>.nKeyValuePair> temp = new List<IDictionary<TKey>.nKeyValuePair>();
        //    foreach (var item in Dictionarys[0])
        //    {
        //        List<Generic> temp2 = new List<Generic>(Dictionarys[0].Count);
        //        Dictionarys.ToList().ForEach(x => temp2.Add(x.Value[item.Key]));
        //        temp.Add(new IDictionary<TKey>.nKeyValuePair(item.Key, temp2.ToArray()));
        //    }
        //    info.AddValue("values", temp.ToArray(), typeof(IDictionary<TKey>.nKeyValuePair[]));
        //}
        #endregion
    }
}
