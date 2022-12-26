using System.Data.SqlClient;

namespace library_automation
{
    internal class CreateSP
    {
        private string buildQuery(string name, string variables, string query) {
            return "CREATE PROC"+ name + "(" + variables +") AS BEGIN" + query + "END";
        }

        public bool createAddBookSP(SqlConnection connection) 
        {
            string name = "add_book";
            string variables = @"
                @Name varchar(255),
	            @Author varchar(255),
	            @Status varchar(255),
	            @BarrowCount int,
	            @PageCount int";
            string query = @"
                INSERT INTO books (name, author, status, barrow_count, page_count)
	            VALUES (@Name, @Author, @Status, @BarrowCount, @PageCount)";

            string procQuery = buildQuery(name, variables, query);

            SqlCommand cmd = new SqlCommand(procQuery, connection);
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            cmd.Connection.Close();
            return true;
        }

        public bool createUpadteBookSP(SqlConnection connection)
        {
            string name = "update_book";
            string variables = @"
                @OldName varchar(255),
	            @Name varchar(255),
	            @Author varchar(255),
	            @Status varchar(255),
	            @PageCount int";
            string query = @"
                UPDATE books
                SET name=@Name, author=@Author, status=@Status, page_count=@PageCount 
                WHERE name = @OldName";

            string procQuery = buildQuery(name, variables, query);

            SqlCommand cmd = new SqlCommand(procQuery, connection);
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            cmd.Connection.Close();
            return true;
        }
    }
}
