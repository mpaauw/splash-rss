using HtmlAgilityPack;

namespace splash_rss.Data
{
    public interface IHTMLHandler
    {
        HtmlDocument LoadHTMLDocumentFromWeb(string url);

        string ParseHTMLDocument(HtmlDocument doc);
    }
}
