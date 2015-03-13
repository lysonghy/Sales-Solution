using Sales.Common.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace Sales.Common.Caching
{
    public class HttpContextCacheEngine:ICacheEngine
    {
private readonly int _minutesTilExpire;
        
        private readonly Cache _cache;
        public HttpContextCacheEngine()
        {
            _cache = HttpContext.Current.Cache;
            this._minutesTilExpire = 10;
        }
        public HttpContextCacheEngine(int minutesTilExpire)
            : this()
        {
            _minutesTilExpire = minutesTilExpire;
        }

        public void Flush()
        {
            RemoveAllWithKeyPrefix(string.Empty);
        }

        public int Count()
        {
            return _cache.Count;
        }

        public bool Exists(string key)
        {
            return _cache[key] != null;
        }

        public object Get(string key)
        {
            return _cache.Get(key);
        }

        public void Add(string key, object value)
        {
            DateTime expiryDate = DateTime.Now.AddMinutes(_minutesTilExpire);
            Add(key, value, expiryDate);
        }

        public void Add(string key, object value, DateTime expiryDate)
        {
            if (Exists(key)) _cache.Remove(key);

            if (value != null) _cache.Add(key, value, null, expiryDate, TimeSpan.Zero, CacheItemPriority.Default, null);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public void RemoveAllWithKeyPrefix(string keyPrefix)
        {
            List<string> keysToRemove = new List<string>();
            IDictionaryEnumerator enumerator = _cache.GetEnumerator();

            while (enumerator.MoveNext())
            {
                string key = enumerator.Key.ToString();

                if (key.StartsWith(keyPrefix, StringComparison.InvariantCultureIgnoreCase))
                {
                    keysToRemove.Add(key);
                }
            }

            foreach (string key in keysToRemove)
            {
                Remove(key);
            }
        }

        public void RemoveAllWithKeySuffix(string keySuffix)
        {
            List<string> keysToRemove = new List<string>();
            IDictionaryEnumerator enumerator = _cache.GetEnumerator();

            while (enumerator.MoveNext())
            {
                string key = enumerator.Key.ToString();

                if (key.EndsWith(keySuffix, StringComparison.InvariantCultureIgnoreCase))
                {
                    keysToRemove.Add(key);
                }
            }

            foreach (string key in keysToRemove)
            {
                Remove(key);
            }
        }


        public string CacheEngineType
        {
            get { return "HttpContextCacheEngine"; }
        }
    }
}
