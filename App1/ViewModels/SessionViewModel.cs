﻿using App1.Models;
using App1.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel; 
using System.Linq;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;


namespace App1.ViewModels
{
    public class SessionViewModel : ViewModelBase
    {
        public SessionViewModel() 
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            var stakesSavedArray = (string[])localSettings.Values["StakesSaved"];
            StakesAvailable = new ObservableCollection<string>(stakesSavedArray);

            var gamesSavedArray = (string[])localSettings.Values["GamesSaved"];
            GameNames = new ObservableCollection<string>(gamesSavedArray);

            var LocationsSaved = (string[])localSettings.Values["Locations"];
            Locations = new ObservableCollection<string>(LocationsSaved);
        }

        #region Properties

        public ObservableCollection<string> StakesAvailable { get; set; }
        public ObservableCollection<string> GameNames { get; set; }
        public ObservableCollection<string> Locations { get; set; }        

        private string stakes = string.Empty;
        public string Stakes
        {
            get { return stakes; }

            set
            {
                if (stakes == value) { return; }

                stakes = value;
                RaisePropertyChanged("Stakes");
            }
        }

        #endregion "Properties" 

        #region Methods
        public SessionViewModel GetSession(int sessionId)
        {
            var session = new SessionViewModel();
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                var _session = (db.Table<Sessions>().Where(
                    s => s.Id == sessionId)).Single();
                session.Id = _session.Id;
                session.Stakes = _session.Stakes;
                session.GameName = _session.GameName;
                session.Location = _session.Location;
                session.BuyIn = _session.BuyIn;
                session.CashOut = _session.CashOut;
                session.StartDate = _session.StartDate;
                session.StartTime = _session.StartTime;
                session.EndDate = _session.EndDate;
                session.EndTime = _session.EndTime;
            }
            
            return session;
        }

        public string SaveSession(SessionViewModel session)
        {
            string result = string.Empty;
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                try
                {
                    var existingSession = (db.Table<Sessions>().Where(
                        s => s.Id == session.Id)).SingleOrDefault();

                    if (existingSession != null)
                    {
                        existingSession.BuyIn = session.BuyIn;
                        existingSession.CashOut = session.CashOut;
                        existingSession.GameName = session.GameName;
                        existingSession.Location = session.Location;
                        existingSession.Profit = session.Profit;
                        existingSession.StartDate = session.StartDate;
                        existingSession.StartTime = session.StartTime;
                        existingSession.EndDate = session.EndDate;
                        existingSession.EndTime = session.EndTime;
                        existingSession.Stakes = session.Stakes;

                        int success = db.Update(existingSession);
                    }
                    else
                    {
                        int success = db.Insert(new Sessions()
                        {
                            BuyIn = session.BuyIn,
                            CashOut = session.CashOut,
                            GameName = session.GameName,
                            Location = session.Location,
                            Profit = session.Profit,
                            StartDate = session.StartDate,
                            StartTime = session.StartTime,
                            EndDate = session.EndDate,
                            EndTime = session.EndTime,
                            Stakes = session.Stakes,
                        });
                    }
                    result = "Success";
                }
                catch
                {
                    result = "This session was not saved.";
                }
            }
            return result;
        }

        public string DeleteSession(int sessionId)
        {
            string result = string.Empty;
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                var existingSession = (db.Table<Sessions>().Where(
                    s => s.Id == sessionId)).Single();

                db.RunInTransaction(() =>
                {
                    if (db.Delete(existingSession) > 0)
                    {
                        result = "Success";
                    }
                    else
                    {
                        result = "This session was not removed";
                    }
                });
            }
            return result;
        }
        #endregion  
    }
}
