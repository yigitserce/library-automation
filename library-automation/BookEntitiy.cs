using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_automation
{
    internal class BookEntitiy
    {
        string _name;
        string _author;
        string _status;
        int _barrowCount;
        int _pageCount;

        public BookEntitiy (string name, string author, int page_count) {
            _name = name;
            _author = author;
            _status = "Müsait";
            _barrowCount = 0;
            _pageCount = page_count;
        }

        public string Name { get; set; }
        public string Author { get; set; }
        public string Status { get; set; }
        public int BarrowCount { get; set; }
        public int PageCount { get; set; }
    }
}
