using FantasyExpressApi.Models;
using FantasyExpressWeb.Models;
using FantasyExpressWeb.Models.BuisnessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace FantasyExpressWeb.Controllers
{
    public class CartController : Controller
    {
        private readonly FantasyExpressDbContext _context;
        public CartController(FantasyExpressDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            CartB koszyk = new CartB(this._context, this.HttpContext);
            var cartData = new CartData
            {
                CartItemList = await koszyk.GetCartItemList(),
                Total = await koszyk.GetTotal()
            };
            return View(cartData);
        }
        public async Task<ActionResult> AddToCart(int id)
        {
            CartB koszyk = new CartB(this._context, this.HttpContext);
            koszyk.AddToCart(await _context.Meals.FindAsync(id));
            return RedirectToAction("Index");
        }

    }
}
