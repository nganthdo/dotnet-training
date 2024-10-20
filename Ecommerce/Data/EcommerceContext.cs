using System;
using Ecommerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data;

public class EcommerceContext(DbContextOptions<EcommerceContext> options)
: DbContext(options)
{
    // DbSet is a class in Entity Framework that represents a collection of entities in the database
    // Categories property will contain a collection of entities of type CategoryEntity.
    public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();


    public DbSet<ProductEntity> Products  => Set<ProductEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<CategoryEntity>().HasData(
            new {Id = 1, Name = "Kids and Family"},
            new {Id = 2, Name = "Eco-Friendly Living"},
            new {Id = 3, Name = "Smart Home Technology"}


        );
    }

}
