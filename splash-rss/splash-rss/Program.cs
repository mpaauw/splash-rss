using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;

namespace splash_rss
{
    class Splash
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage();
            FeedManager feedManager = new FeedManager();
            List<Feed> storageFeeds = storage.GetStorage();
            List<List<SyndicationItem>> data = new List<List<SyndicationItem>>();
            foreach(Feed feed in storageFeeds)
            {
                data.Add(feedManager.LoadFeedData(feed));
            }

            string lol = "haha";
        }
    }
}
