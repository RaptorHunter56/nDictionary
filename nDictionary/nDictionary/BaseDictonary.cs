using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace nDictionary
{
    [Serializable]
    internal partial class BaseDictonary<TKey> : IBaseDictonary<TKey>
    {
        #region Parameters
        public Dictionary<int, Type> Types = new Dictionary<int, Type>();
        public Dictionary<int, Dictionary<TKey, Generic>> Dictionarys = new Dictionary<int, Dictionary<TKey, Generic>>();
        public IEqualityComparer<TKey> Comparer => Dictionarys[0].Comparer;
        #endregion

        #region Constructors
        public BaseDictonary(params Type[] types)
        {
            if (types == null || types.Length < 1) throw new ArgumentNullException("types", $"Value cannot be null.\r\nParameter name: {"types"}");
            try
            { types.ToList().ForEach(x => Types.Add(Types.Count, x)); }
            catch (ArgumentNullException ex)
            { throw new ArgumentNullException(ex.Message, ex); }
            catch (InvalidOperationException ex)
            { throw new InvalidOperationException(ex.Message, ex); }
            catch (ArgumentException ex)
            { throw new ArgumentException(ex.Message, ex); }
        }
        protected BaseDictonary(SerializationInfo info, StreamingContext context) { }
        #endregion

        #region Methods
        public bool ReFactor()
        {
            if (Types == null || Types.Count < 1) throw new ArgumentNullException(this.GetType().GetProperty("Types").Name, $"Value cannot be null.\r\nParameter name: {this.GetType().GetProperty("Types").Name}");
            try
            {
                Dictionarys = new Dictionary<int, Dictionary<TKey, Generic>>();
                Types.ToList().ForEach(x => Dictionarys.Add(x.Key, new Dictionary<TKey, Generic>()));
                return true;
            }
            catch (ArgumentNullException ex)
            { throw new ArgumentNullException(ex.Message, ex); }
            catch (InvalidOperationException ex)
            { throw new InvalidOperationException(ex.Message, ex); }
            catch (ArgumentException ex)
            { throw new ArgumentException(ex.Message, ex); }
        }
        public bool ReFactor(int capacity)
        {
            if (Types == null || Types.Count < 1) throw new ArgumentNullException(this.GetType().GetProperty("Types").Name, $"Value cannot be null.\r\nParameter name: {this.GetType().GetProperty("Types").Name}");
            if (capacity < 1) throw new ArgumentNullException("capacity", $"Value cannot be null.\r\nParameter name: {"capacity"}");
            try
            {
                Dictionarys = new Dictionary<int, Dictionary<TKey, Generic>>();
                Types.ToList().ForEach(x => Dictionarys.Add(x.Key, new Dictionary<TKey, Generic>(capacity)));
                return true;
            }
            catch (ArgumentNullException ex)
            { throw new ArgumentNullException(ex.Message, ex); }
            catch (InvalidOperationException ex)
            { throw new InvalidOperationException(ex.Message, ex); }
            catch (ArgumentException ex)
            { throw new ArgumentException(ex.Message, ex); }
        }
        public bool ReFactor(IEqualityComparer<TKey> comparer)
        {
            if (Types == null || Types.Count < 1) throw new ArgumentNullException(this.GetType().GetProperty("Types").Name, $"Value cannot be null.\r\nParameter name: {this.GetType().GetProperty("Types").Name}");
            if (comparer == null) throw new ArgumentNullException("comparer", $"Value cannot be null.\r\nParameter name: {"comparer"}");
            try
            {
                Dictionarys = new Dictionary<int, Dictionary<TKey, Generic>>();
                Types.ToList().ForEach(x => Dictionarys.Add(x.Key, new Dictionary<TKey, Generic>(comparer)));
                return true;
            }
            catch (ArgumentNullException ex)
            { throw new ArgumentNullException(ex.Message, ex); }
            catch (InvalidOperationException ex)
            { throw new InvalidOperationException(ex.Message, ex); }
            catch (ArgumentException ex)
            { throw new ArgumentException(ex.Message, ex); }
        }

        internal bool Remove(TKey key)
        {
            if (key == null) throw new ArgumentNullException("key", $"Value cannot be null.\r\nParameter name: {"key"}");
            bool r = true;
            try
            {
                foreach (var item in Dictionarys)
                    r = item.Value.Remove(key) ? r : false;
            }
            catch (ArgumentNullException ex)
            { throw new ArgumentNullException(ex.Message, ex); }
            catch { return false; }
            return r;
        }

        public bool ReFactor(int capacity, IEqualityComparer<TKey> comparer)
        {
            if (Types == null || Types.Count < 1) throw new ArgumentNullException(this.GetType().GetProperty("Types").Name, $"Value cannot be null.\r\nParameter name: {this.GetType().GetProperty("Types").Name}");
            if (capacity < 1) throw new ArgumentNullException("capacity", $"Value cannot be null.\r\nParameter name: {"capacity"}");
            if (comparer == null) throw new ArgumentNullException("comparer", $"Value cannot be null.\r\nParameter name: {"comparer"}");
            try
            {
                Dictionarys = new Dictionary<int, Dictionary<TKey, Generic>>();
                Types.ToList().ForEach(x => Dictionarys.Add(x.Key, new Dictionary<TKey, Generic>(capacity, comparer)));
                return true;
            }
            catch (ArgumentNullException ex)
            { throw new ArgumentNullException(ex.Message, ex); }
            catch (InvalidOperationException ex)
            { throw new InvalidOperationException(ex.Message, ex); }
            catch (ArgumentException ex)
            { throw new ArgumentException(ex.Message, ex); }
        }

        internal Generic[] GetnDictionary(TKey key)
        {
            if (key == null) throw new ArgumentNullException("key", $"Value cannot be null.\r\nParameter name: {"key"}");
            try
            {
                List<Generic> temp = new List<Generic>();
                foreach (var item in Dictionarys)
                    temp.Add(item.Value[key]);
                return temp.ToArray();
            }
            catch (Exception ex)
            { throw new Exception(ex.Message, ex); }
        }

        internal void Add(TKey key, dynamic[] vs)
        {
            if (vs == null || vs.Length < 1) throw new ArgumentNullException("vs", $"Value cannot be null.\r\nParameter name: {"vs"}");
            if (key == null) throw new ArgumentNullException("key", $"Value cannot be null.\r\nParameter name: {"key"}");
            try
            {
                var list = vs.ToList();
                var postion = -1;
                foreach (var x in list)
                {
                    postion++;
                    Dictionarys[postion].Add(key, new Generic(x));
                }
            }
            catch (ArgumentNullException ex)
            { throw new ArgumentNullException(ex.Message, ex); }
            catch (ArgumentException ex)
            { throw new ArgumentException(ex.Message, ex); }
        }
        internal void Clear()
        {
            foreach (var item in Dictionarys) item.Value.Clear();
        }

        internal bool ContainsValue<T>(T value, int[] position)
        {
            if (position == null || position.Length < 1) throw new ArgumentNullException("position", $"Value cannot be null.\r\nParameter name: {"position"}");
            if (value == null) throw new ArgumentNullException("value", $"Value cannot be null.\r\nParameter name: {"value"}");
            try
            {
                bool temp = false;
                int temp2 = 1;
                foreach (var item in Dictionarys)
                {
                    if (position.Contains(temp2))
                    {
                        bool temp3 = item.Value.Values.ToList().Select(x => x.Equals(new Generic(value))).Where(x => x == true).Count() > 0;
                        if (temp3) temp = true;
                    }
                    temp2++;
                }
                return temp;
            }
            catch (ArgumentNullException ex)
            { throw new ArgumentNullException(ex.Message, ex); }
            catch (OverflowException ex)
            { throw new OverflowException(ex.Message, ex); }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context) { }
        #endregion
    }
}
