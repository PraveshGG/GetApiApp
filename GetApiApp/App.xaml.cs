using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace GetApiApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new GetApiApp.MainPage());
        }

        public static string DatabasePath = string.Empty;

        public App(string databasePath)
        {
            InitializeComponent();

            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                // Connection to internet is available
                MainPage = new NavigationPage(new GetApiApp.MainPage());

            }
            else
            {
                MainPage = new NavigationPage(new GetApiApp.SavedPosts());

            }


            DatabasePath = databasePath;

        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
