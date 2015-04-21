using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FicFileTool.epub;
using BrightIdeasSoftware;
using eBdb.EpubReader;
namespace FicFileTool.UI
{
    public partial class Form1 : Form
    {
        private List<cEpubFile> _fileList;
        public Form1()
        {
            InitializeComponent();
            //SetEpubView();
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                //
                // The user selected a folder and pressed the OK button.
                // We print the number of files found.
                //
                var dir = folderBrowserDialog1.SelectedPath;
                //List<string> dirs
               // var items = epubListView.Items;
                var dirs = GetFiles(dir);

                LoadList(dirs);
                oEpubFileList.SetObjects(_fileList);
                //this.olvComplex.AddObjects(list);



            }
        }

        private string[] GetFiles(string dir)
        {
            var dirs = Directory.GetFiles(dir, "*.epub", SearchOption.AllDirectories);
            //this.oEpubFileList.SetObjects(dirs);
           
            return dirs;
        }

        private void LoadList (string[] dirs)
		{
			
			foreach (var sfile in dirs) {
                cEpubFile oEpub = new cEpubFile(sfile);
                _fileList.Add (oEpub);
			}
		}
        private void btnLoadEpubInfo_Click(object sender, EventArgs e)
        {
            foreach (cEpubFile oFic in _fileList)
            {
                oFic.LoadFile();
                oEpubFileList.SetObjects(_fileList);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (cEpubFile oFic in _fileList)
            {
                oFic.Save();

            }
        }
        private void SetEpubView()
		{
			//this.olvFiles = new BrightIdeasSoftware.ObjectListView();
			BrightIdeasSoftware.OLVColumn olvColumnFileName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			BrightIdeasSoftware.OLVColumn olvColumnFilePath = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			BrightIdeasSoftware.OLVColumn olvColumnFileModified = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			BrightIdeasSoftware.OLVColumn olvColumnSize = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			

			this.oEpubFileList.AllColumns.Add(olvColumnFileName);
			this.oEpubFileList.AllColumns.Add(olvColumnFilePath);
			this.oEpubFileList.AllColumns.Add(olvColumnFileModified);
			this.oEpubFileList.AllColumns.Add(olvColumnSize);
			//this.oEpubFileList.AllColumns.Add();
			this.oEpubFileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
				olvColumnFileName,
                olvColumnFilePath,
				olvColumnFileModified,
				olvColumnSize});
			// 
			// olvColumnFileName
			// 
			olvColumnFileName.AspectName = "FileName";
			olvColumnFileName.CellPadding = null;
			olvColumnFileName.IsTileViewColumn = true;
			olvColumnFileName.Text = "FileName";
			olvColumnFileName.UseInitialLetterForGroup = true;
			olvColumnFileName.Width = 180;
            // 
            // olvColumnFileCreated
            // 
            olvColumnFilePath.AspectName = "FilePath";
            olvColumnFilePath.CellPadding = null;
            olvColumnFilePath.DisplayIndex = 4;
            olvColumnFilePath.Text = "FilePath";
            olvColumnFilePath.Width = 131;
			// 
			// olvColumnFileModified
			// 
			olvColumnFileModified.AspectName = "Title";
			olvColumnFileModified.CellPadding = null;
			olvColumnFileModified.DisplayIndex = 1;
			olvColumnFileModified.IsTileViewColumn = true;
			olvColumnFileModified.Text = "Title";
			olvColumnFileModified.Width = 127;
			// 
			// olvColumnSize
			// 
			olvColumnSize.AspectName = "Source";
			olvColumnSize.CellPadding = null;
			olvColumnSize.DisplayIndex = 2;
			olvColumnSize.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			olvColumnSize.Text = "Source";
			olvColumnSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			olvColumnSize.Width = 80;
			
		}

       
    }
}