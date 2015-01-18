using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using Utilities.DL;
namespace UrlCollector.OB
{
    public class CHtmlFile
    {
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
        public CHtmlFile(string spath)
        {
            _sFilePath = spath;
        }

        
 

        public bool LoadFile()
        {
            try
            {
              //  doc.Load(_sFilePath);

             //   foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
             //   {
             //       HtmlAttribute att = link.Attributes["href"];
            //        _Source.Add(att.Value);
           //     }
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