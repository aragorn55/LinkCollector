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
            
           System.Console.WriteLine("test");
            CTest oTest = new CTest();
            oTest.ProcessEpubList("epub.txt", "testepub.txt");
        }
    }
}
