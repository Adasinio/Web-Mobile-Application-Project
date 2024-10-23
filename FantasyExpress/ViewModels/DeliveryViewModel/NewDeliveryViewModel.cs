using FantasyExpress.ViewModels.Abstract;
using System;
using FantasyExpress.Services;
using FantasyExpress.Helpers;
using System.Collections.Generic;
using System.Text;

namespace FantasyExpress.ViewModels.DeliveryViewModel
{
    internal class NewDeliveryViewModel : ANewItemViewModel<Delivery>
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

        public NewDeliveryViewModel()
: base()
        {

        }
        public override Delivery SetItem()
        {
            var result = new Delivery().CopyProperties(this);
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
