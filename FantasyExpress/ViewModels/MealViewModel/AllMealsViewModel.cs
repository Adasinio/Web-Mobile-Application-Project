using FantasyExpress.ViewModels.Abstract;
using FantasyExpress.Views.MealViews;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FantasyExpress.ViewModels.MealViewModel
{
    public class AllMealsViewModel : BaseViewModel
    {
        private ObservableCollection<MealForView> _meals;
        public ObservableCollection<MealForView> Meals
        {
            get { return _meals; }
            set { SetProperty(ref _meals, value); }
        }

        public AllMealsViewModel()
        {
            Meals = new ObservableCollection<MealForView>();
        }

        public async Task OnAppearing(int restaurantId)
        {
            Loading = true;
            var service = new swaggerClient("http://localhost:5233/", HttpClient);
            var allMeals = await service.MealsForViewAllAsync(restaurantId);
            Meals = new ObservableCollection<MealForView>(allMeals);
            await Task.Delay(1000);
            Loading = false;
        }

        private bool _loading = true;
        public bool Loading
        {
            get => _loading;
            set
            {
                SetProperty(ref _loading, value);
                OnPropertyChanged(nameof(Loaded));
            }
        }

        public bool Loaded => !Loading;
    }
}
