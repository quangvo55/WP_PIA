using App1.Models;
using System.Collections.ObjectModel; 

namespace App1.ViewModels
{
    public class TourniesViewModel : ViewModelBase
    {
        private ObservableCollection<TourneyViewModel> tourneys;
        public ObservableCollection<TourneyViewModel> Tourneys
        {
            get
            {
                return tourneys;
            }

            set
            {
                tourneys = value;
                RaisePropertyChanged("Tourneys");
            }
        }

        public ObservableCollection<TourneyViewModel> GetTournies()
        {
            tourneys = new ObservableCollection<TourneyViewModel>();
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                var query = db.Table<Tourney>().OrderBy(s => s.EndDate);
                foreach (var _tourney in query)
                {
                    var tourney = new TourneyViewModel()
                    {
                        Id = _tourney.Id,
                        CashOut = _tourney.CashOut,
                        GameType = _tourney.GameType,
                        GameName = _tourney.GameName,
                        Location = _tourney.Location,
                        BuyIn = _tourney.BuyIn,
                        Profit = _tourney.Profit,
                        StartDate = _tourney.StartDate,
                        StartTime = _tourney.StartTime,
                        EndDate = _tourney.EndDate,
                        EndTime = _tourney.EndTime,
                        Rank = _tourney.Rank,
                        PlayerCount = _tourney.PlayerCount
                    };
                    tourneys.Add(tourney);
                }
            }
            return tourneys;
        } 
    }    
}
