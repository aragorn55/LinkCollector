using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Text.RegularExpressions;
namespace BookmarkSorted2.shared
{
	public class CBookmarkExtractor
	{
		public void ExtractBookmark(string vstrBookmark)
		{
			CFileManager oFile = null;
			oFile = new CFileManager();
			string mstrBookmark = null;
			mstrBookmark = MYIdentifyLinks(vstrBookmark);

			oFile.SaveLinks(mstrBookmark);

		}
		/// <summary>Identifies hyperlinks in HTML text.</summary>
		/// <param name="htmlText">HTML text to parse.</param>
		/// <remarks>This method displays the label and destination for
		/// each link in the input text.</remarks>
		public string MYIdentifyLinks(string htmlText)
		{
			Regex hrefRegex = new Regex("<A[^>]*?HREF\\s*=\\s*\"([^\"]+)\"[^>]*?>([\\s\\S]*?)<\\/A>", RegexOptions.IgnoreCase);
			string output = "";
			foreach (Match m in hrefRegex.Matches(htmlText)) {
				//          output &= "Link label: " & m.Groups(2).Value & vbCrLf
				output += m.Groups[1].Value;

			}
			return output;
		}
		/// <summary>Identifies hyperlinks in HTML text.</summary>
		/// <param name="htmlText">HTML text to parse.</param>
		/// <remarks>This method displays the label and destination for
		/// each link in the input text.</remarks>
		public void IdentifyLinks(string htmlText)
		{
			Regex hrefRegex = new Regex("<A[^>]*?HREF\\s*=\\s*\"([^\"]+)\"[^>]*?>([\\s\\S]*?)<\\/A>", RegexOptions.IgnoreCase);
			string output = "";
			foreach (Match m in hrefRegex.Matches(htmlText)) {
				output += "Link label: " + m.Groups[2].Value + Environment.NewLine;
				output += "Link destination: " + m.Groups[1].Value + Environment.NewLine;
			}
			Console.Write(output);
		}
	}
}
