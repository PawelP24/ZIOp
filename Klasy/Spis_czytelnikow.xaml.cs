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
    /// Interaction logic for Spis_czytelnikow.xaml
    /// </summary>
    public partial class Spis_czytelnikow : Window
    {
        DataTable table;
        public Spis_czytelnikow()
        {
            InitializeComponent();
            Fill_Grid();
        }
        public void Fill_Grid()
        {
            DBHandler handler = new DBHandler();
            table = handler.FillGrid_Czytelnicy();
            DG_Czytelnicy.ItemsSource = table.DefaultView;
        }

        private void B_Delete_Click(object sender, RoutedEventArgs e)
        {
            DBHandler handler = new DBHandler();
            DataRowView row = (DataRowView)DG_Czytelnicy.SelectedItem;
            handler.Delete_Czytelnik(Convert.ToInt32(row.Row[0]));
            Fill_Grid();
        }

        private void B_Dodaj_Click(object sender, RoutedEventArgs e)
        {
            Add_Czytelnik czytelnik = new Add_Czytelnik(this);
            czytelnik.ShowDialog();
        }
    }
}
