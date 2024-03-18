using API_AtomHack;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseMySql(connection, new MySqlServerVersion(new Version(8, 3, 0))));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MigrateDatabase();

app.Run();
