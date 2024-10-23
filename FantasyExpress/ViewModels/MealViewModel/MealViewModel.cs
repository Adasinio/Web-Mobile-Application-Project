using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FantasyExpress.ViewModels.Abstract;
using FantasyExpress.Views.MealViews;
using Xamarin.Forms;

namespace FantasyExpress.ViewModels.MealViewModel
{
    public class MealViewModel : BaseViewModel
    {
        public MealViewModel()
        {
        }

        private MealForView _meal;


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

        private decimal _price;
        public decimal Price
        {
            get => _price;
            private set => SetProperty(ref _price, value);
        }
        
        private string _mealTypeName;
        public string MealTypeName
        {
            get => _mealTypeName;
            private set => SetProperty(ref _mealTypeName, value);
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

        internal async Task OnAppearing(int mealId)
        {
            Loading = true;
            var service = new swaggerClient("http://localhost:5233/", HttpClient);
            _meal = await service.MealsForViewGETAsync(mealId);
            Name = _meal.Name;
            Description = _meal.Description;
            Price = Convert.ToDecimal(_meal.Price);
            MealTypeName = _meal.MealTypeData; 
            PhotoUrl = _meal.Url;
            await Task.Delay(1500);
            Loading = false;
        }
    }
}
