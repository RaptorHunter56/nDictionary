﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace nDictionary
{
    public class IDictionary<TKey>
    {
        #region Parameters
        internal BaseDictonary<TKey> @base;
        public int Count => @base.Dictionarys.Values.FirstOrDefault().Count();
        public BaseDictonary<TKey>.nKeyCollection Keys => new BaseDictonary<TKey>.nKeyCollection(this);
        public BaseDictonary<TKey>.nValueCollection[] Values => BaseDictonary<TKey>.nValueCollection.GetOut(this);
        public IEqualityComparer<TKey> Comparer => @base.Comparer;
        #endregion

        #region Constructors
        public IDictionary(Type[] types) => this.@base = new BaseDictonary<TKey>(types);
        #endregion

        #region Methods
        public nKeyValuePair this[TKey key]
        {
            get { return new nKeyValuePair(key, this.@base.GetnDictionary(key)); }
            set { }// Fix
        }

        public void Add(TKey key, params dynamic[] vs) => @base.Add(key, vs);
        public void Clear() => @base.Clear();
        public bool ContainsKey(TKey key) { return true; } // Fix
        #endregion

        public class nKeyValuePair
        {
            #region Parameters
            public TKey Key { get; internal set; }
            public Generic[] Value { get; internal set; }
            #endregion

            #region Constructors
            public nKeyValuePair(TKey key, Generic[] v)
            {
                this.Key = key;
                this.Value = v;
            }
            public nKeyValuePair(TKey key, dynamic[] v)
            {
                this.Key = key;
                this.Value = v.ToList().Select(x => new Generic(x)).ToArray();
            }
            #endregion
        }
    }
}
