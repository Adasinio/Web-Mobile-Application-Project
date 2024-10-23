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
    public partial class NewMealView : ContentPage
    {
        public Meal Item { get; set; }

        public NewMealView()
        {
            InitializeComponent();
            BindingContext = new NewMealViewModel();
        }
    }
}