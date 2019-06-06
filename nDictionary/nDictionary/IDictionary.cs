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
    [Serializable]
    public class IDictionary<TKey> : IEnumerable, IEnumerable<IDictionary<TKey>.nKeyValuePair>
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
        public IDictionary(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("static.dic", GetEnumerator(), typeof(IEnumerator<nKeyValuePair>));
        }
        #endregion

        #region Methods
        public nKeyValuePair this[TKey key]
        {
            get { return new nKeyValuePair(key, this.@base.GetnDictionary(key)); }
            set { }// Fix
        }

        public void Add(TKey key, params dynamic[] vs) => @base.Add(key, vs);

        private void Add(nKeyValuePair item) => this.Add(item.Key, item.Values);

        public void Clear() => @base.Clear();
        public bool ContainsKey(TKey key) => @base.Dictionarys.Values.FirstOrDefault().ContainsKey(key);
        public bool ContainsValue<T>(T value) => ContainsValue<T>(value, Enumerable.Range(1, Values.Count()).ToArray());
        public bool ContainsValue<T>(T value, int position) => ContainsValue<T>(value, new int[1] { position });
        public bool ContainsValue<T>(T value, int[] position) => @base.ContainsValue(value, position);

        public Enumerator GetEnumerator() => new Enumerator(this);
        IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)GetEnumerator();
        IEnumerator<nKeyValuePair> IEnumerable<nKeyValuePair>.GetEnumerator() => (IEnumerator<nKeyValuePair>)GetEnumerator();

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("list", new List<nKeyValuePair>() { new nKeyValuePair(new Generic(0).Cast<TKey>(), new dynamic[1] { "Help" }), new nKeyValuePair(new Generic(1).Cast<TKey>(), new dynamic[1] { "Me" }) }, typeof(List<nKeyValuePair>));
        }

        public bool Remove(TKey key) => ContainsKey(key) ? @base.Remove(key) : false;
        public bool TryGetValue(TKey key, out nKeyValuePair value)
        {
            value = null;
            try { value = new nKeyValuePair(key, @base.GetnDictionary(key)); }
            catch { return false; }
            return true;
        }

        public static T ConvertValue<T>(string value) => (T)Convert.ChangeType(value, typeof(T));
        public static object ConvertValue(string value , Type type) => Convert.ChangeType(value, type);

        public static Dictionary<TKey, T> ToDictionary<T>(IDictionary<TKey> obj, int index = 0)
        {
            Dictionary<TKey, T> temp = new Dictionary<TKey, T>();
            foreach (nKeyValuePair item in obj)
                temp.Add(item.Key, item.Values[index].Cast<T>());
            return temp;
        }
        public Dictionary<TKey, T> ToDictionary<T>(int index = 0)
        {
            Dictionary<TKey, T> temp = new Dictionary<TKey, T>();
            foreach (nKeyValuePair item in this)
                temp.Add(item.Key, item.Values[index].Cast<T>());
            return temp;
        }

        public static T Change<T>(IDictionary<TKey> obj) where T : IDictionary<TKey>, new()
        {
            var result = new T();
            foreach (nKeyValuePair item in obj)
                result.Add(item);
            return result;
        }
        public T Change<T>() where T : IDictionary<TKey>, new()
        {
            var result = new T();
            foreach (nKeyValuePair item in this)
                result.Add(item);
            return result;
        }
        #endregion

        public class nKeyValuePair
        {
            #region Parameters
            public TKey Key { get; internal set; }
            public Generic[] Values { get; internal set; }
            #endregion

            #region Constructors
            public nKeyValuePair(TKey key, dynamic[] v)
            {
                this.Key = key;
                this.Values = v.ToList().Select(x => new Generic(x)).ToArray();
            }
            public nKeyValuePair(TKey key, Generic[] v)
            {
                this.Key = key;
                this.Values = v;
            }
            public nKeyValuePair(SerializationInfo info, StreamingContext context)
            {
            }
            #endregion

            #region Methods
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("key", Key, typeof(TKey));
                info.AddValue("values", Values, typeof(Generic[]));
            }
            #endregion

            #region Overrides
            public override string ToString() => $"[{this.Key}, [{String.Join(", ",this.Values.Select(x => x.GetValue))}]]";
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
            public Enumerator(SerializationInfo info, StreamingContext context)
            {
                this.dictionary = new List<nKeyValuePair>();
                this.dictionaryBase = this.dictionary;
                this.position = -1;
                //info.AddValue("static.dic", GetEnumerator(), typeof(IEnumerator<nKeyValuePair>));
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

            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("static.dic", dictionary, typeof(List<nKeyValuePair>));
            }
            #endregion
        }
    }
}
