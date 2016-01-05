using BibleReader.Bibles;
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
            Console.WriteLine("'" + richTextBox1.Text.Trim() + "'");
        }
    }
}
