using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.DL;
namespace UrlCollector.OB
{
    public class CTest
    {
        public CFile oSaveFile = new CFile("FicUrls.txt");

        public CTest()
        {
            
        }


        public bool ProcessEpubList(string vsFileInput, string vsOutput)
        {
            try
            {
                CFile oFile = new CFile(vsFileInput);
                oSaveFile.FileName = vsOutput;
                List<string> epubList = oFile.ReadList();
                foreach (var spath in epubList)
                {
                    ProcessEpub(spath);
                }
                return true;
            }
            catch (Exception ex)
            {

                oSaveFile.WriteLog(vsFileInput, "error.log");
                oSaveFile.WriteLog(ex.Message, "error.log");
                return false;
            }

        }

        public bool ProcessEpub(string spath)
        {
            try
            {
                if (spath != null)
                {
                    CEpubFile oEpubFile = new CEpubFile(spath);

                    Console.Write(spath);
                    List<string> oList = oEpubFile.FindUrlsList();

                    if (oList.Count > 0)
                    {
                        foreach (var VARIABLE in oList)
                        {
                            oSaveFile.Write(VARIABLE);
                        }
                        return true;
                    }

                    oSaveFile.WriteLog(spath, "error.log");


                    return false; 
                }
                else
                {
                    oSaveFile.WriteLog("empty", "error.log");
                    return false;
                }
            }
            catch (Exception ex)
            {

                oSaveFile.WriteLog(spath, "error.log");
                oSaveFile.WriteLog(ex.Message, "error.log");
                return false;
            }


        }
    }

  
}
