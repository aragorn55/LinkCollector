using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlCollector.OB;
namespace UrlCollector.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WindowWidth = 192;
           System.Console.Write("test");
            CTest oTest = new CTest();
            oTest.ProcessEpubList("epub.txt", "testepub.txt");
        }
    }
}
