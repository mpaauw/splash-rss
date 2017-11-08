using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;
using System.Xml;
using splash_rss.Model;

namespace splash_rss.Data
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
