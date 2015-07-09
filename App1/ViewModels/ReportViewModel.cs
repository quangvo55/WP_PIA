using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using App1.Models;

namespace App1.ViewModels
{
    public class ReportViewModel
    {
        public TimeSpan Duration;
        public Double   Profit;
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
                //TODO add duration > 24hrs
                var dur = session.Duration;
                var dur1 = TimeSpan.Parse(dur);
                Duration += dur1;
            }
            System.Diagnostics.Debug.WriteLine(Duration);
        }
        private void CalculateStats(List<TourneyViewModel> tournies)
        {

        }
    }
}
