using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookmarkCollector.ob;

namespace BookmarkCollector.Console
{
    public class CBKCollector
    {
        private CBookmarkReader oReader = new CBookmarkReader();

        public bool CollectFromText(string vsInput)
        {


            if (oReader.GetLinkFilesFromFile(vsInput))
            {
                if (oReader.ReadLinksFromTextFiles())
                {
                    oReader.SaveLinks();
                    return true;
                }
            }
            return false;

        }

        public bool CollectFromHtml(string vsInput)
        {


            if (oReader.GetLinkFilesFromFile(vsInput))
            {
                if (oReader.ReadWriteLinksFromHtmlFiles())
                {
                    oReader.SaveLinks();
                    return true;
                }
            }
            return false;
        }
    }
}
