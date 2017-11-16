using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.IO;

namespace splash_rss.Data
{
    public class HTMLHandler : IHTMLHandler
    {
        const string xBody = @"//body";
        string[] xHeadings = { @"/h1", @"/h2", @"/h3", @"/h4", @"/h5", @"/h6" };
        const string xParagraph = @"/p";
        const string xDiv = @"/div";

        public HtmlDocument LoadHTMLDocumentFromWeb(string url)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            return doc;
        }

        public string ParseHTMLDocument(HtmlDocument doc)
        {
            string bodyHtml = doc.DocumentNode.SelectSingleNode(xBody).InnerHtml;

            HtmlToText h2t = new HtmlToText();
            var text = h2t.ConvertHtml(bodyHtml);

            // headings:
            foreach(string heading in xHeadings)
            {
                Console.WriteLine("Heading: [" + heading + "]");

                string nodeSelector = xBody + heading;
                try
                {
                    foreach (HtmlNode node in doc.DocumentNode.SelectNodes(nodeSelector))
                    {
                        Console.WriteLine("[" + nodeSelector + "]: " + node.InnerText);
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine("Selector not found: [" + nodeSelector + "]");
                }

                Console.WriteLine();
                Console.ReadLine();
            }

            // paragraphs:
            string selecta = xBody + xDiv;
            try
            {
                foreach(HtmlNode node in doc.DocumentNode.SelectNodes(selecta))
                {
                    Console.WriteLine("[" + selecta + "]: " + node.InnerText);

                    Console.WriteLine();
                    Console.ReadLine();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Selecta not found: [" + selecta + "]");

                Console.WriteLine();
                Console.ReadLine();
            }

            
            return doc.DocumentNode.SelectSingleNode(xBody).InnerText;
        }
    }

    public class HtmlToText
    {
        public HtmlToText()
        {
        }

        public string Convert(string path)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.Load(path);

            StringWriter sw = new StringWriter();
            ConvertTo(doc.DocumentNode, sw);
            sw.Flush();
            return sw.ToString();
        }

        public string ConvertHtml(string html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            StringWriter sw = new StringWriter();
            ConvertTo(doc.DocumentNode, sw);
            sw.Flush();
            return sw.ToString();
        }

        private void ConvertContentTo(HtmlNode node, TextWriter outText)
        {
            foreach (HtmlNode subnode in node.ChildNodes)
            {
                ConvertTo(subnode, outText);
            }
        }

        public void ConvertTo(HtmlNode node, TextWriter outText)
        {
            string html;
            switch (node.NodeType)
            {
                case HtmlNodeType.Comment:
                    // don't output comments
                    break;

                case HtmlNodeType.Document:
                    ConvertContentTo(node, outText);
                    break;

                case HtmlNodeType.Text:
                    // script and style must not be output
                    string parentName = node.ParentNode.Name;
                    if ((parentName == "script") || (parentName == "style"))
                        break;

                    // get text
                    html = ((HtmlTextNode)node).Text;

                    // is it in fact a special closing node output as text?
                    if (HtmlNode.IsOverlappedClosingElement(html))
                        break;

                    // check the text is meaningful and not a bunch of whitespaces
                    if (html.Trim().Length > 0)
                    {
                        outText.Write(HtmlEntity.DeEntitize(html));
                    }
                    break;

                case HtmlNodeType.Element:
                    switch (node.Name)
                    {
                        case "p":
                            // treat paragraphs as crlf
                            outText.Write("\r\n");
                            break;
                    }

                    if (node.HasChildNodes)
                    {
                        ConvertContentTo(node, outText);
                    }
                    break;
            }
        }
    }
}
