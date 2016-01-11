using BibleReader.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibleReader.Bibles
{
    class KJVStrongs : BibleInterface
    {
        private List<string> bookNames = new List<string>();
        private List<Book> booksOfTheBible = new List<Book>();

        public bool readBible(string filename)
            {
            try
                {
                    System.IO.StreamReader br = new System.IO.StreamReader(filename);
                    string line = "";
                    StringBuilder currentBook = new StringBuilder();
                    string currentBookID = "Gen";
                    int currentIndex = 0;

                    while ((line = br.ReadLine()) != null)
                    {
                        if (line.Substring(0,3).CompareTo(currentBookID) == 0) currentBook.Append(" " + line.Substring(4));
                        else
                        {
                            currentBookID = line.Split(' ')[0];
                            booksOfTheBible.Add(new Book(getBookName(currentIndex + 1), currentBook.ToString()));    
                            currentIndex++;
                            bookNames.Add(getBookName(currentIndex));
                            currentBook = new StringBuilder();
                            currentBook.Append(" " + line.Substring(4));
                    }
                    }
                    booksOfTheBible.Add(new Book(getBookName(currentIndex + 1), currentBook.ToString()));
                    bookNames.Add(getBookName(currentIndex));
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }

        public void displayText(RichTextBox r, int book, int chapter)
        {
            string text = getBook(book).getChapter(chapter).ToString();
            string regex = "(";
            if (book < 40) regex += "H";
            else regex += "G";
            regex += ")\\d+";

            Regex id = new Regex(regex);
            Match matcher = id.Match(text);

            r.Text = text;
            while (matcher.Success)
            {            
                r.Select(matcher.Index, matcher.Length);
                r.SelectionFont = new System.Drawing.Font("Calibri", 8);
                r.SelectionColor = System.Drawing.Color.LightSeaGreen;
                matcher = matcher.NextMatch();
            }
        }

        public List<KeyValuePair<Verse, int>> searchText(string text)
        {
            List<KeyValuePair<Verse, int>> results = new List<KeyValuePair<Verse, int>>();
            foreach (Book book in booksOfTheBible)
            {
                foreach (Chapter c in book.getChapters())
                {
                    foreach (Verse v in c.getVerses())
                    {
                        List<int> res = wordSearch(v.getText().ToLower().ToCharArray(), text.ToLower().ToCharArray());
                        for (int i = 0; i < res.Count; i++)
                        {
                            results.Add(new KeyValuePair<Verse, int>(v, res[i]));
                        }
                    }
                }
            }
            return results;
        }

        private List<int> wordSearch(char[] haystack, char[] needle)
        {
            List<int> results = new List<int>();

            if (needle.Length == 0)
            {
                return null;
            }
            int[] charTable = makeCharTable(needle);
            int[] offsetTable = makeOffsetTable(needle);
            for (int i = needle.Length - 1, j; i < haystack.Length;)
            {
                for (j = needle.Length - 1; needle[j] == haystack[i]; --i, --j)
                {
                    if (j == 0)
                    {
                        results.Add(i);
                        break;
                    }
                }
                i += Math.Max(offsetTable[needle.Length - 1 - j], charTable[haystack[i]]);
            }
            return results;
        }

        /**
        * Makes the jump table based on the mismatched character information.
        */
        private static int[] makeCharTable(char[] needle)
        {
            int ALPHABET_SIZE = 256;
            int[] table = new int[ALPHABET_SIZE];
            for (int i = 0; i < table.Length; ++i)
            {
                table[i] = needle.Length;
            }
            for (int i = 0; i < needle.Length - 1; ++i)
            {
                table[needle[i]] = needle.Length - 1 - i;
            }
            return table;
        }

        /**
         * Makes the jump table based on the scan offset which mismatch occurs.
         */
        private static int[] makeOffsetTable(char[] needle)
        {
            int[] table = new int[needle.Length];
            int lastPrefixPosition = needle.Length;
            for (int i = needle.Length - 1; i >= 0; --i)
            {
                if (isPrefix(needle, i + 1))
                {
                    lastPrefixPosition = i + 1;
                }
                table[needle.Length - 1 - i] = lastPrefixPosition - i + needle.Length - 1;
            }
            for (int i = 0; i < needle.Length - 1; ++i)
            {
                int slen = suffixLength(needle, i);
                table[slen] = needle.Length - 1 - i + slen;
            }
            return table;
        }

        /**
         * Is needle[p:end] a prefix of needle?
         */
        private static bool isPrefix(char[] needle, int p)
        {
            for (int i = p, j = 0; i < needle.Length; ++i, ++j)
            {
                if (needle[i] != needle[j])
                {
                    return false;
                }
            }
            return true;
        }

        /**
         * Returns the maximum Length of the substring ends at p and is a suffix.
         */
        private static int suffixLength(char[] needle, int p)
        {
            int len = 0;
            for (int i = p, j = needle.Length - 1;
                     i >= 0 && needle[i] == needle[j]; --i, --j)
            {
                len += 1;
            }
            return len;
        }

        public Book getBook(int index)
            {
                try
                {
                    return booksOfTheBible[index];
                }
                catch (Exception e)
                {
                    return null;
                }
            }

            public Book getBook(String name)
            {
                try
                {
                    return booksOfTheBible[bookNames.IndexOf(name)];
                }
                catch (Exception e)
                {
                    return null;
                }
            }

            public List<Book> getBookRange()
            {
                return booksOfTheBible;
            }

            public List<Book> getBookRange(List<String> bookNames)
            {
                List<Book> bookList = new List<Book>();
                foreach (string s in bookNames)
                {
                    bookList.Add(getBook(s));
                }
                return bookList;
            }

        public String getBookName(int index)
        {
            switch (index)
            {
                case 1: return "Genesis";
                case 2: return "Exodus";
                case 3: return "Leviticus";
                case 4: return "Numbers";
                case 5: return "Deuteronomy";
                case 6: return "Joshua ";
                case 7: return "Judges";
                case 8: return "Ruth";
                case 9: return "1 Samuel";
                case 10: return "2 Samuel";
                case 11: return "1 Kings";
                case 12: return "2 Kings";
                case 13: return "1 Chronicles";
                case 14: return "2 Chronicles";
                case 15: return "Ezra";
                case 16: return "Nehemiah";
                case 17: return "Esther";
                case 18: return "Job";
                case 19: return "Psalms";
                case 20: return "Proverbs";
                case 21: return "Ecclesiastes";
                case 22: return "Song of Solomon";
                case 23: return "Isaiah";
                case 24: return "Jeremiah";
                case 25: return "Lamentations";
                case 26: return "Ezekiel";
                case 27: return "Daniel";
                case 28: return "Hosea";
                case 29: return "Joel";
                case 30: return "Amos";
                case 31: return "Obadiah";
                case 32: return "Jonah";
                case 33: return "Micah";
                case 34: return "Nahum";
                case 35: return "Habakkuk";
                case 36: return "Zephaniah";
                case 37: return "Haggai";
                case 38: return "Zechariah";
                case 39: return "Malachi";
                case 40: return "Matthew";
                case 41: return "Mark";
                case 42: return "Luke";
                case 43: return "John";
                case 44: return "Acts";
                case 45: return "Romans";
                case 46: return "1 Corinthians";
                case 47: return "2 Corinthians";
                case 48: return "Galatians";
                case 49: return "Ephesians";
                case 50: return "Philippians";
                case 51: return "Colossians";
                case 52: return "1 Thessalonians";
                case 53: return "2 Thessalonians";
                case 54: return "1 Timothy";
                case 55: return "2 Timothy";
                case 56: return "Titus";
                case 57: return "Philemon";
                case 58: return "Hebrews";
                case 59: return "James";
                case 60: return "1 Peter";
                case 61: return "2 Peter";
                case 62: return "1 John";
                case 63: return "2 John";
                case 64: return "3 John";
                case 65: return "Jude";
                case 66: return "Revelation";
            }
            return "Error";
        }
    }
}
