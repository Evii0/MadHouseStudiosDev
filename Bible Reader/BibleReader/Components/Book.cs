using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleReader.Components
{
    class Book
    {
        private string name = "";
        private List<Chapter> chapters = new List<Chapter>();

        public Book(string name, string text)
        {
            this.name = name;
            createChapters(text);
        }

        private void createChapters(string text)
        {
            int currentChapter = 1;
            string currentChapterstring = "1:1";
            while (text.IndexOf(currentChapterstring) != -1)
            {
                string nextChapter = Convert.ToString((currentChapter + 1)) + ":1";
                //there is another chapter after this one
                if (text.IndexOf(nextChapter) != -1)
                {
                    chapters.Add(new Chapter(text.Substring(0, text.IndexOf(nextChapter)), currentChapter, name));
                    text = text.Substring(text.IndexOf(nextChapter));
                }
                //this is the last chapter
                else
                {
                    chapters.Add(new Chapter(text, currentChapter, name));
                    text = "";
                }
                currentChapterstring = nextChapter;
                currentChapter++;
            }
        }

        public List<Chapter> getChapters()
        {
            return chapters;
        }

        public int getNumChapters()
        {
            return chapters.Count;
        }

        public Chapter getChapter(int chapterNum)
        {
            return chapters[chapterNum - 1];
        }

        public string getName()
        {
            return name;
        }

        public string toString()
        {
            string t = "";
            for (int i = 0; i < chapters.Count; i++)
            {
                t += chapters[i].toString() + "\n\n";
            }
            return t;
        }
    }
}
