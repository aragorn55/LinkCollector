using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.zip;
namespace FicFileLinkCollector.OB
{
    public class CTest: CFicProcessor
    {
        public CTest()
        {
            
        }
        private bool ProcessEpub(string spath)
        {
            try
            {
                CEpubZip oEpubFile = new CEpubZip(spath);
                
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
            catch (Exception ex)
            {

                oSaveFile.WriteLog(spath, "error.log");
                oSaveFile.WriteLog(ex.Message, "error.log");
                return false;
            }


        }
    }
}
