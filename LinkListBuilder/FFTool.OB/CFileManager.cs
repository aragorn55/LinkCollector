using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace FFTool.OB
{
  



public class CFileManager
{

	public void SaveFF_net(string sInput)
	{
		StreamWriter objStreamWriter = null;

		objStreamWriter = File.AppendText("fanfiction.net.txt");
		objStreamWriter.WriteLine(sInput);
		objStreamWriter.Close();
		objStreamWriter.Dispose();
		objStreamWriter = null;
	}

	public void SaveAddv(string sInput)
	{
		StreamWriter objStreamWriter = null;

		objStreamWriter = File.AppendText("Addventure.txt");
		objStreamWriter.WriteLine(sInput);
		objStreamWriter.Close();
		objStreamWriter.Dispose();
		objStreamWriter = null;
	}

	public void SaveOtherBkmk(string sInput)
	{
		StreamWriter objStreamWriter = null;

		objStreamWriter = File.AppendText("OtherBookmarks.txt");
		objStreamWriter.WriteLine(sInput);
		objStreamWriter.Close();
		objStreamWriter.Dispose();
		objStreamWriter = null;
	}

	public void SaveLinks(string sInput)
	{
		StreamWriter objStreamWriter = null;

		objStreamWriter = File.AppendText("Links.txt");
		objStreamWriter.WriteLine(sInput);
		objStreamWriter.Close();
		objStreamWriter.Dispose();
		objStreamWriter = null;
	}
    public void SaveLink(string sInput)
    {
        StreamWriter objStreamWriter = null;

        objStreamWriter = File.AppendText("Links.txt");
        objStreamWriter.WriteLine(sInput);
        objStreamWriter.Close();
        objStreamWriter.Dispose();
        objStreamWriter = null;
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