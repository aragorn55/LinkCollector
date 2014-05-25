using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.IO;
namespace Bookmark_sorter
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
	}
}
