using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.DL;
using System.Text.RegularExpressions;

namespace FFTool.OB
{
    public class cUrlTool1
    {
        private string msExportedLinkPath;
        private List<String> msUrlList;
        private List<String> msFFdotNetFics;
        //private List<cFFUrlCategory> moFfUrlLists;
        //private cFFUrlCategory moFFdotNetFics;
        private int iFilesExtracted = 0;
        public List<String> UrlList
        {
            get { return msUrlList; }
            set { msUrlList = value; }
        }
        public string ExportedLinkPath
        {
            get { return msExportedLinkPath; }
            set { msExportedLinkPath = value; }
        }
        public cUrlTool1()
        {
            msUrlList = new List<string>();

        }
        public bool GetLinks(string vsPath)
        {
            try
            {
                List<String> sUrlList = new List<string>();
                cFile oFile = new cFile(vsPath);
                List<string> sFileList = oFile.AllFileList(vsPath);
                for (int iCnt = 0; iCnt < sFileList.Count(); iCnt++)
                {
                    string sFilePath = sFileList[iCnt];
                    LoadLinksFromFile(sFilePath);
                    iFilesExtracted = iFilesExtracted + 1;
                }
                //throw new NotImplementedException();
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public List<String> GetLinksFromFile(string vsPath)
        {
            cFile oFile = new cFile(vsPath);
            //oFile.FileName = ;
            List<String> sUrlList = oFile.ReadList();
            return sUrlList;
            //throw new NotImplementedException();

        }
        public bool LoadLinksFromFile(string vsPath)
        {
            try
            {
                cFile oLogger = new cFile("Error.txt");
                oLogger.Write("++++++++++++++++++++++++++");
                oLogger.Write(vsPath);
                oLogger.Write("++++++++++++++++++++++++++");
                cFile oFile = new cFile(vsPath);
                //oFile.FileName = ;
                List<String> sNewUrlList = oFile.ReadList();
                for (int iCnt1 = 0; iCnt1 < sNewUrlList.Count(); iCnt1++)
                {
                    oLogger.Write("-----" + iCnt1.ToString() + "-----");
                    string sUrl1 = sNewUrlList[iCnt1];
                    oLogger.Write(sUrl1);
                    oLogger.Write("-----" + iCnt1.ToString() + "-----");
                    if (sUrl1.Length >= 28)
                    {
                        sUrl1 = FixFFdotNet(sUrl1);
                    }
                    if (sUrl1.Length >= 5)
                    {
                        msUrlList.Add(sUrl1); ;
                    }
                    
                    
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //throw new NotImplementedException();

        }
        public bool LoadLinksFromFileToList(string vsPath)
        {
            try
            {
                cFile oLogger = new cFile("Error.txt");
                oLogger.Write("++++++++++++++++++++++++++");
                oLogger.Write(vsPath);
                oLogger.Write("++++++++++++++++++++++++++");
                cFile oFile = new cFile(vsPath);
                //oFile.FileName = ;
                string pattern = "\r\n|\n";
                String sNewUrlList = oFile.Read();
                string[] sTs = Regex.Split(sNewUrlList, pattern);
                foreach (string sT in sTs)
                {
                    

                }
                for (int iCnt1 = 0; iCnt1 < sTs.Count(); iCnt1++)
                {
                    oLogger.Write("-----" + iCnt1.ToString() + "-----");
                    string sUrl1 = sTs[iCnt1];
                    oLogger.Write(sUrl1);
                    oLogger.Write("-----" + iCnt1.ToString() + "-----");
					CheckLink(sUrl1);


                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //throw new NotImplementedException();

        }
        public bool WriteLinks(List<string> vsUrlList)
        {
            try
            {
                cFile oFile = new cFile(msExportedLinkPath);
                
                //oFile.FileName = msExportedLinkPath;
                for (int iCnt = 0; iCnt < vsUrlList.Count(); iCnt++)
                {

                    oFile.Write(vsUrlList[iCnt]);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
                
            }
            
        }
        public bool WriteLinks(string vsPath)
        {
            try
            {
                cFile oFile = new cFile(vsPath);

                //oFile.FileName = msExportedLinkPath;
                for (int iCnt = 0; iCnt < UrlList.Count(); iCnt++)
                {

                    oFile.Write(UrlList[iCnt]);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;

            }

        }
        public bool SortLinks(string vsPath)
        {
            try
            {
                cFile oFile = new cFile(vsPath);
                //oFile.FileName = ;
                List<String> sUrlList = oFile.ReadList();
                for (int iCnt = 0; iCnt < sUrlList.Count(); iCnt++)
                {

                    if (sUrlList[iCnt].Substring(0, 26) == "http://m.fanfiction.net/s/")
                    {

                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            throw new System.NotImplementedException();

        }

        public string FixFFdotNet(string vsUrl)
        {
            if (vsUrl.Substring(0, 26) == "http://m.fanfiction.net/s/")
            {
               vsUrl = vsUrl.Replace("http://m.fanfiction.net/s/", "http://www.fanfiction.net/s/");
            }
            if (vsUrl.Substring(0, 28) == "http://www.fanfiction.net/s/")
            {
                
                bool blnFound = true;
                int icnt = 29;
                while (blnFound)
                {
                    if (vsUrl.Substring(icnt, 1) == "/")
                    {
                        int iStart = icnt + 1;
                        int iEnd = iStart;
                        int iLeng = 0;
                        string sOldChapter = "";
                        while (vsUrl.Substring(iEnd, 1) != "/")
                        {
                            sOldChapter = sOldChapter + vsUrl.Substring(iEnd, 1);
                            iEnd += 1;
                            iLeng += 1;
                        
                        }
                        //iLeng += 1;
                        //sOldChapter = sOldChapter;
                        string sStartUrl = vsUrl.Substring(0, iStart);
                        string sEnd = vsUrl.Substring(iEnd);
                        vsUrl = sStartUrl + "1" + sEnd;
                        blnFound = false;
                    }
                    icnt = icnt + 1;
                }

            }
            return vsUrl;




        }
        public bool SortUrls(string vsPath)
        {
            try
            {
                cFile oFile = new cFile(vsPath);
                //oFile.FileName = ;
                List<String> sUrlList = oFile.ReadList();
                for (int iCnt = 0; iCnt < sUrlList.Count(); iCnt++)
                {

                    if (sUrlList[iCnt].Substring(0, 26) == "http://m.fanfiction.net/s/")
                    {

                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            throw new System.NotImplementedException();

        }
        public bool SortFFdotNet(string vsPath)
        {
            try
            {
                cFile oFile = new cFile(vsPath);
                //oFile.FileName = ;
                List<String> sUrlList = oFile.ReadList();
                for (int iCnt = 0; iCnt < sUrlList.Count(); iCnt++)
                {

                    if (sUrlList[iCnt].Substring(0, 26) == "http://m.fanfiction.net/s/")
                    {

                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            throw new System.NotImplementedException();

        }
        public bool CheckLink(string vsURL)
        {
            
            throw new System.NotImplementedException();

        }

        public bool CollectFicFiles(string vsPath)
        {
            throw new System.NotImplementedException();
        }

    }
}
