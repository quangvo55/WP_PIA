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
    }
}
