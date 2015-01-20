using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
//using Utilities.CustomException;
namespace Utilities.DL
{
    public class CFile
    {
        private string msFileName;

        public CFile()
        {
            throw new Exception("Implementation not Supported.");
        }
        public CFile(string vsFileName)
        {
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
        public static bool LogError(string sOutput)
        {
            try
            {
                StreamWriter oSW = File.AppendText("ErrorLog.log");
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
        public bool Move()
        {
            throw new System.NotImplementedException();
        }

        public bool Copy()
        {
            throw new System.NotImplementedException();
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

        public bool Rename()
        {
            throw new System.NotImplementedException();
        }




        public bool Serialize(Type oObjectType, object objects)
        {
            try
            {
                TextWriter oTextWriter = new StreamWriter(msFileName);
                XmlSerializer oSerializer = new XmlSerializer(oObjectType);
                //TextReader oTextReader = new StreamReader(@"C:\Users\Public\Students.xml");
                oSerializer.Serialize(oTextWriter, objects);
                oTextWriter.Close();
                oTextWriter.Dispose();
                oTextWriter = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public object Deserialize(Type oObjectType)
        {
            try
            {
                XmlSerializer oSerializer = new XmlSerializer(oObjectType);
                // TextReader oTextReader = new StreamReader(@"C:\Users\Public\Students.xml");
                TextReader oTextReader = new StreamReader(msFileName);
                object oObject = oSerializer.Deserialize(oTextReader);

                oTextReader.Close();
                oTextReader.Dispose();
                oTextReader = null;
                return oObject;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
