﻿using App1.Models;
using System;
using System.Linq;
using Windows.UI.Xaml.Controls;
using System.Collections.Generic;

namespace App1.ViewModels
{
    public class TourneyViewModel : ViewModelBase
    {
        public TourneyViewModel() 
        {
            GameNames = new List<string> { "No Limit Texas Holdem", "Pot Limit Texas Holdem", "Limit Texas Holdem", "PL Omaha" };
            Locations = new List<string> { "Casino", "Online", "Homegame" }; 
        }

        #region Properties

        public List<string> GameNames { get; set; }
        public List<string> Locations { get; set; }

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

        private double place;
        public double Place
        {
            get { return place; }

            set
            {
                if (place == value) { return; }

                place = value;
                RaisePropertyChanged("Place");
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
            get { return endtime - starttime; }
        }


        #endregion

        #region Methods
        public TourneyViewModel GetTourney(int tourneyId)
        {
            var tourney = new TourneyViewModel();
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                var _tourney = (db.Table<Tourney>().Where(
                    s => s.Id == tourneyId)).Single();
                tourney.Id = _tourney.Id;
                tourney.Place = _tourney.Place;
                tourney.GameName = _tourney.GameName;
                tourney.Location = _tourney.Location;
                tourney.BuyIn = _tourney.BuyIn;
                tourney.CashOut = _tourney.CashOut;
                tourney.StartDate = _tourney.StartDate;
                tourney.StartTime = _tourney.StartTime;
                tourney.EndDate = _tourney.EndDate;
                tourney.EndTime = _tourney.EndTime;
            }

            return tourney;
        }

        public string SaveSession(TourneyViewModel tourney)
        {
            string result = string.Empty;
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                try
                {
                    var existingTourney = (db.Table<Tourney>().Where(
                        s => s.Id == tourney.Id)).SingleOrDefault();

                    if (existingTourney != null)
                    {
                        existingTourney.BuyIn = tourney.BuyIn;
                        existingTourney.Place = tourney.Place;
                        existingTourney.GameName = tourney.GameName;
                        existingTourney.Location = tourney.Location;
                        existingTourney.Profit = tourney.Profit;
                        existingTourney.StartDate = tourney.StartDate;
                        existingTourney.StartTime = tourney.StartTime;
                        existingTourney.EndDate = tourney.EndDate;
                        existingTourney.EndTime = tourney.EndTime;
                        existingTourney.CashOut = tourney.CashOut;

                        int success = db.Update(existingTourney);
                    }
                    else
                    {
                        int success = db.Insert(new Tourney()
                        {
                            BuyIn = tourney.BuyIn,
                            CashOut = tourney.CashOut,
                            GameName = tourney.GameName,
                            Location = tourney.Location,
                            Profit = tourney.Profit,
                            StartDate = tourney.StartDate,
                            StartTime = tourney.StartTime,
                            EndDate = tourney.EndDate,
                            EndTime = tourney.EndTime
                            //Place = tourney.Place,
                        });
                    }
                    result = "Success";
                }
                catch
                {
                    result = "This tourney was not saved.";
                }
            }
            return result;
        }

        public string DeleteSession(int tourneyId)
        {
            string result = string.Empty;
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                var existingTourney = (db.Table<Tourney>().Where(
                    s => s.Id == tourneyId)).Single();

                db.RunInTransaction(() =>
                {
                    if (db.Delete(existingTourney) > 0)
                    {
                        result = "Success";
                    }
                    else
                    {
                        result = "This tourney was not removed";
                    }
                });
            }
            return result;
        }
        #endregion 
    }
}
