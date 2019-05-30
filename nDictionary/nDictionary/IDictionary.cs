using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace nDictionary
{
    public class IDictionary<TKey> : IEnumerable
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
        public bool ContainsKey(TKey key) => @base.Dictionarys.Values.FirstOrDefault().ContainsKey(key);
        public bool ContainsValue<T>(T value) => ContainsValue<T>(value, Enumerable.Range(1, Values.Count()).ToArray());
        public bool ContainsValue<T>(T value, int position) => ContainsValue<T>(value, new int[1] { position });
        public bool ContainsValue<T>(T value, int[] position) => @base.ContainsValue(value, position);

        public Enumerator GetEnumerator() => new Enumerator(this);
        IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)GetEnumerator();
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

        public struct Enumerator : IEnumerator<nKeyValuePair>, IEnumerator
        {
            #region Parameters
            private List<nKeyValuePair> dictionary;
            private List<nKeyValuePair> dictionaryBase;
            private int position;
            public object Current => dictionary[position];
            nKeyValuePair IEnumerator<nKeyValuePair>.Current => (nKeyValuePair)this.Current;
            object IEnumerator.Current => this.Current;
            #endregion

            #region Constructors
            public Enumerator(IDictionary<TKey> dictionary)
            {
                var temp = dictionary.@base.Dictionarys.ToList();
                this.dictionary = new List<nKeyValuePair>();
                foreach (var item in temp[0].Value)
                    this.dictionary.Add(new nKeyValuePair(item.Key, temp.Select(x => x.Value[item.Key]).ToArray()));
                this.dictionaryBase = this.dictionary;
                this.position = -1;
            }
            #endregion

            #region Methods
            public void Reset()
            {
                position = -1;
                dictionary = dictionaryBase;
            }
            public bool MoveNext()
            {
                position++;
                return dictionary.Count > position;
            }

            public void Dispose()
            {
                dictionary = new List<nKeyValuePair>();
                dictionaryBase = new List<nKeyValuePair>();
            }
            #endregion
        }
    }
}
