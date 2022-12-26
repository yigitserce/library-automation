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
            //MultipleActiveResultSets=true;
            connecetion_string = "Data Source = localhost;Initial Catalog=library;Integrated Security=true;User Id=sa;Password=1;";
            connection = new SqlConnection(connecetion_string);
        }

        public void Connect() 
        {
            connection.Open();
        }

        public async void Disconnect()
        {
            await connection.CloseAsync();
        }

        public List<BookDto> GetAll()
        {
            List<BookDto> books = new List<BookDto>();
            string query = "SELECT * FROM books";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                BookDto book = new BookDto();
                book.setName((string)reader.GetValue(0));
                book.setAuthor((string)reader.GetValue(1));
                book.setStatus((string)reader.GetValue(2));
                book.setBarrowCount((int)reader.GetValue(3));
                book.setPageCount((int)reader.GetValue(4));
                book.setGivenPerson((string)reader.GetValue(5));
                books.Add(book);
            }
            cmd.Connection.Close();
            return books;
        }

        public bool AddBook(BookEntitiy book)
        {
            BookDto bookByName = GetBookByName(book.getName());
            if (bookByName.getName() == null) 
            {
                string query = "EXEC add_book "
                    + "'" + book.getName() + "',"
                    + "'" + book.getAuthor() + "',"
                    + "'" + book.getStatus() + "',"
                    + "" + book.getBarrowCount() + ","
                    + "'-',"
                    + "" + book.getPageCount() + "";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return true;
            }

            return false;
            
        }

        public bool DeleteBook(string name)
        {
            string query = "DELETE FROM books WHERE name='" + name + "'";
            SqlCommand cmd = new SqlCommand(query, connection);
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return true;
            }
            catch {
                return false;
            }
        }

        public bool UpdateBook()
        {
            //string query = "EXEC update_book "
            //    + "'" + book.getName() + "',"
            //    + "'" + book.getAuthor() + "',"
            //    + "'" + book.getStatus() + "',"
            //    + "" + book.getBarrowCount() + ","
            //    + "'-',"
            //    + "" + book.getPageCount() + "";
            string query = "";
            SqlCommand cmd = new SqlCommand(query, connection);
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void ShowOnlyAvailables()
        {
        }

        public void SortByBarrowCount() 
        {
        }

        public BookDto GetBookByName(string name) {
            BookDto book = new BookDto();
            string query = "SELECT * FROM books WHERE name='" + name + "'";
            SqlCommand cmd = new SqlCommand(query, connection);
            try
            {
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                book.setName((string)reader.GetValue(0));
                cmd.Connection.Close();
                return book;
            }
            catch {
                cmd.Connection.Close();
                return book;
            }
        }

    }
}
