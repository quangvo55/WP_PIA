using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Windows.Phone.UI.Input;

using App1.Models;
using App1.Views;
using App1.Common;
namespace App1
{
    public sealed partial class App : Application
    {
        public static string DBPath = string.Empty;
        public static int CurrentSessionId { get; set; } 

        public App()
        {
            this.InitializeComponent();
            this.Suspending += this.OnSuspending;
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
            InitFromLocalSettings();            
        }

        protected async override void OnLaunched(LaunchActivatedEventArgs e)
        {

            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null)
            {
                rootFrame = new Frame();
                SuspensionManager.RegisterFrame(rootFrame, "appFrame");  
                rootFrame.CacheSize = 1;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    await SuspensionManager.RestoreAsync();
                } 

                // Get a reference to the SQLite database 
                DBPath = Path.Combine(
                    Windows.Storage.ApplicationData.Current.LocalFolder.Path, "sessions.s3db");
                // Initialize the database if necessary 
                using (var db = new SQLite.SQLiteConnection(DBPath))
                {
                    // Create the tables if they don't exist 
                    db.CreateTable<Sessions>();
                    db.CreateTable<Tourney>();
                }
                
                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null || !String.IsNullOrEmpty(e.Arguments))
            {
                if (!rootFrame.Navigate(typeof(MainPage), e.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            } 
        
            // Ensure the current window is active
            Window.Current.Activate();
        }


        private async void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            await SuspensionManager.SaveAsync();  
            deferral.Complete();
        }

        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            Frame frame = Window.Current.Content as Frame;
            if (frame == null)
            {
                return;
            }

            if (frame.CanGoBack)
            {
                frame.GoBack();
                e.Handled = true;
            }
        }

        private void InitFromLocalSettings()
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            var stakesSaved = localSettings.Values["StakesSaved"];
            if (stakesSaved == null)
            {
                localSettings.Values["StakesSaved"] = new List<string> { "$1/$2", "$2/3", "$3/$5", "$5/$10", "$8/$16", "$20/$40", "New" }.ToArray();
            }

            var gamesSaved = localSettings.Values["GamesSaved"];
            if (gamesSaved == null)
            {
                localSettings.Values["GamesSaved"] = new List<string> { "Texas Holdem", "Omaha", "HORSE", "7 Card Stud", "7 Card Stud 8", "Omaha 8", "Razz", "Black Jack", "New" }.ToArray();
            }

            var locations = localSettings.Values["Locations"];
            if (locations == null)
            {
                localSettings.Values["Locations"] = new List<string> { "Casino", "Online", "Home", "New" }.ToArray();
            }

            var gameTypes = localSettings.Values["GameTypesSaved"];
            if (gameTypes == null)
            {
                localSettings.Values["GameTypesSaved"] = new List<string> { "Sit & Go", "Single Table", "MultiTable", "New" }.ToArray();
            }
        }

    }
}