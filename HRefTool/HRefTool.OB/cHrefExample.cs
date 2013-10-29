using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HRefTool.OB
{
    public class CHrefExample
    {
        private static void DumpHRefs(string inputString)
        {
            Match m;
            string HRefPattern = "href\\s*=\\s*(?:[\"'](?<1>[^\"']*)[\"']|(?<1>\\S+))";

            try
            {
                m = Regex.Match(inputString, HRefPattern,
                                RegexOptions.IgnoreCase | RegexOptions.Compiled,
                                TimeSpan.FromSeconds(1));
                while (m.Success)
                {
                    Console.WriteLine("Found href " + m.Groups[1] + " at "
                       + m.Groups[1].Index);
                    m = m.NextMatch();
                }
            }
            catch (RegexMatchTimeoutException)
            {
                Console.WriteLine("The matching operation timed out.");
            }
        }
        public static void Main()
        {
            string inputString = "My favorite web sites include:</P>" +
                                 "<A HREF=\"http://msdn2.microsoft.com\">" +
                                 "MSDN Home Page</A></P>" +
                                 "<A HREF=\"http://www.microsoft.com\">" +
                                 "Microsoft Corporation Home Page</A></P>" +
                                 "<A HREF=\"http://blogs.msdn.com/bclteam\">" +
                                 ".NET Base Class Library blog</A></P>";
            DumpHRefs(inputString);

        }
        // The example displays the following output: 
        //       Found href http://msdn2.microsoft.com at 43 
        //       Found href http://www.microsoft.com at 102 
        //       Found href http://blogs.msdn.com/bclteam at 176
    }
}
