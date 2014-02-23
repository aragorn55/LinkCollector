using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FFtool.OB;
using Utilities.DL;
using BookmarkTools.OB;
namespace FFTool.UI
{
    public partial class frm1 : Form
    {
        private string msFilename = "";
        public frm1()
        {
            InitializeComponent();
            //Test();
        }

        private void btnCollectLinks_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Starting";
            string sPath = "";
            sPath = "E:\\sync\\Dropbox\\Documents\\FF\\input";
            //cFile oFile = new cFile("C:\\Users\\joshua\\Sync\\Dropbox\\Documents\\FF\\input");
            //string[] fileList = oFile.GetAllFileList("C:\\Users\\joshua\\Sync\\Dropbox\\Documents\\FF\\input");
            //cUrlCollector oUrlCollector = new cUrlCollector();
           // oUrlCollector.GetLinks(fileList);
            cUrlTool oUrl = new cUrlTool();
            oUrl.ExportedLinkPath = "E:\\sync\\Dropbox\\Documents\\FF\\InputsAll.txt";
            //oUrl.ExportedLinkPath = "C:\\Users\\joshua\\Sync\\Dropbox\\Documents\\FF\\InputsAll.txt";
            //oUrl.GetLinks("C:\\Users\\joshua\\Sync\\Dropbox\\Documents\\FF\\input");
            oUrl.GetLinks(sPath);
            oUrl.WriteLinks(oUrl.UrlList);
            lblStatus.Text = "Finished";


        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Test3();

           

        }
        private void Test()
        {
            cUrlTool oUrl = new cUrlTool();
            string sUrlInput = "http://m.fanfiction.net/s/3037112/3/";
            lblTest.Text = sUrlInput;
            string sUrlOutput = oUrl.FixFFdotNet(sUrlInput);
            lblTest2.Text = sUrlOutput;


        }
        private void Test2()
        {
            cUrlTool oUrl = new cUrlTool();
            string sFilePath = "C:\\Users\\joshua\\Sync\\Dropbox\\Documents\\FF\\input\\2\\FF.net3.txt";
            lblTest.Text = sFilePath;
            string sUrlOutput = "False";
            if (oUrl.LoadLinksFromFile(sFilePath))
            {
                sUrlOutput = "True";
            }
            //string sUrlOutput = 
            lblTest2.Text = sUrlOutput;


        }
        private void Test3()
        {
            cUrlTool oUrl = new cUrlTool();
            string sFilePath = "C:\\Users\\joshua\\Sync\\Dropbox\\Documents\\FF\\input\\2\\mediaminer.txt";
            lblTest.Text = sFilePath;
            string sUrlOutput = "False";
            if (oUrl.LoadLinksFromFile(sFilePath))
            {
                sUrlOutput = "True";
            }
            //string sUrlOutput = 
            lblTest2.Text = sUrlOutput;


        }

        private void btnCMarksExtractor_Click(object sender, EventArgs e)
        {
            cBookmarkExtractor oBKEx = new cBookmarkExtractor();
            oBKEx.IdentifyLinks(msFilename);
        }

        private void btnFileChooser_Click(object sender, EventArgs e)
        {
            //Ope
        }

        
    }
}
