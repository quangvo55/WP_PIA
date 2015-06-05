using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

﻿using App1.ViewModels;
using App1.Models;

namespace App1.Views
{
    public sealed partial class AllSessions : Page
    {
        SessionsViewModel sessionsViewModel = null;
        public AllSessions()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            sessionsViewModel = new SessionsViewModel();
            this.DataContext = sessionsViewModel.GetSessions();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SessionPage));
        } 

        private void ListViewClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(SessionPage), (SessionViewModel)e.ClickedItem);
        }
        private void ListViewSelect(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
