﻿using App1.Models;
using System.Collections.ObjectModel; 

namespace App1.ViewModels
{
    public class SessionsViewModel : ViewModelBase 
    {
        private ObservableCollection<SessionViewModel> sessions;
        public ObservableCollection<SessionViewModel> Sessions
        {
            get
            {
                return sessions;
            }

            set
            {
                sessions = value;
                RaisePropertyChanged("Sessions");
            }
        }

        public ObservableCollection<SessionViewModel> GetSessions()
        {
            sessions = new ObservableCollection<SessionViewModel>();
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                var query = db.Table<Sessions>().OrderBy(s => s.EndDate);
                foreach (var _session in query)
                {
                    var session = new SessionViewModel()
                    {
                        Id = _session.Id,
                        Stakes = _session.Stakes,
                        GameName = _session.GameName,
                        Location = _session.Location,
                        BuyIn = _session.BuyIn,
                        CashOut = _session.CashOut,
                        Profit = _session.Profit,
                        StartDate = _session.StartDate,
                        StartTime = _session.StartTime,
                        EndDate = _session.EndDate,
                        EndTime = _session.EndTime,
                    };
                    sessions.Add(session);
                }
            }
            return sessions;
        } 
    }
}
