using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

using App1.ViewModels;
using App1.Common;
using App1.Models;
using App1.Utils;

namespace App1.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void newSessionTapped(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SessionPage));
        }

        private void completedSessionTapped(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SessionPage), SessionMode.Completed);
        }

        private void allSessionsTapped(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AllSessions), GameType.Cash);
        }

        private void newTourneyTapped(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TourneyPage));
        }

        private void completedTourneyTapped(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TourneyPage), SessionMode.Completed);
        }

        private void allTourniesTapped(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AllSessions), GameType.Tournament);
        }

        private void newCashReportTapped(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Report), GameType.Cash);
        }
        private void newPlayerTapped(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PlayerPage));
        }

        private void allPlayersTapped(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AllPlayers));
        }
    }
}
