using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using App1.Views;

namespace App1.Utils
{
    public class RebuyHelper
    {
        Page parentPage;
        Popup popup;
        RebuyWindow rebuyWindow;
        public EventHandler<RoutedEventArgs> OKBtnTapped;
        public int RebuyAmount { get; set; }

        public RebuyHelper(Page parentPage) 
        {
            this.parentPage = parentPage;
            this.CreateRebuyPopup();
        }

        private void CreateRebuyPopup() {
            popup = new Popup();
            popup.VerticalOffset = 180;
            rebuyWindow = new RebuyWindow();
            popup.Child = rebuyWindow;
            popup.IsOpen = true;

            parentPage.BottomAppBar.Visibility = Visibility.Collapsed;
            rebuyWindow.okBtnTapped += okBtnTapped;
            rebuyWindow.cancelBtnTapped += btnCancelTapped;
            rebuyWindow.FocusInputBox();
        }

        private void okBtnTapped(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = false;
            this.RebuyAmount = rebuyWindow.RebuyAmount;
            parentPage.BottomAppBar.Visibility = Visibility.Visible;
            if (OKBtnTapped != null)
                OKBtnTapped(this, null);

        }

        private void btnCancelTapped(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = false;
            parentPage.BottomAppBar.Visibility = Visibility.Visible;
        }
    }
}
