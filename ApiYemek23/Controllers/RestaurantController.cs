using ApiYemek23.Abstract;
using ApiYemek23.Concrete;
using ApiYemek23.Entities.AppEntities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ApiYemek23.Controllers
{
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantRepository _repository;

        public RestaurantController(IRestaurantRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("Restaurant Get")]
        public ActionResult<IEnumerable<Restaurant>> GetAllRestaurant()
        {
            var Restaurants = _repository.GetAllRestaurant();
            return Ok(Restaurants);
        }

        [HttpGet("get Restaurant by name")]
        public ActionResult<Restaurant> GetRestaurantByName(string name)
        {
                var RestaurantByName = _repository.GetRestaurantByName(name);
            if (RestaurantByName == null)
            {
                return NotFound();
            }
                return Ok(RestaurantByName);

        }
        [HttpPost("Add restaurant")]
        public ActionResult<Restaurant> AddRestaurant(Restaurant restaurant)
        {
            _repository.AddRestaurant(restaurant);
            return CreatedAtAction(nameof(AddRestaurant), restaurant);
        }

    }
}
