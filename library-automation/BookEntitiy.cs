using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_automation
{
    internal class BookEntitiy
    {
        readonly string name;
        readonly string author;
        readonly string status;
        readonly int barrowCount;
        readonly int pageCount;
        readonly string givenPerson;

        public BookEntitiy (string name, string author, int page_count) {
            this.name = name;
            this.author = author;
            this.status = "Müsait";
            this.barrowCount = 0;
            this.pageCount = page_count;
            this.givenPerson = "-";
        }

        public string getName() { 
            return name;
        }

        public string getAuthor()
        {
            return author;
        }

        public string getStatus() { 
            return status;
        }

        public int getBarrowCount() { 
            return barrowCount;
        }

        public int getPageCount() { 
            return pageCount;
        }

        public string getGivenPerson() { 
            return givenPerson;
        }
    }
}
