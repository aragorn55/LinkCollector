using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using eBdb.EpubReader;
namespace FicFilTool.Model
{
    [Serializable]
    public class CEpubFicFile
    {
        private OrderedDictionary _Content;

        [XmlIgnore] // private Epub oEpub;
        private string sfile;

        private CEpubFile _oEpubFile;
        private List<string> _Creator = new List<string>();


        //private List<DateData> _Date = new List<DateData>();

        private string _StoryLink = "";

        private List<string> _Description = new List<string>();

        private string _FileName = "";

        private List<string> _Format = new List<string>();

        private List<string> _ID = new List<string>();

        private List<string> _Language = new List<string>();

        private List<string> _Source = new List<string>();

        private List<string> _Subject = new List<string>();

        private List<string> _Title = new List<string>();

        private List<string> _Type = new List<string>();

        private string _UUID = "";

        private string _sFilePath;

        private List<string> _sourcesList = new List<string>();

        private string sLink;

        public List<string> Creator
        {
            get { return _Creator; }
            set { _Creator = value; }
        }

        /*
        public List<DateData> Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        */

        public List<string> Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public string FileName1
        {
            get { return _FileName; }
            set { _FileName = value; }
        }

        public List<string> Format
        {
            get { return _Format; }
            set { _Format = value; }
        }

        public List<string> Id1
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public List<string> Language
        {
            get { return _Language; }
            set { _Language = value; }
        }

        public List<string> Source
        {
            get { return _Source; }
            set { _Source = value; }
        }

        // public string FirstSource
        // {
        //   get { return _Source[0]; }

        //}
        public List<string> Subject
        {
            get { return _Subject; }
            set { _Subject = value; }
        }

        public List<string> Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        public string FirstTitle
        {
            get { return _Title[0]; }

        }

        public List<string> Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        public string Uuid
        {
            get { return _UUID; }
            set { _UUID = value; }
        }

        public string SFilePath
        {
            get { return _sFilePath; }
            set { _sFilePath = value; }
        }

        public List<string> SourcesList
        {
            get { return _sourcesList; }
            set { _sourcesList = value; }
        }

        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }

        public List<string> Id
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string StoryLink
        {
            get { return _StoryLink; }
            set { _StoryLink = value; }
        }

        //[XmlIgnore] 

        //private List<string> _Publisher;

        //private List<string> _Contributer;

        //private List<string> _Relation;

        //private List<string> _Coverage;

        //private List<string> _Rights;

        //private OrderedDictionary _ExtendedData;

        //private List<NavPoint> _TOC;
        //private string _s1;

        public string FilePath
        {
            get { return _sFilePath; }
            set { _sFilePath = value; }
        }

        public CEpubFicFile()
        {
            // TODO: Complete member initialization
            //oEpub = new Epub(@sfile);
            FilePath = "";
            //oFileInfo = new FileInfo();
            _FileName = "";
            _Title.Add("");
            _Source.Add("");

            //_sourcesList = oEpub.Source;
        }

        public CEpubFicFile(string sfilepath)
        {
            // TODO: Complete member initialization
            //oEpub = new Epub(@sfile);
            FilePath = sfilepath;
            var oFileInfo = new FileInfo(sfilepath);
            _FileName = oFileInfo.Name;
            _Title.Add("");
            _Source.Add("");

            //_sourcesList = oEpub.Source;
        }

        public void LoadFile()
        {
            Epub oEpub = new Epub(@FilePath);
            _Title = oEpub.Title;
            _Source = oEpub.Source;
            if (oEpub.Source != null)
            {
                if (oEpub.Source.Count > 0)
                {
                    StoryLink = _Source[0];
                }

                if (_Title.Count < 1)
                {
                    _Title.Add("_");
                }
                // if (_Source.Count < 1)
                //    {
                ReadFromFile();
                //FixMetadata();
                // _Source.Add("_");
                //    }
            }
        }

        private void ReadFromFile()
        {

            Epub oEpub = new Epub(@FilePath);
            ContentData cont = (ContentData) oEpub.Content[0];
            string sText = cont.GetContentAsPlainText();
            string[] metadata = sText.Split('\n');
            foreach (string s in metadata)
            {
                if (s.IndexOf("Storylink") != -1)
                {
                    int y = s.Length;
                    int x = s.IndexOf("http");
                    if (x != -1)
                    {
                        string f = s.Substring(x);
                        sLink = f;
                    }


                }
            }
        }

        public async Task LoadFileAsync()
        {
            Epub oEpub = new Epub(@FilePath);
            _Title = oEpub.Title;
            _Source = oEpub.Source;
            if (oEpub.Source != null)
            {
                if (oEpub.Source.Count > 0)
                {
                    StoryLink = _Source[0];
                }

                if (_Title.Count < 1)
                {
                    _Title.Add("_");
                }
                // if (_Source.Count < 1)
                //    {
                await ReadFromFile();
                //FixMetadata();
                // _Source.Add("_");
                //    }
            }
        }

        public async Task FixMetadata()
        {

            //     string sContent = cont.Content;

            //List<string> _metadata = sText.Split(Environment.NewLine);

            _oEpubFile = new CEpubFile();


            _Source.Clear();
            _Source.Add(sLink);
            _StoryLink = sLink;

            _oEpubFile._sFileName = _sFilePath;
            _oEpubFile.OpenEPUB(_sFilePath);
            _oEpubFile.SetSource(sLink);
            await _oEpubFile.SaveEpub();

        }
    }
}