﻿using System;
using System.Collections.Generic;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name = null);
        Restaurant GetById(int restaurantId);
        Restaurant Update(Restaurant updatedRestaurant);
    }
}
