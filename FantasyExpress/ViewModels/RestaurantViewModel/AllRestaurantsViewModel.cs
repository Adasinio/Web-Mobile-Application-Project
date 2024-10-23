using FantasyExpress.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace FantasyExpress.ViewModels.RestaurantViewModel
{
    public class AllRestaurantsViewModel : BaseViewModel
    {
        private ObservableCollection<Restaurant> _restaurants;

        public ObservableCollection<Restaurant> Restaurants
        {
            get { return _restaurants; }
            set { SetProperty(ref _restaurants, value);}
        }
        
        public AllRestaurantsViewModel()
        {
            Restaurants = new ObservableCollection<Restaurant>();
        }

        public async Task OnAppearing() 
        {
            Loading = true;
            var service = new swaggerClient("http://localhost:5233/", HttpClient);
            var allRestaurants = await service.RestaurantsAllAsync();
            Restaurants = new ObservableCollection<Restaurant>(allRestaurants);
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
