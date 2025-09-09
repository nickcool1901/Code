using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BookAuthor
{
    public class DbContext
    {
        private string connStr = "Server=localhost;Database=BooksDB;Trusted_Connection=True;";

        public List<string> SearchBooks(string keyword)
        {
            var results = new List<string>();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                var cmd = new SqlCommand(@"
            SELECT B.Title, B.Year, A.Name AS Author, A.Country
            FROM Books B
            JOIN Authors A ON B.AuthorID = A.AuthorID
            WHERE 
                B.Title LIKE @kw OR 
                CAST(B.Year AS NVARCHAR) LIKE @kw OR
                A.Name LIKE @kw OR 
                A.Country LIKE @kw", conn);

                cmd.Parameters.AddWithValue("@kw", $"%{keyword}%");

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    results.Add($"{reader["Title"]} ({reader["Year"]}) — {reader["Author"]}, {reader["Country"]}");
                }
            }
            return results;
        }

        public SqlDataAdapter GetBooksAdapter(out DataTable dt)
        {
            var conn = new SqlConnection(connStr);
            var adapter = new SqlDataAdapter("SELECT * FROM Books", conn);

            var builder = new SqlCommandBuilder(adapter);
            dt = new DataTable();
            adapter.Fill(dt);

            return adapter;
        }

        public SqlDataAdapter GetAuthorsAdapter(out DataTable dt)
        {
            var conn = new SqlConnection(connStr);
            var adapter = new SqlDataAdapter("SELECT * FROM Authors", conn);

            var builder = new SqlCommandBuilder(adapter);
            dt = new DataTable();
            adapter.Fill(dt);

            return adapter;
        }

        public void DeleteAll() {
            var conn = new SqlConnection(connStr);
            conn.Open();

            var cmd = new SqlCommand(@"
        DELETE FROM Books;
        DELETE FROM Authors;
        DBCC CHECKIDENT ('Books', RESEED, 0);
        DBCC CHECKIDENT ('Authors', RESEED, 0);", conn);

            cmd.ExecuteNonQuery();
        }


        public void InsertTestData()
        {
            var conn = new SqlConnection(connStr);
            conn.Open();

            var checkCmd = new SqlCommand("SELECT COUNT(*) FROM Authors WHERE AuthorID IN (1,2,3)", conn);
            int count = (int)checkCmd.ExecuteScalar();

            if (count > 0)
            {
                MessageBox.Show("Testa dati jau eksistē!");
                return;
            }

            var cmd = new SqlCommand(@"
        SET IDENTITY_INSERT Authors ON;
        INSERT INTO Authors (AuthorID, Name, Country) VALUES 
        (1, 'Nikita Kulakovs', 'Latvija'),
        (2, 'nickcool1901', 'LV'),
        (3, 'NK', 'L@tvija');
        SET IDENTITY_INSERT Authors OFF;

        INSERT INTO Books (Title, Year, AuthorID) VALUES 
        ('2001', 2002, 1),
        ('Gads 2001', 2003, 2),
        ('Pilnie gadi', 2004, 3);", conn);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Testa dati pievienoti!");
        }

        public int Count(string table) {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var cmd = new SqlCommand($"SELECT COUNT(*) FROM {table}", conn);
                return (int)cmd.ExecuteScalar();
            }
        }

    }
}
