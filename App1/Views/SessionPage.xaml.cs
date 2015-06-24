using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Navigation;

﻿using App1.ViewModels;
using App1.Models;
using App1.Utils;

namespace App1.Views
{
    public sealed partial class SessionPage : Page
    {
        SessionViewModel session = new SessionViewModel();
        SessionMode mode = SessionMode.New;
        RebuyHelper rebuyHelper;
        AddStakesHelper addStakesHelper;
        private bool stakesCollectionHasChanged = false;

        public SessionPage()
        {
            this.InitializeComponent();
        }

        #region Events
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (e.Parameter == null)
            {
                ToggleDeleteButton("Stop", Symbol.Stop, DeleteButton_Click, StopButton_Click);
            }
            else
            {
                if (e.Parameter is SessionMode)
                {
                    mode = (SessionMode)e.Parameter;
                } else {
                    session = (SessionViewModel)e.Parameter;
                    App.CurrentSessionId = session.Id;
                    mode = SessionMode.Edit;
                }

                //Update UI
                RemovePlayButton();
                ToggleStartDataInput(true);
                ToggleEndDataInput(true);
            }

            this.DataContext = session;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            //need to sort observable collection
            if (stakesCollectionHasChanged)
            {
                var tempStakes = new List<string>(session.StakesAvailable);
                tempStakes.Sort(GeneralUtil.AlphaNumCompare);
                localSettings.Values["StakesAvailable"] = tempStakes.ToArray();
            }
        }

        private void StakesOnLoad(object sender, RoutedEventArgs e)
        {
            if (mode == SessionMode.New || mode == SessionMode.Completed)
            {
                this.stakesComboBox.SelectedIndex = 0;
            }
        }

        private void GameNameOnLoad(object sender, RoutedEventArgs e)
        {
            if (mode == SessionMode.New || mode == SessionMode.Completed)
            {
                this.gamesComboBox.SelectedIndex = 0;
            }
        }

        private void LocationOnLoad(object sender, RoutedEventArgs e)
        {
            if (mode == SessionMode.New || mode == SessionMode.Completed)
            {
                this.locationComboBox.SelectedIndex = 0;
            }
        }
        #endregion

        #region Xaml Event Handlers
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
                GeneralUtil.ShowMessage("You need to enter a buy in amount before you can start a session.");
                return;
            }

            if (String.IsNullOrEmpty(CashOutAmount.Text))
            {
                GeneralUtil.ShowMessage("You need to enter a cash out amount before you can save the session.");
                return;
            }

            session.BuyIn = Convert.ToDouble(this.BuyInAmount.Text);
            session.CashOut = Convert.ToDouble(this.CashOutAmount.Text);
            session.Stakes = stakesComboBox.SelectedItem.ToString();
            session.GameName = gamesComboBox.SelectedItem.ToString();
            session.Location = locationComboBox.SelectedItem.ToString();
            session.Profit = Convert.ToDouble(this.CashOutAmount.Text) - Convert.ToDouble(this.BuyInAmount.Text);
            session.StartDate = startDate.Date.DateTime;
            session.StartTime = startTime.Time;
            session.EndDate = endDate.Date.DateTime;
            session.EndTime = endTime.Time;

            string result = session.SaveSession(session);
            App.CurrentSessionId = session.Id;
            if (result.Contains("Success"))
            {
                this.Frame.Navigate(typeof(AllSessions), GameType.Cash);
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

        private void TimePicker_Changed(object sender, TimePickerValueChangedEventArgs e)
        {
            DurationCounter.Text = GeneralUtil.GetDateTimeDifference(startDate.Date.DateTime, startTime.Time, endDate.Date.DateTime, endTime.Time);
        }

        private void DatePicker_Changed(object sender, DatePickerValueChangedEventArgs e)
        {
            DurationCounter.Text = GeneralUtil.GetDateTimeDifference(startDate.Date.DateTime, startTime.Time, endDate.Date.DateTime, endTime.Time);
        }
        #endregion

        #region Add Rebuy
        private void RebuyButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(BuyInAmount.Text) || BuyInAmount.Text == "0")
            {
                GeneralUtil.ShowMessage("You need to enter a buy in amount before you can rebuy.");
                return;
            }
            rebuyHelper = new RebuyHelper(this);
            rebuyHelper.OKBtnTapped += RebuyOkBtnTapped;
        }

        private void RebuyOkBtnTapped(object sender, RoutedEventArgs e)
        {
            this.BuyInAmount.Text = (Convert.ToInt32(this.BuyInAmount.Text) + rebuyHelper.RebuyAmount).ToString();
        }
        #endregion

        #region Add Stakes
        private void Stakes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cmb = sender as ComboBox;
            var selectedItem = cmb.SelectedItem.ToString();
            if (selectedItem == "New")
            {
                addStakesHelper = new AddStakesHelper(this);
                addStakesHelper.confirmBtnTapped += StakesOKBtnTapped;
            }
        }
        
        private void StakesOKBtnTapped(object sender, RoutedEventArgs e)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
           
            var stakeToAdd = String.Concat("$", addStakesHelper.LowAmount, "/$", addStakesHelper.HighAmount);
            if (!session.StakesAvailable.Contains(stakeToAdd))
            {
                session.StakesAvailable.Add(stakeToAdd);
                stakesCollectionHasChanged = true;
                stakesComboBox.SelectedIndex = session.StakesAvailable.Count - 1;
            }
            else
            {
                stakesComboBox.SelectedIndex = session.StakesAvailable.IndexOf(stakeToAdd);
            }
            
        }
        #endregion
    }
}
