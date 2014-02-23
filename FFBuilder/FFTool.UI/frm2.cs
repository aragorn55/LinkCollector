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

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lblTest2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTest = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnCollectLinks = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Test";
            // 
            // lblTest2
            // 
            this.lblTest2.AutoSize = true;
            this.lblTest2.Location = new System.Drawing.Point(238, 153);
            this.lblTest2.Name = "lblTest2";
            this.lblTest2.Size = new System.Drawing.Size(23, 13);
            this.lblTest2.TabIndex = 12;
            this.lblTest2.Text = "lbl2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Test";
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Location = new System.Drawing.Point(238, 131);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(35, 13);
            this.lblTest.TabIndex = 10;
            this.lblTest.Text = "label1";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(241, 101);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 9;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(-32, 177);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 13);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "label1";
            // 
            // btnCollectLinks
            // 
            this.btnCollectLinks.Location = new System.Drawing.Point(241, 72);
            this.btnCollectLinks.Name = "btnCollectLinks";
            this.btnCollectLinks.Size = new System.Drawing.Size(75, 23);
            this.btnCollectLinks.TabIndex = 7;
            this.btnCollectLinks.Text = "button1";
            this.btnCollectLinks.UseVisualStyleBackColor = true;
            // 
            // frm2
            // 
            this.ClientSize = new System.Drawing.Size(399, 273);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTest2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnCollectLinks);
            this.Name = "frm2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
            
    }
}
