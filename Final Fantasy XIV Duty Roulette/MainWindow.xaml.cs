﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Final_Fantasy_XIV_Duty_Roulette
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Duty_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("DutyRoulettePage.xaml", UriKind.Relative));
        }

        private void Class_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("ClassRoulettePage.xaml", UriKind.Relative));
        }
    }
}