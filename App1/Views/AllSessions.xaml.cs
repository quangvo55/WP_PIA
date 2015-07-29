using System;
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
        TourniesViewModel tourneyViewModel = null;
        GameType gameType;
        public AllSessions()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            gameType = (GameType)e.Parameter;
            if (gameType == GameType.Cash)
            {
                sessionsViewModel = new SessionsViewModel();
                this.DataContext = sessionsViewModel.GetSessions();
            }
            else
            {
                tourneyViewModel = new TourniesViewModel();
                this.txtTitle.Text = "All Tournaments";
                this.DataContext = tourneyViewModel.GetTournies();
            }
            
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (gameType == GameType.Cash)
            {
                this.Frame.Navigate(typeof(SessionPage));
            }
            else
            {
                this.Frame.Navigate(typeof(TourneyPage));
            }
           
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void ListViewClick(object sender, ItemClickEventArgs e)
        {
            if (gameType == GameType.Cash)
            {
                this.Frame.Navigate(typeof(SessionPage), (SessionViewModel)e.ClickedItem);
            }
            else
            {
                this.Frame.Navigate(typeof(TourneyPage), (TourneyViewModel)e.ClickedItem);
            }
        }
    }
}
