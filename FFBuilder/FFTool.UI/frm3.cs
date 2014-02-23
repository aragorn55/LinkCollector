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
using System.Text.RegularExpressions;

namespace FFTool.UI
{
    public partial class frm3 : Form
    {
        private List<string> msFilePath;
        private string msFolderPath = "";
        public delegate void EventHandler();
        public frm3()
        {
            InitializeComponent();
            //Test();
            //ucFolderS.FolderPathChosen += new EventHandler(ucFolderS_FolderPathChosen);
            //ucFileC.FilePathChosen += new EventHandler(ucFileC_FilePathChosen);
            //uc.UpdateParentPage+= new EventHandler(userControl_UpdateParentPage);

        }

        private void btnCollectLinks_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Starting";
            //cFile oFile = new cFile("C:\\Users\\joshua\\Sync\\Dropbox\\Documents\\FF\\input");
            //string[] fileList = oFile.GetAllFileList("C:\\Users\\joshua\\Sync\\Dropbox\\Documents\\FF\\input");
            //cUrlCollector oUrlCollector = new cUrlCollector();
            List<string> sPaths = GetLinks();
           // oUrlCollector.GetLinks(fileList);
            cUrlTool oUrl = new cUrlTool();
            oUrl.ExportedLinkPath = "C:\\Users\\joshua\\Sync\\Dropbox\\Documents\\FF\\InputsAll.txt";
            int iCnt = 0;
            foreach (string sT in sPaths)
            {
                string sOutput = "FF" + iCnt.ToString() + ".txt";
                sPaths.Add(sT);
                oUrl.GetLinks(sT);
                oUrl.WriteLinks(sOutput);
                iCnt += 1;
            }
            //oUrl.GetLinks("C:\\Users\\joshua\\Sync\\Dropbox\\Documents\\FF\\input");
            //oUrl.WriteLinks(oUrl.UrlList);
            lblStatus.Text = "Finished";


        }

        private List<string> GetLinks()
        {
            List<string> sPaths = new List<string>();
            string pattern = ";";
            string sInput = txtPath.Text;
            string[] sTs = Regex.Split(sInput, pattern);
            foreach (string sT in sTs)
            {
                sPaths.Add(sT);

            }
            return sPaths;
        }
        
        private void btnTest_Click(object sender, EventArgs e)
        {
            Test4();

           

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
        private void Test4()
        {
            string s = "http://www.fanfiction.net/s/5742604/1/Wild_Effect";
            cFFdotNetTool oFF = new cFFdotNetTool();
            //oFF.DownloadFic(s);
            //oFF.test3(s);
            oFF.test(s);
            
            lblStatus.Text = oFF.FFdotNetFic.StoryName;


        }

        

        private void SelectFiles()
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    foreach (string sPath in openFileDialog1.FileNames)
                    {
                        msFilePath.Add(sPath);
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }

        }
        private void SelectFolder()
        {
            FolderBrowserDialog openFolderDialog1 = new FolderBrowserDialog();
            try
            {
                if (openFolderDialog1.ShowDialog() == DialogResult.OK)
                {

                    {
                        msFolderPath = openFolderDialog1.SelectedPath;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }

        }

        private void btnFils_Click(object sender, EventArgs e)
        {
            msFilePath.Clear();

            SelectFiles();
            SetPaths();
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            msFolderPath = "";
            SelectFolder();
            SetPaths();
        }

        private void SetPaths()
        {
            string sPath = "";
            txtPath.Text = msFolderPath;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {

        }

        private void frm3_Load(object sender, EventArgs e)
        {
            txtPath.Text = "C:\\Users\\joshua\\Sync\\Dropbox\\Documents\\FF\\input";
        }

        private void btnExportFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    foreach (string sPath in openFileDialog1.FileNames)
                    {
                        msFilePath.Add(sPath);

                    }
                    FormatExportPath();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }

        private void FormatExportPath()
        {
            string sFolderLists = "";
            foreach (string sPath in msFilePath)
            {
                sFolderLists = sFolderLists + sPath + ";";

            }
            txtPath.Text = sFolderLists;

        } 
    }
}
