using FantasyExpress.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyExpress.Services
{
    internal class MealTypeDataStore : ADataStore<MealType>
    {

        public MealTypeDataStore()
    : base()
        {
            items = fantasyExpress.MealTypesAllAsync().GetAwaiter().GetResult().ToList();
        }

        public override async Task<MealType> AddItemToService(MealType item)
        {
            return await fantasyExpress.MealTypesPOSTAsync(item).HandleRequest();
        }

        public override async Task<bool> DeleteItemFromService(MealType item)
        {
            return await fantasyExpress.MealTypesDELETEAsync(item.Id).HandleRequest();
        }

        public override MealType Find(MealType item)
        {
            return items.Where((MealType arg) => arg.Id == item.Id).FirstOrDefault();
        }

        public override MealType Find(int id)
        {
            return items.Where((MealType arg) => arg.Id == id).FirstOrDefault();
        }

        public override async Task Refresh()
        {
            items = (await fantasyExpress.MealTypesAllAsync()).ToList();
        }

        public override async Task<bool> UpdateItemInService(MealType item)
        {
            return await fantasyExpress.MealTypesPUTAsync(item.Id, item).HandleRequest();
        }

    }
}
