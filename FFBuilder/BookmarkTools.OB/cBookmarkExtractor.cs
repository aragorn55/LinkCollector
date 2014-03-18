using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using Utilities.DL;
namespace BookmarkTools.OB
{
    public class cBookmarkExtractor
    {
        
        public List<string> IdentifyLinks(string vsfileName)
        {
            cFile oFile = new cFile("ExtractedLinks");
            List<string> oLinks = new List<string>();
            StreamReader sr = new StreamReader(vsfileName);
            string input;
            string pattern = @"<A[^>]*?HREF\s*=\s*""([^""]+)""[^>]*?>([\s\S]*?)<\/A>";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            while (sr.Peek() >= 0)
            {
                input = sr.ReadLine();
                
                MatchCollection matches = rgx.Matches(input);

                if (matches.Count > 0)
                {
                   foreach (Match match in matches)
                   {
                       oLinks.Add(match.Value);
                       oFile.Write(match.Value);
                   }

                }
            }
            sr.Close();   
                return oLinks;

        }
    }
}
