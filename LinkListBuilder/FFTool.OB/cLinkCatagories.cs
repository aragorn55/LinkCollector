using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.DL;
using System.IO;
namespace FFTool.OB
{
    // public class cLinkCategories : CollectionBase
    public class cLinkCategorie
    {
        List<cLinkCategory> oCatagories = new List<cLinkCategory>();

        public List<cLinkCategory> Catagories
        {
            get { return oCatagories; }
            set { oCatagories = value; }
        }
        string msFileName = "LinkCategories.txt";

        public void Add(cLinkCategory oLinkCategory)
        {
           // base.List.Add(oLinkCategory);
            oCatagories.Add(oLinkCategory);
        }

        public void RemoveAt(int viIndex)
        {
            //base.List.RemoveAt(viIndex);
            oCatagories.RemoveAt(viIndex);
        }
        /*

        public cLinkCategory this[int viIndex]
        {
            get { return (cLinkCategory)base.List[viIndex]; }
        }
        */
        public bool Load1()
        {
            string[] oLinkCategoryRecord = null;
            StreamReader oFiler = null;
            string sPath = null;
            string sReadLine = null;
            sPath = msFileName;
            int icnt = 0;

            // Open the file that the user picked




            if (File.Exists(sPath))
            {
                oFiler = File.OpenText(sPath);

                while (oFiler.Peek() != -1)
                {
                    icnt += 1;
                    sReadLine = oFiler.ReadLine();
                   oLinkCategoryRecord = sReadLine.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                  //  oLinkCategoryRecord = sReadLine.Split(Convert.ToChar(Constants.vbCrLf));


                    foreach (string LinkRow in oLinkCategoryRecord)
                    {

                        if (LinkRow.Trim().Length > 3)
                        {
                            // Process a student record
                            cLinkCategory oLinkCategory = new cLinkCategory();
                            string[] sLinkFields = null;

                            sLinkFields = LinkRow.Split('|');

                            var _with1 = oLinkCategory;
                            _with1.Name = sLinkFields[1];
                            _with1.FileName = sLinkFields[2];
                            _with1.LinkDefine = sLinkFields[3];
                            oCatagories.Add(oLinkCategory);
                           // Add(oLinkCategory);

                        }

                    }
                    return true;
                }

                try
                {



                }
                catch (Exception ex)
                {
                    throw ex;
                }



                // Cleanup the variables
                oFiler.Close();
                oFiler.Dispose();


            }
            else
            {
                File.Create("LinkCategories.txt");


                if (File.Exists(sPath))
                {
                    oFiler = File.OpenText(sPath);

                    while (oFiler.Peek() != -1)
                    {
                        icnt += 1;
                        sReadLine = oFiler.ReadLine();
                        oLinkCategoryRecord = sReadLine.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);


                      //  oLinkCategoryRecord = sReadLine.Split(Convert.ToChar(Constants.vbCrLf));


                        foreach (string LinkRow in oLinkCategoryRecord)
                        {

                            if (LinkRow.Trim().Length > 3)
                            {
                                // Process a student record
                                cLinkCategory oLinkCategory = new cLinkCategory();
                                string[] sLinkFields = null;

                                sLinkFields = LinkRow.Split('|');

                                var _with2 = oLinkCategory;
                                _with2.Name = sLinkFields[1];
                                _with2.FileName = sLinkFields[2];
                                _with2.LinkDefine = sLinkFields[3];
                                oCatagories.Add(oLinkCategory);
                                // Add(oLinkCategory);

                            }

                        }
                        return true;
                    }

                    try
                    {



                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }



                    // Cleanup the variables
                    oFiler.Close();
                    oFiler.Dispose();



                   // MessageBox.Show("File doeesn't exist.");

                }

                oFiler = null;
            }

            return false;

        }

        public bool Save1()
        {





            // Delete the output file
            cFile oFile = new cFile();
            oFile.Delete();
            oFile = null;


            //foreach (cLinkCategory oLinkCategory in this)
            foreach (cLinkCategory oLinkCategory in oCatagories)
            {
                oLinkCategory.Save();
            }

            return true;

        }
        public bool Save()
        {





            // Delete the output file
            cFile oFile = new cFile();
            oFile.Delete();
            oFile = null;


            //foreach (cLinkCategory oLinkCategory in this)
            foreach (cLinkCategory oLinkCategory in oCatagories)
            {
                oLinkCategory.Save(msFileName);
            }

            return true;

        }
        public bool Load()
        {
            if (File.Exists(msFileName))
            {
                string[] oLinkCatRecord = null;
                cFile oFile = new cFile(msFileName);


                try
                {
                    string sInput = oFile.Read();

                   // oLinkCatRecord = sInput.Split(Convert.ToChar(Constants.vbCrLf));
                    oLinkCatRecord = sInput.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);



                    foreach (string linkRow in oLinkCatRecord)
                    {

                        if (linkRow.Trim().Length > 3)
                        {
                            // Process a student record
                            cLinkCategory oLinkCategory = new cLinkCategory();
                            string[] sLinkFields = null;

                            sLinkFields = linkRow.Split('|');

                            var _with3 = oLinkCategory;

                            _with3.Name = sLinkFields[0];
                            _with3.FileName = sLinkFields[1];
                            _with3.LinkDefine = sLinkFields[2];
                            oCatagories.Add(oLinkCategory);
                            // Add(oLinkCategory);

                        }

                    }
                    return true;

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    cFile oLog = new cFile("error.log");
                    oLog.Write(ex.Message);
                }
            }
            else
            {
                File.Create("LinkCategories.txt");
                Load();
            }
            return false;
        }

        public cLinkCategory Item(int intSearched)
        {
            //return base.List[intSearched];
            return oCatagories[intSearched];
        }
    }
}
