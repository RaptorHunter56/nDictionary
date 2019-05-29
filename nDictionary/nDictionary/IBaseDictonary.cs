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
        [DebuggerDisplay("Count = {Count}")]
        public sealed class nValueCollection : IEnumerable<Generic>
        {
            #region Parameters
            private Dictionary<TKey, Generic>.ValueCollection values;
            public int Count { get { return values.Count; } }
            #endregion
            #region Constructors
            public nValueCollection(IDictionary<TKey> dictionary, int index)
            {
                var temp = new Dictionary<TKey, Generic>();
                var list = dictionary.@base.Dictionarys[index].ToList();
                list.ForEach(x => temp.Add(x.Key, x.Value));
                this.values = temp.Values;
            }
            #endregion
            #region Methods
            internal static nValueCollection[] GetOut(IDictionary<TKey> dictionary)
            {
                List<nValueCollection> temp = new List<nValueCollection>();
                var list = dictionary.@base.Dictionarys.ToList();
                list.ForEach(x => temp.Add(new nValueCollection(dictionary, list.IndexOf(x))));
                return temp.ToArray();
            }
            public void CopyTo<T>(T[] array, int index)
            {
                var temp = new Generic[values.Count];
                values.CopyTo(temp, index);
                array = Array.ConvertAll(temp, x => (T)x.GetValue);
            }
            public Dictionary<TKey, Generic>.ValueCollection.Enumerator GetEnumerator() => values.GetEnumerator();
            IEnumerator<Generic> IEnumerable<Generic>.GetEnumerator() => ((IEnumerable<Generic>)values).GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<Generic>)values).GetEnumerator();
            #endregion
        }
    }
}
