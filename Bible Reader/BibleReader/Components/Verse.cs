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

        private int chapterNumber;
        private int verseNumber;

        public Verse(string text, int chapterNumber, int verseNumber)
        {
            this.text = text.Trim();
            this.chapterNumber = chapterNumber;
            this.verseNumber = verseNumber;
        }

        public string getText()
        {
            return text;
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
