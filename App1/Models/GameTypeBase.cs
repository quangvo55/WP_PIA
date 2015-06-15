using System;
using SQLite;

namespace App1.Models
{
    public class GameTypeBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string GameName { get; set; }
        public string Limit { get; set; }
        public string Location { get; set; }
        public double BuyIn { get; set; }
        public double CashOut { get; set; }
        public double Profit { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
