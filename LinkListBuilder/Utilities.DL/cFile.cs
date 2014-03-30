using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
//using Utilities.CustomException;
namespace Utilities.DL
{
    public class cFile
    {
        private string msFileName;

        public string FileName
        {
            get { return msFileName; }
            set { msFileName = value; }
        }
        public cFile(string vsFileName)
        {
            //msFileName = "..//..//..//Utilities.DL//" + vsFileName;
			msFileName = vsFileName;
        }
        public cFile()
        {
            msFileName = "..//..//..//Utilities.DL//" + "output.txt";
            
        }
        public String Read()
        {
            try
            {
                StreamReader oSR = File.OpenText(msFileName);
                string sInput = oSR.ReadToEnd();
                oSR.Close();
                oSR.Dispose();
                oSR = null;
                return sInput;

            }
            //catch (FileNotFoundException)
            // {
            //     throw new FileWasNotFoundException("Throw it against the wall Moron");
            // }
            catch (Exception ex)
            {

                throw ex;

            }
        }
        public List<String> ReadList()
        {
                try
                {
                    List<String> oOutput = new List<String>();
                    StreamReader oSR = File.OpenText(msFileName);
                    while (oSR.Peek() != -1)
                    {
                        string sInput = oSR.ReadLine();
                        oOutput.Add(sInput);
                    }
                    oSR.Close();
                    oSR.Dispose();
                    oSR = null;
                    return oOutput;
                }
                //catch (FileNotFoundException)
                // {
                //     throw new FileWasNotFoundException("Throw it against the wall Moron");
                // }
                catch (Exception ex)
                {

                    throw ex;

                }
            }
        
        public bool Write(string sOutput)
        {
            try
            {

                StreamWriter oSW = File.AppendText(msFileName);
                oSW.WriteLine(sOutput);
                oSW.Close();
                oSW.Dispose();
                oSW = null;
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
        public bool WriteLog(string sOutput, string vsPath)
        {
            try
            {
                if (!File.Exists(vsPath)){
                    File.Create(vsPath);
                }
                StreamWriter oSW = File.AppendText(vsPath);
                oSW.WriteLine(sOutput);
                oSW.Close();
                oSW.Dispose();
                oSW = null;
                return true;
                }
                
            
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
        public bool Delete()
        {
            try
            {
                if (File.Exists(msFileName))
                {
                    File.Delete(msFileName);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                return false;
                throw ex;
            }
        }
        public string[] GetFileList(string vsPath)
        {
            string[] filePaths = Directory.GetFiles(@vsPath);
            return filePaths;
        }
        public string[] GetFileListWexten(string vsPath, string vsExten)
        {
            vsPath = "@" + vsPath;
            vsExten = "*" + vsExten;
            string[] filePaths = Directory.GetFiles(vsPath, vsExten);
            return filePaths;
        }
        public List<string> AllFileListWExten(string vsPath, string vsExten)
        {
            vsPath = "@" + vsPath;
            vsExten = "*" + vsExten;
            string[] filePaths = Directory.GetFiles(vsPath, vsExten);
            List<string> sFileList = filePaths.ToList();
           
            return sFileList;
        }
        public string[] GetAllFileList(string vsPath)
        {
            //vsPath = "@" + vsPath;
            //string[] filePaths = Directory.GetFiles(@"c:\MyDir\", "*",
            string[] filePaths = Directory.GetFiles(vsPath, "*",
                                         SearchOption.AllDirectories);
            return filePaths;
        }
        public List<string> AllFileList(string vsPath)
        {
            try
            {
                List<string> sFileList = Directory.GetFiles(vsPath, "*", SearchOption.AllDirectories).ToList();
                return sFileList;

            }
            catch (Exception ex)
            {
                WriteLog(ex.Message, "AllFileListError.log");
                throw;
            }
        }
        public void SaveLink(string sInput, string sPath)
        {
            StreamWriter objStreamWriter = null;

            objStreamWriter = File.AppendText(sPath);
            objStreamWriter.WriteLine(sInput);
            objStreamWriter.Close();
            objStreamWriter.Dispose();
            objStreamWriter = null;
        }


       
    }
}
