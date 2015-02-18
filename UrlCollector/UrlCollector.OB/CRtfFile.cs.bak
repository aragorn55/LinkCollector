using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Utilities.DL;


namespace UrlCollector.OB
{
    internal class CRtfFile
    {
        private string spath;
        private string sRTFContent = "";
        private List<string> _urList = new List<string>();
        public CRtfFile(string spath)
        {
            this.spath = spath;
        }

        public List<string> FindUrlsList()
        {
            try
            {
                if (RTFLoader(spath))
                {
                    CTextUrlSearch oSearch = new CTextUrlSearch();
                    List<string> voList = oSearch.GetLinks(sRTFContent);
                    foreach (var oUrl in voList)
                    {
                        _urList.Add(oUrl);
                    }
                }
                return _urList;
                
            }
            catch (System.Exception ex)
            {
                CFile oFile = new CFile();
                oFile.WriteLog(ex.Message, "error.log");
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public bool RTFLoader(string spath)
        {
            string rtf_content;
            try
            {
                rtf_content = System.IO.File.ReadAllText(spath);
               
            }
            catch (Exception ex)
            {
               // Console.Error.Write(ex.Message);
                return false;
            }

            ConvertToPlainText(rtf_content);
            return true;
        }
        public string ConvertToPlainText(string rtf_content)
        { 
            System.Windows.Forms.RichTextBox rtBox = new System.Windows.Forms.RichTextBox();
            rtBox.Rtf = rtf_content;
            string plainText = rtBox.Text;
           
            return plainText;
        }

        
    }
}