﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace System_biblioteczny
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Spis_pracownikow pracownicy;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void B_Pracownicy_Click(object sender, RoutedEventArgs e)
        {
            pracownicy = new Spis_pracownikow();
            pracownicy.ShowDialog();
        }
    }
}