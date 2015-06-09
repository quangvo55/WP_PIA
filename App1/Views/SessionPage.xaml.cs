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
            session.BuyIn = Convert.ToDouble(this.BuyInAmount.Text);
            session.CashOut = Convert.ToDouble(this.CashOutAmount.Text);
            session.Stakes = ((ComboBoxItem)stakesComboBox.SelectedItem).Content.ToString();
            session.GameName = ((ComboBoxItem)gamesComboBox.SelectedItem).Content.ToString();
            session.Location = ((ComboBoxItem)locationComboBox.SelectedItem).Content.ToString();
            session.Profit = Convert.ToDouble(this.CashOutAmount.Text) - Convert.ToDouble(this.BuyInAmount.Text);
            session.StartDate = startDate.Date.DateTime;
            session.EndDate = endDate.Date.DateTime;
            session.EndTime = endTime.Time;

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

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        } 
    }
}
