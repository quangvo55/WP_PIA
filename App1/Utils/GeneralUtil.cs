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
            if (startDate == null || startTime == null || endDate == null || endTime == null) return "00:00";

            var startDateFormatted = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0);
            startDateFormatted = startDateFormatted.Add(startTime);

            var endDateFormatted = new DateTime(endDate.Year, endDate.Month, endDate.Day, 0, 0, 0);
            endDateFormatted = endDateFormatted.Add(endTime);

            var diff = (endDateFormatted - startDateFormatted);
            var totalHours = (diff.TotalHours < 10) ? "0" + Math.Floor(diff.TotalHours).ToString() : Math.Floor(diff.TotalHours).ToString();
            var minutes = (diff.Minutes < 10) ? "0" + diff.Minutes.ToString() : diff.Minutes.ToString();
            return String.Format("{0}:{1}", totalHours, minutes);
        }

        //http://www.davekoelle.com/files/AlphanumComparator.cs
        private enum ChunkType { Alphanumeric, Numeric };
        private static bool InChunk(char ch, char otherCh)
        {
            ChunkType type = ChunkType.Alphanumeric;

            if (char.IsDigit(otherCh))
            {
                type = ChunkType.Numeric;
            }

            if ((type == ChunkType.Alphanumeric && char.IsDigit(ch))
                || (type == ChunkType.Numeric && !char.IsDigit(ch)))
            {
                return false;
            }

            return true;
        }
        public static int AlphaNumCompare(string s1, string s2)
            {
                if (s1 == null || s2 == null)
                {
                    return 0;
                }

                int thisMarker = 0, thisNumericChunk = 0;
                int thatMarker = 0, thatNumericChunk = 0;

                while ((thisMarker < s1.Length) || (thatMarker < s2.Length))
                {
                    if (thisMarker >= s1.Length)
                    {
                        return -1;
                    }
                    else if (thatMarker >= s2.Length)
                    {
                        return 1;
                    }
                    char thisCh = s1[thisMarker];
                    char thatCh = s2[thatMarker];

                    StringBuilder thisChunk = new StringBuilder();
                    StringBuilder thatChunk = new StringBuilder();

                    while ((thisMarker < s1.Length) && (thisChunk.Length == 0 || InChunk(thisCh, thisChunk[0])))
                    {
                        thisChunk.Append(thisCh);
                        thisMarker++;

                        if (thisMarker < s1.Length)
                        {
                            thisCh = s1[thisMarker];
                        }
                    }

                    while ((thatMarker < s2.Length) && (thatChunk.Length == 0 || InChunk(thatCh, thatChunk[0])))
                    {
                        thatChunk.Append(thatCh);
                        thatMarker++;

                        if (thatMarker < s2.Length)
                        {
                            thatCh = s2[thatMarker];
                        }
                    }

                    int result = 0;
                    // If both chunks contain numeric characters, sort them numerically
                    if (char.IsDigit(thisChunk[0]) && char.IsDigit(thatChunk[0]))
                    {
                        thisNumericChunk = Convert.ToInt32(thisChunk.ToString());
                        thatNumericChunk = Convert.ToInt32(thatChunk.ToString());

                        if (thisNumericChunk < thatNumericChunk)
                        {
                            result = -1;
                        }

                        if (thisNumericChunk > thatNumericChunk)
                        {
                            result = 1;
                        }
                    }
                    else
                    {
                        result = thisChunk.ToString().CompareTo(thatChunk.ToString());
                    }

                    if (result != 0)
                    {
                        return result;
                    }
                }

                return 0;
            }
    }
}
