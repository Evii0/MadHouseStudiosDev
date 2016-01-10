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
        private Dictionary<string, string> bibleFiles = new Dictionary<string, string>();
        private int currentStartSelectIndex = 0;
        private int currentEndSelectIndex = 0;
        private int currentStartVerse = 0;
        private int currentEndVerse = 0;

        private bool chapterNumbersClicked = false;

        //may or may not use this to store different bibles, fine if only a few bible versions, not so much if there are 40+...
        private Dictionary<string, BibleInterface> bibles = new Dictionary<string, BibleInterface>();

        public Form1()
        {
            InitializeComponent();
            startup();
        }

        private void startup()
        {
            //TODO: read in from file previous settings, bible options and things
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\alexanpe\Documents\MadHouseStudiosDev\Bible Reader\BibleReader\settings.txt");
            string line = "";
            while ((line = file.ReadLine()) != null)
            {
                string[] temp = line.Split('=');
                if (temp[0] == "bibles")
                {
                    string[] bibleList = temp[1].Split(';');
                    foreach(string s in bibleList)
                    {
                        string[] currentBible = s.Split(',');
                        bibleFiles.Add(currentBible[0], currentBible[1]);
                        bibles.Add(currentBible[0], readBible(currentBible[0], currentBible[1]));
                    }
                }
                else if (temp[0] == "bible") b = bibles[temp[1]];
                else if (temp[0] == "place")
                {
                    string[] verse = temp[1].Split(',');
                    booksOfBibleListBox.SelectedIndex = Convert.ToInt32(verse[0]);
                    chapterNumbersListBox.SelectedIndex = Convert.ToInt32(verse[1]);
                }
            }
            booksOfBibleListBox.SelectedIndex = 0;
            b.displayText(richTextBox1, booksOfBibleListBox.Text, chapterNumbersListBox.SelectedIndex + 1);
        }

        private BibleInterface readBible(string name, string filePath)
        {
            BibleInterface b1 = null;
            switch (name)
            {
                case "King James Version (KJV)":
                    Console.WriteLine("normal");
                    b1 = new KJV();
                    b1.readBible(filePath);
                    break;
                case "King James Version (KJV) - With Strongs' numbers":
                    Console.WriteLine("strongs");
                    b1 = new KJVStrongs();
                    b1.readBible(filePath);
                    break;
            }
            return b1;
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
            if (chapterNumbersClicked)
            {
                b.displayText(richTextBox1, booksOfBibleListBox.Text, chapterNumbersListBox.SelectedIndex + 1);
                chapterNumbersClicked = false;
            }
        }

        private void searchTextBox_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void selectVerse(int verse)
        {

        }

        private void displaySearchResults(List<KeyValuePair<Verse, int>> res)
        {
            searchResultsPanel.Controls.Clear();
            searchResultsPanel.Visible = true;
            int count = 0;
            foreach (KeyValuePair<Verse, int> pair in res)
            {
                if (count > 25) break;
                RichTextBox temp = new RichTextBox();
                searchResultsPanel.Controls.Add(temp);
                temp.Height = 57;
                temp.Width = 327;
                temp.Location = new Point(4, ((count) * 61) + 6);
                temp.Text = pair.Key.getBookName() + " " + pair.Key.getChapterNumber() + ":" + pair.Key.getVerseNumber() + "  " + pair.Key.getText();
                temp.Cursor = Cursors.Hand;
                temp.Click += new EventHandler(searchResult_Click);
                count++;
            }
            Panel moreResultsPanel = new Panel();
            moreResultsPanel.Width = 336;
            moreResultsPanel.Height = 30;
            moreResultsPanel.Location = new Point(-1, ((count) * 61) + 6);
            moreResultsPanel.BackColor = Color.DarkGray;
            moreResultsPanel.Controls.Add(moreResultsLabel);
            moreResultsPanel.Cursor = Cursors.Hand;
            moreResultsPanel.Click += new EventHandler(moreResults_Click);
            
            moreResultsLabel.Location = new Point(120, 5);
            moreResultsLabel.Font = new Font(new FontFamily("Calibri"), 11, FontStyle.Regular);
            moreResultsLabel.ForeColor = Color.White;
            moreResultsLabel.Cursor = Cursors.Hand;
            moreResultsLabel.Click += new EventHandler(moreResults_Click);
            moreResultsLabel.Visible = true;

            searchResultsPanel.Controls.Add(moreResultsPanel);
        }

        /// <summary>
        /// opens new window with full search results
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void moreResults_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            displaySearchResults(b.searchText(searchTextBox.Text));
        }     

        private void searchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') {
                displaySearchResults(b.searchText(searchTextBox.Text));
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

        private void searchResult_Click(object sender, EventArgs e)
        {
            RichTextBox temp = sender as RichTextBox;
            string[] mainSplit = temp.Text.Split(' ');
            string[] chapterVerse = mainSplit[1].Split(':');
            booksOfBibleListBox.SelectedIndex = getBookNumber(mainSplit[0]);
            chapterNumbersListBox.SelectedIndex = Convert.ToInt32(chapterVerse[0]) - 1;
            searchResultsPanel.Visible = false;
        }

        private int getBookNumber(string name)
        {
            int count = 0;
            foreach(Book bo in b.getBookRange())
            {
                if (bo.getName() == name) return count;
                count++;
            }
            return -1;
        }

        private void bibleListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            b = bibles[bibleListComboBox.Text];
            richTextBox1.Text = b.getBook(booksOfBibleListBox.SelectedIndex).getChapter(chapterNumbersListBox.SelectedIndex + 1).toString();
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            searchResultsPanel.Visible = false;
        }

        private void chapterNumbersListBox_Click(object sender, EventArgs e)
        {
            searchResultsPanel.Visible = false;
            chapterNumbersClicked = true;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            searchResultsPanel.Visible = false;
        }
    }
}
