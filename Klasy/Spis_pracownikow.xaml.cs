using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for Spis_pracownikow.xaml
    /// </summary>
    public partial class Spis_pracownikow : Window
    {
        DataTable table;
        public Spis_pracownikow()
        {
            InitializeComponent();
            DataGrid_Fill();
        }

        private void B_dodaj_Click(object sender, RoutedEventArgs e)
        {
            Add_Pracownik pracownik = new Add_Pracownik(this);
            pracownik.ShowDialog();
        }
        public void DataGrid_Fill()
        {
            DBHandler handler = new DBHandler();
            table = handler.FillGrid_Pracownicy();
            DG_Pracownicy.ItemsSource = table.DefaultView;

        }

        private void B_Usun_Click(object sender, RoutedEventArgs e)
        {
            DBHandler handler = new DBHandler();
            DataRowView row = (DataRowView)DG_Pracownicy.SelectedItem;
            handler.Delete_Pracownik(Convert.ToInt32(row.Row[0]));
            DataGrid_Fill();
        }

        private void DG_Pracownicy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            B_Usun.IsEnabled = true;
        }
    }
}
