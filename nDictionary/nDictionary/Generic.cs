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
    //[Serializable]
    public class Generic //: ISerializable
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
        //protected Generic(SerializationInfo info, StreamingContext context) : this(info.GetValue("value", (Type)info.GetValue("type", typeof(Type)))) { }
        #endregion

        #region Methods
        public T Cast<T>(out T result)
        {
            result = (T)GetValue;
            return result;
        }
        public T Cast<T>() => (T)this.GetValue;

        //public void GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //    info.AddValue("value", GetValue, type);
        //    info.AddValue("type", type, typeof(Type));
        //}
        #endregion

        #region Overrides
        public override string ToString() => GetValue.ToString();
        public override bool Equals(object obj) => (obj.GetType() == typeof(Generic))? GetValue.Equals(((Generic)obj).GetValue) : GetValue.Equals(obj);
        public override int GetHashCode() => GetValue.GetHashCode();
        #endregion
    }
}
