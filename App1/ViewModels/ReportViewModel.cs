using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using App1.Models;

namespace App1.ViewModels
{
    public class ReportViewModel
    {
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
        public Double DollarPerHour;
        public Double Cashed;
        public Double DollarPerSession;
        public Double Tips;
        public Double Bankroll;
        public Double BBPerHour;
        public Double BBPerSession;
        public Double DollarPerHourStDev;
        public Double BBPerHourStDev;
        protected List<SessionViewModel> Sessions = null;
        protected List<TourneyViewModel> Tournies = null;

        public ReportViewModel(GameType gameType)
        {
            if (gameType == GameType.Cash)
                Sessions = new List<SessionViewModel>(new SessionsViewModel().GetSessions());                
            else
                Tournies = new List<TourneyViewModel>(new TourniesViewModel().GetTournies());           

            if (Sessions.Count > 0)
                CalculateStats(Sessions);
            else if (Tournies.Count > 0)
                CalculateStats(Tournies);
        }

        private void CalculateStats(List<SessionViewModel> sessions)
        {
            foreach (var session in sessions)
            {
                _totalDuration += session.Duration;
                _totalProfit += session.Profit;
            }
        }
        private void CalculateStats(List<TourneyViewModel> tournies)
        {

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
