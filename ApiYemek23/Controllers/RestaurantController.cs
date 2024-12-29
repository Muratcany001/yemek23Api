using ApiYemek23.Abstract;
using ApiYemek23.Concrete;
using ApiYemek23.Entities.AppEntities;
using ApiYemek23.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ApiYemek23.Controllers
{
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantRepository _Restaurantrepository;
        private readonly RepositoryService _RepositoryService;

        public RestaurantController(IRestaurantRepository Restaurantrepository, RepositoryService repositoryService)
        {
            _Restaurantrepository = Restaurantrepository;
            _RepositoryService = repositoryService;
        }

        [HttpGet("restaurants")]
        public ActionResult<IEnumerable<Restaurant>> GetAllRestaurant()
        {
            var restaurantRepository = _RepositoryService.GetRestaurantRepository();
            var Restaurants = restaurantRepository.GetAllRestaurant();
            return Ok(Restaurants);
        }

        [HttpGet("restaurants/name/{name}")]
        public ActionResult<Restaurant> GetRestaurantByName(string name)
        {
            var restaurantRepository = _RepositoryService.GetRestaurantRepository();
            var RestaurantByName = restaurantRepository.GetRestaurantByName(name);
            if (RestaurantByName == null)
            {
                return NotFound();
            }
                return Ok(RestaurantByName);

        }
        [HttpDelete("restaurants/{id}")]
        public ActionResult<Restaurant> DeleteRestaurantById(int id)
        {
            _Restaurantrepository.DeleteRestaurant(id);
            return CreatedAtAction(nameof(DeleteRestaurantById), id);
        }
        [HttpGet("restaurants/id/{id}")]
        public async Task<IActionResult> GetRestaurantById(int id)
        {
            var restaurantRepository = _RepositoryService.GetRestaurantRepository();

            // Fetch the restaurant by ID using the service
            var restaurantById = await restaurantRepository.GetRestaurantById(id);

            if (restaurantById == null)
            {
                // Return a 404 if the restaurant doesn't exist
                return NotFound(new { message = "Restaurant not found" });
            }

            // Return the restaurant with a 200 OK response
            return Ok(restaurantById);
        }

        [HttpPost("restaurants")]
        public ActionResult<Restaurant> AddRestaurant(Restaurant restaurant)
        {
            var addedRestaurant = _Restaurantrepository.AddRestaurant(restaurant);
            return CreatedAtAction(nameof(GetRestaurantByName), new { name = addedRestaurant.Restaurant_Name }, addedRestaurant);
        }




    }
}
