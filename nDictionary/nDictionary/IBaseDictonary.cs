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
    [Serializable]
    public partial class IBaseDictonary<TKey>
    {
        [DebuggerDisplay("Count = {Count}")]
        public sealed class nKeyCollection : IEnumerable<TKey>
        {
            #region Parameters
            private Dictionary<TKey, Generic>.KeyCollection keys;
            public int Count { get { return keys.Count; } }
            public void CopyTo(TKey[] array, int index)
            {
                if (index < 1) throw new ArgumentNullException("index", $"Value cannot be null.\r\nParameter name: {"index"}");
                if (array == null || array.Length < 1) throw new ArgumentNullException("array", $"Value cannot be null.\r\nParameter name: {"array"}");
                try
                {  keys.CopyTo(array, index); }
                catch (ArgumentNullException ex)
                { throw new ArgumentNullException(ex.Message, ex); }
                catch (ArgumentOutOfRangeException ex)
                { throw new ArgumentOutOfRangeException(ex.Message, ex); }
                catch (ArgumentException ex)
                { throw new ArgumentException(ex.Message, ex); }
            }
            #endregion

            #region Constructors
            public nKeyCollection(IDictionary<TKey> dictionary)
            {
                if (dictionary == null || dictionary.Count < 1) throw new ArgumentNullException("dictionary", $"Value cannot be null.\r\nParameter name: {"dictionary"}");
                try
                { keys = dictionary.@base.Dictionarys.First().Value.Keys; }
                catch (InvalidOperationException ex)
                { throw new InvalidOperationException(ex.Message, ex); }
                catch (ArgumentException ex)
                { throw new ArgumentException(ex.Message, ex); }
            }
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
                if (index < 1) throw new ArgumentNullException("index", $"Value cannot be null.\r\nParameter name: {"index"}");
                if (dictionary == null || dictionary.Count < 1) throw new ArgumentNullException("dictionary", $"Value cannot be null.\r\nParameter name: {"dictionary"}");
                try
                {
                    var temp = new Dictionary<TKey, Generic>();
                    var list = dictionary.@base.Dictionarys[index].ToList();
                    list.ForEach(x => temp.Add(x.Key, x.Value));
                    this.values = temp.Values;
                }
                catch (ArgumentNullException ex)
                { throw new ArgumentNullException(ex.Message, ex); }
                catch (InvalidOperationException ex)
                { throw new InvalidOperationException(ex.Message, ex); }
                catch (ArgumentException ex)
                { throw new ArgumentException(ex.Message, ex); }
            }
            #endregion

            #region Methods
            internal static nValueCollection[] GetOut(IDictionary<TKey> dictionary)
            {
                if (dictionary == null || dictionary.Count < 1) throw new ArgumentNullException("dictionary", $"Value cannot be null.\r\nParameter name: {"dictionary"}");
                try
                {
                    List<nValueCollection> temp = new List<nValueCollection>();
                    var list = dictionary.@base.Dictionarys.ToList();
                    list.ForEach(x => temp.Add(new nValueCollection(dictionary, list.IndexOf(x))));
                    return temp.ToArray();
                }
                catch (ArgumentNullException ex)
                { throw new ArgumentNullException(ex.Message, ex); }
                catch (InvalidOperationException ex)
                { throw new InvalidOperationException(ex.Message, ex); }
            }
            public void CopyTo<T>(T[] array, int index)
            {
                if (index < 1) throw new ArgumentNullException("index", $"Value cannot be null.\r\nParameter name: {"index"}");
                if (array == null || array.Length < 1) throw new ArgumentNullException("array", $"Value cannot be null.\r\nParameter name: {"array"}");
                try
                {
                    var temp = new Generic[values.Count];
                    values.CopyTo(temp, index);
                    array = Array.ConvertAll(temp, x => (T)x.GetValue);
                }
                catch (ArgumentNullException ex)
                { throw new ArgumentNullException(ex.Message, ex); }
                catch (ArgumentOutOfRangeException ex)
                { throw new ArgumentOutOfRangeException(ex.Message, ex); }
                catch (ArgumentException ex)
                { throw new ArgumentException(ex.Message, ex); }
            }
            public Dictionary<TKey, Generic>.ValueCollection.Enumerator GetEnumerator() => values.GetEnumerator();
            IEnumerator<Generic> IEnumerable<Generic>.GetEnumerator() => ((IEnumerable<Generic>)values).GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<Generic>)values).GetEnumerator();
            #endregion
        }
    }
}
