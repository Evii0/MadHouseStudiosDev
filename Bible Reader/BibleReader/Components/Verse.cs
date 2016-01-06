using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleReader.Components
{
    class Verse
    {
        private string text;
        private string book;
        private int chapterNumber;
        private int verseNumber;

        public Verse(string text, int chapterNumber, int verseNumber, string book)
        {
            this.text = text.Trim();
            this.book = book;
            this.chapterNumber = chapterNumber;
            this.verseNumber = verseNumber;
        }

        public string getText()
        {
            return text;
        }

        public string getBookName()
        {
            return book;
        }

        public int getChapterNumber()
        {
            return chapterNumber;
        }

        public int getVerseNumber()
        {
            return verseNumber;
        }
    }
}
