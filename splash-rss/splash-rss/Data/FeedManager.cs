using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using splash_rss.Model;

namespace splash_rss.Data
{
    class FeedManager : IFeedManager
    {
        public List<SyndicationItem> LoadFeedData(Feed feed)
        {
            List<SyndicationItem> data = new List<SyndicationItem>();
            XmlReader reader = XmlReader.Create(feed.endpoint);
            SyndicationFeed syndicationFeed = SyndicationFeed.Load(reader);
            reader.Close();
            foreach(SyndicationItem item in syndicationFeed.Items) {
                data.Add(item);
            }   
            return data;
        }
    }
}
