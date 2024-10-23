using FantasyExpressApi.Models;
using FantasyExpressApi.Models.TableClasses;
using FantasyExpressAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FantasyExpressApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsForViewController : ControllerBase
    {
        private readonly FantasyExpressDbContext _context;

        public MealsForViewController(FantasyExpressDbContext context)
        {
            _context = context;
        }

        // GET: api/<MealsForViewController>
        [HttpGet]
        public async Task<ActionResult<List<MealForView>>> GetAllMealsInRestaurant(int restaurantId)
        {
            return await _context.Meals
                .Include(m => m.MealType)
                .Where(m => m.RestaurantId == restaurantId)
                .Select(m => (MealForView)m)
                .ToListAsync();
        }

        // GET api/<MealsForViewController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MealForView>> Get(int id)
        {
            var m = await _context.Meals.Include(m => m.MealType).FirstOrDefaultAsync(m => m.Id == id);
            if (m == null)
                return NotFound();
            else
                return (MealForView)m;
        }

        // POST api/<MealsForViewController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MealForView value)
        {
            try
            {
                Meal meal = value;


                _context.Meals.Add(meal);
                await _context.SaveChangesAsync();

                return Ok(meal);
            }
            catch (Exception)
            {

                throw;
            }
       
        }

        // PUT api/<MealsForViewController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MealsForViewController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
