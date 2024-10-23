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
    internal class DeliveryDataStore : ADataStore<Delivery>
    {
        public DeliveryDataStore()
            : base()
        {
            items = fantasyExpress.DeliveriesAllAsync().GetAwaiter().GetResult().ToList();
        }


        public override async Task<Delivery> AddItemToService(Delivery item)
        {
            return await fantasyExpress.DeliveriesPOSTAsync(item).HandleRequest();
        }

        public override async Task<bool> DeleteItemFromService(Delivery item)
        {
            return await fantasyExpress.DeliveriesDELETEAsync(item.Id).HandleRequest();
        }



        public override Delivery Find(Delivery item)
        {
            return items.Where((Delivery arg) => arg.Id == item.Id).FirstOrDefault();
        }

        public override Delivery Find(int id)
        {
            return items.Where((Delivery arg) => arg.Id == id).FirstOrDefault();
        }

        public override async Task Refresh()
        {
            items = (await fantasyExpress.DeliveriesAllAsync()).ToList();
        }

        public override async Task<bool> UpdateItemInService(Delivery item)
        {
            return await fantasyExpress.DeliveriesPUTAsync(item.Id, item).HandleRequest();
        }
    }
}
