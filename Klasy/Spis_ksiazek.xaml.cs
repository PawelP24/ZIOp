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
    /// Interaction logic for Spis_ksiazek.xaml
    /// </summary>
    public partial class Spis_ksiazek : Window
    {
        DataTable table;
        public Spis_ksiazek()
        {
            InitializeComponent();
            FillGrid();
        }

        private void B_dodaj_Click(object sender, RoutedEventArgs e)
        {
            Add_Ksiazka ksiazka = new Add_Ksiazka(this);
            ksiazka.ShowDialog();
        }
        public void FillGrid()
        {
            DBHandler handler = new DBHandler();
            table = handler.FillGrid_Ksiazki();
            DG_Ksiazki.ItemsSource = table.DefaultView;
        }

        private void B_Usun_Click(object sender, RoutedEventArgs e)
        {
            Delete_Ksiazka ksiazka = new Delete_Ksiazka(this);
            ksiazka.ShowDialog();
        }
        public int index()
        {
            int indeks;
            DataRowView row = (DataRowView)DG_Ksiazki.SelectedItem;
            indeks = (int)row["ID"];
            return indeks;
        }

        private void DG_Ksiazki_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            B_Usun.IsEnabled = true;
        }
    }
}
