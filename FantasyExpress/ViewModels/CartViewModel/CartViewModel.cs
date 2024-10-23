using FantasyExpress.Services;
using FantasyExpress.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyExpress.ViewModels.CartViewModel
{
    internal class CartViewModel 
    {
        #region Fields
        private Delivery selectedDelivery;
        private List<Delivery> deliveryList;
        private Payment selectedPayment;
        private List<Payment> paymentList;
        #endregion

        #region Properties

        //public Delivery SelectedDelivery
        //{
        //    get => selectedDelivery;
        //    set => SetProperty(ref selectedDelivery, value);
        //}
        public List<Delivery> DeliveryList
        {
            get => deliveryList;
        }

        //public Payment SelectedPayment
        //{
        //    get => selectedPayment;
        //    set => SetProperty(ref selectedPayment, value);
        //}
        public List<Payment> PaymentList
        {
            get => paymentList;
        }


        #endregion

        public CartViewModel() 
        {
        var deliverydatastore = new DeliveryDataStore();
            deliverydatastore.Refresh();
        var paymentdatastore = new PaymentDataStore();
            paymentdatastore.Refresh();
            deliveryList = deliverydatastore.items;
            paymentList = paymentdatastore.items;

        }

    }
}
