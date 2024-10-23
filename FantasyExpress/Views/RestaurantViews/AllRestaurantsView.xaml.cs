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
    public partial class AllRestaurantsView : ContentPage
    {

        AllRestaurantsViewModel _allRestaurantsViewModel;

        public AllRestaurantsView()
        {
            InitializeComponent();
            BindingContext = _allRestaurantsViewModel = new AllRestaurantsViewModel();

        }
        private async void OnRestaurantSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedRestaurant = (Restaurant)e.SelectedItem;
            await Navigation.PushAsync(new RestaurantView(selectedRestaurant.Id));

            restaurantListView.SelectedItem = null;
        }
        private void OnLogoTapped(object sender, EventArgs e)
        {

            Navigation.PushAsync(new AboutPage());
        }

        private void NewRestaurantButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewRestaurantView());
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await _allRestaurantsViewModel.OnAppearing();
        }
    }
}