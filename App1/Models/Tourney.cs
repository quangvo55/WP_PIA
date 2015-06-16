using System;
using SQLite;

namespace App1.Models
{
    public class Tourney : GameTypeBase
    {
        public string GameType { get; set; }
        public double PlayerCount { get; set; }
        public double Rank { get; set; }
    }
}
