using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using App1.Views;

namespace App1.Utils
{
    public class AddItemHelper
    {
        Page parentPage;
        public Popup popupWindow;
        AddItem addItemWindow;
        public EventHandler<RoutedEventArgs> confirmBtnTapped;
        public string txtInput;
        public bool parentHasBottomAppBar;

        public AddItemHelper(Page parentPage, string ItemText) 
        {
            this.parentPage = parentPage;
            this.CreatePopupWindow(ItemText);
            this.parentHasBottomAppBar = this.parentPage.BottomAppBar != null;
        }

        private void CreatePopupWindow(string ItemText)
        {
            popupWindow = new Popup();
            popupWindow.VerticalOffset = 0;
            addItemWindow = new AddItem(ItemText);
            addItemWindow.Height = Window.Current.Bounds.Height;
            popupWindow.Child = addItemWindow;
            popupWindow.IsOpen = true;

            if (parentHasBottomAppBar) parentPage.BottomAppBar.Visibility = Visibility.Collapsed;

            addItemWindow.okBtnTapped += okBtnTapped;
            addItemWindow.cancelBtnTapped += btnCancelTapped;
            addItemWindow.FocusInputBox();
        }

        private void okBtnTapped(object sender, RoutedEventArgs e)
        {
            popupWindow.IsOpen = false;
            this.txtInput = addItemWindow.TextInput;

            if (parentHasBottomAppBar) parentPage.BottomAppBar.Visibility = Visibility.Visible;
            if (confirmBtnTapped != null) confirmBtnTapped(this, null);
        }

        private void btnCancelTapped(object sender, RoutedEventArgs e)
        {
            popupWindow.IsOpen = false;
            if (parentHasBottomAppBar) parentPage.BottomAppBar.Visibility = Visibility.Visible;
        }
    }
}
