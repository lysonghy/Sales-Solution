using Sales.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Common.Caching
{
    public class NoCacheEngine:ICacheEngine
    {
        public NoCacheEngine()
		{
		}

        public void Flush()
        {
        }

        public int Count()
        {
            return 0;
        }

        public bool Exists(string key)
        {
            return false;
        }

        public object Get(string key)
        {
            return null;
        }

        public void Add(string key, object value)
        {
        }

        public void Add(string key, object value, DateTime expiryDate)
        {
        }

        public void Remove(string key)
        {
        }

        public void RemoveAllWithKeyPrefix(string keyPrefix)
        {
        }

        public void RemoveAllWithKeySuffix(string keySuffix)
        {
        }


        public string CacheEngineType
        {
            get { throw new NotImplementedException(); }
        }
    }
}
