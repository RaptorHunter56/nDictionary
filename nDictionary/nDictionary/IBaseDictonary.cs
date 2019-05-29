using System;
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
    public partial class IBaseDictonary<TKey>
    {
        [DebuggerDisplay("Count = {Count}")]
        public sealed class nKeyCollection : IEnumerable<TKey>
        {
            #region Parameters
            private Dictionary<TKey, Generic>.KeyCollection keys;
            public int Count { get { return keys.Count; } }
            public void CopyTo(TKey[] array, int index) => keys.CopyTo(array, index);
            #endregion
            #region Constructors
            public nKeyCollection(IDictionary<TKey> dictionary) => keys = dictionary.@base.Dictionarys.First().Value.Keys;
            #endregion
            #region Methods
            IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator() => ((IEnumerable<TKey>)keys).GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<TKey>)keys).GetEnumerator();
            #endregion
        }
    }
}
