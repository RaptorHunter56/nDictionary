using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace nDictionary
{
    public class IDictionary<TKey>
    {
        #region Parameters
        internal BaseDictonary<TKey> @base;
        #endregion
        #region Constructors
        public IDictionary(Type[] types) { this.@base = new BaseDictonary<TKey>(types); }
        #endregion
    }
}
