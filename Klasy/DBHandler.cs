﻿using System;
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
        public void Add_Ksiazka(Ksiazka ksiazka, Wydawnictwo wydawnictwo)
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
            command.Parameters.Add("@Nazwa", SqlDbType.VarChar).Value = wydawnictwo.nazwa;
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

        public void Add_Czytelnik(Czytelnik czytelnik)
        {
            SqlCommand command = connection.CreateCommand();
            command.Connection.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Czytelnik_Add";
            command.Parameters.Add("@Imie", SqlDbType.VarChar).Value = czytelnik.Imie;
            command.Parameters.Add("@Nazwisko", SqlDbType.VarChar).Value = czytelnik.Nazwisko;
            command.Parameters.Add("@Nr_telefonu", SqlDbType.VarChar).Value = czytelnik.Nr_telefonu;
            command.Parameters.Add("@Adres", SqlDbType.VarChar).Value = czytelnik.Adres;
            command.Parameters.Add("@PESEL", SqlDbType.VarChar).Value = czytelnik.PESEL;
            command.ExecuteNonQuery();
            command.Connection.Close();
        }
        public DataTable FillGrid_Czytelnicy()
        {
            SqlCommand command = connection.CreateCommand();
            command.Connection.Open();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM Czytelnicy";
            DataTable table = new DataTable("Czytelnicy");
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            command.Connection.Close();
            return table;
        }
        public void Delete_Czytelnik(int index)
        {
            SqlCommand command = connection.CreateCommand();
            command.Connection.Open();
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@Id", index);
            command.CommandText = "DELETE FROM Czytelnicy WHERE Id = @Id";
            command.ExecuteNonQuery();
            command.Connection.Close();
        }
        public List<string> cb_Pracownik()
        {
            List<string> Pracownik = new List<string>();
            DataTable pracownik = new DataTable("PESEL");
            SqlCommand command = connection.CreateCommand();
            command.Connection.Open();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT PESEL FROM Pracownicy";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(pracownik);
            command.Connection.Close();
            foreach (DataRow item in pracownik.Rows)
            {
                Pracownik.Add(item["PESEL"].ToString());
            }
            return Pracownik;

        }
        public List<string> cb_Czytelnik()
        {
            List<string> Czytelnik = new List<string>();
            DataTable czytelnik = new DataTable("PESEL");
            SqlCommand command = connection.CreateCommand();
            command.Connection.Open();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT PESEL FROM Czytelnicy";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(czytelnik);
            command.Connection.Close();
            foreach (DataRow item in czytelnik.Rows)
            {
                Czytelnik.Add(item["PESEL"].ToString());
            }
            return Czytelnik;
        }
        public List<string> cb_ISBN()
        {
            List<string> ISBN = new List<string>();
            DataTable ksiazka = new DataTable("ISBN");
            SqlCommand command = connection.CreateCommand();
            command.Connection.Open();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT Kod FROM Ksiazki";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ksiazka);
            command.Connection.Close();
            foreach (DataRow item in ksiazka.Rows)
            {
                ISBN.Add(item["Kod"].ToString());
            }
            return ISBN;
        }
        public void Add_Wydawca(Wydawnictwo wydawca)
        {

            SqlCommand command = connection.CreateCommand();
            command.Connection.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Wydawnictwo_Add";
            command.Parameters.Add("@Nazwa", SqlDbType.VarChar).Value = wydawca.nazwa;
            command.Parameters.Add("@Adres", SqlDbType.VarChar).Value = wydawca.adres;
            command.ExecuteNonQuery();
            command.Connection.Close();

        }
        public List<string> cb_Wydawcy()
        {
            List<string> Wydawcy = new List<string>();
            DataTable wydawcy = new DataTable("Nazwa");
            SqlCommand command = connection.CreateCommand();
            command.Connection.Open();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT Nazwa FROM Wydawnictwa";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(wydawcy);
            command.Connection.Close();
            foreach (DataRow item in wydawcy.Rows)
            {
                 Wydawcy.Add(item["Nazwa"].ToString());
            }
            return Wydawcy;
        }
        public void Delete_Ksiazka(int index,int ilosc)
        {
            SqlCommand command = connection.CreateCommand();
            command.Connection.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Delete_Ksiazka";
            command.Parameters.AddWithValue("@index", index);
            command.Parameters.AddWithValue("@ilosc_ksiazek", ilosc);
           command.ExecuteNonQuery();
            command.Connection.Close();
        }
        public void Delete_Wypozyczenie(int index)
        {
            SqlCommand command = connection.CreateCommand();
            command.Connection.Open();
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@Id", index);
            command.CommandText = "DELETE FROM Wypozyczenie WHERE Id = @Id";
            command.ExecuteNonQuery();
            command.Connection.Close();
        }
        public void Add_Wypozyczenie(Wypozyczenie wypozyczenie)
        {
            SqlCommand command = connection.CreateCommand();
            command.Connection.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Wypozyczenie_Add";
            command.Parameters.Add("@Kod", SqlDbType.VarChar).Value = wypozyczenie.ISBN;
            command.Parameters.Add("@PESELCzytelnika", SqlDbType.VarChar).Value = wypozyczenie.PESELCzytelnik;
            command.Parameters.Add("@PESELPracownika", SqlDbType.VarChar).Value = wypozyczenie.PESELPracownik;
            command.Parameters.Add("@OkresWypozyczenia", SqlDbType.VarChar).Value = wypozyczenie.Okres_wypozyczenie;
            command.ExecuteNonQuery();
            command.Connection.Close();
        }
        public DataTable FillGrid_Wypozyczenie()
        {
            SqlCommand command = connection.CreateCommand();
            command.Connection.Open();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM ViewWypozyczenia";
            DataTable table = new DataTable("Wypozyczenia");
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            command.Connection.Close();
            return table;
        }
        public List<int> cb_sztuki(int index)
        {
            List<int> Liczba_sztuk = new List<int>();
            DataTable ksiazki = new DataTable("Ilosc");
            SqlCommand command = connection.CreateCommand();
            command.Connection.Open();
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@index", SqlDbType.Int).Value = index;
            command.CommandText = "SELECT Ilosc FROM ViewKsiazki WHERE Id = @index";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ksiazki);
            command.Connection.Close();
            foreach (DataRow item in ksiazki.Rows)
            {
                Liczba_sztuk.Add((int)item["Ilosc"]);
            }
            return Liczba_sztuk;
        }
    }
}
