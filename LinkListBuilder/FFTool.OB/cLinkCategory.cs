using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.DL;
namespace FFTool.OB
{
	public class cLinkCategory
	{
		private string mstrName;
	private string mstrFileName;
	private string mstrLinkDefine;
	string msFileName = "LinkCategories.txt";
	public string Name {
		get { return mstrName; }
		set { mstrName = value; }
	}
	public string FileName {
		get { return mstrFileName; }
		set { mstrFileName = value; }
	}
	public string LinkDefine {
		get { return mstrLinkDefine; }
		set { mstrLinkDefine = value; }
	}
	public cLinkCategory(string vsName, string vsFileName, string vsLinkDefine)
	{
		mstrName = vsName;
		mstrFileName = vsFileName;
		mstrLinkDefine = vsLinkDefine;
	}
	public cLinkCategory()
	{
		mstrName = "";
		mstrFileName = "";
		mstrLinkDefine = "";
	}
	public bool Save()
	{


		try {
			cFile oFiler = new cFile();
			oFiler.Write(mstrName + "|" + mstrFileName + "|" + mstrLinkDefine);
			return true;


		} catch (Exception ex) {
			throw ex;


		}


	}
	public bool Save(string vsFileName)
	{


		try {
			cFile oFiler = new cFile(vsFileName);
			oFiler.Write(mstrName + "|" + mstrFileName + "|" + mstrLinkDefine);
			return true;


		} catch (Exception ex) {
			throw ex;


		}


	}
	}
}
