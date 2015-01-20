using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Linq;
using System.Text;
using Utilities.DL;
namespace FicFileLinkCollector.OB
{
    public class CHtmlFicFile
    {
        private string _sFilePath;
        private string _FileName;
        private List<string> _Source = new List<string>();
       private HtmlDocument doc = new HtmlDocument();
        //private List<NavPoint> _TOC;
        //private string _s1;
        private List<string> _sourcesList = new List<string>();

        private string _StoryLink = "";

        private List<string> _Subject = new List<string>();

        private List<string> _Title = new List<string>();

        private List<string> _Type = new List<string>();

        public List<string> SourcesList
        {
            get { return _sourcesList; }
            set { _sourcesList = value; }
        }

        //private List<string> _Rights;
        //private OrderedDictionary _ExtendedData;

        //private List<string> _Coverage;
        private string sLink = "";


        public List<string> Source
        {
            get { return _Source; }
            set { _Source = value; }
        }
        public CHtmlFicFile(string spath)
        {
            _sFilePath = spath;
        }

        
 

        public bool LoadFile()
        {
            try
            {
                doc.Load(_sFilePath);

                foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
                {
                    HtmlAttribute att = link.Attributes["href"];
                    _Source.Add(att.Value);
                }
                return true;
            }
            catch (Exception ex)
            {
                CFile oLogger = new CFile();
                oLogger.WriteLog(_sFilePath, "error.log");
                oLogger.WriteLog(ex.Message, "error.log");
                return false;
            }
 
        }
    }
}