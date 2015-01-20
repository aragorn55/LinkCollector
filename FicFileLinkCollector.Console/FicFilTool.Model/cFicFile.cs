//using eBdb.EpubReader;
//using HtmlAgilityPack;
//using Utilities.DL;
//using EPubMetadataEditor;

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;

namespace FicFilTool.Model
{
    [Serializable]
    public class cFicFile
    {
        private List<string> _sourcesList = new List<string>();
        private List<string> _Format = new List<string>();
        private List<string> _ID = new List<string>();
        private List<string> _Language = new List<string>();
        private OrderedDictionary _Content;
        private List<string> _Source = new List<string>();
        private List<string> _Subject = new List<string>();
        private List<string> _Title = new List<string>();
        private List<string> _Type = new List<string>();
        private string _UUID = "";
        private string _sFilePath;
        private List<string> _Creator = new List<string>();
        private string _StoryLink = "";
        private List<string> _Description = new List<string>();
        private string _FileName = "";
        private string sfile = "";
        private string sLink = "";
        //private List<DateData> _Date = new List<DateData>();
        public List<string> SourcesList
        {
            get { return _sourcesList; }
            set { _sourcesList = value; }
        }

        public string FilePath
        {
            get { return _sFilePath; }
            set { _sFilePath = value; }
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
        

       // private Epub oEpub;
        

        public cFicFile(string vsfilepath)
        {
           
            //oEpub = new Epub(@sfile);
            if (vsfilepath != "")
            {
                FilePath = vsfilepath;
                var oFileInfo = new FileInfo(vsfilepath);
                _FileName = oFileInfo.Name;
            }

           
            _Title.Add("");
            _Source.Add("");

            //_sourcesList = oEpub.Source;
        }

        public cFicFile()
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

       
        public void LoadFile()
        {
            
            
        }
        /*
        public async Task LoadFileAsync()
        {
           
        }
         */
        private void ReadFromFile()
        {
        }

        public void FixMetadata()
        {
            }
    }
}