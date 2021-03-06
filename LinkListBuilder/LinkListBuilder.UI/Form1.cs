﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FFTool.OB;
using Utilities.DL;
namespace LinkListBuilder.UI
{
	public partial class Form1 : Form
	{
		cUrlTool oTool = new cUrlTool();
		cLinkCollector oMerge = new cLinkCollector();
		public Form1()
		{
			InitializeComponent();
		}

		private void btnCollectLinksFromFolder_Click(object sender, EventArgs e)
		{
			ImportTextFileLinks();
		}
		private async void ImportTextFileLinks()
		{
			cFile oFile = new cFile("FilesLoaded");
			try
			{
				string startupPath = Application.StartupPath;
				using (FolderBrowserDialog dialog = new FolderBrowserDialog())
				{
					dialog.Description = "Open a folder which contains the txt output";
					dialog.ShowNewFolderButton = false;
					dialog.RootFolder = Environment.SpecialFolder.MyComputer;
					if (dialog.ShowDialog() == DialogResult.OK)
					{
						string folder = dialog.SelectedPath;
                        Task voTask = GetLinkValues(folder, oFile);
                        //voTask.Start();
					    await voTask;
						lblOutput.Text = "done";
					}
				}
				//using (OpenFileDialog dialog = new OpenFileDialog())
				//{
				//    dialog.Filter = "xml files (*.xml)|*.xml";
				//    dialog.Multiselect = false;
				//    dialog.InitialDirectory = ".";
				//    dialog.Title = "Select file (only in XML format)";
				//    if (dialog.ShowDialog() == DialogResult.OK)
				//    {
				//        SQLGenerator.GenerateSQLTransactions(Application.StartupPath + Settings.Default.xmlFile);
				//    }
				//}
				lblOutput.Text = "done";
			}
			catch (Exception exc)
			{
				MessageBox.Show("Import failed because " + exc.Message + " , please try again later.");
			}

		}

		private async Task GetLinkValues(string folder, cFile oFile)
		{
            List<Task> oTasks = new List<Task>();
			foreach (string fileName in Directory.GetFiles(folder, "*.txt", SearchOption.AllDirectories))
			{
			Task oTask = ProcessFile(fileName);
                oTask.Start();
			    lblOutput.Text = fileName;
	
                oTasks.Add(oTask);
				oFile.Write(fileName);
				//SQLGenerator.GenerateSQLTransactions(Path.GetFullPath(fileName));
			}
		    await oTasks[0];

		}

		private Task ProcessFile(string fileName)
		{
            cFile oFile = new cFile("log");
            // use await here, like so
            Task task = new Task(() =>
            {
                try
                {

                    cUrlTool voTool = new cUrlTool();
                    voTool.GetLinksFromFile(fileName);
                    voTool.WriteLinks();
                }
                catch (Exception ex)
                {
                    oFile.Write(ex.Message);

                }
            });
            //Task<List<String>> voTask = new Task<List<String>>(() => GetLinksFromFile(vsFilepath));
            return task;
            
	
		}

		private void btnSort_Click(object sender, EventArgs e)
		{
			importSortTextFileLinks();
		}
		//importSortTextFileLinks
		private void MergeLinkFiles()
		{
			cFile oFile = new cFile("FilesLoaded");
			try
			{
				string startupPath = Application.StartupPath;
				using (FolderBrowserDialog dialog = new FolderBrowserDialog())
				{
				
				   //     string folder = dialog.SelectedPath;
						lblOutput.Text = "started";
						oMerge.ExportedLinkPath = "Merge.txt";
						oMerge.GetLinks("C:\\Users\\joshua\\Desktop\\ff-links");
						lblOutput.Text = "outputting";
						oMerge.WriteLinks();
					   // oMerge.WriteLinks();
						lblOutput.Text = "done";
		
						
				   
					}
				 lblOutput.Text = "done";
				}
			 
			   
			
			catch (Exception exc)
			{
				MessageBox.Show("Import failed because " + exc.Message + " , please try again later.");
			}
			}
		private void importSortTextFileLinks()
		{
			cFile oFile = new cFile("FilesLoaded");
			try
			{
				string startupPath = Application.StartupPath;
				using (FolderBrowserDialog dialog = new FolderBrowserDialog())
				{
					dialog.Description = "Open a folder which contains the xml output";
				  //  dialog.ShowNewFolderButton = false;
				   // dialog.RootFolder = Environment.SpecialFolder.MyComputer;
					if (dialog.ShowDialog() == DialogResult.OK)
					{
						string folder = dialog.SelectedPath;
						lblOutput.Text = dialog.SelectedPath;
						foreach (string fileName in Directory.GetFiles(folder, "*.txt", SearchOption.AllDirectories))
						{
							oTool.ExportedLinkPath = "Input.txt";
						 List<string> sUrls =  oTool.GetLinksFromFile(fileName);
						 oTool.WriteLinks(sUrls);
						 oTool.AddUrlList(sUrls);
							oFile.Write(fileName);
							//SQLGenerator.GenerateSQLTransactions(Path.GetFullPath(fileName));
						}
						oTool.Sort();
					}
				}
				//using (OpenFileDialog dialog = new OpenFileDialog())
				//{
				//    dialog.Filter = "xml files (*.xml)|*.xml";
				//    dialog.Multiselect = false;
				//    dialog.InitialDirectory = ".";
				//    dialog.Title = "Select file (only in XML format)";
				//    if (dialog.ShowDialog() == DialogResult.OK)
				//    {
				//        SQLGenerator.GenerateSQLTransactions(Application.StartupPath + Settings.Default.xmlFile);
				//    }
				//}
				lblOutput.Text = "done";
			}
			catch (Exception exc)
			{
				MessageBox.Show("Import failed because " + exc.Message + " , please try again later.");
			}

		}

		private void btnMergeLinkFiles_Click(object sender, EventArgs e)
		{
			MergeLinkFiles();
		}
	}
}
