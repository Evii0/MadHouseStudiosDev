using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BibleReader.Components
{
    class Chapter
    {
        private List<Verse> verses = new List<Verse>();
        private int chapterNumber;
        private string book;

        /**
         * 
         * @param text
         * @param chapterNumber
         */
        public Chapter(string text, int chapterNumber, string book)
        {
            this.chapterNumber = chapterNumber;
            this.book = book;
            createVerses(text);
        }

        private void createVerses(string text)
        {
            Regex id = new Regex("(" + Convert.ToString(chapterNumber) + ":)\\d+");
            Match matcher = id.Match(text);
            int currentVerse = 1;
            int offSet = 0;
            //change variable name, also may not work because the psalms have more than 99 sections
            int chapteroff = (chapterNumber < 10) ? 0 : 1;
            if (chapterNumber > 99) chapteroff = 2;
            while (matcher.Success)
            {
                if (currentVerse < 10) offSet = 4 + chapteroff;
                else offSet = 5 + chapteroff;
                //There is a verse after this one
                Match temp = id.Match(text.Substring(offSet));
                if (temp.Success)
                {
                    string verse = text.Substring(offSet, (temp.Index));
                    text = text.Substring(verse.Length + offSet);
                    verses.Add(new Verse(verse, chapterNumber, currentVerse, book));
                }
                //this is the last verse of the chapter.
                else
                {
                    verses.Add(new Verse(text.Substring(offSet), chapterNumber, currentVerse, book));
                    text = text.Substring(text.Length - 2);
                }
                matcher = matcher.NextMatch();
                currentVerse++;
            }
        }

        public List<Verse> getVerses()
        {
            return verses;
        }

        override
        public string ToString()
        {
            StringBuilder s = new StringBuilder();
            string chap = Convert.ToString(chapterNumber);
            for (int i = 0; i < verses.Count; i++)
            {
                s.Append(chap + ":" + Convert.ToString(i + 1) + "  " + verses[i].getText() + "\n");
            }
            return s.ToString().Trim();
        }
    }
}
