using System;
using System.Collections.Generic;
using spacex_explore.Models;
using spacex_explore.Services;
using spacex_explore.ViewModels;
using Xamarin.Forms;

namespace spacex_explore.Views
{
    public partial class RegistrationPage : ContentPage
    {
        MainViewModel mainViewModel;
        CommonService commonService;

        public RegistrationPage()
        {
            InitializeComponent();

            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.Black;

            BindingContext = mainViewModel = new MainViewModel();
            commonService = new CommonService();
        }

        async void signInTap_Tapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void signUpBtn_Clicked(System.Object sender, System.EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(fullnameEnt.Text) || string.IsNullOrWhiteSpace(emailEnt.Text) || string.IsNullOrWhiteSpace(passwordEnt.Text)
                || string.IsNullOrWhiteSpace(conPasswordEnt.Text))
            {
                await DisplayAlert("Error", "Please fill all the fields.", "OK");
                return;
            }

            if (!commonService.IsValidEmail(emailEnt.Text))
            {
                await DisplayAlert("Error", "Please enter a valid email address.", "OK");
                return;
            }

            if (!passwordEnt.Text.ToUpper().Equals(conPasswordEnt.Text.ToUpper()))
            {
                await DisplayAlert("Error", "Passwords are not matched. Please enter again.", "OK");
                return;
            }

            var user = new RegistrationModel
            {
                email = emailEnt.Text.Trim(),
                fullname = fullnameEnt.Text.Trim(),
                password = passwordEnt.Text.Trim()
            };

            var result = await mainViewModel.Register(user);

            if (result)
            {
                await DisplayAlert("Success", "User account created successfully. Login to continue", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}
