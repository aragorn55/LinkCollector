using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  eBdb.EpubReader;
namespace FicFileTool.epub
{
    public class cEpubFile
    {
        private FileInfo moFile;
        //private string _sFilename = "";
        // private string _sFilePath;
       //btrfs
        private string sfile;
        private Epub oEpub;
        private string sTitle;

        private string sSource;
        //private string _s1;
        private List<string> _sourcesList = new List<string>();

        public List<string> SourcesList
        {
            get { return _sourcesList; }
            set { _sourcesList = value; }
        }
        //private List<Date> _dates;
        
        public cEpubFile(string sfilepath)
        {
            moFile = new FileInfo(sfilepath);
            sSource = "";
            sTitle = "";
            // TODO: Complete member initialization
            //oEpub = new Epub(@sfile);
            
            //_sourcesList = oEpub.Source;
        }
        public string FilePath()
        {
            return moFile.FullName;
        }
        public string FileName()
        {
            return moFile.Name;
        }
        public void LoadFile()
        {
            oEpub = new Epub(moFile.FullName);
            _sourcesList = oEpub.Source;
            sTitle = oEpub.Title[0];
            sSource = oEpub.Source[0];
        }

        public string Title()
        {
            return sTitle;
        }
        public string Source()
        {
            return sSource;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
