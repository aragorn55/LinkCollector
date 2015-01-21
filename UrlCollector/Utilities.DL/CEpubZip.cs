using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using Pri.LongPath;
namespace Utilities.zip
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
