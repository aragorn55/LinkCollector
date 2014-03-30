using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.DL;
namespace FFTool.OB
{
    public class cLinkCollector
    {
        private cFFdotNetFics oFFdotNets = new cFFdotNetFics();
        private string msExportedLinkPath;
        private List<String> msUrlList;
        private int iFilesExtracted = 0;
		private bool blnErrors = false;
        private List<string> sFileList;

        public List<string> FileList
        {
            get { return sFileList; }
            set { sFileList = value; }
        }
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
        public cLinkCollector()
        {
            msUrlList = new List<string>();

        }
        public bool GetLink(string vsPath)
        {
            cFile oFile = new cFile(vsPath);
      
            List<String> sUrlList = new List<string>();
            try
            {
                sFileList = oFile.AllFileList(vsPath);
                Parallel.For(0, sFileList.Count, x =>
                {
                    string sFilePath = sFileList[x];
                    LoadToFile(sFilePath);
                    iFilesExtracted = iFilesExtracted + 1;
                });

                return true;
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }
        public bool GetLinks(string vsPath)
        {
            cFile oFile = new cFile(vsPath);
            cFile oLogger = new cFile("GetLinksErrorFilePaths.txt");

            List<String> sUrlList = new List<string>();
            try
            {
               sFileList = oFile.AllFileList(vsPath);
               Parallel.For(0, sFileList.Count, x =>
               {
                   string sFilePath = sFileList[x];
                   LoadLinksFromFile(sFilePath);
                   iFilesExtracted = iFilesExtracted + 1;
               });
                
                //throw new NotImplementedException();
                return true;
            }
            catch (Exception ex)
            {
                oFile.WriteLog(ex.Message, "GetLinksError.log");
                throw ex;
            }
        }
        public bool LoadToFile(string vsPath)
        {
            cFile oFile = new cFile(vsPath);
            try
            {     
                List<String> sNewUrlList = oFile.ReadList();
                Parallel.For(0, sNewUrlList.Count, x =>
                {
                    string sUrl1 = sNewUrlList[x];
                    oFile.SaveLink(sUrl1, msExportedLinkPath);
                });
              oFile.Delete();

                return true;
            }

            catch (Exception ex)
            {
                
                throw ex;
            }
            //throw new NotImplementedException();

        }
        public bool GetLinks(string vsPath, string vsExten)
        {
            cFile oFile = new cFile(vsPath);
            try
            {
                List<String> sUrlList = new List<string>();
               
                sFileList = oFile.AllFileListWExten(vsPath, vsExten);
                Parallel.For(0, sFileList.Count, x =>
               {
                   string sFilePath = sFileList[x];
                   LoadLinksFromFile(sFilePath);
                   iFilesExtracted = iFilesExtracted + 1;
               });
                return true;
            }
            catch (Exception ex)
            {
                oFile.WriteLog(ex.Message, "GetLinksWExtenError.log");
                throw ex;
            }
        }

        public bool LoadLinksFromFile(string vsPath)
        {
            cFile oLogger = new cFile("LoadLinksFromFile.Log");
            try
            {
                
               // oLogger.Write("++++++++++++++++++++++++++");
             //   oLogger.Write(vsPath);
               // oLogger.Write("++++++++++++++++++++++++++");
                cFile oFile = new cFile(vsPath);
                //oFile.FileName = ;
                List<String> sNewUrlList = oFile.ReadList();
                Parallel.For(0, sNewUrlList.Count, x =>
               {
                   string sUrl1 = sNewUrlList[x];
                   // oLogger.Write(sUrl1);
                   // oLogger.Write("-----" + iCnt1.ToString() + "-----"); 
                   msUrlList.Add(sUrl1); ;
               });
               
                return true;
            }

            catch (Exception ex)
            {
                oLogger.WriteLog(ex.Message, "LoadLinksFromFileError.log");
                throw ex;
            }
            //throw new NotImplementedException();

        }
        public bool WriteLinks()
        {
            cFile oFile = new cFile(msExportedLinkPath);
            try
            {
                string sOutput = "" + msUrlList[0];
                
                //oFile.FileName = msExportedLinkPath;
                for (int i = 1; i < msUrlList.Count; i++)
                {
                    sOutput += Environment.NewLine + msUrlList[i];
                }
                oFile.Write(sOutput);
                 
                 Parallel.For(0, sFileList.Count, x =>
               {
               
			 oFile.FileName = sFileList[x];
                    oFile.Delete();
               });
                return true;
            }
            catch (Exception ex)
            {
                oFile.WriteLog(ex.Message, "WriteLinksError.log");
                return false;
                throw ex;
            }
        }
    }
}
