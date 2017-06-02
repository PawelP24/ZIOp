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
        
    }
}
