using System;
using Ecommerce.Data;
using Ecommerce.Dto;
using Ecommerce.Entities;
using Ecommerce.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services;

public static class CategoryService
{
    const string GetCategoryEndpointName = "GetCategory";


    public static RouteGroupBuilder MapCategoryEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("categories").WithParameterValidation();

        // GET /categories
        group.MapGet("/", async (EcommerceContext dbContext) =>
        await dbContext.Categories
        .Select(Category => Category.ToDto())
        .AsNoTracking()
        .ToListAsync());


        // GET /categories/{id}
        group.MapGet("/{id}", async (int id, EcommerceContext dbContext) =>
        {
             CategoryEntity? category = await dbContext.Categories.FindAsync( id);

            //
           return category is null ? Results.NotFound() : Results.Ok(category);

        }).WithName(GetCategoryEndpointName);


        // POST /categories
        group.MapPost("/", async (CreateCategoryDto newCategory, EcommerceContext dbContext) =>
        {
            // if(string.IsNullOrEmpty(newCategory.Name)){
            //     return Results.BadRequest("Name is required");
            // }

            CategoryEntity category = newCategory.ToCategoryEntity();

            /*
            CategoryEntity category = new()
            {
                Name = newCategory.Name
            };*/

            // add new category into Db
            dbContext.Categories.Add(category);
            await dbContext.SaveChangesAsync();

            /*
            CategoryDto categoryDto = new(
                category.Id,
                category.Name
            );*/

            return Results.CreatedAtRoute
            (GetCategoryEndpointName, new { id = category.Id }, category.ToDto());
        }).WithParameterValidation(); // validate required field - using MinimalApis.Extensions in nuget package

        // PUT /categories/{id}
        group.MapPut("/{id}", async (int id, UpdateCategoryDto updatedCategory, EcommerceContext dbContext) =>
        {

            //var index = categories.FindIndex(Category => Category.Id == id);
            var existingCategory = dbContext.Categories.Find(id);

            if (existingCategory is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingCategory)
            .CurrentValues
            .SetValues(updatedCategory.ToCategoryEntity(id));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        }).WithParameterValidation();

        // DELETE /categories/{id}
        group.MapDelete("/{id}", async (int id, EcommerceContext dbContext) =>
        {
            
            await dbContext.Categories
            .Where(categories => categories.Id == id)
            .ExecuteDeleteAsync();
            
            return Results.NoContent();
        });
        return group;
    }


}
