using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_automation
{
    internal class BookDto
    {
        string name;
        string author;
        string status;
        int barrowCount;
        int pageCount;
        string givenPerson;

        public BookDto() {}

        public string getName() 
        { 
            return name;
        }

        public string getAuthor() {
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

        public void setName(string name) {
            this.name = name;
        }

        public void setAuthor(string author) {
            this.author = author;
        }

        public void setStatus(string status) {
            this.status = status;
        }

        public void setBarrowCount(int barrowCount) { 
            this.barrowCount = barrowCount;
        }

        public void setPageCount(int pageCount) {
            this.pageCount = pageCount;
        }

        public void setGivenPerson(string givenPerson) { 
            this.givenPerson = givenPerson;
        }
    }
}
