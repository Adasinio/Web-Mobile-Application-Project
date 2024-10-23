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
    internal class PaymentDataStore : ADataStore<Payment>
    {
        public PaymentDataStore()
            : base()
        {
            items = fantasyExpress.PaymentsAllAsync().GetAwaiter().GetResult().ToList();
        }


        public override async Task<Payment> AddItemToService(Payment item)
        {
            return await fantasyExpress.PaymentsPOSTAsync(item).HandleRequest();
        }

        public override async Task<bool> DeleteItemFromService(Payment item)
        {
            return await fantasyExpress.PaymentsDELETEAsync(item.Id).HandleRequest();
        }



        public override Payment Find(Payment item)
        {
            return items.Where((Payment arg) => arg.Id == item.Id).FirstOrDefault();
        }

        public override Payment Find(int id)
        {
            return items.Where((Payment arg) => arg.Id == id).FirstOrDefault();
        }

        public override async Task Refresh()
        {
            items = (await fantasyExpress.PaymentsAllAsync()).ToList();
        }

        public override async Task<bool> UpdateItemInService(Payment item)
        {
            return await fantasyExpress.PaymentsPUTAsync(item.Id, item).HandleRequest();
        }
    }
}
