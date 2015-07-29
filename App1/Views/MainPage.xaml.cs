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
        AddItemHelper addItemHelper;
        public MainPage()
        {
            this.InitializeComponent();
            SetBankRoll(); 
        }

        private void SetBankRoll()
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            var bankroll = (string)localSettings.Values["BankRoll"];

            setBankRoll.Text = "Set Bank Roll " + (Convert.ToDouble(bankroll)).ToString("C");
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

        private void cashReportTapped(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Report), GameType.Cash);
        }

        private void tourneyReportTapped(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Report), GameType.Tournament);
        }
        private void newPlayerTapped(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PlayerPage));
        }

        private void allPlayersTapped(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AllPlayers));
        }
        private async void supportTapped(object sender, RoutedEventArgs e)
        {
            var emailMessage = new Windows.ApplicationModel.Email.EmailMessage();
            emailMessage.Subject = "message subject";
            emailMessage.Body = "message body";
            var emailRecipient = new Windows.ApplicationModel.Email.EmailRecipient("windows.pokerincometracker@gmail.com");
            emailMessage.To.Add(emailRecipient); 
            await Windows.ApplicationModel.Email.EmailManager.ShowComposeNewEmailAsync(emailMessage); 
        }

        
        private void setBankRollTapped(object sender, RoutedEventArgs e)
        {
            addItemHelper = new AddItemHelper(this, "Bankroll Amount");
            addItemHelper.setInputScopeToNumeric();
            addItemHelper.confirmBtnTapped += confirmBankRollTapped;
        }

        private void confirmBankRollTapped(object sender, RoutedEventArgs e)
        {
            Windows.Storage.ApplicationData.Current.LocalSettings.Values["BankRoll"] = addItemHelper.txtInput;
            SetBankRoll();
        }
    }
}
