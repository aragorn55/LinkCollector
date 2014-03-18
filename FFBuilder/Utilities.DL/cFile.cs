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

        //public cFile()
       // {

       // }
        public cFile(string vsFileName)
        {
            //msFileName = "..//..//..//Utilities.DL//" + vsFileName;
			msFileName = vsFileName;
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
            catch
            {

                throw; //ex;
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
                catch
                {

                    throw; //ex;
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
            string[] filePaths = Directory.GetFiles(@"c:\MyDir\", "*.bmp");
            return filePaths;
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
            string[] filePaths = GetAllFileList(vsPath);
            List<string> sFileList = new List<string>();
            for (int iCnt = 0; iCnt < filePaths.Count(); iCnt++)
            {

                sFileList.Add(filePaths[iCnt]);
            }
            return sFileList;
        }


    }
}
