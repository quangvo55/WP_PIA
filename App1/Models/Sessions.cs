using System;
using SQLite;

namespace App1.Models
{
    public class Sessions
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Stakes { get; set; }
        public string GameName { get; set; }
        public string Location { get; set; }
        public double BuyIn { get; set; }
        public double CashOut { get; set; }
        public double Profit { get; set; }
        public DateTime SessionDate { get; set; }
        public TimeSpan SessionTime { get; set; }
    }
}
