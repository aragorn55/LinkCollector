using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using FicFileTool.Model;
using Utilities.DL;
namespace FicFileTool.Control
{
	public class CFicFileController
	{

		private List<CEpubFicFile> _epubList;
		public CFicFileController()
		{

            EpubList = new List<CEpubFicFile>();
			
		}

        public List<CEpubFicFile> EpubList
	    {
	        get { return _epubList; }
	        set { _epubList = value; }
	    }

        public List<CEpubFicFile> LoadEpubsFromFolder(string vsFilepath)
        {
            try
            {
                var dirs = Directory.EnumerateFiles(vsFilepath, "*.epub", SearchOption.AllDirectories);

                foreach (string currentFile in dirs)
                {
                    CEpubFicFile oEpub = new CEpubFicFile(currentFile);
                    EpubList.Add(oEpub);
                    //string fileName = currentFile.Substring(sourceDirectory.Length + 1);
                    //  Directory.Move(currentFile, Path.Combine(archiveDirectory, fileName));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           return EpubList;
            /*
			var dirs = Directory.GetFiles(vsFilepath, "*.epub", SearchOption.AllDirectories);
			//this.oEpubFileList.SetObjects(dirs);
			foreach (var sfile in dirs)
			{
				cEpubFile oEpub = new cEpubFile(sfile);

				_epubList.Add(oEpub);
				//    count ++;
			}
			return null;
             * */
        }
        /// <summary>
        /// optimized DoWork method - runs aync!
        /// </summary>
        public async Task<List<CEpubFicFile>> DoWorkAsyc(string vsFilepath)
        {
            // use await here, like so:
            return await Task.Run(() => LoadEpubsFromFolder(vsFilepath));
        }

        
        public async Task LoadEpubsFromFolderAsync(string vsFilepath)
		{

            _epubList = await Task.FromResult<List<CEpubFicFile>>(LoadEpubsFromFolder(vsFilepath));
           
           
		}
        
	    public async Task SaveAsync()
	    {
            await Task.Run(() => Save());
	    }

	    public void Save()
        {
            foreach (CEpubFicFile _epub in EpubList)
            {
                
                if (_epub.Source != null)
                {
                    if (_epub.Source.Count > 0)
                    {
                        if (_epub.Source[0].IndexOf('.') == -1)
                        {
                          _epub.FixMetadata();
                        }
                    }
                    else
                    {
                        _epub.FixMetadata();
                    }
                }
                else
                {
                     _epub.FixMetadata();
                }
            }
        }
		public bool FixMetadata()
		{
            foreach (CEpubFicFile _epub in EpubList)
            {
				if (_epub.Source != null){
					if (_epub.Source.Count > 0){
						if (_epub.Source[0].IndexOf('.') == -1){
                            _epub.FixMetadata();
						}
					}
					else{
						_epub.FixMetadata();
					}
				}
				else{
					_epub.FixMetadata();
				}
			}
		return true;
		}
			
		


		private async void btnReadEpub_Click(object sender, EventArgs e){
			 int icnt = 0;
             foreach (CEpubFicFile oEpub in EpubList)
			{
				//lblStatus1.Text = oEpub.FilePath;
			   await oEpub.LoadFileAsync();
				//lblProcessed.Text = icnt.ToString();
			}
				icnt += 1;
		//	lblStatus.Text = "Read";
		//	oEpubFileList.SetObjects(_epubList);
	//return icnt;
			//_epubList[0].FixMetadata();
			//lblOutput.Text = _epubList[0].OEpub.GetContentAsPlainText;
		}

		
		private async void ProcessDataAsync(string vDir)
	{
	// Start the HandleFile method.
		 //   Task<int> task = HandleFileAsync(sFileName);
			 var dirs = Directory.GetFiles(vDir, "*.epub", SearchOption.AllDirectories);
				//this.oEpubFileList.SetObjects(dirs);
				foreach (var sfile in dirs)
				{
                    CEpubFicFile oEpub = new CEpubFicFile(sfile);
				//	lblStatus.Text = sfile;
				 EpubList.Add(oEpub);
				   // count ++;
				}
		//		oEpubFileList.SetObjects(_epubList);
	//int x = await task;
	//lblProcessed.Text = x.ToString();
	}

	private  async Task<int> HandleFileAsync(string vDir)
	{
	//Console.WriteLine("HandleFile enter");
	int count = 0;
		 var dirs = Directory.GetFiles(vDir, "*.epub", SearchOption.AllDirectories);
				//this.oEpubFileList.SetObjects(dirs);
				foreach (var sfile in dirs)
				{
                    CEpubFicFile oEpub = new CEpubFicFile(sfile);
				//	lblStatus.Text = sfile;
				 EpubList.Add(oEpub);
					count ++;
				}
		//		oEpubFileList.SetObjects(_epubList);
	return count;
	}
		private async void ProcessReadAsync()
	{
	// Start the HandleFile method.
	Task<int> task = HandleReadAsync();

	int x = await task;
		//	lblProcessed.Text = x.ToString();
	}

	private  async Task<int> HandleReadAsync(){
		int icnt = 0;
        foreach (CEpubFicFile oEpub in EpubList)
			{
		//		lblStatus1.Text = oEpub.FilePath;
				oEpub.LoadFile();
				icnt += 1;
			//	lblProcessed.Text = icnt.ToString();
			}
//			lblStatus.Text = "Read";
	//		oEpubFileList.SetObjects(_epubList);
	return icnt;
	}
		private  async Task<int> ReadAsync()
		{
			Task[] tasks = new Task[EpubList.Count];
				for (int i = 0; i < EpubList.Count; i++)
				{
					tasks[i] = CreateReadTask(EpubList[i]);
				}
			return 0; 
//#endif
		}

        private Task CreateReadTask(CEpubFicFile epub)
		{
			return null;
		}

        private string MakeWork(CEpubFicFile epubFile)
		{
			epubFile.LoadFile();
			return epubFile.FileName;
		}
        private async Task DoWork(CEpubFicFile epubFile)
		{
			Func<string> function = new Func<string>(() => MakeWork(epubFile));
			TaskFactory oFactory = new TaskFactory();
			string res = await oFactory.StartNew<string>(function);
			Task task  = Task.Factory.StartNew(DoWork(epubFile.LoadFileAsync()));
		  //  task.
			
		}

		private Action DoWork(Task loadFileAsync)
		{
			return null;
        }
        #region xml
        public void SaveXML()
        {
            try
            {
                CFile oFile = new CFile(@"c:\G\Personal\FicData.xml");
                oFile.Serialize(typeof(List<CEpubFicFile>), EpubList);
                oFile = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static public void SerializeToXML(List<CEpubFicFile> epubList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<CEpubFicFile>));
            TextWriter textWriter = new StreamWriter(@"c:\G\Personal\FicData.xml");
            serializer.Serialize(textWriter, epubList);
            textWriter.Close();
        }
        public void LoadXML()
        {
            try
            {
                CFile oFile = new CFile(@"c:\G\Personal\FicData.xml");
                //CFile oFile = new CFile(  "Students.xml");
                EpubList = (List<CEpubFicFile>)oFile.Deserialize(typeof(List<CEpubFicFile>));
                oFile = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void SerializeObject(string filename)
        {
            // Console.WriteLine("Writing With XmlTextWriter");

            XmlSerializer serializer = new XmlSerializer(typeof(CEpubFicFile));

            // Create an XmlTextWriter using a FileStream.
            Stream fs = new FileStream(filename, FileMode.Create);
            XmlWriter writer = new XmlTextWriter(fs, Encoding.Unicode);
            // Serialize using the XmlTextWriter.
            serializer.Serialize(writer, EpubList[0]);
            writer.Close();
        }

#endregion

    }
	}

