using FantasyExpress.ViewModels.MealViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FantasyExpress.Views.MealViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MealView : ContentPage
    {

        MealViewModel _mealViewModel;
        int _mealId;
        
        public MealView(int mealId)
        {
            InitializeComponent();
            BindingContext = _mealViewModel = new MealViewModel();
            _mealId = mealId;
        }

        private void OnLogoTapped(object sender, EventArgs e)
        {

            Navigation.PushAsync(new AboutPage());
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await _mealViewModel.OnAppearing(_mealId);
        }
    }
}