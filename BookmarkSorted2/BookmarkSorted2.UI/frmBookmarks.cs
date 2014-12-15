using System;
using System.IO;
using System.Windows.Forms;
using BookmarkSorted2.shared;

namespace BookmarkSorted2.UI
{
    public partial class frmBookmarks : Form
    {
        public frmBookmarks()
        {
            InitializeComponent();
        }

        private void one()
        {
            CBookmarkSorter oBkSorter = null;
            StreamReader oFile = null;
            string sPath = "c:\\fileio\\flatfile.txt";
            int icnt = 0;
            string strBookmark = null;
            oBkSorter = new CBookmarkSorter();

            var ofdOpenDlg = new OpenFileDialog();

            ofdOpenDlg.InitialDirectory = "C:\\FileIO";
            ofdOpenDlg.Title = "Pick a file to Open";
            ofdOpenDlg.Filter = "Text files (*.txt)|*.txt|All Files (*.*)|*.*";


            if (ofdOpenDlg.ShowDialog() == DialogResult.OK)
            {
                // Open the file that the user picked

                sPath = ofdOpenDlg.FileName;
                Text = sPath;

                if (File.Exists(sPath))
                {
                    oFile = File.OpenText(sPath);

                    while (oFile.Peek() != -1)
                    {
                        icnt += 1;
                        strBookmark = oFile.ReadLine();
                        oBkSorter.SortBookmark(strBookmark);
                    }

                    // Cleanup the variables
                    oFile.Close();
                    oFile.Dispose();
                }
                else
                {
                    MessageBox.Show("File doeesn't exist.");
                }
            }
            oFile = null;
        }

        private void two()
        {
            CBookmarkExtractor oBkExtractor = null;
            StreamReader oFile = null;
            string sPath = "c:\\fileio\\flatfile.txt";
            int icnt = 0;
            string strBookmark = null;
            oBkExtractor = new CBookmarkExtractor();

            var ofdOpenDlg = new OpenFileDialog();

            ofdOpenDlg.InitialDirectory = "C:\\FileIO";
            ofdOpenDlg.Title = "Pick a file to Open";
            ofdOpenDlg.Filter = "Text files (*.html)|*.txt|All Files (*.*)|*.*";


            if (ofdOpenDlg.ShowDialog() == DialogResult.OK)
            {
                // Open the file that the user picked

                sPath = ofdOpenDlg.FileName;
                Text = sPath;

                if (File.Exists(sPath))
                {
                    oFile = File.OpenText(sPath);

                    while (oFile.Peek() != -1)
                    {
                        icnt += 1;
                        strBookmark = oFile.ReadLine();
                        oBkExtractor.ExtractBookmark(strBookmark);
                    }

                    // Cleanup the variables
                    oFile.Close();
                    oFile.Dispose();
                }
                else
                {
                    MessageBox.Show("File doeesn't exist.");
                }
            }
            oFile = null;
        }

        private void btnHtml_Click(object sender, EventArgs e)
        {
            two();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            one();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}