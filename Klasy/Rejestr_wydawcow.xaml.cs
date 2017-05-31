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
    /// Interaction logic for Rejestr_wydawcow.xaml
    /// </summary>
    public partial class Rejestr_wydawcow : Window
    {
        DataTable table;

        public Rejestr_wydawcow()
        {
            InitializeComponent();
            FillGrid_Wydawcy();
        }


        public void FillGrid_Wydawcy()
        {
            DBHandler handler = new DBHandler();
            table = handler.FillGrid_Wydawcy();
            DG_Wydawcy.ItemsSource = table.DefaultView;
        }

        private void B_Usun_Click(object sender, RoutedEventArgs e)
        {
            DBHandler handler = new DBHandler();
            handler.Delete_Wydawnictwo(DG_Wydawcy.SelectedIndex);
            FillGrid_Wydawcy();
        }
    }
}
