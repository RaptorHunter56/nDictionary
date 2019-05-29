using System;
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
        public BaseDictonary<TKey>.nKeyCollection Keys => new BaseDictonary<TKey>.nKeyCollection(this);
        #endregion
        #region Constructors
        public IDictionary(Type[] types) { this.@base = new BaseDictonary<TKey>(types); }
        #endregion
        #region Methods
        public nKeyValuePair this[TKey key]
        {
            get { return new nKeyValuePair(key, this.@base.GetnDictionary(key)); }
            set { }// Fix
        }
        #endregion

        public class nKeyValuePair
        {
            #region Parameters
            public TKey Key { get; internal set; }
            public dynamic[] Value { get; internal set; }
            #endregion
            #region Constructors
            public nKeyValuePair(TKey key, dynamic[] v)
            {
                this.Key = key;
                this.Value = v;
            }
            #endregion
        }
    }
}
