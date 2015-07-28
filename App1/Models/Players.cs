using System;
using SQLite;

namespace App1.Models
{
    public class Player
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Aggressive { get; set; }
        public double Tight { get; set; }
        public string Note { get; set; }
    }
}
