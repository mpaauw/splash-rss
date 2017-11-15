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
        /// <summary>
        /// Loads in SyndicationItem data objects from a verified RSS feed.
        /// </summary>
        /// <param name="feed">The Feed object from which to load syndication data.</param>
        /// <returns>A List of all SyndicationItem objects retrieved from the URL endpoint specified within the Feed object.</returns>
        List<SyndicationItem> LoadFeedData(Feed feed);
    }
}
