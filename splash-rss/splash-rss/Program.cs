using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splash_rss
{
    class Splash
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage();
            List<Feed> data = storage.GetStorage();
            Feed validItem = new Feed("games", "https://www.reddit.com/r/games/.rss");
            Feed invalidItem = new Feed("games", "https://www.reddit.com/r/games");
            storage.AddStorageItem(validItem);
            storage.AddStorageItem(invalidItem);
        }
    }
}
