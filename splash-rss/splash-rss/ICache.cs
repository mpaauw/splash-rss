using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace splash_rss
{
    public interface ICache
    {
        void Insert(string key, object item);

        bool Contains(string key);

        object Get(string key);
    }
}
