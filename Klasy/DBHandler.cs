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
        
        public DataTable FillGrid_Wydawcy()
        {
            SqlCommand command = connection.CreateCommand();
            command.Connection.Open();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM WYDAWNICTWA";
            DataTable table = new DataTable("Wydawnictwa");
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            command.Connection.Close();
            return table;
        }

        public void Delete_Wydawnictwo(int index)
        {
            SqlCommand command = connection.CreateCommand();
            command.Connection.Open();
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@Id", index);
            command.CommandText = "DELETE FROM WYDAWNICTWA WHERE Id = @Id";
            command.ExecuteNonQuery();
            command.Connection.Close();
        }
        public void Add_Ksiazka(Ksiazka ksiazka,Wydawnictwo wydawnictwo)
        {
            SqlCommand command = connection.CreateCommand();
            command.Connection.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Ksiazka_Add";
            command.Parameters.Add("@Tytul", SqlDbType.VarChar).Value = ksiazka.Tytul;
            command.Parameters.Add("@Autor", SqlDbType.VarChar).Value = ksiazka.Autor;
            command.Parameters.Add("@Kod", SqlDbType.VarChar).Value = ksiazka.Kod;
            command.Parameters.Add("@Data_wydania", SqlDbType.VarChar).Value = ksiazka.Data_wydania;
            command.Parameters.Add("@Cena", SqlDbType.Int).Value = ksiazka.Cena;
            command.Parameters.Add("@Ilosc", SqlDbType.Int).Value = ksiazka.Ilosc;
            command.Parameters.Add("@dostepnosc", SqlDbType.VarChar).Value = ksiazka.Dostepnosc;
            command.Parameters.Add("@Nazwa", SqlDbType.VarChar).Value = wydawnictwo.nazwa;
            command.Parameters.Add("@Adres", SqlDbType.VarChar).Value = wydawnictwo.adres;
            command.ExecuteNonQuery();
            command.Connection.Close();
        }
        public DataTable FillGrid_Ksiazki()
        {
            SqlCommand command = connection.CreateCommand();
            command.Connection.Open();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM ViewKsiazki";
            DataTable table = new DataTable("Ksiazki");
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            command.Connection.Close();
            return table;
        }

        
    }
}
