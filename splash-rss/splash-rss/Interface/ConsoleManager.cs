using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace splash_rss.Interface
{
    public class ConsoleManager : IConsoleManager
    {
        public void Navigate(List<SyndicationItem> data)
        {
            
        }

        public void PrintData(List<SyndicationItem> data)
        {
            foreach(SyndicationItem item in data)
            {
                Console.WriteLine(item.Title.Text);
            }
        }
    }
}
