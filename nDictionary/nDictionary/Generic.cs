using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace nDictionary
{
    [Serializable]
    public class Generic : ISerializable
    {
        #region Parameters
        private Type type;
        public dynamic GetValue { get; internal set; }
        public new Type GetType() => type;
        #endregion

        #region Constructors
        public Generic(dynamic value)
        {
            this.GetValue = value;
            type = value.GetType();
        }
        public Generic(Generic value)
        {
            this.GetValue = value.GetValue;
            type = value.type;
        }
        protected Generic(SerializationInfo info, StreamingContext context) : this(info.GetValue("value", (Type)info.GetValue("type", typeof(Type)))) { }
        #endregion

        #region Methods
        public T Cast<T>(out T result)
        {
            try
            {
                result = (T)GetValue;
                return result;
            }
            catch (InvalidCastException ex)
            { throw new InvalidCastException(ex.Message, ex); }
        }
        public T Cast<T>()
        {
            try
            { return (T)GetValue; }
            catch (InvalidCastException ex)
            { throw new InvalidCastException(ex.Message, ex); }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            try
            {
                info.AddValue("type", type, typeof(Type));
                info.AddValue("value", GetValue, type);
            }
            catch (ArgumentNullException ex)
            { throw new ArgumentNullException(ex.Message, ex); }
            catch (SerializationException ex)
            { throw new SerializationException(ex.Message, ex); }
        }
        #endregion

        #region Overrides
        public override string ToString() => GetValue.ToString();
        public override bool Equals(object obj) => (obj.GetType() == typeof(Generic))? GetValue.Equals(((Generic)obj).GetValue) : GetValue.Equals(obj);
        public override int GetHashCode() => GetValue.GetHashCode();
        #endregion
    }
}
