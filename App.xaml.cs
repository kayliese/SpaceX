using System;
using spacex_explore.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace spacex_explore
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new LoginPage());
            Nav();

            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            Nav();
        }

        void Nav()
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            { 
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NoInternetPage();
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
