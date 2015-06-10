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
    public sealed partial class SessionPage : Page
    {
        SessionViewModel session = null;
        SessionMode mode = SessionMode.New;
        public SessionPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter == null)
            {
                session = new SessionViewModel();
                ToggleDeleteButton("Stop", Symbol.Stop, DeleteButton_Click, StopButton_Click);
            }
            else
            {
                session = (SessionViewModel)e.Parameter;
                App.CurrentSessionId = session.Id;
                mode = SessionMode.Edit;

                //Update UI
                RemovePlayButton();
                ToggleEndDataInput(true);
            }

            this.DataContext = session;
        }
                
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            mode = SessionMode.Running;
            TogglePlayButton("Pause", Symbol.Pause, StartButton_Click, PauseButton_Click);
            breakInput.Visibility = Visibility.Visible;
            startDate.Date = DateTime.Now;
            startTime.Time = DateTime.Now.TimeOfDay;
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            mode = SessionMode.Paused;
            TogglePlayButton("Resume", Symbol.Play, PauseButton_Click, ResumeButton_Click); 
        }
        private void ResumeButton_Click(object sender, RoutedEventArgs e)
        {
            mode = SessionMode.Running;
            TogglePlayButton("Pause", Symbol.Pause, ResumeButton_Click, PauseButton_Click); 
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            mode = SessionMode.Stopped;
            ToggleEndDataInput(true);
            endDate.Date = DateTime.Now;
            endTime.Time = DateTime.Now.TimeOfDay;
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
            session.StartTime = startTime.Time;
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

        private void TogglePlayButton(string label, Symbol icon, RoutedEventHandler clickEventToRemove, RoutedEventHandler clickEventToAdd)
        {
            var btn = (AppBarButton)bottomAppBar.PrimaryCommands.ElementAtOrDefault(0);
            btn.Label = label;
            btn.Icon = new SymbolIcon(icon);
            btn.Click -= clickEventToRemove;
            btn.Click += clickEventToAdd;
        }

        private void RemovePlayButton()
        {
            bottomAppBar.PrimaryCommands.RemoveAt(0);
        }

        private void ToggleDeleteButton(string label, Symbol icon, RoutedEventHandler clickEventToRemove, RoutedEventHandler clickEventToAdd)
        {
            var btn = (AppBarButton)bottomAppBar.PrimaryCommands.ElementAtOrDefault(1);
            btn.Label = label;
            btn.Icon = new SymbolIcon(icon);
            btn.Click -= clickEventToRemove;
            btn.Click += clickEventToAdd;
        }

        private void ToggleEndDataInput(bool show)
        {
            sessionEndInput.Visibility = (show) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
