using System;
using System.Collections.Generic;
using Utilities.DL;
namespace UrlCollector.OB
{
    public class CTextFile
    {
        
        private string msFilePath = "";
        private List<string> _urList = new List<string>();
        public CTextFile(string spath)
        {
            msFilePath = spath;
        }

        public List<string> FindUrlsList()
        {
            try
            {
                CFile oFile = new CFile(msFilePath);
                string e = oFile.Read();
                CTextUrlSearch oSearch = new CTextUrlSearch();
                List<string> voList = oSearch.GetLinks(e);
                foreach (var oUrl in voList)
                {
                    _urList.Add(oUrl);
                }
            }
            catch (System.Exception ex)
            {
                CFile oFile = new CFile();
                oFile.WriteLog(ex.Message, "error.log");
                Console.WriteLine(ex.Message);
                throw;
            }
            return _urList;
        }
    }
}