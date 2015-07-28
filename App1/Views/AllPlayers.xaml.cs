using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Navigation;

﻿using App1.ViewModels;
using App1.Models;

namespace App1.Views
{
    public sealed partial class AllPlayers : Page
    {
        PlayersViewModel playersViewModel = null;
        public AllPlayers()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            playersViewModel = new PlayersViewModel();
            this.DataContext = playersViewModel.GetPlayers();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PlayerPage));
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void ListViewClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(PlayerPage), (PlayerViewModel)e.ClickedItem);
        }
    }
}
