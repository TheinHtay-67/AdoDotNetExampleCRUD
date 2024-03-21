using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNetExampleCRUD.AdoDotNetExamples
{
    public class AdoDotNetExample
    {
        public void Read()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuillder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuillder.DataSource = ".";
            sqlConnectionStringBuillder.InitialCatalog = "AdoDotNetExampleCRUD";
            sqlConnectionStringBuillder.UserID = "sa";
            sqlConnectionStringBuillder.Password = "r00tp@ss";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuillder.ConnectionString);
            connection.Open();

            var query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
  FROM [dbo].[tbl_Blog]";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("BlogTitle : " + dr["BlogTitle"]);
                Console.WriteLine("BlogAuthor : " + dr["BlogAuthor"]);
                Console.WriteLine("BlogContent : " + dr["BlogContent"]);
            }
        }

        public void Edit(int id)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuillder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuillder.DataSource = ".";
            sqlConnectionStringBuillder.InitialCatalog = "AdoDotNetExampleCRUD";
            sqlConnectionStringBuillder.UserID = "sa";
            sqlConnectionStringBuillder.Password = "r00tp@ss";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuillder.ConnectionString);
            connection.Open();

            var query = @"SELECT [BlogId]
                              ,[BlogTitle]
                              ,[BlogAuthor]
                              ,[BlogContent]
                          FROM [dbo].[tbl_Blog] where BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No data found");
                return;
            }

            DataRow dr = dt.Rows[0];
            Console.WriteLine("BlogTitle : " + dr["BlogTitle"]);
            Console.WriteLine("BlogAuthor : " + dr["BlogAuthor"]);
            Console.WriteLine("BlogContent : " + dr["BlogContent"]);
        }

        public void Create(string title, string author, string content)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuillder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuillder.DataSource = ".";
            sqlConnectionStringBuillder.InitialCatalog = "AdoDotNetExampleCRUD";
            sqlConnectionStringBuillder.UserID = "sa";
            sqlConnectionStringBuillder.Password = "r00tp@ss";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuillder.ConnectionString);
            connection.Open();

            var query = @"INSERT INTO [dbo].[tbl_Blog]
                               ([BlogTitle]
                               ,[BlogAuthor]
                               ,[BlogContent])
                         VALUES
                               (@BlogTitle
                               ,@BlogAuthor
                               ,@BlogContent)";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            var result = cmd.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Saving successful." : "Saving failed.";
            Console.WriteLine(message);
        }

        public void Update(int id, string title, string author, string content)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuillder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuillder.DataSource = ".";
            sqlConnectionStringBuillder.InitialCatalog = "AdoDotNetExampleCRUD";
            sqlConnectionStringBuillder.UserID = "sa";
            sqlConnectionStringBuillder.Password = "r00tp@ss";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuillder.ConnectionString);
            connection.Open();

            var query = @"UPDATE [dbo].[tbl_Blog]
                           SET [BlogTitle] = @BlogTitle
                              ,[BlogAuthor] = @BlogAuthor
                              ,[BlogContent] = @BlogContent
                         WHERE BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            var result = cmd.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Update successful." : "Update failed.";
            Console.WriteLine(message);
        }

        public void Delete(int id)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuillder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuillder.DataSource = ".";
            sqlConnectionStringBuillder.InitialCatalog = "AdoDotNetExampleCRUD";
            sqlConnectionStringBuillder.UserID = "sa";
            sqlConnectionStringBuillder.Password = "r00tp@ss";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuillder.ConnectionString);
            connection.Open();

            var query = @"DELETE From [dbo].[tbl_Blog]
                         WHERE BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            var result = cmd.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Delete successful." : "Delete failed.";
            Console.WriteLine(message);
        }
    }
}
