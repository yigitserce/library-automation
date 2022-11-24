using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_automation
{
    internal class Repository
    {
        string connecetion_string;
        SqlConnection connection;

        public Repository() 
        {
            connecetion_string = "Data Source = DESKTOP-IIUB1PA;Initial Catalog=library;Integrated Security=true";
            connection = new SqlConnection(connecetion_string);
        }

        public void Connect() 
        {
            connection.Open();
        }

        public void Disconnect()
        {
            connection.Close();
        }

        public List<BookDto> GetAll()
        {
            Connect();
            List<BookDto> books = new List<BookDto>();
            string query = "SELECT * FROM books";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                BookDto book = new BookDto(
                    (string)reader.GetValue(0),
                    (string)reader.GetValue(1),
                    (string)reader.GetValue(2),
                    (int)reader.GetValue(3),
                    (int)reader.GetValue(4)
                    );
                books.Add(book);
            }
            Disconnect();
            return books;
        }

        public bool AddBook(BookEntitiy book)
        {
            Connect();
            List<BookDto> bookByName = GetBookByName(book.Name);

            if (bookByName.Count == 0) 
            {
                string query = "INSERT INTO books (id, name, author, status, barrow_count) VALUES ('"
               + book.Name
               + "', '"
               + book.Author
               + "', '"
               + book.Status
               + "', "
               + book.BarrowCount + ")";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                Disconnect();
                return true;
            }

            Disconnect();
            return false;
            
        }

        public void DeleteBook()
        {
        }

        public void UpdateBook()
        {
        }

        public void ShowOnlyAvailables()
        {
        }

        public void SortByBarrowCount() 
        {
        }

        public List<BookDto> GetBookByName(string name) {
            Connect();
            List<BookDto> books = new List<BookDto>();
            try
            {
                string query = "SELECT * FROM books WHERE name='" + name + "'";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                BookDto book = new BookDto(
                    (string)reader.GetValue(0),
                    (string)reader.GetValue(1),
                    (string)reader.GetValue(2),
                    (int)reader.GetValue(3),
                    (int)reader.GetValue(4)
                    );
                books.Add(book);

                Disconnect();
                return books;
            }
            catch {
                Disconnect();
                return books;
            }
            
        }

    }
}
