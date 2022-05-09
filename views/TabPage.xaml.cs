using System;
using System.Collections.Generic;
using spacex_explore.ViewModels;
using Xamarin.Forms;

namespace spacex_explore.Views
{
    public partial class TabPage : TabbedPage
    {
        public TabPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<ProfilePage>(this, "push_fav", async (ex) => {
                await Navigation.PushAsync(new FavoritesPage());
            });
        }        
    }
}
