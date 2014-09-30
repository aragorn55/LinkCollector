using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFtool.OB
{
    public class cFic
    {
        private string _Category = "";

        private List<string> _chapterLinks;

        private List<string> _chapterNames;

        private string _ChapterText = "";

        private int _ChapterWordCount = 0;

        private string _LinkAdditionInfo = "";

        private string _StoryLink = "";

        private string _StoryStatus = "Unknown";

        private string _Summary = "";

        private int _TotalWordCount = 0;

        private int CountOfChapters = 0;

        private string LastUpdated = "";

        private string msAuthorName = "";

        private string msStoryName = "";

        private string msWebsiteName = "";
        private string _StoryId;

        public string StoryId
        {
            get { return _StoryId; }
            set { _StoryId = value; }
        }

        public string AuthorName
        {
            get { return msAuthorName; }
            set { msAuthorName = value; }
        }

        public string Category
        {
            get { return _Category; }
            set { _Category = value; }
        }

        public List<string> ChapterLinks
        {
            get { return _chapterLinks; }
            set { _chapterLinks = value; }
        }

        public List<string> ChapterNames
        {
            get { return _chapterNames; }
            set { _chapterNames = value; }
        }

        public string ChapterText
        {
            get { return _ChapterText; }
            set { _ChapterText = value; }
        }

        public int ChapterWordCount
        {
            get { return _ChapterWordCount; }
            set { _ChapterWordCount = value; }
        }

        public int CountOfChapters1
        {
            get { return CountOfChapters; }
            set { CountOfChapters = value; }
        }

        public string LastUpdated1
        {
            get { return LastUpdated; }
            set { LastUpdated = value; }
        }

        public string LinkAdditionInfo
        {
            get { return _LinkAdditionInfo; }
            set { _LinkAdditionInfo = value; }
        }

        public string StoryLink
        {
            get { return _StoryLink; }
            set { _StoryLink = value; }
        }

        public string StoryName
        {
            get { return msStoryName; }
            set { msStoryName = value; }
        }

        public string StoryStatus
        {
            get { return _StoryStatus; }
            set { _StoryStatus = value; }
        }

        public string Summary
        {
            get { return _Summary; }
            set { _Summary = value; }
        }

        public int TotalWordCount
        {
            get { return _TotalWordCount; }
            set { _TotalWordCount = value; }
        }

        public string WebsiteName
        {
            get { return msWebsiteName; }
            set { msWebsiteName = value; }
        }
        public cFic()
        {

        }
    }
}
