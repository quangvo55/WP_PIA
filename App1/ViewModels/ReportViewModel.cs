using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using App1.Models;

namespace App1.ViewModels
{
    public class ReportViewModel
    {
        #region Properties
        public TimeSpan _totalDuration = new TimeSpan(0,0,0,0,0);
        public TimeSpan TotalDuration
        {
            get { return _totalDuration; }

            set
            {
                if (_totalDuration == value) { return; }

                _totalDuration = value;
                RaisePropertyChanged("TotalDuration");
            }
        }

        public Double _totalProfit;
        public Double TotalProfit
        {
            get { return _totalProfit; }

            set
            {
                if (_totalProfit == value) { return; }

                _totalProfit = value;
                RaisePropertyChanged("TotalProfit");
            }
        }

        public Double DollarPerHour 
        { 
            get { return _totalProfit/_totalDuration.TotalHours; }
            set { }
        }

        public Double SessionCount
        {
            get; set;
        }

        public Double _cashed = 0;
        public Double Cashed
        {    
            get { return _cashed; }

            set
            {
                if (_cashed == value) { return; }

                _cashed = value;
                RaisePropertyChanged("Cashed");
            }
        }

        public Double DollarPerSession
        {
            get { return _totalProfit / SessionCount; }
            set { }
        } 

        public Double Bankroll;
        public Double DollarPerHourStDev;

        protected List<SessionViewModel> Sessions = null;
        protected List<TourneyViewModel> Tournies = null;
        #endregion

        public ReportViewModel(GameType gameType)
        {
            if (gameType == GameType.Cash)
            {
                Sessions = new List<SessionViewModel>(new SessionsViewModel().GetSessions());
                CalculateStats(Sessions);
            }
            else
            {
                Tournies = new List<TourneyViewModel>(new TourniesViewModel().GetTournies());
                CalculateStats(Tournies);
            }
                

            //if (Sessions != null  && Sessions.Count > 0)
            //    CalculateStats(Sessions);
            //else if (Tournies != null && Tournies.Count > 0)
            //    CalculateStats(Tournies);
        }

        private void CalculateStats(List<SessionViewModel> sessions)
        {
            SessionCount = sessions.Count;

            foreach (var session in sessions)
            {
                _totalDuration += session.Duration;
                _totalProfit += session.Profit;
                if (session.Profit > 0) _cashed++;
            }
        }

        private void CalculateStats(List<TourneyViewModel> tournies)
        {
            SessionCount = tournies.Count;

            foreach (var tourney in tournies)
            {
                _totalDuration += tourney.Duration;
                _totalProfit += tourney.Profit;
                if (tourney.Profit > 0) _cashed++;
            }
        }

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
