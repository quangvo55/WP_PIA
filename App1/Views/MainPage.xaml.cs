using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using App1.ViewModels;
using App1.Common;

namespace App1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //SessionsViewModel sessionsViewModel = null;
        //ObservableCollection<SessionViewModel> sessions = null; 
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void newSessionTapped(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SessionPage));
        }

        private void completedSessionTapped(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SessionPage));
        }

        private void allSessionsTapped(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AllSessions));
        }
    }
}
