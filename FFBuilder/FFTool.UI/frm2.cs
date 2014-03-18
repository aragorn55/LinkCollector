using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FFTool.OB;
using Utilities.DL;
namespace FFTool.UI
{
    public partial class frm2 : Form
    {
        private Label label1;
        private Label lblTest2;
        private Label label2;
        private Label lblTest;
        private Button btnTest;
        private Label lblStatus;
        private Button btnCollectLinks;
    
        public frm2()
        {
            InitializeComponent();
            //Test();
        }

        private void btnCollectLinks_Click(object sender, EventArgs e)
        {

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
            oFF.test();
            
            lblStatus.Text = oFF.FFdotNetFic.StoryName;


        }

      
            
    }
}
