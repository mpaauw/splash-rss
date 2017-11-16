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
}
