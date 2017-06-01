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
    /// Interaction logic for Rejestr_wypozyczen.xaml
    /// </summary>
    public partial class Rejestr_wypozyczen : Window
    {
        public Rejestr_wypozyczen()
        {
            InitializeComponent();
        }

        private void B_Dodaj_Click(object sender, RoutedEventArgs e)
        {
            Add_Wypozyczenie wypozyczenie = new Add_Wypozyczenie(this);
            wypozyczenie.ShowDialog();
        }
    }
}
