using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zip;

namespace Utilities.zip
{
    public class CEpubZip
    {
        private string msFilePath = "";
        private List<string> _urList = new List<string>();
        public CEpubZip(string vsPath)
        {
            msFilePath = vsPath;
        }

        public List<string> FindUrlsList()
        {
            using (var ms = new MemoryStream())
            {
                using (var zip = ZipFile.Read(msFilePath))
                {
                    int totalEntries = zip.Entries.Count;
                    foreach (ZipEntry e in zip.Entries)
                    {
                        e.Extract(ms);
                        var sr = new StreamReader(ms);
                        var myStr = sr.ReadToEnd();
                        SearchEntry(myStr);
                    }
                }

                
                // the application can now access the MemoryStream here
            }

            return _urList;
        }
    

        private void SearchEntry(string e)
        {
            CTextUrlSearch oSearch = new CTextUrlSearch();
            List<string> voList = oSearch.GetLinks(e);
            foreach (var oUrl in voList)
            {
                _urList.Add(oUrl);
            }

        }
  
    }
}
