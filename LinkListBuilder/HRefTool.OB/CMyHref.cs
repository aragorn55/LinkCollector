using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace HRefTool.OB
{
	public class CMyHref
	{
		public CMyHref ()
		{
		}
		public List<string> DumpHRefs(string inputString)
		{
			List<string> oLinkList = new List<string> ();
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
					oLinkList.Add (m.Groups[1].Value);
					m = m.NextMatch();
				}
			}
			catch (RegexMatchTimeoutException)
			{
				Console.WriteLine("The matching operation timed out.");
			}
			return oLinkList;
		}

	}
}

