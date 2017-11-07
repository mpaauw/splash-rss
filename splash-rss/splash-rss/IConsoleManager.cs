using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;

namespace splash_rss
{
    public interface IConsoleManager
    {
        void Navigate(List<SyndicationItem> data);

        void PrintData(List<SyndicationItem> data);
    }
}
