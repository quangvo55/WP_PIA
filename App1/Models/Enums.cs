﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Models
{
    public enum SessionMode
    {
        New,
        Completed,
        Running,
        Paused,
        Stopped,
        Edit,
    }

    public enum GameType
    {   
        Cash,
        Tournament
    }
}
