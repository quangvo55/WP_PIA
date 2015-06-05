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

namespace App1.Views
{
    public sealed partial class SessionPage : Page
    {
        SessionViewModel session = null; 
        public SessionPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter == null)
            {
                session = new SessionViewModel();
            }
            else
            {
                session = (SessionViewModel)e.Parameter;
                App.CurrentSessionId = session.Id;
            }
            this.DataContext = session;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string result = session.SaveSession(session);
            App.CurrentSessionId = session.Id;
            if (result.Contains("Success"))
            {
                this.Frame.Navigate(typeof(MainPage));
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string result = session.DeleteSession(session.Id);
            if (result.Contains("Success"))
            {
                this.Frame.Navigate(typeof(MainPage));
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        } 
    }
}
