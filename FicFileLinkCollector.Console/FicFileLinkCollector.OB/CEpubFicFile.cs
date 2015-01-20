using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using eBdb.EpubReader;
using Utilities.DL;
namespace FicFileLinkCollector.OB
{
    [Serializable]
    public class CEpubFicFile
    {
       

        private Epub _oEpub;
        //private List<DateData> _Date = new List<DateData>();

        private string _sFilePath;
        private string _FileName;
        private List<string> _Source = new List<string>();

        //private List<NavPoint> _TOC;
        //private string _s1;
        private List<string> _sourcesList = new List<string>();

        private string _StoryLink = "";

        private List<string> _Subject = new List<string>();

        private List<string> _Title = new List<string>();

        private List<string> _Type = new List<string>();

        private string _UUID = "";

        //private List<string> _Rights;
        //private OrderedDictionary _ExtendedData;

        //private List<string> _Coverage;
        private string sLink = "";


        public List<string> Source
        {
            get { return _Source; }
            set { _Source = value; }
        }

        public List<string> SourcesList
        {
            get { return _sourcesList; }
            set { _sourcesList = value; }
        }

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

        public string FilePath
        {
            get { return _sFilePath; }
            set { _sFilePath = value; }
        }

        public string StoryLink
        {
            get { return _StoryLink; }
            set { _StoryLink = value; }
        }
        public string Link
        {
            get { return sLink; }
            set { sLink = value; }
        }
        public CEpubFicFile()
        {
            // TODO: Complete member initialization
            //oEpub = new Epub(@sfile);
            FilePath = "";
            //oFileInfo = new FileInfo();
           // _FileName = "";
          //  _Title.Add("");
           // _Source.Add("");

            //_sourcesList = oEpub.Source;
        }

        public CEpubFicFile(string sfilepath)
        {
            // TODO: Complete member initialization
            //oEpub = new Epub(@sfile);
            FilePath = sfilepath;
            var oFileInfo = new FileInfo(sfilepath);
            _FileName = oFileInfo.Name;
            //_Title.Add("");
           // _Source.Add("");

            //_sourcesList = oEpub.Source;
        }

        /*
        public List<DateData> Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        */

        // public string FirstSource
        // {
        //   get { return _Source[0]; }

        //}

        

       

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
                ReadFromFile();
                // if (_Source.Count < 1)
                //    {
                

            }
            else
            {
                ReadFromFile();
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
    }
}