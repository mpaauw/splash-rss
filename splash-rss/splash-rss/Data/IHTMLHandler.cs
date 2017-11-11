using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace splash_rss.Data
{
    public interface IHTMLHandler
    {
        HtmlDocument LoadHTMLDocumentFromWeb(string url);

        string ParseHTMLDocument(HtmlDocument doc, string nodeSelector);
    }
}
