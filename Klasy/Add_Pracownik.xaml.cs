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
    /// Interaction logic for Add_Pracownik.xaml
    /// </summary>
    public partial class Add_Pracownik : Window
    {
        Spis_pracownikow pracownicy;
        DBHandler handler;
        public Add_Pracownik(Spis_pracownikow pracownik)
        {
            InitializeComponent();
            pracownicy = pracownik;
        }

        private void b_Zapisz_Click(object sender, RoutedEventArgs e)
        {
            handler = new DBHandler();
            Pracownik pracownik = new Pracownik(tbImie.Text, tbNazwisko.Text, tbPESEL.Text, tbTelefon.Text);
            handler.Add_Pracownik(pracownik);
            pracownicy.DataGrid_Fill();
        }
    }
}
