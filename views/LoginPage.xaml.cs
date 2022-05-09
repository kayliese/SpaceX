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

            //testing purpose only
            emailEnt.Text = "stephlowk@gmail.com";
            passwordEnt.Text = "Stephanie121^";
        }

        async void signUpTap_Tapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }

        async void signBtn_Clicked(System.Object sender, System.EventArgs e)
        {
    /*        if (string.IsNullOrWhiteSpace(emailEnt.Text) || string.IsNullOrWhiteSpace(passwordEnt.Text))
            {
                await DisplayAlert("Error", "Please fill all the fields.", "OK");
                return;
            }

            if (!commonService.IsValidEmail(emailEnt.Text))
            {
                await DisplayAlert("Error", "Please enter a valid email address.", "OK");
                return;
            }
            
            var result = await mainViewModel.Login(new LoginModel { email = emailEnt.Text.Trim(), password = passwordEnt.Text.Trim()});
    */
          //  if (result)
          //  {                
                Application.Current.MainPage = new NavigationPage(new TabPage());
          //  }
          //  else
           // {
           //     await DisplayAlert("Login faild", "Please check your email and password again.", "OK");
          //  }
        }
    }
}
