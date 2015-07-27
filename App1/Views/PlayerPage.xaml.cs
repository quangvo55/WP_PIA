using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using App1.ViewModels;

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

            this.DataContext = player;
        }
    }
}
