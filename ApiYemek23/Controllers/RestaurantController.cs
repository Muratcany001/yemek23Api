using ApiYemek23.Abstract;
using ApiYemek23.Concrete;
using ApiYemek23.Entities.AppEntities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ApiYemek23.Controllers
{
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantRepository _Restaurantrepository;

        public RestaurantController(IRestaurantRepository Restaurantrepository)
        {
            _Restaurantrepository = Restaurantrepository;
        }
        [HttpGet("GetAllRestaurant")]
        public ActionResult<IEnumerable<Restaurant>> GetAllRestaurant()
        {
            var Restaurants = _Restaurantrepository.GetAllRestaurant();
            return Ok(Restaurants);
        }

        [HttpGet("GetRestaurantByName")]
        public ActionResult<Restaurant> GetRestaurantByName(string name)
        {
                var RestaurantByName = _Restaurantrepository.GetRestaurantByName(name);
            if (RestaurantByName == null)
            {
                return NotFound();
            }
                return Ok(RestaurantByName);

        }
        [HttpPost("AddRestaurant")]
        public ActionResult<Restaurant> AddRestaurant(Restaurant restaurant)
        {
            _Restaurantrepository.AddRestaurant(restaurant);
            return CreatedAtAction(nameof(GetRestaurantByName), new { name = restaurant.Restaurant_Name }, restaurant);
        }


    }
}
