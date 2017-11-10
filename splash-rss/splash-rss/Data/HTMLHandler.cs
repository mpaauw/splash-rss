using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace splash_rss.Data
{
    public class HTMLHandler : IHTMLHandler
    {
        public HtmlDocument LoadHTMLDocumentFromWeb(string url)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            return doc;
        }
    }
}
