using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace System_biblioteczny
{
    /// <summary>
    /// Interaction logic for Add_Czytelnik.xaml
    /// </summary>
    public partial class Add_Czytelnik : Window
    {
        Spis_czytelnikow parentWindow;
        public Add_Czytelnik(Spis_czytelnikow spis)
        {
            InitializeComponent();
            parentWindow = spis;
        }

        private void B_Dodaj_Click(object sender, RoutedEventArgs e)
        {
            Czytelnik czytelnik = new Czytelnik();
            czytelnik.Imie = tbImie.Text;
            czytelnik.Nazwisko = tbNazwisko.Text;
            czytelnik.Nr_telefonu = tbTelefon.Text;
            czytelnik.Adres = tbAdres.Text;
            czytelnik.PESEL = tbPESEL.Text;
            DBHandler handler = new DBHandler();
            handler.Add_Czytelnik(czytelnik);
            parentWindow.Fill_Grid();
        }
    }
}
