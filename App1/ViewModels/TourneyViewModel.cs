﻿using App1.Models;
using App1.Utils;
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
            GameTypes = new List<string> { "Sit & Go", "Single Table", "MultiTable"};
            GameNames = new List<string> { "No Limit Texas Holdem", "Pot Limit Texas Holdem", "Limit Texas Holdem", "PL Omaha" };
            Locations = new List<string> { "Casino", "Online", "Homegame" }; 
        }

        #region Properties
        public List<string> GameTypes { get; set; }
        public List<string> GameNames { get; set; }
        public List<string> Locations { get; set; }

        private string gameType = string.Empty;
        public string GameType
        {
            get { return gameType; }

            set
            {
                if (gameType == value) { return; }

                gameType = value;
                RaisePropertyChanged("GameType");
            }
        }
                
        private double rank;
        public double Rank
        {
            get { return rank; }

            set
            {
                if (rank == value) { return; }

                rank = value;
                RaisePropertyChanged("Rank");
            }
        }

        private double playerCount;
        public double PlayerCount
        {
            get { return playerCount; }

            set
            {
                if (playerCount == value) { return; }

                playerCount = value;
                RaisePropertyChanged("PlayerCount");
            }
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
                tourney.GameType = _tourney.GameType;
                tourney.GameName = _tourney.GameName;
                tourney.Location = _tourney.Location;
                tourney.BuyIn = _tourney.BuyIn;
                tourney.CashOut = _tourney.CashOut;
                tourney.StartDate = _tourney.StartDate;
                tourney.StartTime = _tourney.StartTime;
                tourney.EndDate = _tourney.EndDate;
                tourney.EndTime = _tourney.EndTime;
                tourney.Rank = _tourney.Rank;
                tourney.PlayerCount = _tourney.PlayerCount;
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
                        existingTourney.GameType = tourney.GameType;
                        existingTourney.GameName = tourney.GameName;
                        existingTourney.Location = tourney.Location;
                        existingTourney.Profit = tourney.Profit;
                        existingTourney.StartDate = tourney.StartDate;
                        existingTourney.StartTime = tourney.StartTime;
                        existingTourney.EndDate = tourney.EndDate;
                        existingTourney.EndTime = tourney.EndTime;
                        existingTourney.CashOut = tourney.CashOut;
                        existingTourney.Rank = tourney.Rank;
                        existingTourney.PlayerCount = tourney.PlayerCount;

                        int success = db.Update(existingTourney);
                    }
                    else
                    {
                        int success = db.Insert(new Tourney()
                        {
                            BuyIn = tourney.BuyIn,
                            CashOut = tourney.CashOut,
                            GameType = tourney.GameType,
                            GameName = tourney.GameName,
                            Location = tourney.Location,
                            Profit = tourney.Profit,
                            StartDate = tourney.StartDate,
                            StartTime = tourney.StartTime,
                            EndDate = tourney.EndDate,
                            EndTime = tourney.EndTime,
                            Rank = tourney.Rank,
                            PlayerCount = tourney.PlayerCount,
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
