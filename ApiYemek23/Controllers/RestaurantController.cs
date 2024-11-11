using ApiYemek23.Abstract;
using ApiYemek23.Concrete;
using ApiYemek23.Entities.AppEntities;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult <IEnumerable <Restaurant>> GetAllRestaurant ()
        {
            var Restaurants = _repository.GetAllRestaurant();
            return Ok(Restaurants);
        }
       
    }
}
