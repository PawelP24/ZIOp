using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Rejestr_wypozyczen.xaml
    /// </summary>
    public partial class Rejestr_wypozyczen : Window
    {
        DataTable table;
        public Rejestr_wypozyczen()
        {
            InitializeComponent();
            Fill_Grid();
            SredniOkres();
            ilosc_wypozyczen();
        }
        public void Fill_Grid()
        {
            DBHandler handler = new DBHandler();
            table = handler.FillGrid_Wypozyczenie();
            DG_Wypozyczenia.ItemsSource = table.DefaultView;
        }
        private void B_Dodaj_Click(object sender, RoutedEventArgs e)
        {
            Add_Wypozyczenie wypozyczenie = new Add_Wypozyczenie(this);
            wypozyczenie.ShowDialog();
        }

        private void B_Usun_Click(object sender, RoutedEventArgs e)
        {
            DBHandler handler = new DBHandler();
            DataRowView row = (DataRowView)DG_Wypozyczenia.SelectedItem;
            handler.Delete_Wypozyczenie(Convert.ToInt32(row.Row[0]));
            Fill_Grid();
        }
        public void SredniOkres()
        {
            string sredni_okres;
            int counter = 0;
            int liczba_dni = 0;
            foreach(DataRow item in table.Rows)
            {
                ++counter;
                liczba_dni = liczba_dni + Convert.ToInt32(item["Okres_wypozyczenia"]);
            }
            if (counter > 0)
            {
                sredni_okres = Convert.ToString(liczba_dni / counter);
                tb_czas.Text = sredni_okres;
            }
          
        }
        public void ilosc_wypozyczen()
        {
            int counter = 0;
            foreach (DataRow item in table.Rows)
            {
                ++counter;
            }
            tb_ilosc.Text = Convert.ToString(counter);
        }
        
    }
}
