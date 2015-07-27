using App1.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace App1.ViewModels
{
    public class PlayersViewModel
    {
        private ObservableCollection<PlayerViewModel> players;
        public ObservableCollection<PlayerViewModel> Players
        {
            get
            {
                return players;
            }

            set
            {
                players = value;
                RaisePropertyChanged("Players");
            }
        }

        public ObservableCollection<PlayerViewModel> GetPlayers()
        {
            players = new ObservableCollection<PlayerViewModel>();
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                var query = db.Table<Player>().OrderBy(s => s.FirstName);
                foreach (var _player in query)
                {
                    var player = new PlayerViewModel()
                    {
                        Id = _player.Id,
                        FirstName = _player.FirstName,
                        LastName = _player.LastName,
                        Aggressive = _player.Aggressive,
                        Tight = _player.Tight,
                        Note = _player.Note
                    };
                    players.Add(player);
                }
            }
            return players;
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
