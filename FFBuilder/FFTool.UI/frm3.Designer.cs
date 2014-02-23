namespace FFTool.UI
{
    partial class frm3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCollectLinks = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.lblTest = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTest2 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnImportFiles = new System.Windows.Forms.Button();
            this.btnImportFolder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExportFiles = new System.Windows.Forms.Button();
            this.txtExportPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCollectLinks
            // 
            this.btnCollectLinks.Location = new System.Drawing.Point(403, 152);
            this.btnCollectLinks.Name = "btnCollectLinks";
            this.btnCollectLinks.Size = new System.Drawing.Size(75, 23);
            this.btnCollectLinks.TabIndex = 0;
            this.btnCollectLinks.Text = "CollectLinks";
            this.btnCollectLinks.UseVisualStyleBackColor = true;
            this.btnCollectLinks.Click += new System.EventHandler(this.btnCollectLinks_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(105, 142);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "label1";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(403, 181);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Location = new System.Drawing.Point(400, 211);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(35, 13);
            this.lblTest.TabIndex = 3;
            this.lblTest.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(322, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Test";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(322, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Test";
            // 
            // lblTest2
            // 
            this.lblTest2.AutoSize = true;
            this.lblTest2.Location = new System.Drawing.Point(400, 233);
            this.lblTest2.Name = "lblTest2";
            this.lblTest2.Size = new System.Drawing.Size(23, 13);
            this.lblTest2.TabIndex = 5;
            this.lblTest2.Text = "lbl2";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(152, 21);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(482, 20);
            this.txtPath.TabIndex = 10;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(579, 132);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 14;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnImportFiles
            // 
            this.btnImportFiles.Location = new System.Drawing.Point(640, 20);
            this.btnImportFiles.Name = "btnImportFiles";
            this.btnImportFiles.Size = new System.Drawing.Size(75, 23);
            this.btnImportFiles.TabIndex = 15;
            this.btnImportFiles.Text = "Files";
            this.btnImportFiles.UseVisualStyleBackColor = true;
            this.btnImportFiles.Click += new System.EventHandler(this.btnFils_Click);
            // 
            // btnImportFolder
            // 
            this.btnImportFolder.Location = new System.Drawing.Point(741, 19);
            this.btnImportFolder.Name = "btnImportFolder";
            this.btnImportFolder.Size = new System.Drawing.Size(75, 23);
            this.btnImportFolder.TabIndex = 16;
            this.btnImportFolder.Text = "Folders";
            this.btnImportFolder.UseVisualStyleBackColor = true;
            this.btnImportFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Link Collection Path";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Link Export Taget File";
            // 
            // btnExportFiles
            // 
            this.btnExportFiles.Location = new System.Drawing.Point(640, 46);
            this.btnExportFiles.Name = "btnExportFiles";
            this.btnExportFiles.Size = new System.Drawing.Size(75, 23);
            this.btnExportFiles.TabIndex = 19;
            this.btnExportFiles.Text = "Files";
            this.btnExportFiles.UseVisualStyleBackColor = true;
            this.btnExportFiles.Click += new System.EventHandler(this.btnExportFiles_Click);
            // 
            // txtExportPath
            // 
            this.txtExportPath.Location = new System.Drawing.Point(152, 47);
            this.txtExportPath.Name = "txtExportPath";
            this.txtExportPath.Size = new System.Drawing.Size(482, 20);
            this.txtExportPath.TabIndex = 18;
            // 
            // frm3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 448);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnExportFiles);
            this.Controls.Add(this.txtExportPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnImportFolder);
            this.Controls.Add(this.btnImportFiles);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTest2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnCollectLinks);
            this.Name = "frm3";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frm3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCollectLinks;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTest2;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnImportFiles;
        private System.Windows.Forms.Button btnImportFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnExportFiles;
        private System.Windows.Forms.TextBox txtExportPath;
    }
}

