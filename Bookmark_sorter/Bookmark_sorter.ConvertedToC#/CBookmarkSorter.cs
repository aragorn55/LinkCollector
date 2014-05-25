using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
namespace Bookmark_sorter
{
	public class CBookmarkSorter
	{
		public void SortBookmark(string vstrBookmark)
		{
			CFileManager oFile = null;
			oFile = new CFileManager();
			int intCount = 0;
			intCount = vstrBookmark.IndexOf("fanfiction.net");
			if (intCount >= 0) {
				oFile.SaveFF_net(vstrBookmark);
			} else if (vstrBookmark.IndexOf("addventure") >= 0) {
				oFile.SaveAddv(vstrBookmark);
			} else {
				oFile.SaveOtherBkmk(vstrBookmark);

			}
		}
	}
}
