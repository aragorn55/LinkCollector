using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.DL;

namespace FFTool.OB
{
    public class cUrlTool
    {
        private cFFdotNetFics oFFdotNets = new cFFdotNetFics();
        private string msExportedLinkPath;
        private List<String> msUrlList;
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
        public cUrlTool()
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
            catch 
            {

                throw; //ex;
            }
        }
        public void AddUrlList(List<String> vsUrlList)
        {
            for (int iCnt = 0; iCnt < vsUrlList.Count(); iCnt++)
            {
                msUrlList.Add(vsUrlList[iCnt]);
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
            catch
            {

                throw; //ex;
            }
           // catch (Exception ex)
           // {
           //     throw ex;
           // }
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
            catch
            {

                throw; //ex;
            }
        }
        public void Sort()
        {
            LinkSorter oSorter = new LinkSorter();

            for (int iCnt = 0; iCnt < msUrlList.Count(); iCnt++)
            {
                oSorter.SortBookmark(msUrlList[iCnt]);
                FixFFdotNet(msUrlList[iCnt]);
                
            }
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
                string sId = "";
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
                        cFFdotNetFic oFic = new cFFdotNetFic();
                        oFic.StoryLink = vsUrl;
                        oFic.StoryId = sId;
                        oFFdotNets.Add(oFic);
                        blnFound = false;
                    }
                    else
                    {
                        sId += vsUrl.Substring(icnt, 1);
                    }
                    icnt = icnt + 1;
                }

            }
            return vsUrl;




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
            catch
            {

                throw; //ex;
            }
            throw new System.NotImplementedException();

        }

    }
}
