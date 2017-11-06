using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;
using System.Xml;

namespace splash_rss
{
    class Validator : IValidator
    {
        public bool ValidateFeed(Feed item)
        {
            try
            {
                using (XmlReader reader = XmlReader.Create(item.endpoint))
                {
                    SyndicationFeed syndicationFeed = SyndicationFeed.Load(reader);
                    return true;
                }
            }
            catch(Exception e)
            {
                return false;
            }           
        }
    }
}
