using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using BookmarksManager;
using BookmarksManager.Chrome;
using Utilities.DL;
namespace BookmarkCollector.ob
{
    public class CBookmarkReader
    {
        private  ChromeBookmarksReader oReader = new ChromeBookmarksReader();
        private NetscapeBookmarksReader oHtmlReader = new NetscapeBookmarksReader();
        
        private List<string> oFilesList = new List<string>();
        private List<string> oUrListList = new List<string>();
        private string output = "out.txt";
        public CBookmarkReader()
        {
            
        }

        public bool SaveLinks(string vsFilePath)
        {
            try
            {
                var oFile = new cFile(vsFilePath);
                foreach (var sUrl in oUrListList)
                {
                    oFile.Write(sUrl);
                } 
            }
            catch (Exception)
            {
                
                return false;
            }
            return true;
        }
        public bool ReadChromeFile(string vsFile)
        {
            var bookmarks = oReader.Read(vsFile);
            foreach (var b in bookmarks.AllLinks)
            {
                CBookmark oBookmark = new CBookmark(b.Title, b.Url, b.Description);
            }
            return false;
        }
        public bool ReadHtmlFile(string vsFile)
        {
            //Read bookmarks from file
            try
            {

                cFile oFile = new cFile(vsFile);
                var bookmarks = oHtmlReader.Read(oFile.ReadFileStream());

                foreach (var b in bookmarks.AllLinks)
                {
                    oUrListList.Add(b.Url);
                }
            }
            catch (Exception)
            {
                
                return false;
            }
            return true;
        }
        public bool ReadWriteHtmlFile(string vsFile)
        {
            //Read bookmarks from file
            try
            {

                cFile oFile = new cFile(vsFile);
                cFile oWrite = new cFile("out.txt");
                cFile oLog = new cFile("log.log");
                var bookmarks = oHtmlReader.Read(oFile.ReadFileStream());

                foreach (var b in bookmarks.AllLinks)
                {
                    oWrite.Write(b.Url);
                }
                oLog.Write(vsFile);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        public void SaveLinks()
        {
            cFile oFile = new cFile(output);
            foreach (var sUrl in oUrListList)
            {
                oFile.Write(sUrl);
            }
        }

        public bool ReadLinksFromTextFiles()
        {
            foreach (var sFile in oFilesList)
            {
                try
                {
                    cFile oFile = new cFile(sFile);
                    oUrListList.AddRange(oFile.ReadList());
                    
                }
                catch (Exception)
                {
                    
                   return false;
                }
            }
            return true;
        }

        public bool GetLinkFilesFromFile(string spath)
        {
            try
            {
                cFile oFile = new cFile(spath);
                oFilesList = oFile.ReadList();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
            return false;
        }
        public bool ReadWriteLinksFromHtmlFiles()
        {
            foreach (var sFile in oFilesList)
            {
                try
                {
                    ReadWriteHtmlFile(sFile);

                }
                catch (Exception ex)
                {

                    cFile oFile = new cFile("error.log");
                    oFile.Write(sFile);
                    oFile.Write(ex.Message);
                }
            }
            return true;


        }
        public bool ReadLinksFromHtmlFiles()
        {
            foreach (var sFile in oFilesList)
            {
                try
                {
                    ReadHtmlFile(sFile);

                }
                catch (Exception ex)
                {

                  cFile oFile = new cFile("error.log");
                    oFile.Write(sFile);
                    oFile.Write(ex.Message);
                }
            }
            return true;
           
            
        }
    }
}
