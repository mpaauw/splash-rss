using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splash_rss
{
    public interface IStorage
    {
        void LoadStorage();

        void SaveStorage();

        List<Feed> GetStorage();

        void AddStorageItem(Feed item);
    }
}
