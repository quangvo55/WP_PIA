using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using App1.Utils;

namespace App1.Views
{
    public sealed partial class AddStakes : UserControl
    {
        public EventHandler<TappedRoutedEventArgs> confirmBtnTapped;
        public EventHandler<TappedRoutedEventArgs> cancelBtnTapped;
        public string LowAmount { get; set; }
        public string HighAmount { get; set; }

        public AddStakes()
        {
            this.InitializeComponent();
        }

        public void okBtn_Click(object sender, RoutedEventArgs e)
        {
            if (confirmBtnTapped != null)
            {
                var lowAmount = this.LowAmount = this.lowAmount.Text;
                var highAmount = this.HighAmount = this.highAmount.Text;
                if (String.IsNullOrEmpty(lowAmount) || String.IsNullOrEmpty(lowAmount))
                {
                    GeneralUtil.ShowMessage("The high and low amount can not be empty.");
                    return;
                }
                else
                {
                    confirmBtnTapped(this, null);
                }
            }
        }

        public void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (cancelBtnTapped != null)
                cancelBtnTapped(this, null);
        }

        public void FocusInputBox()
        {
            this.lowAmount.Focus(FocusState.Pointer);
        }
    }
}
