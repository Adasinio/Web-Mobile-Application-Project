using FantasyExpress.ViewModels.MealViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FantasyExpress.Views.MealViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllMealsView : ContentPage
    {
        int _restaurantId;
        AllMealsViewModel _allMealsViewModel;

        public AllMealsView(int restaurantId)
        {
            InitializeComponent();
            BindingContext = _allMealsViewModel = new AllMealsViewModel();
            _restaurantId = restaurantId;
        }

        private async void OnMealSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedMeal = (MealForView)e.SelectedItem;
            await Navigation.PushAsync(new MealView(selectedMeal.Id));

            mealListView.SelectedItem = null;
        }

        private void OnLogoTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AboutPage());
        }
        private void NewMealButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewMealView());
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await _allMealsViewModel.OnAppearing(_restaurantId);
        }
    }
}