﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.DL;
namespace UrlCollector.OB
{
    public class CFicProcessor
    {
        public CFile OSaveFile = new CFile("FicUrls.txt");
        public CFicProcessor()
        {
            
        }

        public bool ProcessEpubList(string vsFileInput, string vsOutput)
        {
            try
            {
                CFile oFile = new CFile(vsFileInput);
                OSaveFile.FileName = vsOutput;
                List<string> epubList = oFile.ReadList();
                foreach (var spath in epubList)
                {
                   // ProcessEpub(spath);
                }
                return true;
            }
            catch (Exception ex)
            {

                OSaveFile.WriteLog(vsFileInput, "error.log");
                OSaveFile.WriteLog(ex.Message, "error.log");
                return false;
            }

        }
        
        public bool ProcessHtmlList(string vsFileInput, string vsOutput)
        {
            try
            {
                CFile oFile = new CFile(vsFileInput);
                OSaveFile.FileName = vsOutput;
                List<string> epubList = oFile.ReadList();
                foreach (var spath in epubList)
                {
                    ProcessHtml(spath);
                }
                return true;
            }
            catch (Exception ex)
            {

                OSaveFile.WriteLog(vsFileInput, "error.log");
                OSaveFile.WriteLog(ex.Message, "error.log");
                return false;
            }

        }
        private bool ProcessEpub(string spath)
        {
            /*
            try
            {
                CEpubFicFile oEpubFile = new CEpubFicFile(spath);
                List<string> oList = new List<string>();
                Console.Write(spath);
                oEpubFile.LoadFile();
                if (oEpubFile.Source.Count > 0)
                {
                    foreach (var sSource in oEpubFile.Source)
                    {
                        if (sSource.Length > 3)
                        {
                           oList.Add(sSource);
                        }
                    }
                }

                if (oEpubFile.StoryLink.Length > 3)
                {
                    oList.Add(oEpubFile.StoryLink);
                }

                if (oEpubFile.Link.Length > 3)
                {
                     oList.Add(oEpubFile.Link);
                }
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
            */
            return false;
        }
        private bool ProcessHtml(string spath)
        {
            /*
           try
           {
               CHtmlFicFile oHtmlFile = new CHtmlFicFile(spath);
               List<string> oList = new List<string>();
               Console.WriteLine(spath);
               oHtmlFile.LoadFile();
               var sSources = oHtmlFile.Source;
               if (sSources.Count > 0)
               {
                   foreach (var sSource in sSources)
                   {
                       if (sSource.Length > 3)
                       {
                           oList.Add(sSource);
                       }
                   }
               }

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
            */
            return false;

        }
       
         
    }

   
}
