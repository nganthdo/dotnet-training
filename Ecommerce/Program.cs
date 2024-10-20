using Ecommerce.Data;
using Ecommerce.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// specify the location of the database file and config DB using SQLite
var connString = builder.Configuration.GetConnectionString("Ecommerce");
builder.Services.AddSqlite<EcommerceContext>(connString);



// app: is an object of IApplicationBuilder, is used to config the endpoints
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.MapCategoryEndpoints();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

await app.MigrateDbAsync();
app.Run();
