using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using App1.Views;

namespace App1.Utils
{
    public class AddStakesHelper
    {
        Page parentPage;
        Popup popup;
        AddStakes addStakesWindow;
        public EventHandler<RoutedEventArgs> OKBtnTapped;
        public string HighAmount;
        public string LowAmount;

        public AddStakesHelper(Page parentPage) 
        {
            this.parentPage = parentPage;
            this.CreatePopupWindow();
        }

        private void CreatePopupWindow()
        {
            popup = new Popup();
            popup.VerticalOffset = 0;
            addStakesWindow = new AddStakes();
            addStakesWindow.Height = Window.Current.Bounds.Height;
            popup.Child = addStakesWindow;
            popup.IsOpen = true;

            parentPage.BottomAppBar.Visibility = Visibility.Collapsed;
            addStakesWindow.okBtnTapped += okBtnTapped;
            addStakesWindow.cancelBtnTapped += btnCancelTapped;
            addStakesWindow.FocusInputBox();
        }

        private void okBtnTapped(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = false;
            parentPage.BottomAppBar.Visibility = Visibility.Visible;
            this.HighAmount = addStakesWindow.HighAmount;
            this.LowAmount = addStakesWindow.LowAmount;
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
