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
using WpfApp.EditorWindows;

namespace WpfApp
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AuthorEditor authorEditor = new AuthorEditor();
            authorEditor.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BookEditor bookEditor = new BookEditor();
            bookEditor.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            GenreEditor genreEditor = new GenreEditor();
            genreEditor.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NcEditorWindow ncEditorWindow = new NcEditorWindow();
            ncEditorWindow.ShowDialog();
        }
    }
}
