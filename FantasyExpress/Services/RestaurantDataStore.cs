using FantasyExpress.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyExpress.Services
{
    internal class RestaurantDataStore : ADataStore<Restaurant>
    {
        public RestaurantDataStore()
: base()
        {
            items = fantasyExpress.RestaurantsAllAsync().GetAwaiter().GetResult().ToList();
        }

        public override async Task<Restaurant> AddItemToService(Restaurant item)
        {
            return await fantasyExpress.RestaurantsPOSTAsync(item).HandleRequest();
        }

        public override async Task<bool> DeleteItemFromService(Restaurant item)
        {
            return await fantasyExpress.RestaurantsDELETEAsync(item.Id).HandleRequest();
        }

        public override Restaurant Find(Restaurant item)
        {
            return items.Where((Restaurant arg) => arg.Id == item.Id).FirstOrDefault();
        }

        public override Restaurant Find(int id)
        {
            return items.Where((Restaurant arg) => arg.Id == id).FirstOrDefault();
        }

        public override async Task Refresh()
        {
            items = (await fantasyExpress.RestaurantsAllAsync()).ToList();
        }

        public override async Task<bool> UpdateItemInService(Restaurant item)
        {
            return await fantasyExpress.RestaurantsPUTAsync(item.Id, item).HandleRequest();
        }


    }
}
