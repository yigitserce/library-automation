using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_automation
{
    internal class BookDto
    {
        string _name;
        string _author;
        string _status;
        int _barrowCount;
        int _pageCount;

        public BookDto(string name, string author, string status, int barrow_count, int page_count) {
            _name = name;
            _author = author;
            _status = status;
            _barrowCount = barrow_count;
            _pageCount = page_count;
        }

        public string Name { get { return _name;} } 
        public string Author { get { return _author;} }
        public string Status { get { return _status;} }
        public int BarrowCount { get { return _barrowCount; } }
        public int PageCount { get { return _pageCount;} }
    }
}
