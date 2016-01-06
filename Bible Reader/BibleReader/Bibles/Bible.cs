using BibleReader.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleReader.Bibles
{
    interface Bible
    {
        bool readBible(string filename);

        Book getBook(int index);

        Book getBook(string name);

        List<Book> getBookRange();

        List<Book> getBookRange(List<string> bookNames);

        string getBookName(int index);

    }
}
