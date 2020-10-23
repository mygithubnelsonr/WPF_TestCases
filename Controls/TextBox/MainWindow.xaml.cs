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

namespace TextBox
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

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)combobox.SelectedItem;
            textbox.Text = item.Content.ToString();
            ProcessInput();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)combobox.SelectedItem;
            textbox.Text = item.Content.ToString();
        }

        private void textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.Key == Key.Enter)
                ProcessInput();
        }

        private void ProcessInput()
        {
            textboxInfo.Text = textbox.Text;
        }
    }
}
