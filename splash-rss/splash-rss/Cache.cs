using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace splash_rss
{
    class Cache : ICache
    {
        private MemoryCache memCache;

        public Cache()
        {
            memCache = new MemoryCache("cacheConfig", new System.Collections.Specialized.NameValueCollection());
        }

        public void Insert(string key, object item)
        {
            memCache.Add(key, item, null);
        }

        public bool Contains(string key)
        {
            if(memCache.Contains(key))
            {
                return true;
            }
            return false;
        }

        public object Get(string key)
        {
            return memCache.Get(key);
        }
    }
}
