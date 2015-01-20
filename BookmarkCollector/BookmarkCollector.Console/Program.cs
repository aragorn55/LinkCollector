using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookmarkCollector.Console
{
    static class Program
    {
        static void Main(string[] args)
        {
            CBKCollector oCollector = new CBKCollector();
            oCollector.CollectFromText("in.txt");
            System.Console.Write("done");
        }
    }
}
