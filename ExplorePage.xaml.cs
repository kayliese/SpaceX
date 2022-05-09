using System;
using System.Collections.Generic;
using spacex_explore.ViewModels;
using Xamarin.Forms;

namespace spacex_explore.Views
{
    public partial class ExplorePage : ContentPage
    {
        //MainViewModel mainViewModel;
        public ExplorePage()
        {
            InitializeComponent();

            //BindingContext = mainViewModel = new MainViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Send("ms", "RefreshData");
        }

        async void favBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            //var view = (ImageButton)sender;           
            //await mainViewModel.MakeFav(view.ClassId);
        }
    }
}
