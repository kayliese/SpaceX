using System;
using System.Collections.Generic;
using spacex_explore.Models;
using spacex_explore.Services;
using spacex_explore.ViewModels;
using Xamarin.Forms;

namespace spacex_explore.Views
{
    public partial class LoginPage : ContentPage
    {
        MainViewModel mainViewModel;
        CommonService commonService;
        public LoginPage()
        {
            InitializeComponent();

            BindingContext = mainViewModel = new MainViewModel();
            commonService = new CommonService();
        }

        async void signUpTap_Tapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }

        async void signBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            
                Application.Current.MainPage = new NavigationPage(new TabPage());

        }
    }
}
