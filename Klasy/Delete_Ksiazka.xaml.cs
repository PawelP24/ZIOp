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
    /// Interaction logic for Delete_Ksiazka.xaml
    /// </summary>
    public partial class Delete_Ksiazka : Window
    {
        List<int> liczba_sztuk;
        Spis_ksiazek parentWindow;
        public Delete_Ksiazka(Spis_ksiazek window)
        {
            InitializeComponent();
            parentWindow = window;
            Fill_cb_sztuki();
        }
        private void Fill_cb_sztuki()
        {
            DBHandler handler = new DBHandler();
            liczba_sztuk = handler.cb_sztuki(parentWindow.index());
            int liczba = liczba_sztuk[0];
            liczba_sztuk.Clear();
            for(int i=1;i<=liczba;++i)
            {
                liczba_sztuk.Add(i);
            }
            cb_sztuki.ItemsSource = liczba_sztuk;
        }
        private void DeleteKsiazka()
        {
            DBHandler handler = new DBHandler();
            handler.Delete_Ksiazka(parentWindow.index(),(int)cb_sztuki.SelectedValue);
            parentWindow.FillGrid();
        }

        private void B_Usun_Click(object sender, RoutedEventArgs e)
        {
            DeleteKsiazka();
        }
    }
}
