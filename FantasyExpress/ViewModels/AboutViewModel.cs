using FantasyExpress;
using FantasyExpress.Views;
using FantasyExpress.Views.MealViews;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FantasyExpress.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Home";

            //var v = new FantasyExpress.swaggerClient("https://localhost:7124/", new System.Net.Http.HttpClient());
       
            //var res = await v.MealTypesAllAsync();
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));

            OpenAllMealsViewCommand = new Command(async () => await Shell.Current.GoToAsync($"//{nameof(AllMealsView)}"));

        }

        public ICommand OpenWebCommand { get; }
        public ICommand OpenAllMealsViewCommand { get; }
        public ICommand OpenMealCommand { get; }
    }
}