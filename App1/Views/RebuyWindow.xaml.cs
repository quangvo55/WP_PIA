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
        public int RebuyAmount 
        { 
            get { return Convert.ToInt32(this.rebuyAmount.Text); }
        }

        public RebuyWindow()
        {
            this.InitializeComponent();
        }

        public void okBtn_Click(object sender, RoutedEventArgs e)
        {
            if (okBtnTapped != null)
            {
                if (String.IsNullOrEmpty(this.rebuyAmount.Text))
                {
                    GeneralUtil.ShowMessage("The buy in amount can not be empty.");
                    return;
                }
                else
                {
                    okBtnTapped(this, null);
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
            this.rebuyAmount.Focus(FocusState.Pointer);
        }
    }
}
