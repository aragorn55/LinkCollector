// End of VB project level imports
// VBConversions Note: VB project level imports
//using System.IO.File;

//using Microsoft.VisualBasic.CompilerServices;
//using Microsoft.VisualBasic;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zlib;
using Microsoft.Win32;
using Ionic.Zip;
using System.Drawing;
using  Utilities.DL;
namespace FicFilTool.Model
{
    public class CEpubFile
    {
        public string FileName = "";
        public int selectedIndex = -1;
        private string appdatafolder;
        private string CaptionString;
        private string coverfile;
        private string coverimagefile;
        private string coverimagefilename;
        private int currentfilenumber;
        private string ebookdirectory;
        private string epubstring = "";
        private bool fixcovermanifest;
        private bool fixcovermetadata;
        private bool m_MouseIsDown;
        private string opfdirectory;
        private string opffile;
        private string pagemapfile;
        private bool possibleDRM;
        private bool projectchanged;
        private bool refreshfilelist = true;
        private string relativecoverimagefile;
        private string[] searchResults;
        private string sFilePath;
        private string tempdirectory;
        private string tocfile;
        private string tocncxfile;
        private string updateinfo;
        private string versioninfo;

        public string _sFileName { get; set; }

        public string Button20 { get; set; }

        public List<String> ComboBox1 { get; set; }

        public int ComboBox1SelectedIndex { get; set; }

        public int ComboBox2SelectedIndex { get; set; }

        public List<string> ComboBox3 { get; set; }

        public int ComboBox3SelectedIndex { get; set; }

        public string Label6 { get; set; }

        public string Label9 { get; set; }

        public string LinkLabel1 { get; set; }

        public List<String> ListBox1 { get; set; }

        public List<String> ListBox2 { get; set; }

        public int ListBox2SelectedIndex { get; set; }

        public Image PictureBox1 { get; set; }
        public Image PictureBox2 { get; set; }
        public string RichTextBox1 { get; set; }

        public string _Title { get; set; }

        public string _Souce { get; set; }

        public string TextBox11 { get; set; }

        public string TextBox12 { get; set; }

        public string TextBox13 { get; set; }

        public string TextBox14 { get; set; }

        public string TextBox15 { get; set; }

        public string TextBox16 { get; set; }

        public string TextBox17 { get; set; }

        public string _Creator { get; set; }

        public string TextBox3 { get; set; }

        public string TextBox4 { get; set; }

        public string TextBox5 { get; set; }

        public string TextBox6 { get; set; }

        public string TextBox7 { get; set; }

        public string TextBox8 { get; set; }

        public string TextBox9 { get; set; }

        public string _Description { get; set; }
        public string DealWithPreviousFile()
        {
            if (projectchanged)
            {
               
                
                    SaveEpub();
                
            }

            // Delete previous temp directory (if it exists)
            if (tempdirectory != "")
            {
                Directory.SetCurrentDirectory(tempdirectory);
                if (ebookdirectory != "")
                {
                    if (Directory.Exists(ebookdirectory))
                    {
                        Directory.Delete(ebookdirectory);
                    }
                }
            }

            ClearInterface();
           
            return ("proceed");
        }

        public void DeleteDirContents(DirectoryInfo dir)
        {
            FileInfo[] fa = null;
            FileInfo f = default(FileInfo);

            fa = dir.GetFiles();

            foreach (FileInfo tempLoopVar_f in fa)
            {
                f = tempLoopVar_f;
                f.Delete();
            }

            DirectoryInfo[] da = null;
            DirectoryInfo d1 = default(DirectoryInfo);

            da = dir.GetDirectories();
            foreach (DirectoryInfo tempLoopVar_d1 in da)
            {
                d1 = tempLoopVar_d1;
                DeleteDirContents(d1);
            }
        }

        public void OpenEPUB(string vsFilename)
        {
            string metadatafile = default(string);
            int instance = default(int);
            FileName = vsFilename;
            //Unzip epub to temp directory
            tempdirectory = Path.GetTempPath();
            instance = 1;
            ebookdirectory = tempdirectory + "EPUB" + instance;
            while (Directory.Exists(ebookdirectory))
            {
                try
                {
                    Directory.Delete(ebookdirectory);
                    goto founddirectory;
                }
                catch (Exception ex)
                {
                    instance++;
                    ebookdirectory = tempdirectory + "EPUB" + instance;
                }
            }
        founddirectory:
            Directory.CreateDirectory(ebookdirectory);
            Directory.SetCurrentDirectory(ebookdirectory);

            try
            {
                using (ZipFile zip = ZipFile.Read(vsFilename))
                {
                    ZipEntry item = default(ZipEntry);
                    foreach (ZipEntry tempLoopVar_item in zip)
                    {
                        item = tempLoopVar_item;
                        item.Extract();
                    }
                    zip.Dispose();
                }
            }
            catch (Exception ex1)
            {
                Console.Error.WriteLine("exception: {0}", ex1);
            }

            //Search for .opf file
            searchResults = Directory.GetFiles(ebookdirectory, "*.opf", SearchOption.AllDirectories);

            //Open .opf file into RichTextBox
            if (searchResults.Length < 1)
            {
                CFile.LogError("ERROR: Metadata not found." + '\n' + "This ebook is malformed.");

                opffile = "";
                return;
            }
            opffile = searchResults[0];
            if (Convert.ToBoolean(opffile.IndexOf("_MACOSX") + 1))
            {
                if (searchResults.Length > 1)
                {
                    opffile = searchResults[1];
                }
            }
            opfdirectory = Path.GetDirectoryName(opffile);
            RichTextBox1 = LoadUnicodeFile(opffile);

            //Process .opf file to determine EPUB version
            string opffiletext = default(string);
            int packagepos = default(int);
            int endpos = default(int);
            int versionpos = default(int);
            opffiletext = RichTextBox1;
            packagepos = opffiletext.IndexOf("<package") + 1;
            if (packagepos != 0)
            {
                endpos = opffiletext.IndexOf(">", packagepos - 1) + 1;
                versionpos = opffiletext.IndexOf("version=", packagepos - 1) + 1;
                if (versionpos < endpos)
                {
                    versioninfo = opffiletext.Substring(versionpos + 9 - 1, 3);
                }
            }

            if (versioninfo == "3.0")
            {
                //Search for toc.ncx file (included in some EPUB3 files for forward compatibility)
                searchResults = Directory.GetFiles(ebookdirectory, "*.ncx", SearchOption.AllDirectories);
                if (searchResults.Length < 1)
                {
                    tocncxfile = "";
                }
                else
                {
                    tocncxfile = searchResults[0];
                    if (Convert.ToBoolean(tocncxfile.IndexOf("_MACOSX") + 1))
                    {
                        if (searchResults.Length > 1)
                        {
                            tocncxfile = searchResults[1];
                        }
                    }
                }

                //Search for nav file
                int itempos = default(int);
                int tocpos = default(int);
                int hrefpos = default(int);
                int itemend = default(int);
                itempos = opffiletext.IndexOf("<item ") + 1;
                while (itempos != 0)
                {
                    itemend = opffiletext.IndexOf("/>", itempos - 1) + 1;
                    tocpos = opffiletext.IndexOf("properties=" + '\u0022' + "nav" + '\u0022') + 1;
                    if (tocpos != 0)
                    {
                        if (tocpos < itemend)
                        {
                            //Found nav file
                            hrefpos = opffiletext.IndexOf("href=", itempos - 1) + 1;
                            endpos = opffiletext.IndexOf(('\u0022').ToString(), hrefpos + 6 - 1) + 1;
                            tocfile = opfdirectory + "\\" +
                                      opffiletext.Substring(hrefpos + 6 - 1, endpos - hrefpos - 6).Replace("/", "\\");

                            Button20 = "Edit nav file";
                            goto lookforpagemap;
                        }
                        //Go to next item
                        itempos = opffiletext.IndexOf("<item ", itemend - 1) + 1;
                    }
                    else
                    {
                        //No nav document
                        CFile.LogError("ERROR: Table of Contents file not found." + '\n' + "This ebook is malformed.");

                        tocfile = "";

                        goto lookforpagemap;
                    }
                }
            }
            else
            {
                //Search for toc.ncx file
                searchResults = Directory.GetFiles(ebookdirectory, "*.ncx", SearchOption.AllDirectories);
                if (searchResults.Length < 1)
                {
                    CFile.LogError("ERROR: Table of Contents file not found." + '\n' + "This ebook is malformed.");

                    tocfile = "";
                }
                else
                {
                    tocfile = searchResults[0];
                    if (Convert.ToBoolean(tocfile.IndexOf("_MACOSX") + 1))
                    {
                        if (searchResults.Length > 1)
                        {
                            tocfile = searchResults[1];
                        }
                    }
                }
                //   Button20 = "Edit toc.ncx file";
            }

        lookforpagemap:
            //Search for page-map.xml file
            searchResults = Directory.GetFiles(ebookdirectory, "page-map.xml", SearchOption.AllDirectories);
            if (searchResults.Length < 1)
            {
                pagemapfile = "";
            }
            else
            {
                pagemapfile = searchResults[0];
                if (Convert.ToBoolean(pagemapfile.IndexOf("_MACOSX") + 1))
                {
                    if (searchResults.Length > 1)
                    {
                        pagemapfile = searchResults[1];
                    }
                }
            }


            //Extract metadata into textboxes
            metadatafile = RichTextBox1;
            ExtractMetadata(metadatafile, true);

            //Process current folder to locate other EPUB files
            searchResults = Directory.GetFiles(Path.GetDirectoryName(vsFilename), "*.epub",
                SearchOption.TopDirectoryOnly);
            refreshfilelist = true;
            ComboBox3.Clear();
            string fi = default(string);
            foreach (string tempLoopVar_fi in searchResults)
            {
                fi = tempLoopVar_fi;
                ComboBox3.Add(fi.Substring(fi.LastIndexOf("\\") + 1, fi.Length - fi.LastIndexOf("\\") - 1));
            }
            int x = 0;
            while (searchResults[x] != vsFilename)
            {
                x++;
            }
            currentfilenumber = x + 1; //searchResults is zero based
            ComboBox3SelectedIndex = x;


            //Update interface
            if (!possibleDRM)
            {
                CaptionString = Path.GetFileName(vsFilename) + " [" + currentfilenumber + "/" + searchResults.Length +
                                "] - EPUB Metadata Editor";
                epubstring = CaptionString;
                projectchanged = false;

                //SaveImageAsToolStripMenuItem.Enabled = True
                if (versioninfo == "3.0")
                {
                    //Title cannot have 'file-as' apparently

                    CFile.LogError("Warning: You are opening an EPUB3 file." + '\n' +
                                   "EPUB3 handing is in alpha-release only.");
                }
            }
            else
            {
                ClearInterface();
                CaptionString = Path.GetFileName(vsFilename) + " [" + currentfilenumber + "/" + searchResults.Length +
                                "] - EPUB Metadata Editor";
                epubstring = CaptionString;
                projectchanged = false;
                CFile.LogError("ERROR: Image file corrupted or encrypted." + '\n' +
                               "Note that EPUB Metadata Editor cannot handle" + '\n' + "EPUB files locked by DRM.");
            }
        }

        public void OpenEPUBFile()
        {
            throw new NotImplementedException();
        }



        public async Task  SaveEpub()
        {
            string metadatafile = default(string);
            string dcnamespace = default(string);
            string optionaltext = default(string);
            string optionaltext2 = default(string);
            int startpos = default(int);
            int namespacelen = default(int);
            int endtag = default(int);
            int endpos = default(int);
            int extracheck = default(int);
            int lenheader = default(int);
            int checktag = default(int);
            int lookforID = default(int);
            int endID = default(int);
            string temporarydirectory = default(string);
            string newheader = default(string);
            string ID = default(string);
            int idpos = default(int);
            int temploop = default(int);
            int temppos = default(int);
            int endheaderpos = default(int);
            int refinespos = default(int);
            int testpos = default(int);
            string idinfo = default(string);
            string rolestring = default(string);
            string identifierscheme = default(string);
            bool creatorfileasplaced = default(bool);
            bool creatorroleplaced = default(bool);
            bool creator2fileasplaced = default(bool);
            bool creator2roleplaced = default(bool);
            bool schemeplaced = default(bool);

            var fi = new FileInfo(FileName);
            /*
            if (FileInUse(fi.FullName))
            {
                CFile.LogError("ERROR: File in use!  Cannot save changes.");
                return;
            }
            */
            //Rewrite .opf file (just the metadata section)
            RichTextBox1 = LoadUnicodeFile(opffile);
            metadatafile = RichTextBox1;

            //Check for non-standard dc namespace tags
            startpos = metadatafile.IndexOf("=" + '\u0022' + "http://purl.org/dc/elements/1.1/") + 1;
            if (startpos != 0)
            {
                // work backwards to find the xmlns definition
                namespacelen = 0;
                while (startpos - namespacelen != 0)
                {
                    namespacelen++;
                    if (metadatafile.Substring(startpos - namespacelen - 1, 6) == "xmlns:")
                    {
                        break;
                    }
                }
                if (namespacelen < startpos)
                {
                    dcnamespace = metadatafile.Substring(startpos - namespacelen + 6 - 1, namespacelen - 6);
                    metadatafile = metadatafile.Replace(dcnamespace + ":", "dc:");
                    metadatafile = metadatafile.Replace("xmlns:" + dcnamespace, "xmlns:dc");
                }
            }

            //Check for non-standard opf namespace tags
            if (
                Convert.ToBoolean(metadatafile.IndexOf("<opf:metadata>") + 1 |
                                  metadatafile.IndexOf("<opf:manifest>") + 1))
            {
                metadatafile = metadatafile.Replace("<opf:", "<");
                metadatafile = metadatafile.Replace("</opf:", "</");
            }

            //Search for xmlns:opf="http://www.idpf.org/2007/opf"
            startpos = metadatafile.IndexOf("xmlns:opf=" + '\u0022' + "http://www.idpf.org/2007/opf" + '\u0022') + 1;
            temppos = metadatafile.IndexOf("<dc:") + 1;
            if ((startpos == 0) || (startpos > temppos))
            {
                //Add it to <metadata > tag
                startpos = metadatafile.IndexOf("<metadata") + 1;
                startpos = metadatafile.IndexOf(">", startpos - 1) + 0;
                extracheck =
                    metadatafile.IndexOf("xmlns:dc=" + '\u0022' + "http://purl.org/dc/elements/1.1/" + '\u0022') + 1;
                if (extracheck == 0)
                {
                    metadatafile = metadatafile.Substring(0, startpos) + " xmlns:dc=" + '\u0022' +
                                   "http://purl.org/dc/elements/1.1/" + '\u0022' + " xmlns:opf=" + '\u0022' +
                                   "http://www.idpf.org/2007/opf" + '\u0022' + metadatafile.Substring(startpos + 1 - 1);
                }
                else
                {
                    metadatafile = metadatafile.Substring(0, startpos) + " xmlns:opf=" + '\u0022' +
                                   "http://www.idpf.org/2007/opf" + '\u0022' + metadatafile.Substring(startpos + 1 - 1);
                }
            }

            //Output title
            startpos = metadatafile.IndexOf("<dc:title") + 1;
            if (startpos != 0)
            {
                endpos = metadatafile.IndexOf("</dc:title>") + 1;
                lenheader = "<dc:title".Length;

                //If optional attributes
                if (TextBox16 != "")
                {
                    optionaltext = " opf:file-as=" + '\u0022' + XMLOutput(TextBox16) + '\u0022' + ">";
                }
                else
                {
                    optionaltext = ">";
                }
                metadatafile = metadatafile.Substring(0, startpos + lenheader - 1) + optionaltext + XMLOutput(_Title) +
                               metadatafile.Substring(endpos - 1);
            }
            else
            {
                // no title yet, so add it after <metadata... > tag
                startpos = metadatafile.IndexOf("<metadata") + 1;
                startpos = metadatafile.IndexOf(">", startpos - 1) + 2;
                //If optional attributes
                if (TextBox16 != "")
                {
                    optionaltext = " opf:file-as=" + '\u0022' + XMLOutput(TextBox16) + '\u0022' + ">";
                }
                else
                {
                    optionaltext = ">";
                }
                metadatafile = metadatafile.Substring(0, startpos) + "  <dc:title" + optionaltext + XMLOutput(_Title) +
                               "</dc:title>" + metadatafile.Substring(startpos - 1);
            }

            //Output first creator
            startpos = metadatafile.IndexOf("<dc:creator") + 1;
            if (startpos != 0)
            {
                endheaderpos = metadatafile.IndexOf(">", startpos - 1) + 1;
                endpos = metadatafile.IndexOf("</dc:creator>", startpos - 1) + 1;
                lenheader = "<dc:creator".Length;
                if (versioninfo == "3.0")
                {
                    metadatafile = metadatafile.Substring(0, endheaderpos) + _Creator +
                                   metadatafile.Substring(endpos - 1);
                    // get id
                    idpos = metadatafile.IndexOf("id=", startpos - 1) + 1;
                    idinfo = "";
                    if (idpos != 0)
                    {
                        for (temploop = idpos + 4; temploop <= endpos; temploop++)
                        {
                            if (
                                Convert.ToBoolean(
                                    char.Parse(
                                        Convert.ToString(metadatafile.Substring(temploop - 1, 1) ==
                                                         Convert.ToString('\u0022')))))
                            {
                                idinfo = metadatafile.Substring(idpos + 4 - 1, temploop - idpos - 4);
                                goto lookforrefines;
                            }
                        }
                    }
                    else
                    {
                        metadatafile = metadatafile.Substring(0, startpos) + "<dc:creator id=" + '\u0022' + "creator" +
                                       '\u0022' + ">" + _Creator + metadatafile.Substring(endpos - 1);
                        idinfo = "creator";
                    }
                lookforrefines:
                    if (idinfo != "")
                    {
                        temppos =
                            metadatafile.IndexOf(("<meta refines=" + '\u0022' + "#" + idinfo + '\u0022'), startpos - 1) +
                            1;
                        creatorfileasplaced = false;
                        creatorroleplaced = false;
                        rolestring = "aut";
                        while (temppos != 0)
                        {
                            endheaderpos = metadatafile.IndexOf(">", temppos - 1) + 1;
                            endpos = metadatafile.IndexOf("</meta>", temppos - 1) + 1;
                            refinespos = metadatafile.IndexOf(("property=" + '\u0022' + "file-as"), temppos - 1) + 1;
                            if (refinespos != 0)
                            {
                                if (refinespos < endpos)
                                {
                                    metadatafile = metadatafile.Substring(0, endheaderpos) + TextBox12 +
                                                   metadatafile.Substring(endpos - 1);
                                    creatorfileasplaced = true;
                                }
                            }
                            refinespos = metadatafile.IndexOf(("property=" + '\u0022' + "role"), temppos - 1) + 1;
                            if (refinespos != 0)
                            {
                                if (refinespos < endpos)
                                {
                                    if (ComboBox1SelectedIndex == 1)
                                    {
                                        rolestring = "edt";
                                    }
                                    if (ComboBox1SelectedIndex == 2)
                                    {
                                        rolestring = "ill";
                                    }
                                    if (ComboBox1SelectedIndex == 3)
                                    {
                                        rolestring = "trl";
                                    }
                                    metadatafile = metadatafile.Substring(0, endheaderpos) + rolestring +
                                                   metadatafile.Substring(endpos - 1);
                                    creatorroleplaced = true;
                                }
                            }
                            temppos =
                                metadatafile.IndexOf(("<meta refines=" + '\u0022' + "#" + idinfo + '\u0022'), endpos - 1) +
                                1;
                        }
                        if (((creatorroleplaced == false) || (creatorfileasplaced == false)) && (TextBox12 != ""))
                        {
                            startpos = metadatafile.IndexOf("</dc:creator>") + 14; //end of creator
                            if ((creatorfileasplaced == false) && (creatorroleplaced == false))
                            {
                                metadatafile = metadatafile.Substring(0, startpos) + '\n' + "    <meta refines=" +
                                               '\u0022' + "#" + idinfo + '\u0022' + " property=" + '\u0022' + "file-as" +
                                               '\u0022' + ">" + TextBox12 + "</meta>" + '\n' + "    <meta refines=" +
                                               '\u0022' + "#" + idinfo + '\u0022' + " property=" + '\u0022' + "role" +
                                               '\u0022' + " scheme=" + '\u0022' + "marc:relators" + '\u0022' + ">" +
                                               rolestring + "</meta>" + metadatafile.Substring(startpos - 1);
                            }
                            else if ((creatorfileasplaced == false) && creatorroleplaced)
                            {
                                metadatafile = metadatafile.Substring(0, startpos) + '\n' + "    <meta refines=" +
                                               '\u0022' + "#" + idinfo + '\u0022' + " property=" + '\u0022' + "file-as" +
                                               '\u0022' + ">" + TextBox12 + "</meta>" +
                                               metadatafile.Substring(startpos - 1);
                            }
                            else if (creatorfileasplaced && (creatorroleplaced == false))
                            {
                                startpos = metadatafile.IndexOf("</meta>", startpos - 1) + 1;
                                metadatafile = metadatafile.Substring(0, startpos) + '\n' + "    <meta refines=" +
                                               '\u0022' + "#" + idinfo + '\u0022' + " property=" + '\u0022' + "role" +
                                               '\u0022' + " scheme=" + '\u0022' + "marc:relators" + '\u0022' + ">" +
                                               rolestring + "</meta>" + metadatafile.Substring(startpos - 1);
                            }
                        }
                    }

                    //Output second creator?
                    endpos = metadatafile.IndexOf("</dc:creator>") + 1; //find end of first creator
                    startpos = metadatafile.IndexOf("<dc:creator", endpos - 1) + 1; //look for another one
                    if ((TextBox3 != "") || (startpos != 0))
                    {
                        if (startpos != 0)
                        {
                            endheaderpos = metadatafile.IndexOf(">", startpos - 1) + 1;
                            endpos = metadatafile.IndexOf("</dc:creator>", startpos - 1) + 1;
                            metadatafile = metadatafile.Substring(0, endheaderpos) + TextBox3 +
                                           metadatafile.Substring(endpos - 1);

                            // get id
                            idpos = metadatafile.IndexOf("id=", startpos - 1) + 1;
                            idinfo = "";
                            if (idpos != 0)
                            {
                                for (temploop = idpos + 4; temploop <= endpos; temploop++)
                                {
                                    if (
                                        Convert.ToBoolean(
                                            char.Parse(
                                                Convert.ToString(metadatafile.Substring(temploop - 1, 1) ==
                                                                 Convert.ToString('\u0022')))))
                                    {
                                        idinfo = metadatafile.Substring(idpos + 4 - 1, temploop - idpos - 4);
                                        goto lookforrefines2;
                                    }
                                }
                            }
                            else
                            {
                                metadatafile = metadatafile.Substring(0, startpos) + "<dc:creator id=" + '\u0022' +
                                               "creator2" + '\u0022' + ">" + TextBox3 +
                                               metadatafile.Substring(endpos - 1);
                                idinfo = "creator2";
                            }
                        lookforrefines2:
                            if (idinfo != "")
                            {
                                temppos =
                                    metadatafile.IndexOf(("<meta refines=" + '\u0022' + "#" + idinfo + '\u0022'),
                                        startpos - 1) + 1;
                                creator2fileasplaced = false;
                                creator2roleplaced = false;
                                rolestring = "aut";
                                while (temppos != 0)
                                {
                                    endheaderpos = metadatafile.IndexOf(">", temppos - 1) + 1;
                                    endpos = metadatafile.IndexOf("</meta>", temppos - 1) + 1;
                                    refinespos =
                                        metadatafile.IndexOf(("property=" + '\u0022' + "file-as"), temppos - 1) + 1;
                                    if (refinespos != 0)
                                    {
                                        if (refinespos < endpos)
                                        {
                                            metadatafile = metadatafile.Substring(0, endheaderpos) + TextBox13 +
                                                           metadatafile.Substring(endpos - 1);
                                            creator2fileasplaced = true;
                                        }
                                    }
                                    refinespos = metadatafile.IndexOf(("property=" + '\u0022' + "role"), temppos - 1) +
                                                 1;
                                    if (refinespos != 0)
                                    {
                                        if (refinespos < endpos)
                                        {
                                            if (ComboBox2SelectedIndex == 1)
                                            {
                                                rolestring = "edt";
                                            }
                                            if (ComboBox2SelectedIndex == 2)
                                            {
                                                rolestring = "ill";
                                            }
                                            if (ComboBox2SelectedIndex == 3)
                                            {
                                                rolestring = "trl";
                                            }
                                            metadatafile = metadatafile.Substring(0, endheaderpos) + rolestring +
                                                           metadatafile.Substring(endpos - 1);
                                            creator2roleplaced = true;
                                        }
                                    }
                                    temppos =
                                        metadatafile.IndexOf(("<meta refines=" + '\u0022' + "#" + idinfo + '\u0022'),
                                            endpos - 1) + 1;
                                }
                                if (((creator2roleplaced == false) || (creator2fileasplaced == false)) &&
                                    (TextBox13 != ""))
                                {
                                    startpos = metadatafile.IndexOf("</dc:creator>") + 1;
                                    startpos = metadatafile.IndexOf("</dc:creator>", startpos + 1 - 1) + 14;
                                    //end of second creator
                                    if ((creator2fileasplaced == false) && (creator2roleplaced == false))
                                    {
                                        metadatafile = metadatafile.Substring(0, startpos) + '\n' + "    <meta refines=" +
                                                       '\u0022' + "#" + idinfo + '\u0022' + " property=" + '\u0022' +
                                                       "file-as" + '\u0022' + ">" + TextBox13 + "</meta>" + '\n' +
                                                       "    <meta refines=" + '\u0022' + "#" + idinfo + '\u0022' +
                                                       " property=" + '\u0022' + "role" + '\u0022' + " scheme=" +
                                                       '\u0022' + "marc:relators" + '\u0022' + ">" + rolestring +
                                                       "</meta>" + metadatafile.Substring(startpos - 1);
                                    }
                                    else if ((creator2fileasplaced == false) && creator2roleplaced)
                                    {
                                        metadatafile = metadatafile.Substring(0, startpos) + '\n' + "    <meta refines=" +
                                                       '\u0022' + "#" + idinfo + '\u0022' + " property=" + '\u0022' +
                                                       "file-as" + '\u0022' + ">" + TextBox13 + "</meta>" +
                                                       metadatafile.Substring(startpos - 1);
                                    }
                                    else if (creator2fileasplaced && (creator2roleplaced == false))
                                    {
                                        startpos = metadatafile.IndexOf("</meta>", startpos - 1) + 1;
                                        metadatafile = metadatafile.Substring(0, startpos) + '\n' + "    <meta refines=" +
                                                       '\u0022' + "#" + idinfo + '\u0022' + " property=" + '\u0022' +
                                                       "role" + '\u0022' + " scheme=" + '\u0022' + "marc:relators" +
                                                       '\u0022' + ">" + rolestring + "</meta>" +
                                                       metadatafile.Substring(startpos - 1);
                                    }
                                }
                            }
                        }
                        else
                        {
                            //Second creator being added
                            startpos = metadatafile.IndexOf("</dc:creator>") + 1;
                            startpos = metadatafile.IndexOf("<dc:", startpos - 1) + 0;
                            //start of next item after first creator
                            rolestring = "aut";
                            if (ComboBox2SelectedIndex == 1)
                            {
                                rolestring = "edt";
                            }
                            if (ComboBox2SelectedIndex == 2)
                            {
                                rolestring = "ill";
                            }
                            if (ComboBox2SelectedIndex == 3)
                            {
                                rolestring = "trl";
                            }
                            metadatafile = metadatafile.Substring(0, startpos) + "<dc:creator id=" + '\u0022' +
                                           "creator2" + '\u0022' + ">" + TextBox3 + "</dc:creator>" + '\n' +
                                           "    <meta refines=" + '\u0022' + "#creator2" + '\u0022' + " property=" +
                                           '\u0022' + "file-as" + '\u0022' + ">" + TextBox13 + "</meta>" + '\n' +
                                           "    <meta refines=" + '\u0022' + "#creator2" + '\u0022' + " property=" +
                                           '\u0022' + "role" + '\u0022' + " scheme=" + '\u0022' + "marc:relators" +
                                           '\u0022' + ">" + rolestring + "</meta>" + '\n' + "    " +
                                           metadatafile.Substring(startpos - 1);
                        }
                    }
                    if (TextBox3 == "")
                    {
                        endpos = metadatafile.IndexOf("</dc:creator>") + 1; //find end of first creator
                        startpos = metadatafile.IndexOf("<dc:creator", endpos - 1) + 1; //look for another one
                        if (startpos != 0)
                        {
                            //Second creator exists but needs to be deleted
                            endpos = metadatafile.IndexOf("</dc:creator>", startpos - 1) + 1;

                            //Get id
                            idpos = metadatafile.IndexOf("id=", startpos - 1) + 1;
                            idinfo = "";
                            if (idpos != 0)
                            {
                                for (temploop = idpos + 4; temploop <= endpos; temploop++)
                                {
                                    if (
                                        Convert.ToBoolean(
                                            char.Parse(
                                                Convert.ToString(metadatafile.Substring(temploop - 1, 1) ==
                                                                 Convert.ToString('\u0022')))))
                                    {
                                        idinfo = metadatafile.Substring(idpos + 4 - 1, temploop - idpos - 4);
                                        temppos =
                                            metadatafile.IndexOf(
                                                ("<meta refines=" + '\u0022' + "#" + idinfo + '\u0022'), startpos - 1) +
                                            1;
                                        while (temppos != 0)
                                        {
                                            endpos = metadatafile.IndexOf("</meta>", temppos - 1) + 1;
                                            metadatafile = metadatafile.Substring(0, temppos - 1) +
                                                           metadatafile.Substring(endpos + 8 - 1);
                                            startpos = metadatafile.IndexOf("</dc:creator>") + 1;
                                            startpos = metadatafile.IndexOf("<dc:creator", startpos - 1) + 1;
                                            temppos =
                                                metadatafile.IndexOf(
                                                    ("<meta refines=" + '\u0022' + "#" + idinfo + '\u0022'),
                                                    startpos - 1) + 1;
                                        }
                                        startpos = metadatafile.IndexOf("</dc:creator>") + 1;
                                        startpos = metadatafile.IndexOf("<dc:creator", startpos - 1) + 1;
                                        endpos = metadatafile.IndexOf("</dc:creator>", startpos - 1) + 1;
                                        metadatafile = metadatafile.Substring(0, startpos - 1) +
                                                       metadatafile.Substring(endpos + 14 - 1);
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                //No id (therefore no refines)
                                metadatafile = metadatafile.Substring(0, startpos - 1) +
                                               metadatafile.Substring(endpos + 14 - 1);
                            }
                        }
                    }
                }
                else
                {
                    //If optional attributes
                    if (TextBox12 != "")
                    {
                        optionaltext = "";
                        if ((ComboBox1SelectedIndex == 0) || (ComboBox1SelectedIndex == -1))
                        {
                            optionaltext = " opf:role=" + '\u0022' + "aut" + '\u0022';
                        }
                        if (ComboBox1SelectedIndex == 1)
                        {
                            optionaltext = " opf:role=" + '\u0022' + "edt" + '\u0022';
                        }
                        if (ComboBox1SelectedIndex == 2)
                        {
                            optionaltext = " opf:role=" + '\u0022' + "ill" + '\u0022';
                        }
                        if (ComboBox1SelectedIndex == 3)
                        {
                            optionaltext = " opf:role=" + '\u0022' + "trl" + '\u0022';
                        }
                        optionaltext = optionaltext + " opf:file-as=" + '\u0022' + TextBox12 + '\u0022' + ">";
                    }
                    else
                    {
                        optionaltext = ">";
                    }
                    metadatafile = metadatafile.Substring(0, startpos + lenheader - 1) + optionaltext + _Creator +
                                   metadatafile.Substring(endpos - 1);

                    //Output second creator?
                    endpos = metadatafile.IndexOf("</dc:creator>") + 1; //find end of first creator
                    startpos = metadatafile.IndexOf("<dc:creator", endpos - 1) + 1; //look for another one
                    if ((TextBox3 != "") || (startpos != 0))
                    {
                        //Get optional attributes
                        if (TextBox13 != "")
                        {
                            optionaltext = "";
                            if ((ComboBox2SelectedIndex == 0) || (ComboBox2SelectedIndex == -1))
                            {
                                optionaltext = " opf:role=" + '\u0022' + "aut" + '\u0022';
                            }
                            if (ComboBox2SelectedIndex == 1)
                            {
                                optionaltext = " opf:role=" + '\u0022' + "edt" + '\u0022';
                            }
                            if (ComboBox2SelectedIndex == 2)
                            {
                                optionaltext = " opf:role=" + '\u0022' + "ill" + '\u0022';
                            }
                            if (ComboBox2SelectedIndex == 3)
                            {
                                optionaltext = " opf:role=" + '\u0022' + "trl" + '\u0022';
                            }
                            optionaltext = optionaltext + " opf:file-as=" + '\u0022' + TextBox13 + '\u0022' + ">";
                        }
                        else
                        {
                            optionaltext = ">";
                        }
                        if (startpos != 0)
                        {
                            endpos = metadatafile.IndexOf("</dc:creator>", startpos - 1) + 1;
                            lenheader = "<dc:creator".Length;
                            metadatafile = metadatafile.Substring(0, startpos + lenheader - 1) + optionaltext + TextBox3 +
                                           metadatafile.Substring(endpos - 1);
                        }
                        else
                        {
                            //Original file did not have second creator
                            metadatafile = metadatafile.Substring(0, endpos + 13) + '\r' + '\n' + '\t' + "<dc:creator" +
                                           optionaltext + TextBox3 + "</dc:creator>" + '\r' + '\n' +
                                           metadatafile.Substring(endpos + 14 - 1);
                        }
                    }
                    if (TextBox3 == "")
                    {
                        endpos = metadatafile.IndexOf("</dc:creator>") + 1; //find end of first creator
                        startpos = metadatafile.IndexOf("<dc:creator", endpos - 1) + 1; //look for another one
                        if (startpos != 0)
                        {
                            //Second creator exists but needs to be deleted
                            endpos = metadatafile.IndexOf("</dc:creator>", startpos - 1) + 1;
                            metadatafile = metadatafile.Substring(0, startpos - 1) +
                                           metadatafile.Substring(endpos + 14 - 1);
                        }
                    }
                }
            }
            else
            {
                if (versioninfo == "3.0")
                {
                    //Creator being added
                    startpos = metadatafile.IndexOf("</dc:title>") + 1;
                    startpos = metadatafile.IndexOf("<dc:", startpos - 1) + 0; //start of next item after title
                    if (TextBox12 != "")
                    {
                        rolestring = "aut";
                        if (ComboBox1SelectedIndex == 1)
                        {
                            rolestring = "edt";
                        }
                        if (ComboBox1SelectedIndex == 2)
                        {
                            rolestring = "ill";
                        }
                        if (ComboBox1SelectedIndex == 3)
                        {
                            rolestring = "trl";
                        }
                        metadatafile = metadatafile.Substring(0, startpos) + "<dc:creator id=" + '\u0022' + "creator" +
                                       '\u0022' + ">" + _Creator + "</dc:creator>" + '\n' + "    <meta refines=" +
                                       '\u0022' + "#creator" + '\u0022' + " property=" + '\u0022' + "file-as" + '\u0022' +
                                       ">" + TextBox12 + "</meta>" + '\n' + "    <meta refines=" + '\u0022' + "#creator" +
                                       '\u0022' + " property=" + '\u0022' + "role" + '\u0022' + " scheme=" + '\u0022' +
                                       "marc:relators" + '\u0022' + ">" + rolestring + "</meta>" + '\n' + "    " +
                                       metadatafile.Substring(startpos - 1);
                    }
                    else
                    {
                        metadatafile = metadatafile.Substring(0, startpos) + "<dc:creator>" + TextBox3 + "</dc:creator>" +
                                       '\n' + "    " + metadatafile.Substring(startpos - 1);
                    }

                    //Check for second author
                    if (TextBox3 != "")
                    {
                        //Second creator being added
                        startpos = metadatafile.IndexOf("</dc:creator>") + 1;
                        startpos = metadatafile.IndexOf("<dc:", startpos - 1) + 0;
                        //start of next item after first creator
                        //Get optional attributes
                        if (TextBox13 != "")
                        {
                            rolestring = "aut";
                            if (ComboBox2SelectedIndex == 1)
                            {
                                rolestring = "edt";
                            }
                            if (ComboBox2SelectedIndex == 2)
                            {
                                rolestring = "ill";
                            }
                            if (ComboBox2SelectedIndex == 3)
                            {
                                rolestring = "trl";
                            }
                            metadatafile = metadatafile.Substring(0, startpos) + "<dc:creator id=" + '\u0022' +
                                           "creator2" + '\u0022' + ">" + TextBox3 + "</dc:creator>" + '\n' +
                                           "    <meta refines=" + '\u0022' + "#creator2" + '\u0022' + " property=" +
                                           '\u0022' + "file-as" + '\u0022' + ">" + TextBox13 + "</meta>" + '\n' +
                                           "    <meta refines=" + '\u0022' + "#creator2" + '\u0022' + " property=" +
                                           '\u0022' + "role" + '\u0022' + " scheme=" + '\u0022' + "marc:relators" +
                                           '\u0022' + ">" + rolestring + "</meta>" + '\n' + "    " +
                                           metadatafile.Substring(startpos - 1);
                        }
                        else
                        {
                            metadatafile = metadatafile.Substring(0, startpos) + "<dc:creator>" + TextBox3 +
                                           "</dc:creator>" + '\n' + "    " + metadatafile.Substring(startpos - 1);
                        }
                    }
                }
                else
                {
                    //No creator yet, so add it after <metadata... > tag
                    startpos = metadatafile.IndexOf("<metadata") + 1;
                    startpos = metadatafile.IndexOf(">", startpos - 1) + 2;
                    //If optional attributes
                    if (TextBox12 != "")
                    {
                        optionaltext = "";
                        if ((ComboBox1SelectedIndex == 0) || (ComboBox1SelectedIndex == -1))
                        {
                            optionaltext = " opf:role=" + '\u0022' + "aut" + '\u0022';
                        }
                        if (ComboBox1SelectedIndex == 1)
                        {
                            optionaltext = " opf:role=" + '\u0022' + "edt" + '\u0022';
                        }
                        if (ComboBox1SelectedIndex == 2)
                        {
                            optionaltext = " opf:role=" + '\u0022' + "ill" + '\u0022';
                        }
                        if (ComboBox1SelectedIndex == 3)
                        {
                            optionaltext = " opf:role=" + '\u0022' + "trl" + '\u0022';
                        }
                        optionaltext = optionaltext + " opf:file-as=" + '\u0022' + TextBox12 + '\u0022' + ">";
                    }
                    else
                    {
                        optionaltext = ">";
                    }

                    // check for second author
                    if (TextBox3 != "")
                    {
                        //Get optional attributes
                        if (TextBox13 != "")
                        {
                            optionaltext2 = "";
                            if ((ComboBox2SelectedIndex == 0) || (ComboBox2SelectedIndex == -1))
                            {
                                optionaltext2 = " opf:role=" + '\u0022' + "aut" + '\u0022';
                            }
                            if (ComboBox2SelectedIndex == 1)
                            {
                                optionaltext2 = " opf:role=" + '\u0022' + "edt" + '\u0022';
                            }
                            if (ComboBox2SelectedIndex == 2)
                            {
                                optionaltext2 = " opf:role=" + '\u0022' + "ill" + '\u0022';
                            }
                            if (ComboBox2SelectedIndex == 3)
                            {
                                optionaltext2 = " opf:role=" + '\u0022' + "trl" + '\u0022';
                            }
                            optionaltext2 = optionaltext2 + " opf:file-as=" + '\u0022' + TextBox13 + '\u0022' + ">";
                        }
                        else
                        {
                            optionaltext2 = ">";
                        }
                        // output two creators
                        metadatafile = metadatafile.Substring(0, startpos) + "  <dc:creator" + optionaltext + _Creator +
                                       "</dc:creator>" + '\n' + "  <dc:creator" + optionaltext2 + TextBox3 +
                                       "</dc:creator>" + metadatafile.Substring(startpos - 1);
                    }
                    else
                    {
                        // output only one creator
                        metadatafile = metadatafile.Substring(0, startpos) + "  <dc:creator" + optionaltext + _Creator +
                                       "</dc:creator>" + metadatafile.Substring(startpos - 1);
                    }
                }
            }

            //Output (Calibre) series and series index
            startpos = metadatafile.IndexOf("<meta name=" + '\u0022' + "calibre:series" + '\u0022') + 1;
            if ((TextBox15 != "") || (startpos != 0))
            {
                if (startpos != 0)
                {
                    endpos = metadatafile.IndexOf("/>", startpos - 1) + 1;
                     var oInfo = new StringInfo("<meta name=" + '\u0022' + "calibre:series" + '\u0022');
                     lenheader = oInfo.LengthInTextElements;
                    metadatafile = metadatafile.Substring(0, startpos + lenheader - 1) + " content=" + '\u0022' +
                                   XMLOutput(TextBox15) + '\u0022' + metadatafile.Substring(endpos - 1);
                }
                else
                {
                    endpos = metadatafile.IndexOf("</dc:title>") + 1;
                    metadatafile = metadatafile.Substring(0, endpos + 10) + '\r' + '\n' + '\t' + "<meta name=" +
                                   '\u0022' + "calibre:series" + '\u0022' +
                                   (" content=" + '\u0022' + XMLOutput(TextBox15) + '\u0022' + "/>" + '\r' + '\n' +
                                    metadatafile.Substring(endpos + 11 - 1));
                }
            }
            startpos = metadatafile.IndexOf("<meta name=" + '\u0022' + "calibre:series_index" + '\u0022') + 1;
            if ((TextBox14 != "") || (startpos != 0))
            {
                if (startpos != 0)
                {
                    endpos = metadatafile.IndexOf("/>", startpos - 1) + 1;
                     var oInfo = new StringInfo("<meta name=" + '\u0022' + "calibre:series_index" + '\u0022');
                     lenheader = oInfo.LengthInTextElements;
                    metadatafile = metadatafile.Substring(0, startpos + lenheader - 1) + " content=" + '\u0022' +
                                   TextBox14 + '\u0022' + metadatafile.Substring(endpos - 1);
                }
                else
                {
                    endpos = metadatafile.IndexOf("</dc:title>") + 1;
                    metadatafile = metadatafile.Substring(0, endpos + 10) + '\r' + '\n' + '\t' + "<meta name=" +
                                   '\u0022' + "calibre:series_index" + '\u0022' +
                                   (" content=" + '\u0022' + TextBox14 + '\u0022' + "/>" + '\r' + '\n' +
                                    metadatafile.Substring(endpos + 11 - 1));
                }
            }

            //Output description
            metadatafile =
                metadatafile.Replace(
                    "<dc:description xmlns:dc=" + '\u0022' + "http://purl.org/dc/elements/1.1/" + '\u0022' + " />",
                    "<dc:description />");
            testpos = metadatafile.IndexOf("<dc:description />") + 1;
            if ((testpos != 0) && (TextBox4 == ""))
            {
            }
            else
            {
                startpos = metadatafile.IndexOf("<dc:description/>") + 1;
                if (startpos == 0)
                {
                    if (testpos != 0)
                    {
                        metadatafile = metadatafile.Replace("<dc:description />",
                            "<dc:description>" + XMLOutput(TextBox4) + "</dc:description>");
                    }
                    else
                    {
                        startpos = metadatafile.IndexOf("<dc:description") + 1;
                        if (startpos == 0)
                        {
                            startpos = metadatafile.IndexOf("<description") + 1;
                        }
                        if ((TextBox4 != "") || (startpos != 0))
                        {
                            if (startpos != 0)
                            {
                                endtag = metadatafile.IndexOf(">", startpos - 1) + 1;
                                lenheader = endtag - startpos + 1;
                                endpos = metadatafile.IndexOf("</dc:description>") + 1;
                                if (endpos == 0)
                                {
                                    endpos = metadatafile.IndexOf("</description>") + 1;
                                }
                                if (endpos != 0)
                                {
                                    metadatafile = metadatafile.Substring(0, startpos + lenheader - 1) +
                                                   XMLOutput(TextBox4) + metadatafile.Substring(endpos - 1);
                                }
                                else
                                {
                                    endpos = metadatafile.IndexOf(" />", startpos - 1) + 1;
                                    if (endpos != 0)
                                    {
                                        metadatafile = metadatafile.Substring(0, startpos + lenheader - 1) +
                                                       XMLOutput(TextBox4) + "</dc:description>" +
                                                       metadatafile.Substring(endpos + 3 - 1);
                                    }
                                }
                            }
                            else
                            {
                                endpos = metadatafile.IndexOf("</dc:title>") + 1;
                                metadatafile = metadatafile.Substring(0, endpos + 11) + '\r' + '\n' + '\t' +
                                               "<dc:description>" + XMLOutput(TextBox4) + "</dc:description>" + '\r' +
                                               '\n' + metadatafile.Substring(endpos + 12 - 1);
                            }
                        }
                    }
                }
                else
                {
                    metadatafile = metadatafile.Replace("<dc:description/>",
                        "<dc:description>" + XMLOutput(TextBox4) + "</dc:description>");
                }
            }

            //Output publisher
            metadatafile =
                metadatafile.Replace(
                    "<dc:publisher xmlns:dc=" + '\u0022' + "http://purl.org/dc/elements/1.1/" + '\u0022' + " />",
                    "<dc:publisher />");
            testpos = metadatafile.IndexOf("<dc:publisher />") + 1;
            if ((testpos != 0) && (TextBox5 == ""))
            {
            }
            else
            {
                startpos = metadatafile.IndexOf("<dc:publisher/>") + 1;
                if (startpos == 0)
                {
                    if (testpos != 0)
                    {
                        metadatafile = metadatafile.Replace("<dc:publisher />",
                            "<dc:publisher>" + XMLOutput(TextBox5) + "</dc:publisher>");
                    }
                    else
                    {
                        startpos = metadatafile.IndexOf("<dc:publisher") + 1;
                        if (startpos == 0)
                        {
                            startpos = metadatafile.IndexOf("<publisher") + 1;
                        }
                        if ((TextBox5 != "") || (startpos != 0))
                        {
                            if (startpos != 0)
                            {
                                endtag = metadatafile.IndexOf(">", startpos - 1) + 1;
                                lenheader = endtag - startpos + 1;
                                endpos = metadatafile.IndexOf("</dc:publisher>") + 1;
                                if (endpos == 0)
                                {
                                    endpos = metadatafile.IndexOf("</publisher>") + 1;
                                }
                                if (endpos != 0)
                                {
                                    metadatafile = metadatafile.Substring(0, startpos + lenheader - 1) +
                                                   XMLOutput(TextBox5) + metadatafile.Substring(endpos - 1);
                                }
                                else
                                {
                                    endpos = metadatafile.IndexOf(" />", startpos - 1) + 1;
                                    if (endpos != 0)
                                    {
                                        metadatafile = metadatafile.Substring(0, startpos + lenheader - 1) +
                                                       XMLOutput(TextBox5) + "</dc:publisher>" +
                                                       metadatafile.Substring(endpos + 3 - 1);
                                    }
                                }
                            }
                            else
                            {
                                endpos = metadatafile.IndexOf("</dc:title>") + 1;
                                metadatafile = metadatafile.Substring(0, endpos + 11) + '\r' + '\n' + '\t' +
                                               "<dc:publisher>" + XMLOutput(TextBox5) + "</dc:publisher>" + '\r' + '\n' +
                                               metadatafile.Substring(endpos + 12 - 1);
                            }
                        }
                    }
                }
                else
                {
                    metadatafile = metadatafile.Replace("<dc:publisher/>",
                        "<dc:publisher>" + XMLOutput(TextBox5) + "</dc:publisher>");
                }
            }

            //Output date
            startpos = metadatafile.IndexOf("<dc:date") + 1;
            if (startpos == 0)
            {
                startpos = metadatafile.IndexOf("<date") + 1;
            }
            if ((TextBox6 != "") || (startpos != 0))
            {
                if (startpos != 0)
                {
                    endtag = metadatafile.IndexOf(">", startpos - 1) + 1;
                    checktag = metadatafile.IndexOf("opf:event", startpos - 1) + 1;
                    newheader = "";
                    if ((checktag != 0) && (checktag < endtag))
                    {
                        if (Label6 == "Date")
                        {
                            // remove event
                            newheader = "<dc:date>";
                        }
                        else
                        {
                            // replace existing event
                            newheader = "<dc:date opf:event=" + '\u0022' + Label6.Substring(6, Label6.Length - 7) +
                                        '\u0022' + ">";
                        }
                    }
                    else
                    {
                        // there is no event in the tag
                        if (Label6 != "Date")
                        {
                            // add event
                            newheader = "<dc:date opf:event=" + '\u0022' + Label6.Substring(6, Label6.Length - 7) +
                                        '\u0022' + ">";
                        }
                        else
                        {
                            // leave things as they are
                            newheader = "<dc:date>";
                        }
                    }
                    endpos = metadatafile.IndexOf("</dc:date>") + 1;
                    if (endpos == 0)
                    {
                        endpos = metadatafile.IndexOf("</date>") + 1;
                        if (endpos != 0)
                        {
                            metadatafile = metadatafile.Substring(0, startpos - 1) + newheader + TextBox6 + "</dc:date>" +
                                           metadatafile.Substring(endpos + 7 - 1);
                        }
                        else
                        {
                            endpos = metadatafile.IndexOf(" />", startpos - 1) + 1;
                            if (endpos != 0)
                            {
                                metadatafile = metadatafile.Substring(0, startpos - 1) + newheader + TextBox6 +
                                               "</dc:date>" + metadatafile.Substring(endpos + 3 - 1);
                            }
                        }
                    }
                    else
                    {
                        metadatafile = metadatafile.Substring(0, startpos - 1) + newheader + TextBox6 +
                                       metadatafile.Substring(endpos - 1);
                    }
                }
                else
                {
                    endpos = metadatafile.IndexOf("</dc:title>") + 1;
                    if (Label6 == "Date")
                    {
                        metadatafile = metadatafile.Substring(0, endpos + 11) + '\r' + '\n' + '\t' + "<dc:date>" +
                                       TextBox6 + "</dc:date>" + '\r' + '\n' + metadatafile.Substring(endpos + 12 - 1);
                    }
                    else
                    {
                        metadatafile = metadatafile.Substring(0, endpos + 11) + '\r' + '\n' + '\t' +
                                       "<dc:date opf:event=" + '\u0022' + Label6.Substring(6, Label6.Length - 7) +
                                       '\u0022' + ">" + TextBox6 + "</dc:date>" + '\r' + '\n' +
                                       metadatafile.Substring(endpos + 12 - 1);
                    }
                }
            }

            //Output subject
            metadatafile =
                metadatafile.Replace(
                    "<dc:subject xmlns:dc=" + '\u0022' + "http://purl.org/dc/elements/1.1/" + '\u0022' + " />",
                    "<dc:subject />");
            testpos = metadatafile.IndexOf("<dc:subject />") + 1;
            if ((testpos != 0) && (TextBox17 == ""))
            {
            }
            else
            {
                startpos = metadatafile.IndexOf("<dc:subject/>") + 1;
                if (startpos == 0)
                {
                    if (testpos != 0)
                    {
                        metadatafile = metadatafile.Replace("<dc:subject />",
                            "<dc:subject>" + XMLOutput(TextBox17) + "</dc:subject>");
                    }
                    else
                    {
                        startpos = metadatafile.IndexOf("<dc:subject") + 1;
                        if (startpos == 0)
                        {
                            startpos = metadatafile.IndexOf("<subject") + 1;
                        }
                        if ((TextBox17 != "") || (startpos != 0))
                        {
                            if (startpos != 0)
                            {
                                endtag = metadatafile.IndexOf(">", startpos - 1) + 1;
                                lenheader = endtag - startpos + 1;
                                endpos = metadatafile.IndexOf("</dc:subject>") + 1;
                                if (endpos == 0)
                                {
                                    endpos = metadatafile.IndexOf("</subject>") + 1;
                                }
                                if (endpos != 0)
                                {
                                    metadatafile = metadatafile.Substring(0, startpos + lenheader - 1) +
                                                   XMLOutput(TextBox17) + metadatafile.Substring(endpos - 1);
                                }
                                else
                                {
                                    endpos = metadatafile.IndexOf(" />", startpos - 1) + 1;
                                    if (endpos != 0)
                                    {
                                        metadatafile = metadatafile.Substring(0, startpos + lenheader - 1) +
                                                       XMLOutput(TextBox17) + "</dc:subject>" +
                                                       metadatafile.Substring(endpos + 3 - 1);
                                    }
                                }
                            }
                            else
                            {
                                endpos = metadatafile.IndexOf("</dc:title>") + 1;
                                metadatafile = metadatafile.Substring(0, endpos + 11) + '\r' + '\n' + '\t' +
                                               "<dc:subject>" + XMLOutput(TextBox17) + "</dc:subject>" + '\r' + '\n' +
                                               metadatafile.Substring(endpos + 12 - 1);
                            }
                        }
                    }
                }
                else
                {
                    metadatafile = metadatafile.Replace("<dc:subject/>",
                        "<dc:subject>" + XMLOutput(TextBox17) + "</dc:subject>");
                }
            }

            //Output type
            metadatafile =
                metadatafile.Replace(
                    "<dc:type xmlns:dc=" + '\u0022' + "http://purl.org/dc/elements/1.1/" + '\u0022' + " />",
                    "<dc:type />");
            testpos = metadatafile.IndexOf("<dc:type />") + 1;
            if ((testpos != 0) && (TextBox7 == ""))
            {
            }
            else
            {
                startpos = metadatafile.IndexOf("<dc:type/>") + 1;
                if (startpos == 0)
                {
                    if (testpos != 0)
                    {
                        metadatafile = metadatafile.Replace("<dc:type />", "<dc:type>" + TextBox7 + "</dc:type>");
                    }
                    else
                    {
                        startpos = metadatafile.IndexOf("<dc:type") + 1;
                        if (startpos == 0)
                        {
                            startpos = metadatafile.IndexOf("<type") + 1;
                        }
                        if ((TextBox7 != "") || (startpos != 0))
                        {
                            if (startpos != 0)
                            {
                                endtag = metadatafile.IndexOf(">", startpos - 1) + 1;
                                lenheader = endtag - startpos + 1;
                                endpos = metadatafile.IndexOf("</dc:type>") + 1;
                                if (endpos == 0)
                                {
                                    endpos = metadatafile.IndexOf("</type>") + 1;
                                }
                                if (endpos != 0)
                                {
                                    metadatafile = metadatafile.Substring(0, startpos + lenheader - 1) + TextBox7 +
                                                   metadatafile.Substring(endpos - 1);
                                }
                                else
                                {
                                    endpos = metadatafile.IndexOf(" />", startpos - 1) + 1;
                                    if (endpos != 0)
                                    {
                                        metadatafile = metadatafile.Substring(0, startpos + lenheader - 1) + TextBox7 +
                                                       "</dc:type>" + metadatafile.Substring(endpos + 3 - 1);
                                    }
                                }
                            }
                            else
                            {
                                endpos = metadatafile.IndexOf("</dc:title>") + 1;
                                metadatafile = metadatafile.Substring(0, endpos + 11) + '\r' + '\n' + '\t' + "<dc:type>" +
                                               TextBox7 + "</dc:type>" + '\r' + '\n' +
                                               metadatafile.Substring(endpos + 12 - 1);
                            }
                        }
                    }
                }
                else
                {
                    metadatafile = metadatafile.Replace("<dc:type/>", "<dc:type>" + TextBox7 + "</dc:type>");
                }
            }

            //Output format
            metadatafile =
                metadatafile.Replace(
                    "<dc:format xmlns:dc=" + '\u0022' + "http://purl.org/dc/elements/1.1/" + '\u0022' + " />",
                    "<dc:format />");
            testpos = metadatafile.IndexOf("<dc:format />") + 1;
            if ((testpos != 0) && (TextBox8 == ""))
            {
            }
            else
            {
                startpos = metadatafile.IndexOf("<dc:format/>") + 1;
                if (startpos == 0)
                {
                    if (testpos != 0)
                    {
                        metadatafile = metadatafile.Replace("<dc:format />", "<dc:format>" + TextBox8 + "</dc:format>");
                    }
                    else
                    {
                        startpos = metadatafile.IndexOf("<dc:format") + 1;
                        if (startpos == 0)
                        {
                            startpos = metadatafile.IndexOf("<format") + 1;
                        }
                        if ((TextBox8 != "") || (startpos != 0))
                        {
                            if (startpos != 0)
                            {
                                endtag = metadatafile.IndexOf(">", startpos - 1) + 1;
                                lenheader = endtag - startpos + 1;
                                endpos = metadatafile.IndexOf("</dc:format>") + 1;
                                if (endpos == 0)
                                {
                                    endpos = metadatafile.IndexOf("</format>") + 1;
                                }
                                if (endpos != 0)
                                {
                                    metadatafile = metadatafile.Substring(0, startpos + lenheader - 1) + TextBox8 +
                                                   metadatafile.Substring(endpos - 1);
                                }
                                else
                                {
                                    endpos = metadatafile.IndexOf(" />", startpos - 1) + 1;
                                    if (endpos != 0)
                                    {
                                        metadatafile = metadatafile.Substring(0, startpos + lenheader - 1) + TextBox8 +
                                                       "</dc:format>" + metadatafile.Substring(endpos + 3 - 1);
                                    }
                                }
                            }
                            else
                            {
                                endpos = metadatafile.IndexOf("</dc:title>") + 1;
                                metadatafile = metadatafile.Substring(0, endpos + 11) + '\r' + '\n' + '\t' +
                                               "<dc:format>" + TextBox8 + "</dc:format>" + '\r' + '\n' +
                                               metadatafile.Substring(endpos + 12 - 1);
                            }
                        }
                    }
                }
                else
                {
                    metadatafile = metadatafile.Replace("<dc:format/>", "<dc:format>" + TextBox8 + "</dc:format>");
                }
            }

            //Output identifier
            if (versioninfo == "3.0")
            {
                startpos = metadatafile.IndexOf("<dc:identifier") + 1;
                if (startpos != 0)
                {
                    endheaderpos = metadatafile.IndexOf(">", startpos - 1) + 1;
                    endpos = metadatafile.IndexOf("</dc:identifier>", startpos - 1) + 1;
                    lenheader = "<dc:identifier".Length;
                    metadatafile = metadatafile.Substring(0, endheaderpos) + TextBox9 +
                                   metadatafile.Substring(endpos - 1);

                    if (Label9 != "Identifier")
                    {
                        identifierscheme = Label9.Substring(12, Label9.Length - 13);
                    }
                    else
                    {
                        goto outputsource;
                    }

                    // get id
                    idpos = metadatafile.IndexOf("id=", startpos - 1) + 1;
                    idinfo = "";
                    if (idpos != 0)
                    {
                        for (temploop = idpos + 4; temploop <= endpos; temploop++)
                        {
                            if (
                                Convert.ToBoolean(
                                    char.Parse(
                                        Convert.ToString(metadatafile.Substring(temploop - 1, 1) ==
                                                         Convert.ToString('\u0022')))))
                            {
                                idinfo = metadatafile.Substring(idpos + 4 - 1, temploop - idpos - 4);
                                goto lookforrefines5;
                            }
                        }
                    }
                    else
                    {
                        metadatafile = metadatafile.Substring(0, startpos) + "<dc:identifier id=" + '\u0022' + "pub-id" +
                                       '\u0022' + ">" + TextBox9 + metadatafile.Substring(endpos - 1);
                        idinfo = "pub-id";
                    }
                lookforrefines5:
                    if (idinfo != "")
                    {
                        temppos =
                            metadatafile.IndexOf(("<meta refines=" + '\u0022' + "#" + idinfo + '\u0022'), startpos - 1) +
                            1;
                        schemeplaced = false;
                        while (temppos != 0)
                        {
                            endheaderpos = metadatafile.IndexOf(">", temppos - 1) + 1;
                            endpos = metadatafile.IndexOf("</meta>", temppos - 1) + 1;
                            refinespos = metadatafile.IndexOf(("scheme=" + '\u0022'), temppos - 1) + 1;
                            if (refinespos != 0)
                            {
                                if (refinespos < endpos)
                                {
                                    metadatafile = metadatafile.Substring(0, refinespos + 7) +
                                                   identifierscheme.Replace("=", '\u0022' + ">") +
                                                   metadatafile.Substring(endpos - 1);
                                    schemeplaced = true;
                                }
                            }
                            temppos =
                                metadatafile.IndexOf(("<meta refines=" + '\u0022' + "#" + idinfo + '\u0022'), endpos - 1) +
                                1;
                        }
                        if (schemeplaced == false)
                        {
                            startpos = metadatafile.IndexOf("</dc:identifier>") + 17; //end of identifier
                            metadatafile = metadatafile.Substring(0, startpos) + '\n' + "    <meta refines=" + '\u0022' +
                                           "#" + idinfo + '\u0022' + " property=" + '\u0022' + "identifier-type" +
                                           '\u0022' + " scheme=" + '\u0022' +
                                           identifierscheme.Replace("=", '\u0022' + ">") + "</meta>" +
                                           metadatafile.Substring(startpos - 1);
                        }
                    }
                }
            }
            else
            {
                startpos = metadatafile.IndexOf("<dc:identifier") + 1;
                if (startpos == 0)
                {
                    startpos = metadatafile.IndexOf("<identifier") + 1;
                }
                if ((TextBox9 != "") || (startpos != 0))
                {
                    if (startpos != 0)
                    {
                        endtag = metadatafile.IndexOf(">", startpos - 1) + 1;
                        checktag = metadatafile.IndexOf("opf:scheme", startpos - 1) + 1;
                        lookforID = metadatafile.IndexOf("id=", startpos - 1) + 1;
                        if ((lookforID != 0) && (lookforID < endtag))
                        {
                            endID = metadatafile.IndexOf(('\u0022').ToString(), lookforID + 5 - 1) + 1;
                            ID = metadatafile.Substring(lookforID + 4 - 1, endID - lookforID - 4);
                        }
                        else
                        {
                            ID = "";
                            lookforID = 0;
                        }
                        newheader = "";
                        if ((checktag != 0) && (checktag < endtag))
                        {
                            if (Label9 == "Identifier")
                            {
                                // remove scheme
                                if (lookforID == 0)
                                {
                                    newheader = "<dc:identifier>";
                                }
                                else
                                {
                                    newheader = "<dc:identifier id=" + '\u0022' + ID + '\u0022' + ">";
                                }
                            }
                            else
                            {
                                // replace existing scheme
                                if (lookforID == 0)
                                {
                                    newheader = "<dc:identifier opf:scheme=" + '\u0022' +
                                                Label9.Substring(12, Label9.Length - 13) + '\u0022' + ">";
                                }
                                else
                                {
                                    newheader = "<dc:identifier id=" + '\u0022' + ID + '\u0022' + " opf:scheme=" +
                                                '\u0022' + Label9.Substring(12, Label9.Length - 13) + '\u0022' + ">";
                                }
                            }
                        }
                        else
                        {
                            // there is no scheme in the tag
                            if (Label9 != "Identifier")
                            {
                                // add scheme
                                if (lookforID == 0)
                                {
                                    newheader = "<dc:identifier opf:scheme=" + '\u0022' +
                                                Label9.Substring(12, Label9.Length - 13) + '\u0022' + ">";
                                }
                                else
                                {
                                    newheader = "<dc:identifier id=" + '\u0022' + ID + '\u0022' + " opf:scheme=" +
                                                '\u0022' + Label9.Substring(12, Label9.Length - 13) + '\u0022' + ">";
                                }
                            }
                            else
                            {
                                // leave things as they are
                                if (lookforID == 0)
                                {
                                    newheader = "<dc:identifier>";
                                }
                                else
                                {
                                    newheader = "<dc:identifier id=" + '\u0022' + ID + '\u0022' + ">";
                                }
                            }
                        }
                        endpos = metadatafile.IndexOf("</dc:identifier>") + 1;
                        extracheck = metadatafile.IndexOf("<dc:", startpos + 1 - 1) + 1;
                        if ((extracheck != 0) && (endpos > extracheck))
                        {
                            endpos = 0; //look to see if field end is actually for a second identifier
                        }
                        if (endpos == 0)
                        {
                            endpos = metadatafile.IndexOf("</identifier>") + 1;
                            if (endpos != 0)
                            {
                                metadatafile = metadatafile.Substring(0, startpos - 1) + newheader + TextBox9 +
                                               "</dc:identifier>" + metadatafile.Substring(endpos + 13 - 1);
                            }
                            else
                            {
                                endpos = metadatafile.IndexOf(" />", startpos - 1) + 1;
                                if (endpos != 0)
                                {
                                    metadatafile = metadatafile.Substring(0, startpos - 1) + newheader + TextBox9 +
                                                   "</dc:identifier>" + metadatafile.Substring(endpos + 3 - 1);
                                }
                            }
                        }
                        else
                        {
                            metadatafile = metadatafile.Substring(0, startpos - 1) + newheader + TextBox9 +
                                           metadatafile.Substring(endpos - 1);
                        }
                    }
                    else
                    {
                        endpos = metadatafile.IndexOf("</dc:title>") + 1;
                        if (Label9 == "Identifier")
                        {
                            metadatafile = metadatafile.Substring(0, endpos + 11) + '\r' + '\n' + '\t' +
                                           "<dc:identifier>" + TextBox9 + "</dc:identifier>" + '\r' + '\n' +
                                           metadatafile.Substring(endpos + 12 - 1);
                        }
                        else
                        {
                            metadatafile = metadatafile.Substring(0, endpos + 11) + '\r' + '\n' + '\t' +
                                           "<dc:identifier opf:scheme=" + '\u0022' +
                                           Label9.Substring(12, Label9.Length - 13) + '\u0022' + ">" + TextBox9 +
                                           "</dc:identifier>" + '\r' + '\n' + metadatafile.Substring(endpos + 12 - 1);
                        }
                    }
                }
            }

        outputsource:
            //Output source
            metadatafile =
                metadatafile.Replace(
                    "<dc:source xmlns:dc=" + '\u0022' + "http://purl.org/dc/elements/1.1/" + '\u0022' + " />",
                    "<dc:source />");
            testpos = metadatafile.IndexOf("<dc:source />") + 1;
            if ((testpos != 0) && (_Souce == ""))
            {
            }
            else
            {
                startpos = metadatafile.IndexOf("<dc:source/>") + 1;
                if (startpos == 0)
                {
                    if (testpos != 0)
                    {
                        metadatafile = metadatafile.Replace("<dc:source />", "<dc:source>" + _Souce + "</dc:source>");
                    }
                    else
                    {
                        startpos = metadatafile.IndexOf("<dc:source") + 1;
                        if (startpos == 0)
                        {
                            startpos = metadatafile.IndexOf("<source") + 1;
                        }
                        if ((_Souce != "") || (startpos != 0))
                        {
                            if (startpos != 0)
                            {
                                endtag = metadatafile.IndexOf(">", startpos - 1) + 1;
                                lenheader = endtag - startpos + 1;
                                endpos = metadatafile.IndexOf("</dc:source>") + 1;
                                if (endpos == 0)
                                {
                                    endpos = metadatafile.IndexOf("</source>") + 1;
                                }
                                if (endpos != 0)
                                {
                                    metadatafile = metadatafile.Substring(0, startpos + lenheader - 1) + _Souce +
                                                   metadatafile.Substring(endpos - 1);
                                }
                                else
                                {
                                    endpos = metadatafile.IndexOf(" />", startpos - 1) + 1;
                                    if (endpos != 0)
                                    {
                                        metadatafile = metadatafile.Substring(0, startpos + lenheader - 1) + _Souce +
                                                       "</dc:source>" + metadatafile.Substring(endpos + 3 - 1);
                                    }
                                }
                            }
                            else
                            {
                                endpos = metadatafile.IndexOf("</dc:title>") + 1;
                                metadatafile = metadatafile.Substring(0, endpos + 11) + '\r' + '\n' + '\t' +
                                               "<dc:source>" + _Souce + "</dc:source>" + '\r' + '\n' +
                                               metadatafile.Substring(endpos + 12 - 1);
                            }
                        }
                    }
                }
                else
                {
                    metadatafile = metadatafile.Replace("<dc:source/>", "<dc:source>" + _Souce + "</dc:source>");
                }
            }

            //Output language
            metadatafile =
                metadatafile.Replace(
                    "<dc:language xmlns:dc=" + '\u0022' + "http://purl.org/dc/elements/1.1/" + '\u0022' + " />",
                    "<dc:language />");
            testpos = metadatafile.IndexOf("<dc:language />") + 1;
            if ((testpos != 0) && (TextBox11 == ""))
            {
            }
            else
            {
                startpos = metadatafile.IndexOf("<dc:language/>") + 1;
                if (startpos == 0)
                {
                    if (testpos != 0)
                    {
                        metadatafile = metadatafile.Replace("<dc:language />",
                            "<dc:language>" + TextBox11 + "</dc:language>");
                    }
                    else
                    {
                        startpos = metadatafile.IndexOf("<dc:language") + 1;
                        if (startpos == 0)
                        {
                            startpos = metadatafile.IndexOf("<language") + 1;
                        }
                        if ((TextBox11 != "") || (startpos != 0))
                        {
                            if (startpos != 0)
                            {
                                endtag = metadatafile.IndexOf(">", startpos - 1) + 1;
                                lenheader = endtag - startpos + 1;
                                endpos = metadatafile.IndexOf("</dc:language>") + 1;
                                if (endpos == 0)
                                {
                                    endpos = metadatafile.IndexOf("</language>") + 1;
                                }
                                if (endpos != 0)
                                {
                                    metadatafile = metadatafile.Substring(0, startpos + lenheader - 1) + TextBox11 +
                                                   metadatafile.Substring(endpos - 1);
                                }
                                else
                                {
                                    endpos = metadatafile.IndexOf(" />", startpos - 1) + 1;
                                    if (endpos != 0)
                                    {
                                        metadatafile = metadatafile.Substring(0, startpos + lenheader - 1) + TextBox11 +
                                                       "</dc:language>" + metadatafile.Substring(endpos + 3 - 1);
                                    }
                                }
                            }
                            else
                            {
                                endpos = metadatafile.IndexOf("</dc:title>") + 1;
                                metadatafile = metadatafile.Substring(0, endpos + 11) + '\r' + '\n' + '\t' +
                                               "<dc:language>" + TextBox11 + "</dc:language>" + '\r' + '\n' +
                                               metadatafile.Substring(endpos + 12 - 1);
                            }
                        }
                    }
                }
                else
                {
                    metadatafile = metadatafile.Replace("<dc:language/>", "<dc:language>" + TextBox11 + "</dc:language>");
                }
            }

            RichTextBox1 = metadatafile;
            SaveUnicodeFile(opffile, RichTextBox1);

            //Zip temp directory (after deleting original file)
            fi.Delete();

            //Delete mimetype file
            temporarydirectory = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(ebookdirectory);
            File.Delete("mimetype");
            Directory.SetCurrentDirectory(temporarydirectory);

            using (var zip = new ZipOutputStream(FileName))
            {
                //Add mimetype file first
                zip.CompressionLevel = CompressionLevel.None;
                zip.PutNextEntry("mimetype");
                var buffer = new byte[2049];
                buffer = Encoding.ASCII.GetBytes("application/epub+zip");
                zip.Write(buffer, 0, buffer.Length);

                //Add all other files next
                zip.CompressionLevel = CompressionLevel.Default;
                AddDirectoryToZip(zip, ebookdirectory);
            }


            //Update interface
            epubstring = CaptionString;
           
            projectchanged = false;
        }

          public void SetSource(string sLink)
          {
              _Souce = sLink;
          }


        private void AddDirectoryToZip(ZipOutputStream zip, string directoryToAdd)
        {
            string[] filesToZip = Directory.GetFiles(directoryToAdd);
            string[] directoriesToZip = Directory.GetDirectories(directoryToAdd);

            //Recursively add any subdirectories of the current directory
            string inputDirectoryName = default(string);
            foreach (string tempLoopVar_inputDirectoryName in directoriesToZip)
            {
                inputDirectoryName = tempLoopVar_inputDirectoryName;
                AddDirectoryToZip(zip, inputDirectoryName);
            }

            //Add any files in current directory
            string inputFileName = default(string);
            foreach (string tempLoopVar_inputFileName in filesToZip)
            {
                inputFileName = tempLoopVar_inputFileName;
                zip.PutNextEntry(Path.GetFullPath(inputFileName).Substring(ebookdirectory.Length + 1 - 1));
                using (FileStream input = File.Open(inputFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    int n = default(int);
                    var buffer = new byte[2049];
                    n = input.Read(buffer, 0, buffer.Length);
                    while (n > 0)
                    {
                        zip.Write(buffer, 0, n);
                        n = input.Read(buffer, 0, buffer.Length);
                    }
                }
            }
        }

        private void ClearInterface()
        {
            _Title = "";
            _Creator = "";
            TextBox3 = "";
            TextBox4 = "";
            _Description = "";
            TextBox5 = "";
            TextBox6 = "";
            TextBox7 = "";
            TextBox8 = "";
            TextBox9 = "";
            _Souce = "";
            TextBox11 = "";
            TextBox12 = "";
            TextBox13 = "";
            TextBox14 = "";
            TextBox15 = "";
            TextBox16 = "";
            TextBox17 = "";
            //    ComboBox1[] = -1;
            //  ComboBox2SelectedIndex = -1;
            //PictureBox1.Image = null;
            // Label4.Visible = false;
            // Button1.Visible = false;
            // Label25.Visible = false;
            //  GroupBox1.Visible = false;
            //  ListBox2.Items.Clear();
        }
        private void ExtractMetadata(string metadatafile, bool extractcover)
        {
            int startpos = default(int);
            int namespacelen = default(int);
            int endpos = default(int);
            int endheader = default(int);
            int lenheader = default(int);
            int fileaspos = default(int);
            int temploop = default(int);
            int rolepos = default(int);
            int coverfilepos = default(int);
            int nextcharpos = default(int);
            int firsttaglength = default(int);
            string dcnamespace = default(string);
            string rolestring = default(string);
            string coverfiletext = default(string);
            string langtext = default(string);
            string hreftype = default(string);
            string nextchar = default(string);
            string tempstring = default(string);
            int idpos = default(int);
            int endheaderpos = default(int);
            int temppos = default(int);
            int refinespos = default(int);
            string idinfo = default(string);

            //Check for non-standard dc namespace tags
            startpos = metadatafile.IndexOf("=" + '\u0022' + "http://purl.org/dc/elements/1.1/") + 1;
            if (startpos != 0)
            {
                // work backwards to find the xmlns definition
                namespacelen = 0;
                while (startpos - namespacelen != 0)
                {
                    namespacelen++;
                    if (metadatafile.Substring(startpos - namespacelen - 1, 6) == "xmlns:")
                    {
                        break;
                    }
                }
                if (namespacelen < startpos)
                {
                    dcnamespace = metadatafile.Substring(startpos - namespacelen + 6 - 1, namespacelen - 6);
                    metadatafile = metadatafile.Replace(dcnamespace + ":", "dc:");
                }
            }

            //Check for non-standard opf namespace tags
            if (
                Convert.ToBoolean(metadatafile.IndexOf("<opf:metadata>") + 1 |
                                  metadatafile.IndexOf("<opf:manifest>") + 1))
            {
                metadatafile = metadatafile.Replace("<opf:", "<");
                metadatafile = metadatafile.Replace("</opf:", "</");
            }

            //Get title
            try
            {
                startpos = metadatafile.IndexOf("<dc:title") + 1;
                if (startpos != 0)
                {
                    endpos = metadatafile.IndexOf("</dc:title>") + 1;
                    lenheader = "<dc:title".Length;
                    if (metadatafile.Substring(startpos + lenheader - 1, 1) == ">")
                    {
                        _Title =
                            XMLInput(metadatafile.Substring(startpos + lenheader + 1 - 1,
                                endpos - startpos - lenheader - 1));
                    }
                    else
                    {
                        //Get optional attributes
                        fileaspos = metadatafile.IndexOf("opf:file-as=", startpos - 1) + 1;
                        if (fileaspos != 0)
                        {
                            for (temploop = fileaspos + 13; temploop <= endpos; temploop++)
                            {
                                if (
                                    Convert.ToBoolean(
                                        char.Parse(
                                            Convert.ToString(metadatafile.Substring(temploop - 1, 1) ==
                                                             Convert.ToString('\u0022')))))
                                {
                                    TextBox16 =
                                        XMLInput(metadatafile.Substring(fileaspos + 13 - 1, temploop - fileaspos - 13));
                                }
                            }
                        }
                        for (temploop = startpos; temploop <= endpos; temploop++)
                        {
                            if (metadatafile.Substring(temploop - 1, 1) == ">")
                            {
                                _Title = XMLInput(metadatafile.Substring(temploop + 1 - 1, endpos - temploop - 1));
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                _Title = "ERROR";
            }

            //Get creator
            try
            {
                startpos = metadatafile.IndexOf("<dc:creator") + 1;
                if (startpos != 0)
                {
                    endpos = metadatafile.IndexOf("</dc:creator>") + 1;
                    lenheader = "<dc:creator".Length;
                    if (metadatafile.Substring(startpos + lenheader + 1 - 1) == ">")
                    {
                        _Creator = metadatafile.Substring(startpos + lenheader - 1, endpos - startpos - lenheader);
                    }
                    else
                    {
                        if (versioninfo == "3.0")
                        {
                            endheaderpos = metadatafile.IndexOf(">", startpos - 1) + 1;
                            _Creator = metadatafile.Substring(endheaderpos + 1 - 1, endpos - endheaderpos - 1);
                            //Get id
                            idpos = metadatafile.IndexOf("id=", startpos - 1) + 1;
                            idinfo = "";
                            if (idpos != 0)
                            {
                                for (temploop = idpos + 4; temploop <= endpos; temploop++)
                                {
                                    if (
                                        Convert.ToBoolean(
                                            char.Parse(
                                                Convert.ToString(metadatafile.Substring(temploop - 1, 1) ==
                                                                 Convert.ToString('\u0022')))))
                                    {
                                        idinfo = metadatafile.Substring(idpos + 4 - 1, temploop - idpos - 4);
                                        break;
                                    }
                                }
                            }

                            if (idinfo != "")
                            {
                                temppos =
                                    metadatafile.IndexOf(("<meta refines=" + '\u0022' + "#" + idinfo + '\u0022'),
                                        startpos - 1) + 1;
                                while (temppos != 0)
                                {
                                    endheaderpos = metadatafile.IndexOf(">", temppos - 1) + 1;
                                    endpos = metadatafile.IndexOf("</meta>", temppos - 1) + 1;
                                    refinespos =
                                        metadatafile.IndexOf(("property=" + '\u0022' + "file-as"), temppos - 1) + 1;
                                    if (refinespos != 0)
                                    {
                                        if (refinespos < endpos)
                                        {
                                            TextBox12 = metadatafile.Substring(endheaderpos + 1 - 1,
                                                endpos - endheaderpos - 1);
                                        }
                                    }
                                    refinespos = metadatafile.IndexOf(("property=" + '\u0022' + "role"), temppos - 1) +
                                                 1;
                                    if (refinespos != 0)
                                    {
                                        if (refinespos < endpos)
                                        {
                                            rolestring = metadatafile.Substring(endheaderpos + 1 - 1,
                                                endpos - endheaderpos - 1);
                                            if (rolestring == "aut")
                                            {
                                                ComboBox1SelectedIndex = 0;
                                            }
                                            else if (rolestring == "edt")
                                            {
                                                ComboBox1SelectedIndex = 1;
                                            }
                                            else if (rolestring == "ill")
                                            {
                                                ComboBox1SelectedIndex = 2;
                                            }
                                            else if (rolestring == "trl")
                                            {
                                                ComboBox1SelectedIndex = 3;
                                            }
                                            else
                                            {
                                                ComboBox1SelectedIndex = 0;
                                            }
                                        }
                                    }
                                    temppos =
                                        metadatafile.IndexOf(("<meta refines=" + '\u0022' + "#" + idinfo + '\u0022'),
                                            endpos - 1) + 1;
                                }
                            }
                        }
                        else
                        {
                            //Get optional attributes
                            fileaspos = metadatafile.IndexOf("opf:file-as=", startpos - 1) + 1;
                            if (fileaspos != 0)
                            {
                                for (temploop = fileaspos + 13; temploop <= endpos; temploop++)
                                {
                                    if (
                                        Convert.ToBoolean(
                                            char.Parse(
                                                Convert.ToString(metadatafile.Substring(temploop - 1, 1) ==
                                                                 Convert.ToString('\u0022')))))
                                    {
                                        TextBox12 = metadatafile.Substring(fileaspos + 13 - 1, temploop - fileaspos - 13);
                                        break;
                                    }
                                }
                            }

                            rolepos = metadatafile.IndexOf("opf:role=", startpos - 1) + 1;
                            if (rolepos != 0)
                            {
                                rolestring = metadatafile.Substring(rolepos + 10 - 1, 3);
                                if (rolestring == "aut")
                                {
                                    ComboBox1SelectedIndex = 0;
                                }
                                else if (rolestring == "edt")
                                {
                                    ComboBox1SelectedIndex = 1;
                                }
                                else if (rolestring == "ill")
                                {
                                    ComboBox1SelectedIndex = 2;
                                }
                                else if (rolestring == "trl")
                                {
                                    ComboBox1SelectedIndex = 3;
                                }
                                else
                                {
                                    ComboBox1SelectedIndex = 0;
                                }
                            }
                            else
                            {
                                ComboBox1SelectedIndex = 0;
                            }

                            for (temploop = startpos; temploop <= endpos; temploop++)
                            {
                                if (metadatafile.Substring(temploop - 1, 1) == ">")
                                {
                                    _Creator = metadatafile.Substring(temploop + 1 - 1, endpos - temploop - 1);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                _Creator = "ERROR";
            }

            if (endpos == 0)
            {
                goto skipsecondcreator;
            }

            //Look for second creator
            try
            {
                startpos = metadatafile.IndexOf("<dc:creator") + 1;
                startpos = metadatafile.IndexOf("<dc:creator", startpos + 1 - 1) + 1;
                if (startpos != 0)
                {
                    endpos = metadatafile.IndexOf("</dc:creator>", startpos - 1) + 1;
                    lenheader = "<dc:creator".Length;
                    if (metadatafile.Substring(startpos + 1 - 1) == ">")
                    {
                        TextBox3 = metadatafile.Substring(startpos + lenheader - 1, endpos - startpos - lenheader);
                    }
                    else
                    {
                        if (versioninfo == "3.0")
                        {
                            endheaderpos = metadatafile.IndexOf(">", startpos - 1) + 1;
                            TextBox3 = metadatafile.Substring(endheaderpos + 1 - 1, endpos - endheaderpos - 1);
                            // get id
                            idpos = metadatafile.IndexOf("id=", startpos - 1) + 1;
                            idinfo = "";
                            if (idpos != 0)
                            {
                                for (temploop = idpos + 4; temploop <= endpos; temploop++)
                                {
                                    if (
                                        Convert.ToBoolean(
                                            char.Parse(
                                                Convert.ToString(metadatafile.Substring(temploop - 1, 1) ==
                                                                 Convert.ToString('\u0022')))))
                                    {
                                        idinfo = metadatafile.Substring(idpos + 4 - 1, temploop - idpos - 4);
                                        break;
                                    }
                                }
                            }

                            if (idinfo != "")
                            {
                                temppos =
                                    metadatafile.IndexOf(("<meta refines=" + '\u0022' + "#" + idinfo + '\u0022'),
                                        startpos - 1) + 1;
                                while (temppos != 0)
                                {
                                    endheaderpos = metadatafile.IndexOf(">", temppos - 1) + 1;
                                    endpos = metadatafile.IndexOf("</meta>", temppos - 1) + 1;
                                    refinespos =
                                        metadatafile.IndexOf(("property=" + '\u0022' + "file-as"), temppos - 1) + 1;
                                    if (refinespos != 0)
                                    {
                                        if (refinespos < endpos)
                                        {
                                            TextBox13 = metadatafile.Substring(endheaderpos + 1 - 1,
                                                endpos - endheaderpos - 1);
                                        }
                                    }
                                    refinespos = metadatafile.IndexOf(("property=" + '\u0022' + "role"), temppos - 1) +
                                                 1;
                                    if (refinespos != 0)
                                    {
                                        if (refinespos < endpos)
                                        {
                                            rolestring = metadatafile.Substring(endheaderpos + 1 - 1,
                                                endpos - endheaderpos - 1);
                                            if (rolestring == "aut")
                                            {
                                                ComboBox2SelectedIndex = 0;
                                            }
                                            else if (rolestring == "edt")
                                            {
                                                ComboBox2SelectedIndex = 1;
                                            }
                                            else if (rolestring == "ill")
                                            {
                                                ComboBox2SelectedIndex = 2;
                                            }
                                            else if (rolestring == "trl")
                                            {
                                                ComboBox2SelectedIndex = 3;
                                            }
                                            else
                                            {
                                                ComboBox2SelectedIndex = 0;
                                            }
                                        }
                                    }
                                    temppos =
                                        metadatafile.IndexOf(("<meta refines=" + '\u0022' + "#" + idinfo + '\u0022'),
                                            endpos - 1) + 1;
                                }
                            }
                        }
                        else
                        {
                            //Get optional attributes
                            fileaspos = metadatafile.IndexOf("opf:file-as=", startpos - 1) + 1;
                            if (fileaspos != 0)
                            {
                                for (temploop = fileaspos + 13; temploop <= endpos; temploop++)
                                {
                                    if (
                                        Convert.ToBoolean(
                                            char.Parse(
                                                Convert.ToString(metadatafile.Substring(temploop - 1, 1) ==
                                                                 Convert.ToString('\u0022')))))
                                    {
                                        TextBox13 = metadatafile.Substring(fileaspos + 13 - 1, temploop - fileaspos - 13);
                                        break;
                                    }
                                }
                            }

                            rolepos = metadatafile.IndexOf("opf:role=", startpos - 1) + 1;
                            if (rolepos != 0)
                            {
                                rolestring = metadatafile.Substring(rolepos + 10 - 1, 3);
                                if (rolestring == "aut")
                                {
                                    ComboBox2SelectedIndex = 0;
                                }
                                if (rolestring == "edt")
                                {
                                    ComboBox2SelectedIndex = 1;
                                }
                                if (rolestring == "ill")
                                {
                                    ComboBox2SelectedIndex = 2;
                                }
                                if (rolestring == "trl")
                                {
                                    ComboBox2SelectedIndex = 3;
                                }
                            }

                            for (temploop = startpos; temploop <= endpos; temploop++)
                            {
                                if (metadatafile.Substring(temploop - 1, 1) == ">")
                                {
                                    TextBox3 = metadatafile.Substring(temploop + 1 - 1, endpos - temploop - 1);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                TextBox3 = "ERROR";
            }

        skipsecondcreator:

            //Get (Calibre) Series and Series Index
            try
            {
                startpos = metadatafile.IndexOf("<meta name=" + '\u0022' + "calibre:series" + '\u0022') + 1;
                if (startpos != 0)
                {
                    startpos = metadatafile.IndexOf(("content=" + '\u0022'), startpos - 1) + 1;
                    if (startpos != 0)
                    {
                        endpos = metadatafile.IndexOf("/>", startpos - 1) + 1;
                        var oInfo = new StringInfo("content=" + '\u0022');
                        lenheader = oInfo.LengthInTextElements;
                        TextBox15 =
                            XMLInput(metadatafile.Substring(startpos + lenheader - 1, endpos - startpos - lenheader - 1));
                    }

                    startpos = metadatafile.IndexOf("<meta name=" + '\u0022' + "calibre:series_index" + '\u0022') + 1;
                    if (startpos != 0)
                    {
                        startpos = metadatafile.IndexOf(("content=" + '\u0022'), startpos - 1) + 1;
                        if (startpos != 0)
                        {
                            endpos = metadatafile.IndexOf("/>", startpos - 1) + 1;
                            var oInfo = new StringInfo("content=" + '\u0022');
                            lenheader = oInfo.LengthInTextElements;
                            TextBox14 = metadatafile.Substring(startpos + lenheader - 1,
                                endpos - startpos - lenheader - 1);
                        }
                    }
                }
            }
            catch (Exception)
            {
                TextBox15 = "ERROR";
            }

            //Get Description
            try
            {
                metadatafile =
                    metadatafile.Replace(
                        "<dc:description xmlns:dc=" + '\u0022' + "http://purl.org/dc/elements/1.1/" + '\u0022' + " />",
                        "<dc:description />");
                if (metadatafile.IndexOf("<dc:description />") + 1 == 0)
                {
                    startpos = metadatafile.IndexOf("<dc:description/>") + 1;
                    if (startpos == 0)
                    {
                        startpos = metadatafile.IndexOf("<dc:description") + 1;
                        if (startpos == 0)
                        {
                            startpos = metadatafile.IndexOf("<description") + 1;
                        }
                        if (startpos != 0)
                        {
                            endheader = metadatafile.IndexOf(">", startpos - 1) + 1;
                            lenheader = endheader - startpos + 1;
                            endpos = metadatafile.IndexOf("</dc:description>") + 1;
                            if (endpos == 0)
                            {
                                endpos = metadatafile.IndexOf("</description>") + 1;
                            }
                            TextBox4 =
                                XMLInput(metadatafile.Substring(startpos + lenheader - 1, endpos - startpos - lenheader));
                            _Description = TextBox4;
                        }
                    }
                }
            }
            catch (Exception)
            {
                TextBox4 = "ERROR";
            }

            //Get Publisher
            try
            {
                metadatafile =
                    metadatafile.Replace(
                        "<dc:publisher xmlns:dc=" + '\u0022' + "http://purl.org/dc/elements/1.1/" + '\u0022' + " />",
                        "<dc:publisher />");
                if (metadatafile.IndexOf("<dc:publisher />") + 1 == 0)
                {
                    startpos = metadatafile.IndexOf("<dc:publisher/>") + 1;
                    if (startpos == 0)
                    {
                        startpos = metadatafile.IndexOf("<dc:publisher") + 1;
                        if (startpos == 0)
                        {
                            startpos = metadatafile.IndexOf("<publisher") + 1;
                        }
                        if (startpos != 0)
                        {
                            endheader = metadatafile.IndexOf(">", startpos - 1) + 1;
                            lenheader = endheader - startpos + 1;
                            endpos = metadatafile.IndexOf("</dc:publisher>") + 1;
                            if (endpos == 0)
                            {
                                endpos = metadatafile.IndexOf("</publisher>") + 1;
                            }
                            TextBox5 =
                                XMLInput(metadatafile.Substring(startpos + lenheader - 1, endpos - startpos - lenheader));
                        }
                    }
                }
            }
            catch (Exception)
            {
                TextBox5 = "ERROR";
            }

            //Get Date
            try
            {
                Label6 = "Date";

                startpos = metadatafile.IndexOf("<dc:date") + 1;
                firsttaglength = 8;
                if (startpos == 0)
                {
                    startpos = metadatafile.IndexOf("<date") + 1;
                    firsttaglength = 5;
                }
                if (startpos != 0)
                {
                    endheader = metadatafile.IndexOf(">", startpos - 1) + 1;
                    lenheader = endheader - startpos + 1;
                    endpos = metadatafile.IndexOf("</dc:date>") + 1;
                    if (endpos == 0)
                    {
                        endpos = metadatafile.IndexOf("</date>") + 1;
                    }
                    if (metadatafile.Substring(startpos + firsttaglength - 1, 1) == ">")
                    {
                        TextBox6 = metadatafile.Substring(startpos + lenheader - 1, endpos - startpos - lenheader);
                    }
                    else
                    {
                        //Get optional attribute: event
                        fileaspos = metadatafile.IndexOf("opf:event=", startpos - 1) + 1;
                        if (fileaspos != 0)
                        {
                            TextBox6 = metadatafile.Substring(startpos + lenheader - 1, endpos - startpos - lenheader);
                            Label6 = "Date (" + metadatafile.Substring(fileaspos + 11 - 1, endheader - fileaspos - 12) +
                                     ")";
                        }
                    }
                }
            }
            catch (Exception)
            {
                TextBox6 = "ERROR";
            }

            //Get Subject
            try
            {
                metadatafile =
                    metadatafile.Replace(
                        "<dc:subject xmlns:dc=" + '\u0022' + "http://purl.org/dc/elements/1.1/" + '\u0022' + " />",
                        "<dc:subject />");
                if (metadatafile.IndexOf("<dc:subject />") + 1 == 0)
                {
                    startpos = metadatafile.IndexOf("<dc:subject/>") + 1;
                    if (startpos == 0)
                    {
                        startpos = metadatafile.IndexOf("<dc:subject") + 1;
                        if (startpos == 0)
                        {
                            startpos = metadatafile.IndexOf("<subject") + 1;
                        }
                        if (startpos != 0)
                        {
                            endheader = metadatafile.IndexOf(">", startpos - 1) + 1;
                            lenheader = endheader - startpos + 1;
                            endpos = metadatafile.IndexOf("</dc:subject>") + 1;
                            if (endpos == 0)
                            {
                                endpos = metadatafile.IndexOf("</subject>") + 1;
                            }
                            TextBox17 =
                                XMLInput(metadatafile.Substring(startpos + lenheader - 1, endpos - startpos - lenheader));
                        }
                    }
                }
            }
            catch (Exception)
            {
                TextBox17 = "ERROR";
            }

            //Get Type
            try
            {
                metadatafile =
                    metadatafile.Replace(
                        "<dc:type xmlns:dc=" + '\u0022' + "http://purl.org/dc/elements/1.1/" + '\u0022' + " />",
                        "<dc:type />");
                if (metadatafile.IndexOf("<dc:type />") + 1 == 0)
                {
                    startpos = metadatafile.IndexOf("<dc:type/>") + 1;
                    if (startpos == 0)
                    {
                        startpos = metadatafile.IndexOf("<dc:type") + 1;
                        if (startpos == 0)
                        {
                            startpos = metadatafile.IndexOf("<type") + 1;
                        }
                        if (startpos != 0)
                        {
                            endheader = metadatafile.IndexOf(">", startpos - 1) + 1;
                            lenheader = endheader - startpos + 1;
                            endpos = metadatafile.IndexOf("</dc:type>") + 1;
                            if (endpos == 0)
                            {
                                endpos = metadatafile.IndexOf("</type>") + 1;
                            }
                            TextBox7 = metadatafile.Substring(startpos + lenheader - 1, endpos - startpos - lenheader);
                        }
                    }
                }
            }
            catch (Exception)
            {
                TextBox7 = "ERROR";
            }

            //Get Format
            try
            {
                metadatafile =
                    metadatafile.Replace(
                        "<dc:format xmlns:dc=" + '\u0022' + "http://purl.org/dc/elements/1.1/" + '\u0022' + " />",
                        "<dc:format />");
                if (metadatafile.IndexOf("<dc:format />") + 1 == 0)
                {
                    startpos = metadatafile.IndexOf("<dc:format/>") + 1;
                    if (startpos == 0)
                    {
                        startpos = metadatafile.IndexOf("<dc:format/>") + 1;
                        if (startpos == 0)
                        {
                            startpos = metadatafile.IndexOf("<dc:format") + 1;
                            if (startpos == 0)
                            {
                                startpos = metadatafile.IndexOf("<format") + 1;
                            }
                            if (startpos != 0)
                            {
                                endheader = metadatafile.IndexOf(">", startpos - 1) + 1;
                                lenheader = endheader - startpos + 1;
                                endpos = metadatafile.IndexOf("</dc:format>") + 1;
                                if (endpos == 0)
                                {
                                    endpos = metadatafile.IndexOf("</format>") + 1;
                                }
                                TextBox8 = metadatafile.Substring(startpos + lenheader - 1,
                                    endpos - startpos - lenheader);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                TextBox8 = "ERROR";
            }

            //Get Identifier
            try
            {
                startpos = metadatafile.IndexOf("<dc:identifier") + 1;
                firsttaglength = 14;
                if (startpos == 0)
                {
                    startpos = metadatafile.IndexOf("<identifier") + 1;
                    firsttaglength = 11;
                }
                if (startpos != 0)
                {
                    bool nocontent = default(bool);
                    nocontent = false;
                    endheader = metadatafile.IndexOf(">", startpos - 1) + 1;
                    lenheader = endheader - startpos + 1;
                    endpos = metadatafile.IndexOf("</dc:identifier>") + 1;
                    if (endpos == 0)
                    {
                        endpos = metadatafile.IndexOf("</identifier>") + 1;
                    }
                    if (endpos == 0)
                    {
                        endpos = metadatafile.IndexOf(" />", startpos - 1) + 1;
                        if (endpos != 0)
                        {
                            nocontent = true;
                        }
                    }
                    if (endpos != 0)
                    {
                        if (metadatafile.Substring(startpos + firsttaglength - 1, 1) == ">")
                        {
                            TextBox9 = metadatafile.Substring(startpos + lenheader - 1, endpos - startpos - lenheader);
                            Label9 = "Identifier";
                        }
                        else
                        {
                            if (versioninfo == "3.0")
                            {
                                endheaderpos = metadatafile.IndexOf(">", startpos - 1) + 1;
                                TextBox9 = metadatafile.Substring(endheaderpos + 1 - 1, endpos - endheaderpos - 1);
                                Label9 = "Identifier";


                                //Get id
                                idpos = metadatafile.IndexOf("id=", startpos - 1) + 1;
                                idinfo = "";
                                if (idpos != 0)
                                {
                                    for (temploop = idpos + 4; temploop <= endpos; temploop++)
                                    {
                                        if (
                                            Convert.ToBoolean(
                                                char.Parse(
                                                    Convert.ToString(metadatafile.Substring(temploop - 1, 1) ==
                                                                     Convert.ToString('\u0022')))))
                                        {
                                            idinfo = metadatafile.Substring(idpos + 4 - 1, temploop - idpos - 4);
                                            break;
                                        }
                                    }
                                }
                                if (idinfo != "")
                                {
                                    temppos =
                                        metadatafile.IndexOf(("<meta refines=" + '\u0022' + "#" + idinfo + '\u0022'),
                                            startpos - 1) + 1;
                                    while (temppos != 0)
                                    {
                                        endheaderpos = metadatafile.IndexOf(">", temppos - 1) + 1;
                                        endpos = metadatafile.IndexOf("</meta>", temppos - 1) + 1;
                                        refinespos =
                                            metadatafile.IndexOf(("property=" + '\u0022' + "identifier-type"),
                                                temppos - 1) + 1;
                                        if (refinespos != 0)
                                        {
                                            if (refinespos < endpos)
                                            {
                                                refinespos =
                                                    metadatafile.IndexOf(("scheme=" + '\u0022'), refinespos - 1) + 1;
                                                if (refinespos != 0)
                                                {
                                                    if (refinespos < endpos)
                                                    {
                                                        Label9 = "Identifier (" +
                                                                 metadatafile.Substring(refinespos + 8 - 1,
                                                                     endheaderpos - refinespos - 10) + "=" +
                                                                 metadatafile.Substring(endheaderpos + 1 - 1,
                                                                     endpos - endheaderpos - 1) + ")";
                                                    }
                                                }
                                            }
                                        }
                                        temppos =
                                            metadatafile.IndexOf(
                                                ("<meta refines=" + '\u0022' + "#" + idinfo + '\u0022'), endpos - 1) + 1;
                                    }
                                }
                            }
                            else
                            {
                                //Get optional attribute: scheme
                                fileaspos = metadatafile.IndexOf("opf:scheme=", startpos - 1) + 1;
                                if (fileaspos != 0)
                                {
                                    for (temploop = fileaspos + 13; temploop <= endpos; temploop++)
                                    {
                                        if (
                                            Convert.ToBoolean(
                                                char.Parse(
                                                    Convert.ToString(metadatafile.Substring(temploop - 1, 1) ==
                                                                     Convert.ToString('\u0022')))))
                                        {
                                            Label9 = "Identifier (" +
                                                     metadatafile.Substring(fileaspos + 12 - 1,
                                                         temploop - fileaspos - 12) + ")";
                                            break;
                                        }
                                    }
                                    if (nocontent == false)
                                    {
                                        TextBox9 = metadatafile.Substring(startpos + lenheader - 1,
                                            endpos - startpos - lenheader);
                                    }
                                    else
                                    {
                                        //Get id
                                        idpos = metadatafile.IndexOf("id=", startpos - 1) + 1;
                                        TextBox9 = "";
                                        if (idpos != 0)
                                        {
                                            for (temploop = idpos + 4; temploop <= endpos; temploop++)
                                            {
                                                if (
                                                    Convert.ToBoolean(
                                                        char.Parse(
                                                            Convert.ToString(metadatafile.Substring(temploop - 1, 1) ==
                                                                             Convert.ToString('\u0022')))))
                                                {
                                                    TextBox9 = metadatafile.Substring(idpos + 4 - 1,
                                                        temploop - idpos - 4);
                                                    break;
                                                }
                                            }
                                        }
                                    }

                                }
                                else
                                {
                                    if (nocontent == false)
                                    {
                                        TextBox9 = metadatafile.Substring(startpos + lenheader - 1,
                                            endpos - startpos - lenheader);
                                    }
                                    else
                                    {
                                        //Get id
                                        idpos = metadatafile.IndexOf("id=", startpos - 1) + 1;
                                        TextBox9 = "";
                                        if (idpos != 0)
                                        {
                                            for (temploop = idpos + 4; temploop <= endpos; temploop++)
                                            {
                                                if (
                                                    Convert.ToBoolean(
                                                        char.Parse(
                                                            Convert.ToString(metadatafile.Substring(temploop - 1, 1) ==
                                                                             Convert.ToString('\u0022')))))
                                                {
                                                    TextBox9 = metadatafile.Substring(idpos + 4 - 1,
                                                        temploop - idpos - 4);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    Label9 = "Identifier";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                TextBox9 = "ERROR";
            }

            //Get source
            try
            {
                metadatafile =
                    metadatafile.Replace(
                        "<dc:source xmlns:dc=" + '\u0022' + "http://purl.org/dc/elements/1.1/" + '\u0022' + " />",
                        "<dc:source />");
                if (metadatafile.IndexOf("<dc:source />") + 1 == 0)
                {
                    startpos = metadatafile.IndexOf("<dc:source/>") + 1;
                    if (startpos == 0)
                    {
                        startpos = metadatafile.IndexOf("<dc:source") + 1;
                        if (startpos == 0)
                        {
                            startpos = metadatafile.IndexOf("<source") + 1;
                        }
                        if (startpos != 0)
                        {
                            endheader = metadatafile.IndexOf(">", startpos - 1) + 1;
                            lenheader = endheader - startpos + 1;
                            endpos = metadatafile.IndexOf("</dc:source>") + 1;
                            if (endpos == 0)
                            {
                                endpos = metadatafile.IndexOf("</source>") + 1;
                            }
                            _Souce = metadatafile.Substring(startpos + lenheader - 1, endpos - startpos - lenheader);
                        }
                    }
                }
            }
            catch (Exception)
            {
                _Souce = "ERROR";
            }

            //Get Language
            try
            {
                metadatafile =
                    metadatafile.Replace(
                        "<dc:language xmlns:dc=" + '\u0022' + "http://purl.org/dc/elements/1.1/" + '\u0022' + " />",
                        "<dc:language />");
                if (metadatafile.IndexOf("<dc:language />") + 1 == 0)
                {
                    startpos = metadatafile.IndexOf("<dc:language/>") + 1;
                    if (startpos == 0)
                    {
                        startpos = metadatafile.IndexOf("<dc:language") + 1;
                        if (startpos == 0)
                        {
                            startpos = metadatafile.IndexOf("<language") + 1;
                        }
                        if (startpos != 0)
                        {
                            endheader = metadatafile.IndexOf(">", startpos - 1) + 1;
                            lenheader = endheader - startpos + 1;
                            endpos = metadatafile.IndexOf("</dc:language>") + 1;
                            if (endpos == 0)
                            {
                                endpos = metadatafile.IndexOf("</language>") + 1;
                            }
                            langtext = metadatafile.Substring(startpos + lenheader - 1, endpos - startpos - lenheader);
                            TextBox11 = langtext;
                        }
                    }
                }
            }
            catch (Exception)
            {
                TextBox11 = "ERROR";
            }

            if (extractcover == false)
            {
                goto didnotfindhref;
            }

            //Get Cover
            try
            {
                possibleDRM = false;

                startpos = metadatafile.IndexOf("<guide") + 1;
                if (startpos == 0)
                {
                    startpos = metadatafile.IndexOf("<opf:guide") + 1;
                }
                if (startpos == 0)
                {
                    //Some Sony Reader Library files have no <guide>
                    startpos = metadatafile.IndexOf("<manifest") + 1;
                    if (startpos == 0)
                    {
                        startpos = metadatafile.IndexOf("<opf:manifest") + 1;
                    }
                    if (startpos != 0)
                    {
                        hreftype = "id=" + '\u0022' + "cov" + '\u0022';
                        coverfilepos = metadatafile.IndexOf(hreftype, startpos - 1) + 1;
                        if (coverfilepos == 0)
                        {
                            hreftype = "id=" + '\u0022' + "cover" + '\u0022';
                            coverfilepos = metadatafile.IndexOf(hreftype, startpos - 1) + 1;
                            if (coverfilepos == 0)
                            {
                                hreftype = "id=" + '\u0022' + "coverpage" + '\u0022';
                                coverfilepos = metadatafile.IndexOf(hreftype, startpos - 1) + 1;
                            }
                        }
                    }
                }
                else
                {
                    hreftype = "type=" + '\u0022' + "cover" + '\u0022';
                    coverfilepos = metadatafile.IndexOf(hreftype, startpos - 1) + 1;
                    if (coverfilepos == 0)
                    {
                        //some Sony Reader Library files require different processing
                        hreftype = "title=" + '\u0022' + "Cover" + '\u0022';
                        coverfilepos = metadatafile.IndexOf(hreftype, startpos - 1) + 1;
                        if (coverfilepos == 0)
                        {
                            hreftype = "title=" + '\u0022' + "Cover Page" + '\u0022';
                            coverfilepos = metadatafile.IndexOf(hreftype, startpos - 1) + 1;
                            if (coverfilepos == 0)
                            {
                                hreftype = "type=" + '\u0022' + "coverimagestandard" + '\u0022';
                                coverfilepos = metadatafile.IndexOf(hreftype, startpos - 1) + 1;
                            }
                        }
                    }
                }

                if (coverfilepos == 0)
                {
                    goto didnotfindhref;
                }

                //find href (scanning forwards)
                nextcharpos = coverfilepos + 1;
                nextchar = metadatafile.Substring(nextcharpos - 1, 1);
                while (nextchar != ">")
                {
                    tempstring = metadatafile.Substring(nextcharpos - 1, 5);
                    if (tempstring == "href=")
                    {
                        goto foundhref;
                    }
                    nextcharpos++;
                    nextchar = metadatafile.Substring(nextcharpos - 1, 1);
                }

                //find href (scanning backwards)
                nextcharpos = coverfilepos - 1;
                nextchar = metadatafile.Substring(nextcharpos - 1, 1);
                while (nextchar != "<")
                {
                    tempstring = metadatafile.Substring(nextcharpos - 1, 5);
                    if (tempstring == "href=")
                    {
                        goto foundhref;
                    }
                    nextcharpos--;
                    nextchar = metadatafile.Substring(nextcharpos - 1, 1);
                }
                goto didnotfindhref;
            foundhref:
                coverfilepos = nextcharpos;
                endpos = metadatafile.IndexOf(('\u0022').ToString(), coverfilepos + 6 - 1) + 1;
                coverfile = Path.GetDirectoryName(opffile) + "\\" +
                            metadatafile.Substring(coverfilepos + 6 - 1, endpos - coverfilepos - 6).Replace("/", "\\");

                if ((Path.GetExtension(coverfile) == ".jpg") || (Path.GetExtension(coverfile) == ".jpeg") ||
                    (Path.GetExtension(coverfile) == ".png"))
                {
                    if (File.Exists(coverfile))
                    {
                        coverimagefile = coverfile;
                       
                        try
                        {
                            PictureBox1 = Image.FromFile(coverfile);
                            // PictureBox1.Load();
                        }
                        catch (Exception)
                        {
                            possibleDRM = true;
                            goto exitsub;
                        }
                        goto updateinterface;
                    }
                }
                else
                {
                    //Parse coverfile for image information
                    if (File.Exists(coverfile))
                    {
                        coverfiletext = LoadUnicodeFile(coverfile);
                        startpos = coverfiletext.IndexOf("<svg") + 1;
                        if (startpos != 0)
                        {
                        }
                        startpos = coverfiletext.IndexOf("<img") + 1;
                        if (startpos != 0)
                        {
                            startpos = coverfiletext.IndexOf("src", startpos - 1) + 1;
                            startpos = coverfiletext.IndexOf(('\u0022').ToString(), startpos - 1) + 1;
                            if (startpos != 0)
                            {
                                endpos = coverfiletext.IndexOf(('\u0022').ToString(), startpos + 1 - 1) + 1;
                                if (endpos != 0)
                                {
                                    relativecoverimagefile = coverfiletext.Substring(startpos + 1 - 1,
                                        endpos - startpos - 1);
                                    coverimagefile = Path.GetDirectoryName(coverfile) + "\\" +
                                                     coverfiletext.Substring(startpos + 1 - 1, endpos - startpos - 1)
                                                         .Replace("/", "\\");
                                    if (File.Exists(coverimagefile))
                                    {
                                     
                                        try
                                        {
                                            PictureBox1 = Image.FromFile(coverimagefile);
                                        }
                                        catch (Exception)
                                        {
                                            possibleDRM = true;
                                            goto exitsub;
                                        }
                                        goto updateinterface;
                                    }
                                }
                            }
                        }
                        else
                        {
                            startpos = coverfiletext.IndexOf("<image") + 1;
                            if (startpos != 0)
                            {
                                startpos = coverfiletext.IndexOf("href", startpos - 1) + 1;
                                startpos = coverfiletext.IndexOf(('\u0022').ToString(), startpos - 1) + 1;
                                if (startpos != 0)
                                {
                                    endpos = coverfiletext.IndexOf(('\u0022').ToString(), startpos + 1 - 1) + 1;
                                    if (endpos != 0)
                                    {
                                        relativecoverimagefile = coverfiletext.Substring(startpos + 1 - 1,
                                            endpos - startpos - 1);
                                        coverimagefile = Path.GetDirectoryName(coverfile) + "\\" +
                                                         coverfiletext.Substring(startpos + 1 - 1, endpos - startpos - 1)
                                                             .Replace("/", "\\");
                                        if (File.Exists(coverimagefile))
                                        {
                                          
                                            try
                                            {
                                                PictureBox1 = Image.FromFile(coverimagefile);
                                            }
                                            catch (Exception)
                                            {
                                                possibleDRM = true;
                                                goto exitsub;
                                            }
                                            goto updateinterface;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                startpos = coverfiletext.IndexOf("<svg:image") + 1;
                                if (startpos != 0)
                                {
                                    startpos = coverfiletext.IndexOf("href", startpos - 1) + 1;
                                    startpos = coverfiletext.IndexOf(('\u0022').ToString(), startpos - 1) + 1;
                                    if (startpos != 0)
                                    {
                                        endpos = coverfiletext.IndexOf(('\u0022').ToString(), startpos + 1 - 1) + 1;
                                        if (endpos != 0)
                                        {
                                            relativecoverimagefile = coverfiletext.Substring(startpos + 1 - 1,
                                                endpos - startpos - 1);
                                            coverimagefile = Path.GetDirectoryName(coverfile) + "\\" +
                                                             coverfiletext.Substring(startpos + 1 - 1,
                                                                 endpos - startpos - 1).Replace("/", "\\");
                                            if (File.Exists(coverimagefile))
                                            {
                                                
                                                try
                                                {
                                                    PictureBox1 = Image.FromFile(coverimagefile);
                                                }
                                                catch (Exception)
                                                {
                                                    possibleDRM = true;
                                                    goto exitsub;
                                                }
                                                goto updateinterface;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }


        didnotfindhref:


            if (extractcover)
            {
                //Look for existing images
                startpos = metadatafile.IndexOf("<manifest") + 1;
                endpos = metadatafile.IndexOf("</manifest>") + 1;
                int imgpos = default(int);
                int hrefpos = default(int);
                int endhrefpos = default(int);
                int imgnum = default(int);
                string href = default(string);
                string imgfilename = default(string);
                imgpos = startpos;
                imgnum = 0;
                while (imgpos < endpos)
                {
                    imgpos = metadatafile.IndexOf(("media-type=" + '\u0022' + "image/jpeg"), imgpos + 1 - 1) + 1;
                    if ((imgpos == 0) || (imgpos > endpos))
                    {
                        break;
                    }

                    //Scan backwards looking for start of <item>
                    temppos = imgpos;
                    while (temppos > startpos)
                    {
                        temppos--;
                        if (metadatafile.Substring(temppos - 1, 5) == "<item")
                        {
                            break;
                        }
                    }
                    hrefpos = metadatafile.IndexOf("href=", temppos - 1) + 1;
                    endhrefpos = metadatafile.IndexOf(('\u0022').ToString(), hrefpos + 6 - 1) + 1;
                    href = metadatafile.Substring(hrefpos + 6 - 1, endhrefpos - hrefpos - 6);
                    href = href.Replace("%20", " ");
                    ListBox2.Add(href);
                    imgnum++;
                    if (href.IndexOf("cover") + 1 != 0)
                    {
                        ListBox2SelectedIndex = imgnum - 1;
                    }
                }

                if (ListBox2.Count > 0)
                {
                    if (ListBox2SelectedIndex == -1)
                    {
                        ListBox2SelectedIndex = 0;
                    }
                    //Show preview
                    imgfilename = Path.GetDirectoryName(opffile) + "\\" +
                                  ListBox2[ListBox2SelectedIndex].ToString().Replace("/", "\\");
                    if (File.Exists(imgfilename))
                    {
                        
                        try
                        {
                            PictureBox2 = Image.FromFile(imgfilename);
                        }
                        catch (Exception)
                        {
                            possibleDRM = true;
                        }
                    }
                }
            }
            goto exitsub;

        updateinterface:
            // Check to see if cover has been prioritised already
            if (File.Exists(ebookdirectory + "\\0000Cover.jpg") ||
                (File.Exists(ebookdirectory + "\\0000Cover.jpeg") ||
                (File.Exists(ebookdirectory + "\\0000Cover.png"))))
            {
            }

            fixcovermetadata = false;
            fixcovermanifest = false;


            if (relativecoverimagefile != "")
            {
                int pos = default(int);

                // Check to see if cover image information is in metadata
                // e.g. <meta content="cover.jpg" name="cover"/>
                pos = relativecoverimagefile.LastIndexOf("/");
                coverimagefilename = relativecoverimagefile.Substring(pos + 2 - 1);
                pos = metadatafile.IndexOf("name=" + '\u0022' + "cover" + '\u0022') + 1;
                if (pos == 0)
                {
                    fixcovermetadata = true;
                }

                // Check to see if cover image information is in manifest
                // e.g. <item href="Images/cover.jpg" id="cover" media-type="image/jpeg"/>
                startpos = metadatafile.IndexOf("<manifest") + 1;
                pos = metadatafile.IndexOf(("id=" + '\u0022' + "cover" + '\u0022'), startpos - 1) + 1;
                if (pos == 0)
                {
                    fixcovermanifest = true;
                }
                else
                {
                    endpos = metadatafile.IndexOf("</manifest>") + 1;
                    if ((pos < startpos) || (pos > endpos))
                    {
                        fixcovermanifest = true;
                    }
                }
            }
        exitsub:
            1.GetHashCode(); //VBConversions note: C# requires an executable line here, so a dummy line was added.
        }
        /*
        private bool FileInUse(string sFile)
        {
            if (File.Exists(sFile))
            {
                try
                {
                    var F = (short)(FileSystem.FreeFile());
                    FileSystem.FileOpen(F, sFile, OpenMode.Binary, OpenAccess.ReadWrite, OpenShare.LockReadWrite, -1);
                    FileSystem.FileClose(F);
                }
                catch
                {
                    return true;
                }
            }
            return default(bool);
        }
        */
        private string GetHTMLCoverFile(string imagefile)
        {
            string returnstring = default(string);
            returnstring = "<?xml version=\'1.0\' encoding=\'utf-8\'?>" + '\n';
            returnstring = returnstring + "<html xmlns=" + '\u0022' + "http://www.w3.org/1999/xhtml" + '\u0022' +
                           " xml:lang=" + '\u0022' + "en" + '\u0022' + ">" + '\n';
            returnstring = returnstring + "   <head>" + '\n';
            returnstring = returnstring + "       <meta http-equiv=" + '\u0022' + "Content-Type" + '\u0022' +
                           " content=" + '\u0022' + "text/html; charset=UTF-8" + '\u0022' + "/>" + '\n';
            returnstring = returnstring + "       <meta name=" + '\u0022' + "calibre:cover" + '\u0022' + " content=" +
                           '\u0022' + "true" + '\u0022' + "/>" + '\n';
            returnstring = returnstring + "       <title>Cover</title>" + '\n';
            returnstring = returnstring + "       <style type=" + '\u0022' + "text/css" + '\u0022' + " title=" +
                           '\u0022' + "override_css" + '\u0022' + ">" + '\n';
            returnstring = returnstring + "           @page {padding: 0pt; margin:0pt}" + '\n';
            returnstring = returnstring + "           body { text-align: center; padding:0pt; margin: 0pt }" + '\n';
            returnstring = returnstring + "           div { padding:0pt; margin: 0pt }" + '\n';
            returnstring = returnstring + "           img { padding:0pt; margin: 0pt }" + '\n';
            returnstring = returnstring + "       </style>" + '\n';
            returnstring = returnstring + "   </head>" + '\n';
            returnstring = returnstring + "   <body>" + '\n';
            returnstring = returnstring + "       <div>" + '\n';
            returnstring = returnstring + "           <img src=" + '\u0022' + imagefile + '\u0022' + " alt=" + '\u0022' +
                           "cover" + '\u0022' + " style=" + '\u0022' + "height: 100%" + '\u0022' + "/>" + '\n';
            returnstring = returnstring + "       </div>" + '\n';
            returnstring = returnstring + "   </body>" + '\n';
            returnstring = returnstring + "</html>";
            return returnstring;
        }

        private object GetMimeType(string fileName)
        {
            string mimeType = "application/unknown";
            string ext = Path.GetExtension(fileName).ToLower();
            RegistryKey regKey = default(RegistryKey);
            regKey = Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey.GetValue("Content Type") != null)
            {
                mimeType = regKey.GetValue("Content Type").ToString();
            }
            return mimeType;
        }

        private string LoadUnicodeFile(string filename)
        {
            string UnicodeText = default(string);
            StreamReader sr = default(StreamReader);
            UnicodeText = "";
            try
            {
                sr = File.OpenText(filename);
                UnicodeText = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();
            }
            catch
            {
                //Always check to make sure the object isnt nothing (to avoid nullreference exceptions)
                if (sr != null)
                {
                    sr.Close();
                    sr = null;
                }
            }
            return UnicodeText;
        }

        

        public string frm3default { get; set; }

       

        private void SaveUnicodeFile(string filename, string UnicodeText)
        {
            StreamWriter sw = default(StreamWriter);
            try
            {
                sw = new StreamWriter(filename, false);
                sw.WriteLine(UnicodeText);
                sw.Close();
                sw.Dispose();
            }
            catch
            {
                if (sw != null)
                {
                    sw.Close();
                    sw = null;
                }
            }
        }
        /*
        private void wait(int interval)
        {
            // Loops for a specificied period of time (milliseconds)
            var sw = new Stopwatch();
            sw.Start();
            while (sw.ElapsedMilliseconds < interval)
            {
                // Allows UI to remain responsive
                Application.DoEvents();
            }
            sw.Stop();
        }
         */
        private string XMLInput(string InputString)
        {
            int x = default(int);
            int length = default(int);
            string OutputString = default(string);
            string nextchars = default(string);
            bool DidSomething = default(bool);
            OutputString = "";
            length = InputString.Length;
            x = 1;
            while (x <= length)
            {
                DidSomething = false;
                if (x + 3 <= length)
                {
                    nextchars = InputString.Substring(x - 1, 4);
                    if (nextchars == "&lt;")
                    {
                        OutputString = OutputString + "<";
                        x = x + 4;
                        DidSomething = true;
                    }
                    else if (nextchars == "&gt;")
                    {
                        OutputString = OutputString + ">";
                        x = x + 4;
                        DidSomething = true;
                    }
                }
                if (x + 4 <= length)
                {
                    nextchars = InputString.Substring(x - 1, 5);
                    if (nextchars == "&amp;")
                    {
                        OutputString = OutputString + "&";
                        x = x + 5;
                        DidSomething = true;
                    }
                }
                if (x + 5 <= length)
                {
                    nextchars = InputString.Substring(x - 1, 6);
                    if (nextchars == "&quot;")
                    {
                        OutputString = OutputString + '\u0022';
                        x = x + 6;
                        DidSomething = true;
                    }
                    else if (nextchars == "&apos;")
                    {
                        OutputString = OutputString + "\'";
                        x = x + 6;
                        DidSomething = true;
                    }
                }
                if (!DidSomething)
                {
                    OutputString = OutputString + InputString.Substring(x - 1, 1);
                    x++;
                }
            }
            return OutputString;
        }

        private string XMLOutput(string InputString)
        {
            int x = default(int);
            string OutputString = default(string);
            string nextchar = default(string);
            OutputString = "";
            for (x = 1; x <= InputString.Length; x++)
            {
                nextchar = InputString.Substring(x - 1, 1);
                if ((nextchar == "&") || (nextchar == "<") || (nextchar == ">") || (char.Parse(nextchar) == '\u0022') ||
                    (nextchar == "\'"))
                {
                    if (nextchar == "&")
                    {
                        OutputString = OutputString + "&amp;";
                    }
                    else if (nextchar == "<")
                    {
                        OutputString = OutputString + "&lt;";
                    }
                    else if (nextchar == ">")
                    {
                        OutputString = OutputString + "&gt;";
                    }
                    else if (char.Parse(nextchar) == '\u0022')
                    {
                        OutputString = OutputString + "&quot;";
                    }
                    else if (nextchar == "\'")
                    {
                        OutputString = OutputString + "&apos;";
                    }
                }
                else
                {
                    OutputString = OutputString + nextchar;
                }
            }
            return OutputString;
        }
    }
}
