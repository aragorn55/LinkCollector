﻿using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Utilities.DL
{
    public class CEpubZip
    {
        private string msFilePath = "";
        private List<string> _urList = new List<string>();
        public CEpubZip(string vsPath)
        {
            msFilePath = vsPath;
        }
        public List<string> ReturnEpubContents()
        {
            


            using (FileStream zipFileToOpen = Pri.LongPath.File.OpenRead(msFilePath))
    
    using (ZipArchive archive = new ZipArchive(zipFileToOpen, ZipArchiveMode.Read))
    {

        foreach (ZipArchiveEntry zipArchiveEntry in archive.Entries)
        {
            using (Stream stream = zipArchiveEntry.Open())
            {
                var sr = new StreamReader(stream);
                 var myStr = sr.ReadToEnd();
                        _urList.Add(myStr);
            }
   
        }
            
    }

           
            return _urList;
        }
    

       
  
    }
}
