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
        public Popup stakesPopup;
        AddStakes addStakesWindow;
        public EventHandler<RoutedEventArgs> confirmBtnTapped;
        public string HighAmount;
        public string LowAmount;
        public bool parentHasBottomAppBar;

        public AddStakesHelper(Page parentPage) 
        {
            this.parentPage = parentPage;
            this.CreatePopupWindow();
            this.parentHasBottomAppBar = this.parentPage.BottomAppBar != null;
        }

        private void CreatePopupWindow()
        {
            stakesPopup = new Popup();
            stakesPopup.VerticalOffset = 0;
            addStakesWindow = new AddStakes();
            addStakesWindow.Height = Window.Current.Bounds.Height;
            stakesPopup.Child = addStakesWindow;
            stakesPopup.IsOpen = true;

            if (parentHasBottomAppBar) parentPage.BottomAppBar.Visibility = Visibility.Collapsed;

            addStakesWindow.confirmBtnTapped += okBtnTapped;
            addStakesWindow.cancelBtnTapped += btnCancelTapped;
            addStakesWindow.FocusInputBox();
        }

        private void okBtnTapped(object sender, RoutedEventArgs e)
        {
            stakesPopup.IsOpen = false;
            
            this.HighAmount = addStakesWindow.HighAmount;
            this.LowAmount = addStakesWindow.LowAmount;

            if (parentHasBottomAppBar) parentPage.BottomAppBar.Visibility = Visibility.Visible;
            if (confirmBtnTapped != null) confirmBtnTapped(this, null);
        }

        private void btnCancelTapped(object sender, RoutedEventArgs e)
        {
            stakesPopup.IsOpen = false;
            if (parentHasBottomAppBar) parentPage.BottomAppBar.Visibility = Visibility.Visible;
        }
    }
}
