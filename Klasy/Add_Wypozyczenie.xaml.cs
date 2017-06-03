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
    /// Interaction logic for Add_Wypozyczenie.xaml
    /// </summary>
    public partial class Add_Wypozyczenie : Window
    {
        List<int> dni;
        List<string> PESELczytelnika;
        List<string> PESELpracownika;
        List<string> ISBN;
        Rejestr_wypozyczen parentWindow;
        public Add_Wypozyczenie(Rejestr_wypozyczen wypozyczenia)
        {
            InitializeComponent();
            parentWindow = wypozyczenia;
            Fill_cb_Dni();
            Fill_cb_Pracownik();
            Fill_cb_Czytelnik();
            Fill_cb_ISBN();
        }

        public void Fill_cb_Dni()
        {
            dni = new List<int>();
            for(int i=1;i<=30;++i)
            {
                dni.Add(i);
            }
            cb_dni.ItemsSource = dni;
            
        }
        public void Fill_cb_Czytelnik()
        {
            PESELczytelnika = new List<string>();
            DBHandler handler = new DBHandler();
            PESELczytelnika = handler.cb_Czytelnik();
            cb_czytelnik.ItemsSource = PESELczytelnika;
        }
        public void Fill_cb_Pracownik()
        {
            PESELpracownika = new List<string>();
            DBHandler handler = new DBHandler();
            PESELpracownika = handler.cb_Pracownik();
            cb_pracownik.ItemsSource = PESELpracownika;
        }
        public void Fill_cb_ISBN()
        {
            ISBN = new List<string>();
            DBHandler handler = new DBHandler();
            ISBN = handler.cb_ISBN();
            cb_ISBN.ItemsSource = ISBN;
        }

        private void B_Dodaj_Click(object sender, RoutedEventArgs e)
        {
            DBHandler handler = new DBHandler();
            Wypozyczenie wypozyczenie = new Wypozyczenie();
            wypozyczenie.ISBN = cb_ISBN.SelectedValue.ToString();
            wypozyczenie.Okres_wypozyczenie = Convert.ToInt32(cb_dni.SelectedValue);
            wypozyczenie.PESELCzytelnik = cb_czytelnik.SelectedValue.ToString();
            wypozyczenie.PESELPracownik = cb_pracownik.SelectedValue.ToString();
            handler.Add_Wypozyczenie(wypozyczenie);
            parentWindow.Fill_Grid();
            parentWindow.SredniOkres();
            parentWindow.ilosc_wypozyczen();
        }
    }
}
