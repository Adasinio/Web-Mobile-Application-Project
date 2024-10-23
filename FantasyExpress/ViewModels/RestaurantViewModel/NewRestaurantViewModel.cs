using System;
using FantasyExpress.Services;
using FantasyExpress.Helpers;
using System.Collections.Generic;
using System.Text;
using FantasyExpress.ViewModels.Abstract;

namespace FantasyExpress.ViewModels.RestaurantViewModel
{
    internal class NewRestaurantViewModel : ANewItemViewModel<Restaurant>
    {
        #region Fields
        private string name;
        private string description;
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
        #endregion

        public NewRestaurantViewModel()
: base()
        {

        }
        public override Restaurant SetItem()
        {
            var result = new Restaurant().CopyProperties(this);
            result.CreatedDate = DateTime.Now;
            result.IsActive = true;
            return result;
        }

        public override bool ValidateSave()
        {
            return true;
        }


    }
}
