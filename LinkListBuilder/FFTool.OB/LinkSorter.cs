using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.DL;
namespace FFTool.OB
{
    public class LinkSorter
    {
private string msFileName = "LinkCategories.txt";
	private cLinkCategorie oLinkCategories;
	public void SortBookmark(string vstrBookmark)
	{
        cFile oFile = new cFile();

		int intCount = 0;

		for (int intSearched = 0; intSearched <= (oLinkCategories.Catagories.Count - 1); intSearched++) {
            cLinkCategory oLinkCategory = new cLinkCategory();
			oLinkCategory = oLinkCategories.Catagories[intSearched];
			intCount = vstrBookmark.IndexOf(oLinkCategory.LinkDefine);
			if (intCount >= 0) {
				oFile.SaveLink(vstrBookmark, oLinkCategory.FileName);
			}
		}


		oFile.SaveLink(vstrBookmark, "miscBookmarks.txt");



	}
	public LinkSorter()
	{
		oLinkCategories = new cLinkCategorie();
		oLinkCategories.Load();


	}
	public void SortBookmarkDB(string vstrBookmark)
	{
		cFile oFile = new cFile();
		

		int intCount = 0;

        for (int intSearched = 0; intSearched <= (oLinkCategories.Catagories.Count - 1); intSearched++)
        {
			//cLinkCategory oLinkCategory = default(cLinkCategory);
			//oLinkCategory = (cLinkCategory)oLinkCategories.Item(intSearched);
			//intCount = vstrBookmark.IndexOf(oLinkCategory.LinkDefine);
            cLinkCategory oLinkCategory = new cLinkCategory();
            oLinkCategory = oLinkCategories.Catagories[intSearched];
            intCount = vstrBookmark.IndexOf(oLinkCategory.LinkDefine);
			if (intCount >= 0) {
				oFile.SaveLink(vstrBookmark, oLinkCategory.FileName);
			}
		}


		oFile.SaveLink(vstrBookmark, "miscBookmarks.txt");



	}
    }
}
