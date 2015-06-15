using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Navigation;

﻿using App1.ViewModels;
using App1.Models;
using App1.Utils;

namespace App1.Views
{
    public sealed partial class TourneyPage : Page
    {
        TourneyViewModel tourney = null;
        SessionMode mode = SessionMode.New;

        public TourneyPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (e.Parameter == null)
            {
                tourney = new TourneyViewModel();
                ToggleDeleteButton("Stop", Symbol.Stop, DeleteButton_Click, StopButton_Click);
            }
            else
            {
                if (e.Parameter is SessionMode)
                {
                    mode = (SessionMode)e.Parameter;
                }
                else
                {
                    tourney = (TourneyViewModel)e.Parameter;
                    App.CurrentSessionId = tourney.Id;
                    mode = SessionMode.Edit;
                }

                //Update UI
                RemovePlayButton();
                ToggleStartDataInput(true);
                ToggleEndDataInput(true);
            }

            this.DataContext = tourney;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(BuyInAmount.Text) || BuyInAmount.Text == "0")
            {
                GeneralUtil.ShowMessage("You need to enter a buy in amount before you can start a session.");
                return;
            }

            mode = SessionMode.Running;
            TogglePlayButton("Pause", Symbol.Pause, StartButton_Click, PauseButton_Click);
            sessionStartInput.Visibility = Visibility.Visible;
            DurationCounter.Visibility = Visibility.Visible;
            var stopBtn = (AppBarButton)bottomAppBar.PrimaryCommands.ElementAtOrDefault(1);
            stopBtn.IsEnabled = true;
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
            if (String.IsNullOrEmpty(BuyInAmount.Text) || BuyInAmount.Text == "0")
            {
                GeneralUtil.ShowMessage("You need to enter a buy in amount before you can start a tournament.");
                return;
            }

            //if (String.IsNullOrEmpty(CashOut.Text))
            //{
            //    GeneralUtil.ShowMessage("You need to enter a cash out amount before you can save the tournament.");
            //    return;
            //}

            tourney.BuyIn = Convert.ToDouble(this.BuyInAmount.Text);
            tourney.CashOut = Convert.ToDouble(this.CashOut.Text);
            tourney.GameName = gamesComboBox.SelectedItem.ToString();
            tourney.Location = locationComboBox.SelectedItem.ToString();
            tourney.Profit = Convert.ToDouble(this.CashOut.Text) - Convert.ToDouble(this.BuyInAmount.Text);
            tourney.StartDate = startDate.Date.DateTime;
            tourney.StartTime = startTime.Time;
            tourney.EndDate = endDate.Date.DateTime;
            tourney.EndTime = endTime.Time;


            string result = tourney.SaveSession(tourney);
            App.CurrentSessionId = tourney.Id;
            if (result.Contains("Success"))
            {
                this.Frame.Navigate(typeof(MainPage));
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string result = tourney.DeleteSession(tourney.Id);
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
            btn.IsEnabled = false;
            btn.Icon = new SymbolIcon(icon);
            btn.Click -= clickEventToRemove;
            btn.Click += clickEventToAdd;
        }

        private void ToggleEndDataInput(bool show)
        {
            sessionEndInput.Visibility = (show) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void ToggleStartDataInput(bool show)
        {
            sessionStartInput.Visibility = (show) ? Visibility.Visible : Visibility.Collapsed;
            DurationCounter.Visibility = (show) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void timePicker_TimeChanged(object sender, TimePickerValueChangedEventArgs e)
        {
            var end = endTime.Time;
            var start = startTime.Time;
            DurationCounter.Text = (end - start).ToString();
        }
    }
}
