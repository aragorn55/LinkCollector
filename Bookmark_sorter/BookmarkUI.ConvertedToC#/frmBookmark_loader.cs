using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using Bookmark_sorter;
namespace BookmarkUI
{

	public partial class frmBookmark_loader
	{

		private void btnOpen_Click(System.Object sender, System.EventArgs e)
		{
			CBookmarkSorter oBkSorter = null;
			StreamReader oFile = null;
			string sPath = "c:\\fileio\\flatfile.txt";
			int icnt = 0;
			string strBookmark = null;
			oBkSorter = new CBookmarkSorter();

			OpenFileDialog ofdOpenDlg = new OpenFileDialog();

			ofdOpenDlg.InitialDirectory = "C:\\FileIO";
			ofdOpenDlg.Title = "Pick a file to Open";
			ofdOpenDlg.Filter = "Text files (*.txt)|*.txt|All Files (*.*)|*.*";


			if (ofdOpenDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				// Open the file that the user picked

				sPath = ofdOpenDlg.FileName;
				this.Text = sPath;

				if (File.Exists(sPath)) {
					oFile = File.OpenText(sPath);

					while (oFile.Peek() != -1) {
						icnt += 1;
						strBookmark = oFile.ReadLine();
						oBkSorter.SortBookmark(strBookmark);
					}

					// Cleanup the variables
					oFile.Close();
					oFile.Dispose();


				} else {
					MessageBox.Show("File doeesn't exist.");

				}

			}
			oFile = null;


		}

		private void btnHtml_Click(System.Object sender, System.EventArgs e)
		{
			CBookmarkExtractor oBkExtractor = null;
			StreamReader oFile = null;
			string sPath = "c:\\fileio\\flatfile.txt";
			int icnt = 0;
			string strBookmark = null;
			oBkExtractor = new CBookmarkExtractor();

			OpenFileDialog ofdOpenDlg = new OpenFileDialog();

			ofdOpenDlg.InitialDirectory = "C:\\FileIO";
			ofdOpenDlg.Title = "Pick a file to Open";
			ofdOpenDlg.Filter = "Text files (*.html)|*.txt|All Files (*.*)|*.*";


			if (ofdOpenDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				// Open the file that the user picked

				sPath = ofdOpenDlg.FileName;
				this.Text = sPath;

				if (File.Exists(sPath)) {
					oFile = File.OpenText(sPath);

					while (oFile.Peek() != -1) {
						icnt += 1;
						strBookmark = oFile.ReadLine();
						oBkExtractor.ExtractBookmark(strBookmark);
					}

					// Cleanup the variables
					oFile.Close();
					oFile.Dispose();


				} else {
					MessageBox.Show("File doeesn't exist.");

				}

			}
			oFile = null;


		}
	}
}
