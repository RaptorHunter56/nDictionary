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
    //[Serializable]
    public class IDictionary<TKey> : IEnumerable, IEnumerable<IDictionary<TKey>.nKeyValuePair>//, ISerializable
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
        //public IDictionary(SerializationInfo info, StreamingContext context)
        //{
        //    @base = new BaseDictonary<TKey>((Type[])info.GetValue("types", typeof(Type[])));
        //    @base.ReFactor();
        //    @base.GetObjectData(info, context);
        //    //@base = (BaseDictonary<TKey>)info.GetValue("base", typeof(BaseDictonary<TKey>));
        //}
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
        IEnumerator<nKeyValuePair> IEnumerable<nKeyValuePair>.GetEnumerator() => (IEnumerator<nKeyValuePair>)GetEnumerator();

        //public void GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //    info.AddValue("types", @base.Types.Select(x => x.Value).ToArray(), typeof(Type[]));
        //    info.AddValue("base", @base, typeof(BaseDictonary<TKey>));
        //}

        public bool Remove(TKey key) => ContainsKey(key) ? @base.Remove(key) : false;
        public bool TryGetValue(TKey key, out nKeyValuePair value)
        {
            value = null;
            try { value = new nKeyValuePair(key, @base.GetnDictionary(key)); }
            catch { return false; }
            return true;
        }

        #endregion

        //[Serializable]
        public class nKeyValuePair// : ISerializable
        {
            #region Parameters
            public TKey Key { get; internal set; }
            public Generic[] Values { get; internal set; }
            #endregion

            #region Constructors
            public nKeyValuePair(TKey key, Generic[] v)
            {
                this.Key = key;
                this.Values = v;
            }
            public nKeyValuePair(TKey key, dynamic[] v)
            {
                this.Key = key;
                this.Values = v.ToList().Select(x => new Generic(x)).ToArray();
            }
            //public nKeyValuePair(SerializationInfo info, StreamingContext context)
            //{
            //    Key = (TKey)info.GetValue("key", typeof(TKey));
            //    Value = (Generic[])info.GetValue("values", typeof(Generic[]));
            //}
            #endregion

            #region Methods
            //public void GetObjectData(SerializationInfo info, StreamingContext context)
            //{
            //    info.AddValue("key", Key, typeof(TKey));
            //    info.AddValue("values", Value, typeof(Generic[]));
            //}
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
