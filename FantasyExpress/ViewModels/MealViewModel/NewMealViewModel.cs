using FantasyExpress.Services;
using FantasyExpress.Helpers;
using FantasyExpress.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyExpress.ViewModels.MealViewModel
{
    internal class NewMealViewModel : ANewItemViewModel<Meal>
    {

        #region Fields

        private string name;
        private string description;
        private decimal price;
        private bool isActive;
        private DateTime createdDate;
        private DateTime modifiedDate;
        private string url;
        private MealType selectedMealType;
        private List<MealType> mealTypeList;
        private Restaurant selectedRestaurant;
        private List<Restaurant> restaurantList;

        #endregion

        #region Properties

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public decimal Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }

        public bool IsActive
        {
            get => isActive;
            set => SetProperty(ref isActive, value);
        }

        public DateTime CreatedDate
        {
            get => createdDate;
            set => SetProperty(ref createdDate, value);
        }

        public DateTime ModifiedDate
        {
            get => modifiedDate;
            set => SetProperty(ref modifiedDate, value);
        }

        public string Url
        {
            get => url;
            set => SetProperty(ref url, value);
        }
        public MealType SelectedMealType
        {
            get => selectedMealType;
            set => SetProperty(ref selectedMealType, value);
        }
        public List<MealType> MealTypeList
        {
            get => mealTypeList;
        }

        public Restaurant SelectedRestaurant
        {
            get => selectedRestaurant;
            set => SetProperty(ref selectedRestaurant, value);
        }
        public List<Restaurant> RestaurantList
        {
            get => restaurantList;
        }

        #endregion

        public NewMealViewModel()
: base()
        {
            var mealtypedatastore = new MealTypeDataStore();
            mealtypedatastore.Refresh();
            var restaurantdatastore = new RestaurantDataStore();
            restaurantdatastore.Refresh();
            mealTypeList = mealtypedatastore.items;
            selectedMealType = new MealType();
            restaurantList = restaurantdatastore.items;
            selectedRestaurant = new Restaurant();
        }
        public override Meal SetItem()
        {
            var result = new Meal().CopyProperties(this);
            result.CreatedDate = DateTime.Now;
            result.IsActive = true;
            result.MealTypeId = selectedMealType.Id;
            result.RestaurantId = selectedRestaurant.Id;

            return result;
        }

        public override bool ValidateSave()
        {
            return true;
        }
    }
}
