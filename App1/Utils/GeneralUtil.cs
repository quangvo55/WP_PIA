using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace App1.Utils
{
    public static class GeneralUtil
    {
        public static void ShowMessage(string text)
        {
            var dialog = new MessageDialog(text);
            dialog.ShowAsync();
        }

        public static string GetDateTimeDifference(DateTime startDate, TimeSpan startTime, DateTime endDate, TimeSpan endTime)
        {
            var startDateFormatted = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0);
            startDateFormatted = startDateFormatted.Add(startTime);

            var endDateFormatted = new DateTime(endDate.Year, endDate.Month, endDate.Day, 0, 0, 0);
            endDateFormatted = endDateFormatted.Add(endTime);

            var diff = (endDateFormatted - startDateFormatted);
            var totalHours = (diff.TotalHours < 10) ? "0" + Math.Floor(diff.TotalHours).ToString() : Math.Floor(diff.TotalHours).ToString();
            var minutes = (diff.Minutes < 10) ? "0" + diff.Minutes.ToString() : diff.Minutes.ToString();
            return String.Format("{0}:{1}", totalHours, minutes);
        }
    }
}
