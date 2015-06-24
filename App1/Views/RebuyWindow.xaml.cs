using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using App1.Utils;

namespace App1.Views
{
    public partial class RebuyWindow : UserControl
    {
        public EventHandler<TappedRoutedEventArgs> okBtnTapped;
        public EventHandler<TappedRoutedEventArgs> cancelBtnTapped;

        public RebuyWindow()
        {
            this.InitializeComponent();
        }

        public void okBtn_Click(object sender, RoutedEventArgs e)
        {
            if (okBtnTapped != null)
            {
                var buyInAmount = this.rebuyAmount.Text;
                if (String.IsNullOrEmpty(buyInAmount))
                {
                    GeneralUtil.ShowMessage("The buy in amount can not be empty.");
                    return;
                }
                else
                {
                    this.RebuyAmount = Convert.ToInt32(buyInAmount);
                    okBtnTapped(this, null);
                }                
            }                
        }

        public void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (cancelBtnTapped != null)
                cancelBtnTapped(this, null);
        }
        public int RebuyAmount { get; set; }

        public void FocusInputBox()
        {
            this.rebuyAmount.Focus(FocusState.Pointer);
        }
    }
}
