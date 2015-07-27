﻿using App1.Models;
using System.ComponentModel;
using System.Linq;

namespace App1.ViewModels
{
    public class PlayerViewModel
    {

        #region Properties

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

        private string firstname;
        public string FirstName
        {
            get { return firstname; }

            set
            {
                if (firstname == value) { return; }

                firstname = value;
                RaisePropertyChanged("FirstName");
            }
        }

        private string lastname;
        public string LastName
        {
            get { return lastname; }

            set
            {
                if (lastname == value) { return; }

                lastname = value;
                RaisePropertyChanged("LastName");
            }
        }

        private string note;
        public string Note
        {
            get { return note; }

            set
            {
                if (note == value) { return; }

                note = value;
                RaisePropertyChanged("Note");
            }
        }

        private int aggressive;
        public int Aggressive
        {
            get { return aggressive; }

            set
            {
                if (aggressive == value) { return; }

                aggressive = value;
                RaisePropertyChanged("Aggressive");
            }
        }

        private int tight;
        public int Tight
        {
            get { return tight; }

            set
            {
                if (tight == value) { return; }

                tight = value;
                RaisePropertyChanged("Tight");
            }
        }

        #endregion "Properties"

        #region Methods
        public PlayerViewModel GetPlayer(int playerId)
        {
            var player = new PlayerViewModel();
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                var _player = (db.Table<Player>().Where(
                    s => s.Id == playerId)).Single();
                player.Id = _player.Id;
                player.FirstName = _player.FirstName;
                player.LastName = _player.LastName;
                player.Aggressive = _player.Aggressive;
                player.Tight = _player.Tight;
                player.Note = _player.Note;
            }

            return player;
        }

        public string SavePlayer(PlayerViewModel player)
        {
            string result = string.Empty;
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                try
                {
                    var existingPlayer = (db.Table<Player>().Where(
                        s => s.Id == player.Id)).SingleOrDefault();

                    if (existingPlayer != null)
                    {
                        existingPlayer.FirstName = player.FirstName;
                        existingPlayer.LastName = player.LastName;
                        existingPlayer.Aggressive = player.Aggressive;
                        existingPlayer.Tight = player.Tight;
                        existingPlayer.Note = player.Note;

                        int success = db.Update(existingPlayer);
                    }
                    else
                    {
                        int success = db.Insert(new Player()
                        {
                            FirstName = player.FirstName,
                            LastName = player.LastName,
                            Aggressive = player.Aggressive,
                            Tight = player.Tight,
                            Note = player.Note,
                        });
                    }
                    result = "Success";
                }
                catch
                {
                    result = "This player was not saved.";
                }
            }
            return result;
        }

        public string DeletePlayer(int playerId)
        {
            string result = string.Empty;
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                var existingPlayer = (db.Table<Player>().Where(
                    s => s.Id == playerId)).Single();

                db.RunInTransaction(() =>
                {
                    if (db.Delete(existingPlayer) > 0)
                    {
                        result = "Success";
                    }
                    else
                    {
                        result = "This player was not removed";
                    }
                });
            }
            return result;
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
