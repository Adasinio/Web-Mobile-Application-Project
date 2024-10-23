using FantasyExpress.ViewModels.Abstract;
using System;
using FantasyExpress.Services;
using FantasyExpress.Helpers;
using System.Collections.Generic;
using System.Text;

namespace FantasyExpress.ViewModels.PaymentVieModel
{
    internal class NewPaymentViewModel : ANewItemViewModel<Payment>
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

        public NewPaymentViewModel()
: base()
        {

        }
        public override Payment SetItem()
        {
            var result = new Payment().CopyProperties(this);
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
