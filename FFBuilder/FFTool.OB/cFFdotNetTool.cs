using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using mshtml;
using Utilities.DL;
namespace FFtool.OB
{
    public class cFFdotNetTool
    {
        private cFFdotNetFic oFFdotNetFic = new cFFdotNetFic();

        public cFFdotNetFic FFdotNetFic
        {
            get { return oFFdotNetFic; }
            set { oFFdotNetFic = value; }
        }
        public cFFdotNetTool()
        {
            cFFdotNetFic oFFdotNetFic = new cFFdotNetFic();
        }
        public bool DownloadFic(string vsURL)
        {
            cWeb oWeb = new cWeb();
            oWeb.GrabPageToFile(vsURL, "Test.html");
            

            return false;

        }
        public void FormatPage()
        {
            HtmlDocument doc = new HtmlDocument();
            doc.Load("Test.html");
            HtmlNode oNode = doc.GetElementbyId("gui_table1");
                for (int iCnt = 0; iCnt < oNode.Attributes.Count(); iCnt++)
            {

                //Console.WriteLine(oNode.Attributes[iCnt]);
                HtmlAttribute oAtt = oNode.Attributes[iCnt];
                Console.WriteLine(oAtt.Value);
            }

        }
        public bool test(string vsURL)
        {
            // The HtmlWeb class is a utility class to get the HTML over HTTP
            HtmlWeb htmlWeb = new HtmlWeb();

            // Creates an HtmlDocument object from an URL
            HtmlAgilityPack.HtmlDocument document = htmlWeb.Load(vsURL);

            // Targets a specific node
            HtmlNode someNode = document.GetElementbyId("mynode");
            GetTitle(document);
            GetSummary(document);
            
            GetDate(document);
            GetChapter(document);
            GetTotalChapters(document);
            GetFicId(document);
            GetAuthor(document);
            GetBody(document);
           
            
            // Get Title
            
            
            
            
           
    
    return true;
        }

        private void GetAuthor(HtmlAgilityPack.HtmlDocument document)
        {
            throw new NotImplementedException();
            //this simply works because InnerText is iterative for all child nodes
            HtmlAgilityPack.HtmlNodeCollection nodes = document.DocumentNode.SelectNodes("Date XPath");
            //but to be more accurate you can use the next line instead
            //HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//td[@class='title']/a");
            string result = "";

            result = "";
            if (GetData(nodes, ref result))
            {
                //oFFdotNetFic.ChapterText
                oFFdotNetFic.LastUpdated1 = result;
            }
            else
            {
                cFile oFile = new cFile("error.txt");
                oFile.Write("___________");
                oFile.Write("LastUpdated1 Failed got back: " + result);
                oFile.Write("___________");
            }
        }

        private void GetFicId(HtmlAgilityPack.HtmlDocument document)
        {
            throw new NotImplementedException();
            //this simply works because InnerText is iterative for all child nodes
            HtmlNodeCollection nodes = document.DocumentNode.SelectNodes("Date XPath");
            //but to be more accurate you can use the next line instead
            //HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//td[@class='title']/a");
            string result = "";

            result = "";
            if (GetData(nodes, ref result))
            {
                //oFFdotNetFic.ChapterText
                oFFdotNetFic.LastUpdated1 = result;
            }
            else
            {
                cFile oFile = new cFile("error.txt");
                oFile.Write("___________");
                oFile.Write("LastUpdated1 Failed got back: " + result);
                oFile.Write("___________");
            }
        }

        private void GetTotalChapters(HtmlAgilityPack.HtmlDocument document)
        {
            throw new NotImplementedException();
            //this simply works because InnerText is iterative for all child nodes
            HtmlNodeCollection nodes = document.DocumentNode.SelectNodes("Date XPath");
            //but to be more accurate you can use the next line instead
            //HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//td[@class='title']/a");
            string result = "";

            result = "";
            if (GetData(nodes, ref result))
            {
                //oFFdotNetFic.ChapterText
                oFFdotNetFic.LastUpdated1 = result;
            }
            else
            {
                cFile oFile = new cFile("error.txt");
                oFile.Write("___________");
                oFile.Write("LastUpdated1 Failed got back: " + result);
                oFile.Write("___________");
            }
        }

        private void GetChapter(HtmlAgilityPack.HtmlDocument document)
        {
            throw new NotImplementedException();
            //this simply works because InnerText is iterative for all child nodes
            HtmlNodeCollection nodes = document.DocumentNode.SelectNodes("Date XPath");
            //but to be more accurate you can use the next line instead
            //HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//td[@class='title']/a");
            string result = "";

            result = "";
            if (GetData(nodes, ref result))
            {
                //oFFdotNetFic.ChapterText
                oFFdotNetFic.LastUpdated1 = result;
            }
            else
            {
                ProcessError("GetChapter", result);
            }
        }

        private static void ProcessError(string vsErrorType, string result)
        {
            cFile oFile = new cFile("error.txt");
            oFile.Write("___________");
            oFile.Write(vsErrorType + " Failed got back: " + result);
            oFile.Write("___________");
        }

        private void GetBody(HtmlAgilityPack.HtmlDocument document)
        {
            throw new NotImplementedException();
            //this simply works because InnerText is iterative for all child nodes
            HtmlNodeCollection nodes = document.DocumentNode.SelectNodes("Date XPath");
            //but to be more accurate you can use the next line instead
            //HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//td[@class='title']/a");
            string result = "";

            result = "";
            if (GetData(nodes, ref result))
            {
                //oFFdotNetFic.ChapterText
                oFFdotNetFic.LastUpdated1 = result;
            }
            else
            {
                cFile oFile = new cFile("error.txt");
                oFile.Write("___________");
                oFile.Write("LastUpdated1 Failed got back: " + result);
                oFile.Write("___________");
            }

        }
        //Xpath
        private void GetDate(HtmlAgilityPack.HtmlDocument document)
        {
            throw new NotImplementedException();
            //this simply works because InnerText is iterative for all child nodes
            HtmlNodeCollection nodes = document.DocumentNode.SelectNodes("Date XPath");
            //but to be more accurate you can use the next line instead
            //HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//td[@class='title']/a");
            string result = "";

            result = "";
            if (GetData(nodes, ref result))
            {
                //oFFdotNetFic.ChapterText
                oFFdotNetFic.LastUpdated1 = result;
            }
            else
            {
                cFile oFile = new cFile("error.txt");
                oFile.Write("___________");
                oFile.Write("LastUpdated1 Failed got back: " + result);
                oFile.Write("___________");
            }
        }

        private void GetTitle(HtmlAgilityPack.HtmlDocument document)
        {
            throw new NotImplementedException();
            //this simply works because InnerText is iterative for all child nodes
            HtmlNodeCollection nodes = document.DocumentNode.SelectNodes("html/body/div[4]/div/div/table/tbody/tr/td/table/tbody/tr[1]/td/b");
            //but to be more accurate you can use the next line instead
            //HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//td[@class='title']/a");
            string result = "";

            result = "";
            if (GetData(nodes, ref result))
            {
                oFFdotNetFic.StoryName = result;
            }
            else
            {
                cFile oFile = new cFile("error.txt");
                oFile.Write("___________");
                oFile.Write("StoryName Failed got back: " + result);
                oFile.Write("___________");
            }
        }

        private void GetSummary(HtmlAgilityPack.HtmlDocument document)
        {
            //this simply works because InnerText is iterative for all child nodes
            HtmlNodeCollection nodes = document.DocumentNode.SelectNodes("html/body/div[4]/div/div/table/tbody/tr/td/table/tbody/tr[1]/td/div[1]/text()");
            //but to be more accurate you can use the next line instead
            //HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//td[@class='title']/a");
            string result = "";

            result = "";
            if (GetData(nodes, ref result))
            {
                oFFdotNetFic.Summary = result;
            }
            else
            {
                cFile oFile = new cFile("error.txt");
                oFile.Write("___________");
                oFile.Write("Summary Failed got back: " + result);
                oFile.Write("___________");
            }
        }

        private bool GetData(HtmlNodeCollection nodes, ref string result)
        {
            List<string> results = new List<string>();
            foreach (HtmlNode item in nodes)
            {
                results.Add(item.InnerText);
                result = item.InnerText;
                cFile oFile = new cFile("nodes.txt");
                oFile.Write("___________");
                oFile.Write(item.XPath.ToString());
                oFile.Write(result);
                oFile.Write("___________");
            }
            if (results.Count == 1)
            {
                result = results[0].ToString();
                return true;
            }
            return false;
            throw new NotImplementedException();
        }
        public void writeChildren(HtmlNode vNode)
        {
            cFile oFile = new cFile("nodes.txt");
            foreach (HtmlNode link in vNode.ChildNodes)
            {
                oFile.Write("--");
                oFile.Write("-----------------------------");
                oFile.Write("-----------------------------");
                oFile.Write("--");
                oFile.Write(link.Name.ToString());
                oFile.Write(link.XPath.ToString());
                oFile.Write(link.InnerHtml);
              //  writeChildren(link);

            }

        }
        public bool test2()
        {
            HtmlDocument doc = new HtmlDocument();
            doc.Load("Test.html");
          //HtmlNode link = new HtmlNode(doc.DocumentNode.SelectSingleNode("<title>")

            HtmlNode link = doc.DocumentNode;
            HtmlNode link1 = link.SelectSingleNode("/html[1]/body[1]");
           // oFFdotNetFic.StoryName =  doc.DocumentNode.SelectSingleNode("title").InnerHtml;
                //oFFdotNetFic.StoryName = link.InnerText();
                oFFdotNetFic.StoryName = link1.InnerHtml;
           
            
            List<string> hrefTags = new List<string>();
          
            
    
    return true;
        }
        public bool test3(string vsURL)
        {
            cWeb oWeb = new cWeb();
            string htmlContent = oWeb.GrabPageToString(vsURL);
            

            // Obtain the document interface
            IHTMLDocument2 htmlDocument = (IHTMLDocument2)new mshtml.HTMLDocument();

            // Construct the document
            htmlDocument.write(htmlContent);
            //htmlDocument.
            List<IHTMLElement> oOut = new List<IHTMLElement>();


            // Extract all elements
            IHTMLElementCollection allElements = htmlDocument.all;
            cFile oFile = new cFile("ele.txt");
            // Iterate all the elements and display tag names
            foreach (IHTMLElement element in allElements)
            {
               
                oFile.Write(element.tagName);
                
            }

            return false;
        }

        public bool FindName(HtmlDocument vdoc)
        {
          

            HtmlNode link = vdoc.DocumentNode;
            HtmlNode link1 = link.SelectSingleNode("/html[1]/head[1]/title[1]");
            // oFFdotNetFic.StoryName =  doc.DocumentNode.SelectSingleNode("title").InnerHtml;
            //oFFdotNetFic.StoryName = link.InnerText();
            oFFdotNetFic.StoryName = link1.InnerHtml;
            return true;
        }
        
        
        

        
        

    }
}
