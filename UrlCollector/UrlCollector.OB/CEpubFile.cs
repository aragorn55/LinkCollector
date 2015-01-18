using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.zip;
namespace UrlCollector.OB
{
    public class CEpubFile
    {
        private string msFilePath = "";
        private List<string> _urList = new List<string>();
        public CEpubFile(string vsPath)
        {
            msFilePath = vsPath;
        }

        public List<string> FindUrlsList()
        {
          CEpubZip oEpubZip = new CEpubZip(msFilePath);
              
                    foreach (var e in oEpubZip.ReturnEpubContents())
                    {
                       
                        SearchEntry(e);
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
