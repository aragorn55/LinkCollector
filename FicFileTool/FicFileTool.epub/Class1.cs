using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  eBdb.EpubReader;
namespace FicFileTool.epub
{
    public class Class1
    {
        private 
        //Init epub object.
        Epub epub = new Epub(@"c:\example.epub");
        
        //Get book title (Every epub file can have multiple titles)
        string title = epub.Title[0];

        //Get book authors (Every epub file can have multiple authors)
        string author = epub.Creator[0];

        //Get all book content as plain text
        string plainText = epub.GetContentAsPlainText();

        //Get all book content as html text
        string htmlText = epub.GetContentAsHtml();

        //Get some part of book content
        ContentData contentData = epub.Content[0] as ContentData;

        //Get Table Of Contents (TOC)
        List<NavPoint> navPoints = epub.TOC;
    }
}
