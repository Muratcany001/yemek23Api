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

        [HttpGet("GetAllRestaurant")]
        public ActionResult<IEnumerable<Restaurant>> GetAllRestaurant()
        {
            var restaurantRepository = _RepositoryService.GetRestaurantRepository();
            var Restaurants = restaurantRepository.GetAllRestaurant();
            return Ok(Restaurants);
        }

        [HttpGet("GetRestaurantByName")]
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
        [HttpDelete("Delete restaurant/{id} ")]
        public ActionResult<Restaurant> DeleteRestaurantById(int id)
        {
            _Restaurantrepository.DeleteRestaurant(id);
            return CreatedAtAction(nameof(DeleteRestaurantById), id);
        }
        [HttpGet("GetRestaurantById/{id}")]
        public async Task<IActionResult> GetRestaurantById(int id)
        {
            var restaurantRepository = _RepositoryService.GetRestaurantRepository();
            var RestaurantById = await restaurantRepository.GetRestaurantById(id);
            
            if (RestaurantById == null)
            {
                return NotFound("Restaurant not found");
            }

            return Ok(RestaurantById);
        }
        [HttpPost("AddRestaurant")]
        public ActionResult<Restaurant> AddRestaurant(Restaurant restaurant)
        {
            _Restaurantrepository.AddRestaurant(restaurant);
            return CreatedAtAction(nameof(GetRestaurantByName), new { name = restaurant.Restaurant_Name }, restaurant);
        }


    }
}
