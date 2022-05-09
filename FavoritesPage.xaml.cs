using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace spacex_explore.Views
{
    public partial class FavoritesPage : ContentPage
    {
        public FavoritesPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Send("ms", "RefreshData");
        }

        async void backBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
