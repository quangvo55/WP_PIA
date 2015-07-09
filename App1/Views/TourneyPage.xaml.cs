using System;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;

using System.Collections.Generic;
using System.Collections.ObjectModel;

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
        TourneyViewModel tourney = new TourneyViewModel();
        SessionMode mode = SessionMode.New;
        RebuyHelper rebuyHelper;
        AddItemHelper addItemHelper;
        private bool gameTypeCollectionHasChanged = false;
        private bool gamesCollectionHasChanged = false;
        private bool locationCollectionHasChanged = false;

        public TourneyPage()
        {
            this.InitializeComponent();
        }
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

        private void GameTypeOnLoad(object sender, RoutedEventArgs e)
        {
            if (mode == SessionMode.New || mode == SessionMode.Completed)
            {
                this.gametypeComboBox.SelectedIndex = 0;
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
            tourney.Rank = Convert.ToDouble(Rank.Text);
            tourney.PlayerCount = Convert.ToDouble(PlayerCount.Text);


            string result = tourney.SaveSession(tourney);
            App.CurrentSessionId = tourney.Id;
            if (result.Contains("Success"))
            {
                SaveComboChanges();
                this.Frame.Navigate(typeof(AllSessions), GameType.Tournament);
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

        private void RebuyButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(BuyInAmount.Text) || BuyInAmount.Text == "0")
            {
                GeneralUtil.ShowMessage("You need to enter a buy in amount before you can rebuy.");
                return;
            }
            rebuyHelper = new RebuyHelper(this);
            rebuyHelper.OKBtnTapped += rebuyOkBtnTapped;
        }

        private void rebuyOkBtnTapped(object sender, RoutedEventArgs e)
        {
            this.BuyInAmount.Text = (Convert.ToInt32(this.BuyInAmount.Text) + rebuyHelper.RebuyAmount).ToString();
        }

        private void Games_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var cmb = sender as ComboBox;
            if (cmb.SelectedItem.ToString() == "New")
            {
                addItemHelper = new AddItemHelper(this, "Game name");
                addItemHelper.confirmBtnTapped += GamesOKBtnTapped;
            }
        }

        private void GamesOKBtnTapped(object sender, RoutedEventArgs e)
        {
            var gameName = addItemHelper.txtInput;
            if (!tourney.GameNames.Contains(gameName))
            {
                tourney.GameNames.Add(gameName);
                gamesCollectionHasChanged = true;
                gamesComboBox.SelectedIndex = tourney.GameNames.Count - 1;
            }
            else
            {
                gamesComboBox.SelectedIndex = tourney.GameNames.IndexOf(gameName);
            }
        }

        private void Location_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var cmb = sender as ComboBox;
            if (cmb.SelectedItem.ToString() == "New")
            {
                addItemHelper = new AddItemHelper(this, "Location");
                addItemHelper.confirmBtnTapped += LocationOKBtnTapped;
            }
        }

        private void LocationOKBtnTapped(object sender, RoutedEventArgs e)
        {
            var location = addItemHelper.txtInput;
            if (!tourney.Locations.Contains(location))
            {
                tourney.Locations.Add(location);
                locationCollectionHasChanged = true;
                locationComboBox.SelectedIndex = tourney.Locations.Count - 1;
            }
            else
            {
                locationComboBox.SelectedIndex = tourney.Locations.IndexOf(location);
            }
        }

        private void GameTypes_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var cmb = sender as ComboBox;
            if (cmb.SelectedItem.ToString() == "New")
            {
                addItemHelper = new AddItemHelper(this, "Game type");
                addItemHelper.confirmBtnTapped += GameTypeOKBtnTapped;
            }
        }

        private void GameTypeOKBtnTapped(object sender, RoutedEventArgs e)
        {
            var gametype = addItemHelper.txtInput;
            if (!tourney.GameTypes.Contains(gametype))
            {
                tourney.GameTypes.Add(gametype);
                gameTypeCollectionHasChanged = true;
                gametypeComboBox.SelectedIndex = tourney.GameTypes.Count - 1;
            }
            else
            {
                gametypeComboBox.SelectedIndex = tourney.GameTypes.IndexOf(gametype);
            }
        }

        private void SaveComboChanges()
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            //need to sort observable collection
            if (gameTypeCollectionHasChanged)
            {
                var tempList = new List<string>(tourney.GameTypes);
                tempList.Sort();
                localSettings.Values["GameTypesSaved"] = tempList.ToArray();
            }

            if (gamesCollectionHasChanged)
            {
                var tempList = new List<string>(tourney.GameNames);
                tempList.Sort();
                localSettings.Values["GamesSaved"] = tempList.ToArray();
            }

            if (locationCollectionHasChanged)
            {
                var tempList = new List<string>(tourney.Locations);
                tempList.Sort();
                localSettings.Values["Locations"] = tempList.ToArray();
            }
        }
    }
}
