﻿using ApiYemek23.Entities.AppEntities;

namespace ApiYemek23.Abstract
{
    public interface IRestaurantRepository
    {
        Restaurant GetAllRestaurant();
        Restaurant GetRestaurantByName(string name);
        Restaurant AddRestaurant(Restaurant restaurant);
    }
}
