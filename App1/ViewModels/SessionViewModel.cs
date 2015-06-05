﻿﻿using App1.Models;
using System;
using System.Linq; 

namespace App1.ViewModels
{
    public class SessionViewModel : ViewModelBase
    {
        #region Properties

        private int id = 0;
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

        private double buyin = 0;
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

        private double cashout = 0;
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

        private double profit = 0;
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

        private DateTime sessiondate = DateTime.Now;
        public DateTime SessionDate
        {
            get { return sessiondate; }

            set
            {
                if (sessiondate == value) { return; }

                sessiondate = value;
                RaisePropertyChanged("SessionDate");
            }
        }

        private string sessiontime = string.Empty;
        public string SessionTime
        {
            get { return sessiontime; }

            set
            {
                if (sessiontime == value) { return; }

                sessiontime = value;
                RaisePropertyChanged("SessionTime");
            }
        }
        

        #endregion "Properties" 

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
                session.SessionDate = _session.SessionDate;
                session.SessionTime = _session.SessionTime;
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
                        existingSession.Stakes = session.Stakes;
                        existingSession.GameName = session.GameName;
                        existingSession.Location = session.Location;
                        existingSession.BuyIn = session.BuyIn;
                        existingSession.CashOut = session.CashOut;
                        existingSession.SessionDate = session.SessionDate;
                        existingSession.SessionTime = session.SessionTime;
                        int success = db.Update(existingSession);
                    }
                    else
                    {
                        int success = db.Insert(new Sessions()
                        {
                            Stakes = session.Stakes,
                            GameName = session.GameName,
                            Location = session.Location,
                            BuyIn = session.BuyIn,
                            CashOut = session.CashOut,
                            SessionDate = session.SessionDate,
                            SessionTime = session.SessionTime
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
    }
}
