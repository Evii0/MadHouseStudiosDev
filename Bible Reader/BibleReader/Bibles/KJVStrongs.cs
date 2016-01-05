using BibleReader.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleReader.Bibles
{
    class KJVStrongs : Bible
    {
        private List<String> bookNames = new List<String>();
        private List<Book> booksOfTheBible = new List<Book>();

        public bool readBible(string filename)
            {
                try
                {
                    System.IO.StreamReader br = new System.IO.StreamReader(filename);
                    String line = "";
                    StringBuilder currentBook = new StringBuilder();
                    String currentBookID = "Gen";
                    int currentIndex = 0;

                    while ((line = br.ReadLine()) != null)
                    {
                        if (line.Split(' ')[0].CompareTo(currentBookID) == 0) currentBook.Append(" " + line.Substring(4));
                        else
                        {
                            currentBookID = line.Split(' ')[0];
                            //System.out.println(currentBookID);
                            booksOfTheBible.Add(new Book(getBookName(currentIndex + 1), currentBook.ToString()));
                            currentBook = new StringBuilder();
                            currentIndex++;
                            bookNames.Add(getBookName(currentIndex));
                        }
                    }
                    booksOfTheBible.Add(new Book(getBookName(currentIndex + 1), currentBook.ToString()));
                    bookNames.Add(getBookName(currentIndex));
                    Console.WriteLine("Size: " + booksOfTheBible[booksOfTheBible.Count - 1]);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
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
