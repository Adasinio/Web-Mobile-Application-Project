using FantasyExpress.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FantasyExpress.Services
{
    internal class MealDataStore : ADataStore<Meal>
    {
        public MealDataStore()
            : base()
        {
            items = fantasyExpress.MealsAllAsync().GetAwaiter().GetResult().ToList();
        }


        public override async Task<Meal> AddItemToService(Meal item)
        {
            return await fantasyExpress.MealsPOSTAsync(item).HandleRequest();
        }

        public override async Task<bool> DeleteItemFromService(Meal item)
        {
            return await fantasyExpress.MealsDELETEAsync(item.Id).HandleRequest();
        }



        public override Meal Find(Meal item)
        {
            return items.Where((Meal arg) => arg.Id == item.Id).FirstOrDefault();
        }

        public override Meal Find(int id)
        {
            return items.Where((Meal arg) => arg.Id == id).FirstOrDefault();
        }

        public override async Task Refresh()
        {
            items = (await fantasyExpress.MealsAllAsync()).ToList();
        }

        public override async Task<bool> UpdateItemInService(Meal item)
        {
            return await fantasyExpress.MealsPUTAsync(item.Id, item).HandleRequest();
        }
    }
}
