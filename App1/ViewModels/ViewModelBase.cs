using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

﻿using App1.Models;
using App1.Utils;

namespace App1.ViewModels
{
    public class ViewModelBase
    {
        public ViewModelBase()
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            var gamesSavedArray = (string[])localSettings.Values["GamesSaved"];
            GameNames = new ObservableCollection<string>(gamesSavedArray);

            var LocationsSaved = (string[])localSettings.Values["Locations"];
            Locations = new ObservableCollection<string>(LocationsSaved);
        }

        #region Properties;
        public ObservableCollection<string> GameNames { get; set; }
        public ObservableCollection<string> Locations { get; set; }  
        private int id;
        public int Id
        {
            get { return id; }

            set
            {
                if (id == value) { return; }

                id = value;
                RaisePropertyChanged("Id");
            }
        }

        private string gamename = string.Empty;
        public string GameName
        {
            get { return gamename; }

            set
            {
                if (gamename == value) { return; }

                gamename = value;
                RaisePropertyChanged("GameName");
            }
        }

        private string location = string.Empty;
        public string Location
        {
            get { return location; }

            set
            {
                if (location == value) { return; }

                location = value;
                RaisePropertyChanged("Location");
            }
        }

        private double buyin;
        public double BuyIn
        {
            get { return buyin; }

            set
            {
                if (buyin == value) { return; }

                buyin = value;
                RaisePropertyChanged("BuyIn");
            }
        }

        private double cashout;
        public double CashOut
        {
            get { return cashout; }

            set
            {
                if (cashout == value) { return; }

                cashout = value;
                RaisePropertyChanged("CashOut");
            }
        }

        private double profit;
        public double Profit
        {
            get { return profit; }

            set
            {
                if (profit == value) { return; }

                profit = value;
                RaisePropertyChanged("Profit");
            }
        }

        public string ProfitAsCurrency
        {
            get { return profit.ToString("C"); }
        }

        private DateTime startdate = DateTime.Now;
        public DateTime StartDate
        {
            get { return startdate; }

            set
            {
                if (startdate == value) { return; }

                startdate = value;
                RaisePropertyChanged("StartDate");
            }
        }
        private DateTime enddate = DateTime.Now;
        public DateTime EndDate
        {
            get { return enddate; }

            set
            {
                if (enddate == value) { return; }

                enddate = value;
                RaisePropertyChanged("EndDate");
            }
        }

        private TimeSpan starttime;
        public TimeSpan StartTime
        {
            get { return starttime; }

            set
            {
                if (starttime == value) { return; }

                starttime = value;
                RaisePropertyChanged("StartTime");
            }
        }

        private TimeSpan endtime;
        public TimeSpan EndTime
        {
            get { return endtime; }

            set
            {
                if (endtime == value) { return; }

                endtime = value;
                RaisePropertyChanged("EndTime");
            }
        }

        public TimeSpan Duration
        {
            get { return GeneralUtil.GetDateTimeDifference(startdate, starttime, enddate, endtime); }
        }

        public SolidColorBrush FontColor
        {
            get
            {
                return (this.profit > 0) ? new SolidColorBrush(Colors.Green) : (this.profit == 0) ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Red);
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
    }
}
