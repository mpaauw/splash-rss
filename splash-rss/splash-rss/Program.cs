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
            SplashConfig config = new SplashConfig();
            var commands = config.GetCommands();

            Feed testFeedItem = new Feed("foo", "bar");

            Cache c = new Cache();
            c.Insert(testFeedItem.name, testFeedItem);
            bool contains = c.Contains(testFeedItem.name);
            Feed returnedItem = (Feed)c.Get(testFeedItem.name);
        }
    }
}
