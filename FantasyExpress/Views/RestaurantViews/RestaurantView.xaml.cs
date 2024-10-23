using FantasyExpress.ViewModels.MealViewModel;
using FantasyExpress.ViewModels.RestaurantViewModel;
using FantasyExpress.Views.MealViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FantasyExpress.Views.RestaurantViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantView : ContentPage
    {

        RestaurantViewModel _restaurantViewModel;
        int _restaurantId;

        public RestaurantView(int restaurantId)
        {
            InitializeComponent();
            BindingContext = _restaurantViewModel = new RestaurantViewModel();
            _restaurantId = restaurantId;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AllMealsView(_restaurantId));
        }

        private void OnLogoTapped(object sender, EventArgs e)
        {

            Navigation.PushAsync(new AboutPage());
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await _restaurantViewModel.OnAppearing(_restaurantId);
        }
    }
}