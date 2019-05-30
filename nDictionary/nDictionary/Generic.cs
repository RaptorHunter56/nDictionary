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
    public class Generic
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
        #endregion

        #region Methods
        public T Cast<T>(out T result)
        {
            result = (T)GetValue;
            return result;
        }
        #endregion

        #region Overrides
        public override string ToString() => GetValue.ToString();
        #endregion
    }
}
