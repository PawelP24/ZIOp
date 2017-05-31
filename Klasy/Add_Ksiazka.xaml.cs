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
        public Add_Ksiazka(Spis_ksiazek ksiazki)
        {
            InitializeComponent();
            parentWindow = ksiazki;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DBHandler handler = new DBHandler();
            Wydawnictwo wydawnictwo = new Wydawnictwo(tbNazwa.Text,tbAdres.Text);
            Ksiazka ksiazka = new Ksiazka();
            ksiazka.Tytul = tbTytul.Text;
            ksiazka.Autor = tbAutor.Text;
            ksiazka.Kod = tbKod.Text;
            ksiazka.Data_wydania = tbData.Text;
            ksiazka.Cena = Convert.ToDouble(tbCena.Text);
            ksiazka.Ilosc = Convert.ToInt32(tbIlosc.Text);
            ksiazka.Dostepnosc = "TAK";
            handler.Add_Ksiazka(ksiazka, wydawnictwo);
            parentWindow.FillGrid();
        }
    }
}
