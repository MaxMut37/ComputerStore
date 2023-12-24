﻿using ComputerStore.ModelsCodeFirst;
using ComputerStore.Services;
using ComputerStore.ViewModel;
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

namespace ComputerStore.View
{
    /// <summary>
    /// Логика взаимодействия для AddProductView.xaml
    /// </summary>
    public partial class AddProductView : Window
    {
        public AddProductView()
        {
            InitializeComponent();

            DataContext = new AddProductViewModel();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void btnMinimaze_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnCloze_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        } 
    }
}