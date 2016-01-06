using BibleReader.Bibles;
using BibleReader.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibleReader
{
    public partial class Form1 : Form
    {

        private Bible b;
        public Form1()
        {
            InitializeComponent();
            
            b = new KJV();
            b.readBible(@"c:\users\alexanpe\documents\visual studio 2015\Projects\BibleReader\BibleReader\BibleTextDocuments\kjv.txt");
            startup();
            
            //richTextBox1.Text =  b.getBook("Psalms").toString();
        }

        
        private void startup()
        {
            //read in from file previous settings and things
            booksOfBibleListBox.SelectedIndex = 0;
        }

        private void booksOfBibleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] chapterNumList = new string[b.getBook(booksOfBibleListBox.SelectedIndex).getNumChapters()];
            for(int i = 1; i <= b.getBook(booksOfBibleListBox.SelectedIndex).getNumChapters(); i++)
            {
                chapterNumList[i - 1] = Convert.ToString(i);
            }
            chapterNumbersListBox.DataSource = chapterNumList;
        }

        private void chapterNumbersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = b.getBook(booksOfBibleListBox.SelectedIndex).getChapter(chapterNumbersListBox.SelectedIndex + 1).toString();
        }

        private void searchTextBox_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchText()
        {
            List<KeyValuePair<Verse, int>> results = new List<KeyValuePair<Verse, int>>();
            foreach (Book book in b.getBookRange())
            {
                foreach (Chapter c in book.getChapters())
                {
                    foreach (Verse v in c.getVerses())
                    {
                        List<int> res = wordSearch(v.getText().ToLower().ToCharArray(), searchTextBox.Text.ToLower().ToCharArray());
                        for (int i = 0; i < res.Count; i++)
                        {
                            results.Add(new KeyValuePair<Verse, int>(v, res[i]));
                        }
                    }
                }
            }
            foreach (KeyValuePair<Verse, int> pair in results)
            {
                Console.WriteLine(pair.Key.getBookName() + " " + pair.Key.getChapterNumber() + ":" + pair.Key.getVerseNumber() + "  " + pair.Key.getText());
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            searchText();
        }

        

        private void searchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') { searchText(); e.Handled = true; }
        }
    }
}
