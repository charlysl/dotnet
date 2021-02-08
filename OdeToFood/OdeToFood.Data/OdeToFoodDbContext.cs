using System;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    // Must inherit from DbContext to use Entity Framework
    //
    // Will automatically generate the schema.
    public class OdeToFoodDbContext : DbContext
    {
        // Perform CRUD operations on Restaurant
        //
        // Can have dozens more entities, and also
        // relations between them.
        // This is covered in the EF PL courses
        DbSet<Restaurant> Restaurants { get; set; }
    }
}
