using System.Text.RegularExpressions;
public class CBookmarkExtractor
{
	public void ExtractBookmark(string vstrBookmark)
	{
		CFileManager oFile = default(CFileManager);
		oFile = new CFileManager();
		string mstrBookmark = null;
		mstrBookmark = MYIdentifyLinks(vstrBookmark);
		oFile.SaveLinks(mstrBookmark);
	}

	public string MYIdentifyLinks(string htmlText)
	{
		Regex hrefRegex = new Regex("<A[^>]*?HREF\\s*=\\s*\"([^\"]+)\"[^>]*?>([\\s\\S]*?)<\\/A>", RegexOptions.IgnoreCase);
		string output = "";
		//          
		foreach (Match m in hrefRegex.Matches(htmlText)) {
			output += m.Groups(1).Value;
			return output;
		}
	}
}
