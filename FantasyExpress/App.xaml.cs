using FantasyExpress.Services;
using FantasyExpress.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FantasyExpress
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            DependencyService.Register<MealDataStore>();
            DependencyService.Register<RestaurantDataStore>();
            DependencyService.Register<MealTypeDataStore>();
            DependencyService.Register<OrderDataStore>();
            DependencyService.Register<PaymentDataStore>();
            DependencyService.Register<DeliveryDataStore>();
            MainPage = new AppShell();
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
