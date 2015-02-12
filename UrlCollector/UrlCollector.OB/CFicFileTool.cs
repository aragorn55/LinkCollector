using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.DL;
namespace UrlCollector.OB
{
    public class CFicFileTool
    {
        public CFile oSaveFile = new CFile("FicUrls.txt");
        

        public CFicFileTool()
        {
            
        }

        public bool ProcessFileList(string vsFileInput, string vsOutput)
        {
            try
            {
                CFile oFile = new CFile(vsFileInput);
                oSaveFile.FileName = vsOutput;
                List<string> epubList = oFile.ReadList();
                foreach (var spath in epubList)
                {

                    ProcessFile(spath);
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

        public bool ProcessFile1(string spath)
        {

            try
            {
                ExtractFromFile(spath);
            }
            catch (Exception ex)
            {

                oSaveFile.WriteLog(spath, "error.log");
                oSaveFile.WriteLog(ex.Message, "error.log");
                return false;
            }

            return false;
        }

        private List<string> ExtractFromFile(string spath)
        {
            if (spath.Substring(spath.Length - 5) == ".epub")
            {
                ProcessEpub(spath);
                var oList = ExtractFromEpub(spath);
                return oList;
            }
            else
            {
                var oList = ExtractFromText(spath);
                return oList;
            }
        }

      

      

        private bool ProcessFile(string spath)
        {

            try
            {
                if (spath != null)
                {

                    var oList = ExtractFromFile(spath);
                    if (oList.Count > 0)
                    {
                        foreach (var variable in oList)
                        {
                            oSaveFile.Write(variable);
                        }
                        return true;
                    }

                    oSaveFile.WriteLog(spath + " | empty", "error.log");


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
        private bool ProcessText(string spath)
        {

            try
            {
                if (spath != null)
                {
                    var oList = ExtractFromText(spath);

                    if (oList.Count > 0)
                    {
                        foreach (var variable in oList)
                        {
                            oSaveFile.Write(variable);
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

        private List<string> ExtractFromText(string spath)
        {
            CTextFile oTextFile = new CTextFile(spath);

            Console.WriteLine(spath);
            List<string> oList = oTextFile.FindUrlsList();
            return oList;
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
                    var oList = ExtractFromEpub(spath);

                    if (oList.Count > 0)
                    {
                        foreach (var variable in oList)
                        {
                            oSaveFile.Write(variable);
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

        private List<string> ExtractFromEpub(string spath)
        {
            CEpubFile oEpubFile = new CEpubFile(spath);

            Console.WriteLine(spath);
            List<string> oList = oEpubFile.FindUrlsList();
            return oList;
        }
        private List<string> ExtractFromRtf(string spath)
        {
            CRtfFile oRtfFile= new CRtfFile(spath);

            Console.WriteLine(spath);
            List<string> oList = oRtfFile.FindUrlsList();
            return oList;
        }
    }

  
}
