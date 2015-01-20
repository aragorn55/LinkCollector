using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  FicFileLinkCollector.OB;
namespace FicFileLinkCollector.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //CFicProcessor oProcessor = new CFicProcessor();
            CTest oTest = new CTest();
            oTest.ProcessEpubList("epub.txt", "testepub.txt");
            //oProcessor.ProcessEpubList("epub.txt", "epubout.txt");
           // oProcessor.ProcessHtmlList("html.txt", "htmlout.txt");
        }
    }
}
