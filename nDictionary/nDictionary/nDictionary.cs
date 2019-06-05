using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace nDictionary
{
    [Serializable]
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
        protected nDictionary(SerializationInfo info, StreamingContext context) : base(info, context) { }
        #endregion

        #region Methods
        #endregion
    }
    [Serializable]
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
        public nDictionary(SerializationInfo info, StreamingContext context) : base(info, context) { }
        #endregion

        #region Methods
        #endregion
    }
    [Serializable]
    public class nDictionary<TKey, TValue1, TValue2, TValue3> : IDictionary<TKey>
    {
        #region Parameters
        public static Type[] GetTypes { get { return new Type[] { typeof(TValue1), typeof(TValue2), typeof(TValue3) }; } }
        #endregion

        #region Constructors
        public nDictionary() : base(GetTypes) { this.@base.ReFactor(); }
        public nDictionary(int capacity) : base(GetTypes) { this.@base.ReFactor(capacity); }
        public nDictionary(IEqualityComparer<TKey> comparer) : base(GetTypes) { this.@base.ReFactor(comparer); }
        public nDictionary(nDictionary<TKey, TValue1, TValue2, TValue3> dictionary) : base(GetTypes) { this.@base.ReFactor(); }// Fix
        public nDictionary(int capacity, IEqualityComparer<TKey> comparer) : base(GetTypes) { this.@base.ReFactor(comparer); }
        public nDictionary(nDictionary<TKey, TValue1, TValue2, TValue3> dictionary, IEqualityComparer<TKey> comparer) : base(GetTypes) { this.@base.ReFactor(); }// Fix
        public nDictionary(SerializationInfo info, StreamingContext context) : base(info, context) { }
        #endregion

        #region Methods
        #endregion
    }
    [Serializable]
    public class nDictionary<TKey, TValue1, TValue2, TValue3, TValue4> : IDictionary<TKey>
    {
        #region Parameters
        public static Type[] GetTypes { get { return new Type[] { typeof(TValue1), typeof(TValue2), typeof(TValue3), typeof(TValue4) }; } }
        #endregion

        #region Constructors
        public nDictionary() : base(GetTypes) { this.@base.ReFactor(); }
        public nDictionary(int capacity) : base(GetTypes) { this.@base.ReFactor(capacity); }
        public nDictionary(IEqualityComparer<TKey> comparer) : base(GetTypes) { this.@base.ReFactor(comparer); }
        public nDictionary(nDictionary<TKey, TValue1, TValue2, TValue3, TValue4> dictionary) : base(GetTypes) { this.@base.ReFactor(); }// Fix
        public nDictionary(int capacity, IEqualityComparer<TKey> comparer) : base(GetTypes) { this.@base.ReFactor(comparer); }
        public nDictionary(nDictionary<TKey, TValue1, TValue2, TValue3, TValue4> dictionary, IEqualityComparer<TKey> comparer) : base(GetTypes) { this.@base.ReFactor(); }// Fix
        public nDictionary(SerializationInfo info, StreamingContext context) : base(info, context) { }
        #endregion

        #region Methods
        #endregion
    }
    [Serializable]
    public class nDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5> : IDictionary<TKey>
    {
        #region Parameters
        public static Type[] GetTypes { get { return new Type[] { typeof(TValue1), typeof(TValue2), typeof(TValue3), typeof(TValue4), typeof(TValue5) }; } }
        #endregion

        #region Constructors
        public nDictionary() : base(GetTypes) { this.@base.ReFactor(); }
        public nDictionary(int capacity) : base(GetTypes) { this.@base.ReFactor(capacity); }
        public nDictionary(IEqualityComparer<TKey> comparer) : base(GetTypes) { this.@base.ReFactor(comparer); }
        public nDictionary(nDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5> dictionary) : base(GetTypes) { this.@base.ReFactor(); }// Fix
        public nDictionary(int capacity, IEqualityComparer<TKey> comparer) : base(GetTypes) { this.@base.ReFactor(comparer); }
        public nDictionary(nDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5> dictionary, IEqualityComparer<TKey> comparer) : base(GetTypes) { this.@base.ReFactor(); }// Fix
        public nDictionary(SerializationInfo info, StreamingContext context) : base(info, context) { }
        #endregion

        #region Methods
        #endregion
    }
    [Serializable]
    public class nDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6> : IDictionary<TKey>
    {
        #region Parameters
        public static Type[] GetTypes { get { return new Type[] { typeof(TValue1), typeof(TValue2), typeof(TValue3), typeof(TValue4), typeof(TValue5), typeof(TValue6) }; } }
        #endregion

        #region Constructors
        public nDictionary() : base(GetTypes) { this.@base.ReFactor(); }
        public nDictionary(int capacity) : base(GetTypes) { this.@base.ReFactor(capacity); }
        public nDictionary(IEqualityComparer<TKey> comparer) : base(GetTypes) { this.@base.ReFactor(comparer); }
        public nDictionary(nDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6> dictionary) : base(GetTypes) { this.@base.ReFactor(); }// Fix
        public nDictionary(int capacity, IEqualityComparer<TKey> comparer) : base(GetTypes) { this.@base.ReFactor(comparer); }
        public nDictionary(nDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6> dictionary, IEqualityComparer<TKey> comparer) : base(GetTypes) { this.@base.ReFactor(); }// Fix
        public nDictionary(SerializationInfo info, StreamingContext context) : base(info, context) { }
        #endregion

        #region Methods
        #endregion
    }
    [Serializable]
    public class nDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7> : IDictionary<TKey>
    {
        #region Parameters
        public static Type[] GetTypes { get { return new Type[] { typeof(TValue1), typeof(TValue2), typeof(TValue3), typeof(TValue4), typeof(TValue5), typeof(TValue6), typeof(TValue7) }; } }
        #endregion

        #region Constructors
        public nDictionary() : base(GetTypes) { this.@base.ReFactor(); }
        public nDictionary(int capacity) : base(GetTypes) { this.@base.ReFactor(capacity); }
        public nDictionary(IEqualityComparer<TKey> comparer) : base(GetTypes) { this.@base.ReFactor(comparer); }
        public nDictionary(nDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7> dictionary) : base(GetTypes) { this.@base.ReFactor(); }// Fix
        public nDictionary(int capacity, IEqualityComparer<TKey> comparer) : base(GetTypes) { this.@base.ReFactor(comparer); }
        public nDictionary(nDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7> dictionary, IEqualityComparer<TKey> comparer) : base(GetTypes) { this.@base.ReFactor(); }// Fix
        public nDictionary(SerializationInfo info, StreamingContext context) : base(info, context) { }
        #endregion

        #region Methods
        #endregion
    }
    [Serializable]
    public class nDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8> : IDictionary<TKey>
    {
        #region Parameters
        public static Type[] GetTypes { get { return new Type[] { typeof(TValue1), typeof(TValue2), typeof(TValue3), typeof(TValue4), typeof(TValue5), typeof(TValue6), typeof(TValue7), typeof(TValue8) }; } }
        #endregion

        #region Constructors
        public nDictionary() : base(GetTypes) { this.@base.ReFactor(); }
        public nDictionary(int capacity) : base(GetTypes) { this.@base.ReFactor(capacity); }
        public nDictionary(IEqualityComparer<TKey> comparer) : base(GetTypes) { this.@base.ReFactor(comparer); }
        public nDictionary(nDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8> dictionary) : base(GetTypes) { this.@base.ReFactor(); }// Fix
        public nDictionary(int capacity, IEqualityComparer<TKey> comparer) : base(GetTypes) { this.@base.ReFactor(comparer); }
        public nDictionary(nDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8> dictionary, IEqualityComparer<TKey> comparer) : base(GetTypes) { this.@base.ReFactor(); }// Fix
        public nDictionary(SerializationInfo info, StreamingContext context) : base(info, context) { }
        #endregion

        #region Methods
        #endregion
    }
    [Serializable]
    public class nDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9> : IDictionary<TKey>
    {
        #region Parameters
        public static Type[] GetTypes { get { return new Type[] { typeof(TValue1), typeof(TValue2), typeof(TValue3), typeof(TValue4), typeof(TValue5), typeof(TValue6), typeof(TValue7), typeof(TValue8), typeof(TValue9) }; } }
        #endregion

        #region Constructors
        public nDictionary() : base(GetTypes) { this.@base.ReFactor(); }
        public nDictionary(int capacity) : base(GetTypes) { this.@base.ReFactor(capacity); }
        public nDictionary(IEqualityComparer<TKey> comparer) : base(GetTypes) { this.@base.ReFactor(comparer); }
        public nDictionary(nDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9> dictionary) : base(GetTypes) { this.@base.ReFactor(); }// Fix
        public nDictionary(int capacity, IEqualityComparer<TKey> comparer) : base(GetTypes) { this.@base.ReFactor(comparer); }
        public nDictionary(nDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9> dictionary, IEqualityComparer<TKey> comparer) : base(GetTypes) { this.@base.ReFactor(); }// Fix
        public nDictionary(SerializationInfo info, StreamingContext context) : base(info, context) { }
        #endregion

        #region Methods
        #endregion
    }
    [Serializable]
    public class nDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10> : IDictionary<TKey>
    {
        #region Parameters
        public static Type[] GetTypes { get { return new Type[] { typeof(TValue1), typeof(TValue2), typeof(TValue3), typeof(TValue4), typeof(TValue5), typeof(TValue6), typeof(TValue7), typeof(TValue8), typeof(TValue9), typeof(TValue10) }; } }
        #endregion

        #region Constructors
        public nDictionary() : base(GetTypes) { this.@base.ReFactor(); }
        public nDictionary(int capacity) : base(GetTypes) { this.@base.ReFactor(capacity); }
        public nDictionary(IEqualityComparer<TKey> comparer) : base(GetTypes) { this.@base.ReFactor(comparer); }
        public nDictionary(nDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10> dictionary) : base(GetTypes) { this.@base.ReFactor(); }// Fix
        public nDictionary(int capacity, IEqualityComparer<TKey> comparer) : base(GetTypes) { this.@base.ReFactor(comparer); }
        public nDictionary(nDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10> dictionary, IEqualityComparer<TKey> comparer) : base(GetTypes) { this.@base.ReFactor(); }// Fix
        public nDictionary(SerializationInfo info, StreamingContext context) : base(info, context) { }
        #endregion

        #region Methods
        #endregion
    }
}
