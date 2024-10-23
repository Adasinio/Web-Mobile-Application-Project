using FantasyExpress.Views.MealViews;
using FantasyExpress.Views.RestaurantViews;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FantasyExpress.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();

        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new AllRestaurantsView());
        }
    }
}