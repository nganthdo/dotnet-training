using System;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data;

public static class DataExtensions
{
    /*automatically apply EF Core migrations to the database 
    when the ASP.NET Core application starts -> ensures that the database is always in sync 
    with the models in the source code
    */
    public static async Task MigrateDbAsync (this WebApplication app){
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceContext>();
        await dbContext.Database.MigrateAsync();

    }


}
