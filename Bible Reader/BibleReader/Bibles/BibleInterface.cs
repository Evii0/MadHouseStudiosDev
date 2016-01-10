using BibleReader.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibleReader.Bibles
{
    interface BibleInterface
    {
        bool readBible(string filename);

        Book getBook(int index);

        Book getBook(string name);

        List<Book> getBookRange();

        List<Book> getBookRange(List<string> bookNames);

        string getBookName(int index);

        List<KeyValuePair<Verse, int>> searchText(string text);

        void displayText(RichTextBox r, string book, int chapter);
    }
}
