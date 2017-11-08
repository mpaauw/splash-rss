using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;
using splash_rss.Model;

namespace splash_rss.Data
{
    public interface IFeedManager
    {
        List<SyndicationItem> LoadFeedData(Feed feed);
    }
}
