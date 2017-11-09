using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;
using splash_rss.Data;
using splash_rss.Interface;
using splash_rss.Model;

namespace splash_rss
{
    class Splash
    { 
        static void Main(string[] args)
        {
            ConsoleManager consoleManager = new ConsoleManager();
            Storage storage = new Storage();
            FeedManager feedManager = new FeedManager();
            List<Feed> storageFeeds = storage.GetStorage();
            List<List<SyndicationItem>> data = new List<List<SyndicationItem>>();
            foreach(Feed feed in storageFeeds)
            {
                List<SyndicationItem> datum = feedManager.LoadFeedData(feed);
                consoleManager.Navigate(datum, 0);
            }
        }
    }
}
