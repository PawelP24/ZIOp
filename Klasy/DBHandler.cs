using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_biblioteczny
{
    public class DBHandler
    {
        private string connectionString;
        SqlConnection connection;
        public DBHandler()
        {
            connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Biblioteka; Integrated Security = True; Pooling = False";
            connection = new SqlConnection(connectionString);
        }

        public void Add_Pracownik(Pracownik pracownik)
        {
            SqlCommand command = connection.CreateCommand();
            command.Connection.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Pracownik_Add";
            command.Parameters.Add("@Imie", SqlDbType.VarChar).Value = pracownik.imie;
            command.Parameters.Add("@Nazwisko", SqlDbType.VarChar).Value = pracownik.nazwisko;
            command.Parameters.Add("@PESEL", SqlDbType.VarChar).Value = pracownik.PESEL;
            command.Parameters.Add("@Nr_telefonu", SqlDbType.VarChar).Value = pracownik.Nr_telefonu;
            command.ExecuteNonQuery();
            command.Connection.Close();
            
        }

        public DataTable FillGrid_Pracownicy()
        {
            SqlCommand command = connection.CreateCommand();
            command.Connection.Open();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM PRACOWNICY";
            DataTable table = new DataTable("Pracownicy");
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            command.Connection.Close();
            return table;
        }

        public void Delete_Pracownik(int index)
        {
            SqlCommand command = connection.CreateCommand();
            command.Connection.Open();
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@Id", index);
            command.CommandText = "DELETE FROM PRACOWNICY WHERE Id = @Id";
            command.ExecuteNonQuery();
            command.Connection.Close();
        }
        
    }
}
