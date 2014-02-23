using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using HtmlAgilityPack;
namespace FFtool1.OB
{
    public class cWebFileGrabber
    {
        public bool Test()
        {
            // The HtmlWeb class is a utility class to get the HTML over HTTP
            HtmlWeb htmlWeb = new HtmlWeb();

            // Creates an HtmlDocument object from an URL
            HtmlAgilityPack.HtmlDocument document = htmlWeb.Load("http://www.somewebsite.com");

            // Targets a specific node
            HtmlNode someNode1 = document.GetElementbyId("mynode");

            // If there is no node with that Id, someNode will be null
            if (someNode1 != null)
            {
                // Extracts all links within that node
                IEnumerable<HtmlNode> allLinks = someNode1.Descendants("a");

                // Outputs the href for external links
                foreach (HtmlNode link in allLinks)
                {
                    // Checks whether the link contains an HREF attribute
                    if (link.Attributes.Contains("href"))
                    {
                        // Simple check: if the href begins with "http://", prints it out
                        if (link.Attributes["href"].Value.StartsWith("http://"))
                            Console.WriteLine(link.Attributes["href"].Value);
                    }
                }
            }

            // Targets a specific node
            HtmlNode someNode2 = document.DocumentNode.SelectSingleNode("//*[@id='mynode']");

            // If there is no node with that Id, someNode will be null
            if (someNode2 != null)
            {
                // Extracts all links within that node
                // Note the leading dot (.) to make it look relative to the current node instead of the whole document
                HtmlNodeCollection allLinks1 = someNode2.SelectNodes(".//a");

            }

            // Extracts all links under a specific node that have an href that begins with "http://"
            HtmlNodeCollection allLinks2 = document.DocumentNode.SelectNodes("//*[@id='mynode']//a[starts-with(@href,'http://')]");

            // Outputs the href for external links
            foreach (HtmlNode link in allLinks2)
                Console.WriteLine(link.Attributes["href"].Value);
            return false;
        }
    }
}