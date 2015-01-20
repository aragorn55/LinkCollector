using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookmarkCollector.ob;
namespace BookmarkCollector.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTextLinkLoad_Click(object sender, EventArgs e)
        {
             CBookmarkReader oReader = new CBookmarkReader();
        string spath = txtTextInputPath.Text;
            if (!oReader.GetLinkFilesFromFile(spath)) return;
            if (oReader.ReadLinksFromTextFiles())
            {
                oReader.SaveLinks();
            }
        }

        private void btnHtml_Click(object sender, EventArgs e)
        {
            CBookmarkReader oReader = new CBookmarkReader();
            string spath = txtHtml.Text;
            if (!oReader.GetLinkFilesFromFile(spath)) return;
            if (oReader.ReadWriteLinksFromHtmlFiles())
            {
                MessageBox.Show("done");
            }
        }

        private void btnSqlite_Click(object sender, EventArgs e)
        {

        }

        private void btnChrome_Click(object sender, EventArgs e)
        {

        }
        }
           
    }
