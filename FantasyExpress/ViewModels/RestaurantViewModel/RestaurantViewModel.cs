using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using FantasyExpress.ViewModels.Abstract;
using Xamarin.Forms;

namespace FantasyExpress.ViewModels.RestaurantViewModel
{
    public class RestaurantViewModel : BaseViewModel
    {

        public RestaurantViewModel()
        {
        }

        private Restaurant _restaurant;

        private string _name;

        public string Name
        {
            get => _name;
            private set => SetProperty(ref _name, value);
        }        
        private string _description;

        public string Description
        {
            get => _description;
            private set => SetProperty(ref _description, value);
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

        private const string _noPhotoUrl = "https://freeiconshop.com/wp-content/uploads/edd/image-outline-filled.png";
        private string _photoUrl = _noPhotoUrl;
        public string PhotoUrl
        {
            get => _photoUrl;
            set
            {
                if (string.IsNullOrEmpty(value))
                    SetProperty(ref _photoUrl, _noPhotoUrl);
                else
                    SetProperty(ref _photoUrl, value);
            }
        }

        internal async Task OnAppearing(int restaurantId)
        {
            Loading = true;
            var service = new swaggerClient("http://localhost:5233/", HttpClient);
            _restaurant = await service.RestaurantsGETAsync(restaurantId);
            Name = _restaurant.Name;
            Description = _restaurant.Description;
            await Task.Delay(1500);
            Loading = false;
        }

    }
}
