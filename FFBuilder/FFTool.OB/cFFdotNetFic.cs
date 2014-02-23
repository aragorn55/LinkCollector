using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFtool.OB
{
    public class cFFdotNetFic: cFic
    {
        //Fill these variables with content but do not modify the variables names!!
        private string msWebsiteName = "";			//Name of the website, nicely formated (String)
        private string msStoryText = "";

        public string StoryText
        {
            get { return msStoryText; }
            set { msStoryText = value; }
        }
        public string WebsiteName
        {
            get { return msWebsiteName; }
            set { msWebsiteName = value; }
        }
        private string msStoryName = "";				//Contains the name of the Story that you are downloading (String)

        public string StoryName
        {
            get { return msStoryName; }
            set { msStoryName = value; }
        }
        private string msAuthorName = "";			//Contains the name of the Author (String)

        public string AuthorName
        {
            get { return msAuthorName; }
            set { msAuthorName = value; }
        }
        private int CountOfChapters = 0;		//Count of chapters (Integer)

        public int CountOfChapters1
        {
            get { return CountOfChapters; }
            set { CountOfChapters = value; }
        }
        private string LastUpdated = "";			//Date of the last update (String, Format mm/dd/yyyy)

        public string LastUpdated1
        {
            get { return LastUpdated; }
            set { LastUpdated = value; }
        }
        private string _Summary = "";				//Summary of the story (String)

        public string Summary
        {
            get { return _Summary; }
            set { _Summary = value; }
        }
        private string _StoryStatus = "Unknown";	//Status of the story (Either "Complete", "In Progress" or "Unknown") (String)

        public string StoryStatus
        {
            get { return _StoryStatus; }
            set { _StoryStatus = value; }
        }
        private string _Category = "";				//Story Category (String)

        public string Category
        {
            get { return _Category; }
            set { _Category = value; }
        }
        private string _StoryLink = "";				//Link to the story. IMPORTANT: independent of the entered link (chapter 1 or 2 or 20...) this has to be always the same!! Also it must be a link that the downloader accepts. (String)

        public string StoryLink
        {
            get { return _StoryLink; }
            set { _StoryLink = value; }
        }
        private int _TotalWordCount = 0;			//Total wordcount of the story. Set it to 0 if the total wordcount isn't displayed by the website. Then it'll be the sum of all chapters. (Integer)

        public int TotalWordCount
        {
            get { return _TotalWordCount; }
            set { _TotalWordCount = value; }
        }
        private List<string> _chapterNames;			//Name/title of the chapters. (Use chapterNames.push(""); to add a new entry) (String)

        public List<string> ChapterNames
        {
            get { return _chapterNames; }
            set { _chapterNames = value; }
        }
        private List<string> _chapterLinks;			//Link to the chapters. (Use chapterLinks.push(""); to add a new entry) (String)

        public List<string> ChapterLinks
        {
            get { return _chapterLinks; }
            set { _chapterLinks = value; }
        }
        private string _LinkAdditionInfo = "";		//Set link if you want to request additional infos

        public string LinkAdditionInfo
        {
            get { return _LinkAdditionInfo; }
            set { _LinkAdditionInfo = value; }
        }


//variables for "analyseChapter()"
        private string _ChapterText = "";			//contains the storytext with html formatting. This is overwritten each time that analyseChapter() is called (Stirng)

        public string ChapterText
        {
            get { return _ChapterText; }
            set { _ChapterText = value; }
        }
        private int _ChapterWordCount = 0;		//coontains the count of words for this chapter. Set to 0 if the information is not provided by the website (Integer)

        public int ChapterWordCount
        {
            get { return _ChapterWordCount; }
            set { _ChapterWordCount = value; }
        }

//End variable area
        public cFFdotNetFic()
        {
            msStoryName = "";

        }
    }
}
