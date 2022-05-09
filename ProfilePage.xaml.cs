using System;
using System.Collections.Generic;
using spacex_explore.ViewModels;
using Xamarin.Forms;

namespace spacex_explore.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();           
        }

        async void showFavBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            MessagingCenter.Send(this, "push_fav");
        }

        async void signOutBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}
