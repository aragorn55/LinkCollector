using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Text.RegularExpressions;
namespace Bookmark_sorter
{
	public class CBookmarkExtractor
	{
		public void ExtractBookmark(string vstrBookmark)
		{
			CFileManager oFile = null;
			oFile = new CFileManager();
			string mstrBookmark = null;
			mstrBookmark = MYIdentifyLinks(vstrBookmark);
			//    Dim intCount As Integer
			//      intCount = vstrBookmark.IndexOf(Chr(34))
			//    If intCount >= 0 Then
			//intCount += 1
			//   For intCount1 As Integer = intCount To (vstrBookmark.Length - 1)
			//If vstrBookmark.Substring(intCount, intCount + 1) = Chr(34) Then
			//intCount = vstrBookmark.Length + 1
			//    Else
			//    mstrBookmark = mstrBookmark & vstrBookmark.Substring(intCount, intCount + 1)
			//    intCount += 1
			//    End If

			//    Next
			oFile.SaveLinks(mstrBookmark);
			//    End If
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
				return output;
			}
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
				output += "Link label: " + m.Groups[2].Value + Constants.vbCrLf;
				output += "Link destination: " + m.Groups[1].Value + Constants.vbCrLf;
			}
			Interaction.MsgBox(output);
		}
	}
}
