using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using BrightIdeasSoftware;
using FicFilTool.UI;
using  FicFileTool.Model;
using  FicFileTool.Control;
namespace FicFileTool.UI
{
    public partial class Form1 : Form
    {
        
        private CFicFileController oController;
        private List<CEpubFicFile> _epubList;
        public Form1()
        {
            
            oController = new CFicFileController();
            _epubList = new List<CEpubFicFile>();
            InitializeComponent();
        }

        private async void btnFolder_Click(object sender, EventArgs e)
        {
            _epubList.Clear();
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                await oController.LoadEpubsFromFolderAsync(folderBrowserDialog1.SelectedPath);
                oEpubFileList.SetObjects(oController.EpubList);
            }
           
        }
        private void btnLoadEpubInfo_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "savings";
            //if (_epubList != null) SerializeToXML(_epubList);

            lblStatus.Text = "Saved";
        }

       

        private async void btnReadEpub_Click(object sender, EventArgs e)
        {
            int icnt = 0;
            foreach (CEpubFicFile oEpub in _epubList)
            {
                lblStatus.Text = oEpub.FilePath;
                await oEpub.LoadFileAsync();
                lblProcessed.Text = icnt.ToString();
            }
            icnt += 1;
            lblStatus.Text = "Read";
            oEpubFileList.SetObjects(_epubList);
            //return icnt;
            //_epubList[0].FixMetadata();
            //lblOutput.Text = _epubList[0].OEpub.GetContentAsPlainText;
        }
        

        private async void ProcessDataAsync(string vDir)
        {
            // Start the HandleFile method.
            //   Task<int> task = HandleFileAsync(sFileName);
            var dirs = Directory.GetFiles(vDir, "*.epubFic", SearchOption.AllDirectories);
            //this.oEpubFileList.SetObjects(dirs);
            foreach (var sfile in dirs)
            {
                CEpubFicFile oEpubFic = new CEpubFicFile(sfile);
                lblStatus.Text = sfile;
                _epubList.Add(oEpubFic);
                // count ++;
            }
            oEpubFileList.SetObjects(_epubList);
            //int x = await task;
            //lblProcessed.Text = x.ToString();
        }

        private async Task<int> HandleFileAsync(string vDir)
        {
            //Console.WriteLine("HandleFile enter");
            int count = 0;
            var dirs = Directory.GetFiles(vDir, "*.epubFic", SearchOption.AllDirectories);
            //this.oEpubFileList.SetObjects(dirs);
            foreach (var sfile in dirs)
            {
                CEpubFicFile oEpubFic = new CEpubFicFile(sfile);
                lblStatus.Text = sfile;
                _epubList.Add(oEpubFic);
                count++;
            }
            oEpubFileList.SetObjects(_epubList);
            return count;
        }
        private async void ProcessReadAsync()
        {
            // Start the HandleFile method.
            Task<int> task = HandleReadAsync();

            int x = await task;
            lblProcessed.Text = x.ToString();
        }

        private async Task<int> HandleReadAsync()
        {
            int icnt = 0;
            foreach (CEpubFicFile oEpub in _epubList)
            {
                lblStatus.Text = oEpub.FilePath;
                oEpub.LoadFile();
                icnt += 1;
                lblProcessed.Text = icnt.ToString();
            }
            lblStatus.Text = "Read";
            oEpubFileList.SetObjects(_epubList);
            return icnt;
        }
        private async Task<int> ReadAsync()
        {
            Task[] tasks = new Task[_epubList.Count];
            for (int i = 0; i < _epubList.Count; i++)
            {
                tasks[i] = CreateReadTask(_epubList[i]);
            }
            return 0;
            //#endif
        }

        private Task CreateReadTask(CEpubFicFile epubFic)
        {
            return null;
        }

        private string MakeWork(CEpubFicFile epubFicFile)
        {
            epubFicFile.LoadFile();
            return epubFicFile.FileName;
        }
        private async Task DoWork(CEpubFicFile epubFicFile)
        {
            Func<string> function = new Func<string>(() => MakeWork(epubFicFile));
            TaskFactory oFactory = new TaskFactory();
            string res = await oFactory.StartNew<string>(function);
            Task task = await epubFicFile.LoadFileAsync();
            //  task.

        }



    }
}