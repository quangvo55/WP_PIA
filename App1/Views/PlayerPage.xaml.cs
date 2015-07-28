using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Navigation;
using App1.ViewModels;
using App1.Utils;

namespace App1.Views
{
    public sealed partial class PlayerPage : Page
    {
        PlayerViewModel player = new PlayerViewModel();
        public PlayerPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                player = (PlayerViewModel)e.Parameter;
            }
            else
            {
                HideDeleteButton();
            }

            this.DataContext = player;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(firstName.Text))
            {
                GeneralUtil.ShowMessage("The first name field is required.");
                return;
            }

            player.FirstName = this.firstName.Text;
            player.LastName = (string.IsNullOrEmpty(this.lastName.Text)) ? "" :  this.lastName.Text ;
            player.Aggressive = this.aggresssive.Value;
            player.Tight = this.tight.Value;
            player.Note = this.notes.Text;

            string result = player.SavePlayer(player);
            if (result.Contains("Success"))
            {
                this.Frame.Navigate(typeof(AllPlayers));
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string result = player.DeletePlayer(player.Id);
            if (result.Contains("Success"))
            {
                this.Frame.Navigate(typeof(AllPlayers));
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void HideDeleteButton()
        {
            var btn = (AppBarButton)bottomAppBar.PrimaryCommands.ElementAtOrDefault(1);
            btn.Visibility = Visibility.Collapsed;
        }

    }
}
