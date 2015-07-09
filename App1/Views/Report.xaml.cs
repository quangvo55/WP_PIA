using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Navigation;
using App1.Models;
using App1.ViewModels;

namespace App1.Views
{
    public sealed partial class Report : Page
    {
        private GameType gameType;
        private ReportViewModel reportViewModel;
        public Report()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            gameType = (GameType)e.Parameter;
            if (gameType == GameType.Cash)
            {
                reportViewModel = new ReportViewModel(gameType);
            }
            else
            {
            }
        }
    }
}
