using FantasyExpress.Views.DeliveryViews;
using FantasyExpress.Views.MealViews;
using FantasyExpress.Views.PaymentViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FantasyExpress.Views.CartView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartView : ContentPage
    {
        public CartView()
        {
            InitializeComponent();
        }

        private void NewDeliveryButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewDeliveryView());
        }

        private void NewPaymentButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewPaymentView());
        }
    }
}