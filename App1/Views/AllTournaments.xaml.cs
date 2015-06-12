using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Navigation;

﻿using App1.ViewModels;
using App1.Models;

namespace App1.Views
{
    public sealed partial class AllTournaments : Page
    {
        public AllTournaments()
        {
            this.InitializeComponent();
        }

        TourniesViewModel tourniesViewModel = null;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            tourniesViewModel = new TourniesViewModel();
            this.DataContext = tourniesViewModel.GetTournies();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TourneyPage));
        } 

        private void ListViewClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(TourneyPage), (TourneyViewModel)e.ClickedItem);
        }
    }
}
