using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Books
    {
        

        public static DataSet GetAllBooks()
        {
            SqlConnection kon = new SqlConnection(Connection.kon);

            SqlCommand kom = new SqlCommand("GetAllBooks", kon);

            kom.CommandType = CommandType.StoredProcedure;

            kon.Open();

            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(kom);

            da.Fill(ds);

            ds.Tables[0].TableName = "book";

            kom.ExecuteNonQuery();

            kon.Close();

            return ds;
        }

        public static void DeleteBook(int id)
        {
            SqlConnection kon = new SqlConnection(Connection.kon);

            SqlCommand kom = new SqlCommand("DELETE FROM Knjiga WHERE ID_Knjige = @id", kon);

            kom.Parameters.AddWithValue("@id", id);

            kon.Open();

            kom.ExecuteNonQuery();

            kon.Close();
        }

        public static void SaveBook(int id, string name,string autor, int id_zanr)
        {
            SqlConnection kon = new SqlConnection(Connection.kon);

            kon.Open();
            SqlCommand kom = new SqlCommand("SaveBook", kon);
            kom.CommandType = CommandType.StoredProcedure;
            kom.Parameters.AddWithValue("@id", id);
            kom.Parameters.AddWithValue("@autor", autor);
            kom.Parameters.AddWithValue("@name", name);
            kom.Parameters.AddWithValue("@id_zanr", id_zanr);

         
            kom.ExecuteNonQuery();

            kon.Close();
        }

        public static DataSet getBookByID(int id)
        {
            SqlConnection kon = new SqlConnection(Connection.kon);

            SqlCommand kom = new SqlCommand("GetOneBook", kon);
            kom.Parameters.AddWithValue("@id", id);  
            kom.CommandType = CommandType.StoredProcedure;
            kon.Open();
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(kom);
            da.Fill(ds);
            ds.Tables[0].TableName = "book";
            kom.ExecuteNonQuery();
            kon.Close();

            return ds;

        }

        public static DataSet getAllZanrovi()
        {
            SqlConnection kon = new SqlConnection(Connection.kon);

            SqlCommand kom = new SqlCommand("SELECT * FROM Zanrovi", kon);

            kon.Open();

            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(kom);

            da.SelectCommand = kom;

            da.Fill(ds);
            ds.Tables[0].TableName = "zanr";
            kon.Close();

            return ds;
        }

        public static DataSet GetOneGenre(int id)
        {
            SqlConnection kon = new SqlConnection(Connection.kon);

            SqlCommand kom = new SqlCommand("GetOneGenre", kon);
            kom.Parameters.AddWithValue("@id", id);
            kom.CommandType = CommandType.StoredProcedure;
            kon.Open();
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(kom);
            da.Fill(ds);
            ds.Tables[0].TableName = "book";
            kom.ExecuteNonQuery();
            kon.Close();

            return ds;
        }
    }
}
