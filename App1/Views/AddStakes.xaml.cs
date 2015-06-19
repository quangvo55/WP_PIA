using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using App1.Utils;

namespace App1.Views
{
    public sealed partial class AddStakes : UserControl
    {
        public EventHandler<TappedRoutedEventArgs> okBtnTapped;
        public EventHandler<TappedRoutedEventArgs> cancelBtnTapped;
        public string LowAmount { get; set; }
        public string HighAmount { get; set; }
        public AddStakes()
        {
            this.InitializeComponent();
        }

        public void okBtn_Click(object sender, RoutedEventArgs e)
        {
            if (okBtnTapped != null)
            {
                var lowAmount  = this.lowAmount.Text;
                var highAmount = this.highAmount.Text;
                if (String.IsNullOrEmpty(lowAmount))
                {
                    GeneralUtil.ShowMessage("The buy in amount can not be empty.");
                    return;
                }

                if (String.IsNullOrEmpty(lowAmount))
                {
                    GeneralUtil.ShowMessage("The buy in amount can not be empty.");
                    return;
                }

                this.LowAmount = lowAmount;
                this.HighAmount = highAmount;
                okBtnTapped(this, null);
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
