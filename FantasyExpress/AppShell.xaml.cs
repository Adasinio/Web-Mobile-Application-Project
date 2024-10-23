using FantasyExpress.ViewModels;
using FantasyExpress.Views;
using FantasyExpress.Views.DeliveryViews;
using FantasyExpress.Views.MealViews;
using FantasyExpress.Views.PaymentViews;
using FantasyExpress.Views.RestaurantViews;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FantasyExpress
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MealView), typeof(MealView));
            Routing.RegisterRoute(nameof(NewMealView), typeof(NewMealView));
            Routing.RegisterRoute(nameof(NewRestaurantView), typeof(NewRestaurantView));
            Routing.RegisterRoute(nameof(NewPaymentView), typeof(NewPaymentView));
            Routing.RegisterRoute(nameof(NewDeliveryView), typeof(NewDeliveryView));
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
