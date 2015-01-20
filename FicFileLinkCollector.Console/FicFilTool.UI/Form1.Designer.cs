namespace FicFileTool.UI
{
    partial class Form1
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
            this.lblPath = new System.Windows.Forms.Label();
            this.btnFolder = new System.Windows.Forms.Button();
            this.btnLoadEpubInfo = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.oEpubFileList = new BrightIdeasSoftware.ObjectListView();
            this.olvFileName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvFilePath = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvTitle = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvSource = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.btnSave = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblProcessed = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.oEpubFileList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPath
            // 
            this.lblPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPath.Location = new System.Drawing.Point(12, 9);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(326, 31);
            this.lblPath.TabIndex = 1;
            this.lblPath.Text = "label1";
            // 
            // btnFolder
            // 
            this.btnFolder.Location = new System.Drawing.Point(360, 9);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(98, 31);
            this.btnFolder.TabIndex = 2;
            this.btnFolder.Text = "Foder";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // btnLoadEpubInfo
            // 
            this.btnLoadEpubInfo.Location = new System.Drawing.Point(481, 9);
            this.btnLoadEpubInfo.Name = "btnLoadEpubInfo";
            this.btnLoadEpubInfo.Size = new System.Drawing.Size(75, 31);
            this.btnLoadEpubInfo.TabIndex = 3;
            this.btnLoadEpubInfo.Text = "Load Info";
            this.btnLoadEpubInfo.UseVisualStyleBackColor = true;
            this.btnLoadEpubInfo.Click += new System.EventHandler(this.btnLoadEpubInfo_Click);
            // 
            // oEpubFileList
            // 
            this.oEpubFileList.AllColumns.Add(this.olvFileName);
            this.oEpubFileList.AllColumns.Add(this.olvFilePath);
            this.oEpubFileList.AllColumns.Add(this.olvTitle);
            this.oEpubFileList.AllColumns.Add(this.olvSource);
            this.oEpubFileList.AllowColumnReorder = true;
            this.oEpubFileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvFileName,
            this.olvFilePath,
            this.olvTitle,
            this.olvSource});
            this.oEpubFileList.GridLines = true;
            this.oEpubFileList.HeaderWordWrap = true;
            this.oEpubFileList.Location = new System.Drawing.Point(12, 60);
            this.oEpubFileList.Name = "oEpubFileList";
            this.oEpubFileList.ShowItemCountOnGroups = true;
            this.oEpubFileList.Size = new System.Drawing.Size(1313, 373);
            this.oEpubFileList.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.oEpubFileList.TabIndex = 4;
            this.oEpubFileList.UseCompatibleStateImageBehavior = false;
            this.oEpubFileList.View = System.Windows.Forms.View.Details;
            // 
            // olvFileName
            // 
            this.olvFileName.AspectName = "FileName";
            this.olvFileName.CellPadding = null;
            this.olvFileName.Text = "FileName";
            this.olvFileName.Width = 166;
            // 
            // olvFilePath
            // 
            this.olvFilePath.AspectName = "FilePath";
            this.olvFilePath.CellPadding = null;
            this.olvFilePath.Text = "FilePath";
            this.olvFilePath.Width = 574;
            // 
            // olvTitle
            // 
            this.olvTitle.AspectName = "Title";
            this.olvTitle.CellPadding = null;
            this.olvTitle.Text = "Title";
            // 
            // olvSource
            // 
            this.olvSource.AspectName = "Source";
            this.olvSource.CellPadding = null;
            this.olvSource.Text = "Source";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(598, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 30);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 440);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1357, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 448);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 13);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "label2";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(750, 25);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(35, 13);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "label1";
            // 
            // lblProcessed
            // 
            this.lblProcessed.AutoSize = true;
            this.lblProcessed.Location = new System.Drawing.Point(792, 25);
            this.lblProcessed.Name = "lblProcessed";
            this.lblProcessed.Size = new System.Drawing.Size(35, 13);
            this.lblProcessed.TabIndex = 9;
            this.lblProcessed.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(849, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1357, 462);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblProcessed);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.oEpubFileList);
            this.Controls.Add(this.btnLoadEpubInfo);
            this.Controls.Add(this.btnFolder);
            this.Controls.Add(this.lblPath);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.oEpubFileList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        #endregion

        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.Button btnLoadEpubInfo;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private BrightIdeasSoftware.ObjectListView oEpubFileList;
        private BrightIdeasSoftware.OLVColumn olvFileName;
        private BrightIdeasSoftware.OLVColumn olvFilePath;
        private BrightIdeasSoftware.OLVColumn olvTitle;
        private BrightIdeasSoftware.OLVColumn olvSource;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblProcessed;
        private System.Windows.Forms.Label label3;
    }
}

