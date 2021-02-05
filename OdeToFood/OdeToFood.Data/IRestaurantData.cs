using System;
using System.Collections.Generic;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name = null);
        Restaurant GetById(int restaurantId);

        // It is a convention to return a reference of the same type.
        //
        // The reason is that by calling update some additional changes
        // may have been made by the data layer, on top of those made
        // from the user interface, like automatically generating a timestamp.
        Restaurant Update(Restaurant updatedRestaurant);

        Restaurant Add(Restaurant newRestaurant);

        // It is a convention to have this method.
        //
        // The reason is that the core object represents a unit of work (?),
        // and will be dirty until explicitly commited to storage.
        int Commit();
    }
}
