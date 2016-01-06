using BibleReader.Bibles;
using BibleReader.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibleReader
{
    public partial class Form1 : Form
    {

        private BibleInterface b;
        private int currentStartSelectIndex = 0;
        private int currentEndSelectIndex = 0;
        private int currentStartVerse = 0;
        private int currentEndVerse = 0;

        public Form1()
        {
            InitializeComponent();
            
            b = new KJV();
            b.readBible(@"c:\users\alexanpe\documents\visual studio 2015\Projects\BibleReader\BibleReader\BibleTextDocuments\kjv.txt");
            startup();
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

        

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<Verse, int> pair in b.searchText(searchTextBox.Text))
            {
                Console.WriteLine(pair.Key.getBookName() + " " + pair.Key.getChapterNumber() + ":" + pair.Key.getVerseNumber() + "  " + pair.Key.getText());
            }
        }     

        private void searchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') {
                foreach (KeyValuePair<Verse, int> pair in b.searchText(searchTextBox.Text))
                {
                    Console.WriteLine(pair.Key.getBookName() + " " + pair.Key.getChapterNumber() + ":" + pair.Key.getVerseNumber() + "  " + pair.Key.getText());
                }
                e.Handled = true;
            }
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            //start index has changed
            if (richTextBox1.SelectionStart != currentStartSelectIndex)
            {
                currentStartSelectIndex = richTextBox1.SelectionStart;
                currentStartVerse = getCurrentVerse(currentStartSelectIndex);
                Console.WriteLine("Starting verse: " + currentStartVerse);
            }

            //end index has changed but is the same as the start index
            if (richTextBox1.SelectionLength == 0) { currentEndSelectIndex = currentStartSelectIndex; currentEndVerse = currentStartVerse; Console.WriteLine("Ending verse: " + currentEndVerse); }

            //end index has changed and is different
            else if ((richTextBox1.SelectionStart + richTextBox1.SelectionLength) != currentEndSelectIndex)
            {
                currentEndSelectIndex = richTextBox1.SelectionStart + richTextBox1.SelectionLength;
                currentEndVerse = getCurrentVerse(currentEndSelectIndex);
                Console.WriteLine("Ending verse: " + currentEndVerse);
            }
        }

        /// <summary>
        /// gets the verse that contains the given index.
        /// </summary>
        /// <param name="index">index selected in the rich text box</param>
        /// <returns>an int denoting the verse selected</returns>
        private int getCurrentVerse(int index)
        {
            int indexOfVerse = Regex.Match(richTextBox1.Text.Substring(0, richTextBox1.SelectionStart), "(" + chapterNumbersListBox.SelectedItem + ":)\\d+", RegexOptions.RightToLeft).Index;
            string[] temp = richTextBox1.Text.Substring(indexOfVerse, 10).Split(' ');
            int currentVerse = Convert.ToInt32(temp[0].Split(':')[1]);

            //get current line
            int line = richTextBox1.GetLineFromCharIndex(index);

            // Get current column.
            int firstChar = richTextBox1.GetFirstCharIndexFromLine(line);
            if (index - firstChar < 3) currentVerse++;

            return currentVerse;
        }
    }
}
