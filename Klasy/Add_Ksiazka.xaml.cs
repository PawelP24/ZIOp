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
    /// Interaction logic for Add_Ksiazka.xaml
    /// </summary>
    public partial class Add_Ksiazka : Window
    {
        Spis_ksiazek parentWindow;
        List<string> wydawcy;
        public Add_Ksiazka(Spis_ksiazek ksiazki)
        {
            InitializeComponent();
            parentWindow = ksiazki;
            Fill_cb_Nazwa();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DBHandler handler = new DBHandler();
            Wydawnictwo wydawca = new Wydawnictwo();
            Ksiazka ksiazka = new Ksiazka();
            ksiazka.Tytul = tbTytul.Text;
            ksiazka.Autor = tbAutor.Text;
            ksiazka.Kod = tbKod.Text;
            ksiazka.Data_wydania = tbData.Text;
            ksiazka.Cena = Convert.ToDouble(tbCena.Text);
            ksiazka.Ilosc = Convert.ToInt32(tbIlosc.Text);
            wydawca.nazwa = cb_Nazwa.SelectedValue.ToString();
            handler.Add_Ksiazka(ksiazka,wydawca);
            parentWindow.FillGrid();
        }
        private void Fill_cb_Nazwa()
        {
            wydawcy = new List<string>();
            DBHandler handler = new DBHandler();
            wydawcy = handler.cb_Wydawcy();
            cb_Nazwa.ItemsSource = wydawcy;
        }
    }
}
