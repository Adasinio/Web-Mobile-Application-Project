using FantasyExpressApi.Models;
using FantasyExpressApi.Models.TableClasses;
using FantasyExpressWeb.Models.TableClasses;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace FantasyExpressWeb.Models.BuisnessLogic
{
    public class CartB
    {
        private readonly FantasyExpressDbContext _context;
        private string CartSessionId;
        public CartB(FantasyExpressDbContext context, HttpContext httpContext)
        {
            _context = context;
            this.CartSessionId = GetCartSessionId(httpContext);
        }

        private string GetCartSessionId(HttpContext httpContext)
        {
            //Jeżeli w Sesji IdSesjiKoszyka jest null-em
            if (httpContext.Session.GetString("CartSessionId") == null)
            {
                //Jeżeli context.User.Identity.Name nie jest puste i nie posiada białych zanków
                if (!string.IsNullOrWhiteSpace(httpContext.User.Identity.Name))
                {
                    httpContext.Session.SetString("CartSessionId", httpContext.User.Identity.Name);
                }
                else
                {
                    // W przeciwnym wypadku wygeneruj przy pomocy random Guid IdSesjiKoszyka
                    Guid tempCartSessionId = Guid.NewGuid();
                    // Wyślij wygenerowane IdSesjiKoszyka jako cookie
                    httpContext.Session.SetString("CartSessionId", tempCartSessionId.ToString());
                }
            }
            return httpContext.Session.GetString("CartSessionId").ToString();
        }


        public void AddToCart(Meal meal)
        {
            //Najpierw sprawdzamy czy dany towar już istnieje w koszyku danego klienta
            var cartItem =
               (
                   from element in _context.CartItems
                   where element.MealId == meal.Id &&
                         element.CartSessionId == CartSessionId
                   select element
               ).FirstOrDefault();
            // jeżeli brak tego towaru w koszyku
            if (cartItem == null)
            {
                // Wtedy tworzymy nowy element w koszyku
                cartItem = new CartItem()
                {
                    CartSessionId = this.CartSessionId,
                    MealId = meal.Id,
                    Meal = _context.Meals.Find(meal.Id),
                    Quantity = 1,
                    CreatedDate = DateTime.Now
                };
                //i dodajemy do kolekcji lokalne
                _context.CartItems.Add(cartItem);
            }
            else
            {
                // Jeżeli dany towar istnieje już w koszyku to liczbe sztuk zwiekszamy o 1
                cartItem.Quantity++;
            }
            // Zapisujemy zmiany do bazy
            _context.SaveChanges();
        }
        public async Task<List<CartItem>> GetCartItemList()
        {
            return await
               _context.CartItems.Where(e => e.CartSessionId == this.CartSessionId).Include(e => e.Meal).ToListAsync();
        }
        public async Task<decimal> GetTotal()
        {
            var item =
                (
                from element in _context.CartItems
                where element.CartSessionId == this.CartSessionId
                select (decimal?)element.Quantity * element.Meal.Price
                );
            return await item.SumAsync() ?? decimal.Zero;
        }


    }
}
