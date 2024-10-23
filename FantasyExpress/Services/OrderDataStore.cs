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
    internal class OrderDataStore : ADataStore<Order>
    {
        public OrderDataStore()
            : base()
        {
            items = fantasyExpress.OrdersAllAsync().GetAwaiter().GetResult().ToList();
        }


        public override async Task<Order> AddItemToService(Order item)
        {
            return await fantasyExpress.OrdersPOSTAsync(item).HandleRequest();
        }

        public override async Task<bool> DeleteItemFromService(Order item)
        {
            return await fantasyExpress.OrdersDELETEAsync(item.Id).HandleRequest();
        }



        public override Order Find(Order item)
        {
            return items.Where((Order arg) => arg.Id == item.Id).FirstOrDefault();
        }

        public override Order Find(int id)
        {
            return items.Where((Order arg) => arg.Id == id).FirstOrDefault();
        }

        public override async Task Refresh()
        {
            items = (await fantasyExpress.OrdersAllAsync()).ToList();
        }

        public override async Task<bool> UpdateItemInService(Order item)
        {
            return await fantasyExpress.OrdersPUTAsync(item.Id, item).HandleRequest();
        }
    }
}
