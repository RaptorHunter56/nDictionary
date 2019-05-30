using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace nDictionary
{
    public class nDictionary<TKey, TValue1> : IDictionary<TKey>
    {
        #region Parameters
        public static Type[] GetTypes { get { return new Type[] { typeof(TValue1) }; } }
        #endregion

        #region Constructors
        public nDictionary() : base(GetTypes) { this.@base.ReFactor(); }
        public nDictionary(int capacity) : base(GetTypes) { this.@base.ReFactor(capacity); }
        public nDictionary(IEqualityComparer<TKey> comparer) : base(GetTypes) { this.@base.ReFactor(comparer); }
        public nDictionary(nDictionary<TKey, TValue1> dictionary) : base(GetTypes) { this.@base.ReFactor(); }// Fix
        public nDictionary(int capacity, IEqualityComparer<TKey> comparer) : base(GetTypes) { this.@base.ReFactor(comparer); }
        public nDictionary(nDictionary<TKey, TValue1> dictionary, IEqualityComparer<TKey> comparer) : base(GetTypes) { this.@base.ReFactor(); }// Fix
        protected nDictionary(SerializationInfo info, StreamingContext context) : base(GetTypes) { throw new NotImplementedException(); }// Fix
        #endregion
    }
    public class nDictionary<TKey, TValue1, TValue2> : IDictionary<TKey>
    {
        #region Parameters
        public static Type[] GetTypes { get { return new Type[] { typeof(TValue1), typeof(TValue2) }; } }
        #endregion

        #region Constructors
        public nDictionary() : base(GetTypes) { this.@base.ReFactor(); }
        public nDictionary(int capacity) : base(GetTypes) { this.@base.ReFactor(capacity); }
        public nDictionary(IEqualityComparer<TKey> comparer) : base(GetTypes) { this.@base.ReFactor(comparer); }
        public nDictionary(nDictionary<TKey, TValue1, TValue2> dictionary) : base(GetTypes) { this.@base.ReFactor(); }// Fix
        public nDictionary(int capacity, IEqualityComparer<TKey> comparer) : base(GetTypes) { this.@base.ReFactor(comparer); }
        public nDictionary(nDictionary<TKey, TValue1, TValue2> dictionary, IEqualityComparer<TKey> comparer) : base(GetTypes) { this.@base.ReFactor(); }// Fix
        protected nDictionary(SerializationInfo info, StreamingContext context) : base(GetTypes) { throw new NotImplementedException(); }// Fix
        #endregion
    }
}
