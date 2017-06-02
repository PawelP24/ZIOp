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
    /// Interaction logic for Add_Wydawca.xaml
    /// </summary>
    public partial class Add_Wydawca : Window
    {
        Rejestr_wydawcow parentWindow;
        public Add_Wydawca(Rejestr_wydawcow wydawca)
        {
            InitializeComponent();
            parentWindow = wydawca;
        }

        private void B_Dodaj_Click(object sender, RoutedEventArgs e)
        {
            DBHandler handler = new DBHandler();
            Wydawnictwo wydawnictwo = new Wydawnictwo();
            wydawnictwo.nazwa = tb_Nazwa.Text;
            wydawnictwo.adres = tb_Adres.Text;
            handler.Add_Wydawca(wydawnictwo);
            parentWindow.FillGrid_Wydawcy();
        }
        
    }
}
