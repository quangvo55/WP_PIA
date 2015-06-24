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
        Popup stakesPopup;
        AddStakes addStakesWindow;
        public EventHandler<RoutedEventArgs> TESTOKBtnTapped;
        public string HighAmount;
        public string LowAmount;

        public AddStakesHelper(Page parentPage) 
        {
            this.parentPage = parentPage;
            this.CreatePopupWindow();
        }

        private void CreatePopupWindow()
        {
            stakesPopup = new Popup();
            stakesPopup.VerticalOffset = 0;
            addStakesWindow = new AddStakes();
            //addStakesWindow.Height = Window.Current.Bounds.Height;
            stakesPopup.Child = addStakesWindow;
            stakesPopup.IsOpen = true;

            parentPage.BottomAppBar.Visibility = Visibility.Collapsed;
            addStakesWindow.confirmBtnTapped += okBtnTapped;
            addStakesWindow.cancelBtnTapped += btnCancelTapped;
            addStakesWindow.FocusInputBox();
        }

        private void okBtnTapped(object sender, RoutedEventArgs e)
        {
            stakesPopup.IsOpen = false;
            parentPage.BottomAppBar.Visibility = Visibility.Visible;
            this.HighAmount = addStakesWindow.HighAmount;
            this.LowAmount = addStakesWindow.LowAmount;
            if (TESTOKBtnTapped != null)
            {
                TESTOKBtnTapped(this, null);
            }
            stakesPopup.IsOpen = false;
        }

        private void btnCancelTapped(object sender, RoutedEventArgs e)
        {
            stakesPopup.IsOpen = false;
            parentPage.BottomAppBar.Visibility = Visibility.Visible;
        }

        public void closePopup()
        {
            stakesPopup.IsOpen = false;
        }
    }
}
