﻿using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
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
    }
}
