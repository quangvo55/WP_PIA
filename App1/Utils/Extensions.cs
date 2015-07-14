using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Utils
{
    public static class Extensions
    {
        public static string ToHHMMString(this TimeSpan span)
        {
            var totalHours = (span.TotalHours < 10) ? "0" + Math.Floor(span.TotalHours).ToString() : Math.Floor(span.TotalHours).ToString();
            var minutes = (span.Minutes < 10) ? "0" + span.Minutes.ToString() : span.Minutes.ToString();
            return String.Format("{0}:{1}", totalHours, minutes);
        }
    }
}
