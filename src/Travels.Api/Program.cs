using Travels.Application;
using Travels.Application.Interfaces.Services;
using Travels.Application.Services;
using Travels.Application.Interfaces.Repositories;
using Travels.Application.UseCases.AddRoute;
using Travels.Application.UseCases.UpdateRoute;
using Travels.Application.UseCases.GetCheapestRoute;
using Travels.Infrastructure;
using Travels.Infrastructure.Seed;
using Travels.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Custom services para atender ao Clean Arch
builder.Services.AddApplicationServices(); // Serviços de Application
builder.Services.AddInfrastructureServices(); // Serviços de Infrastructure

builder.Services.AddSingleton<IRouteRepository, RouteRepository>();

builder.Services.AddTransient<AddRouteHandler>();
builder.Services.AddTransient<UpdateRouteHandler>();
builder.Services.AddTransient<GetCheapestRouteHandler>();
builder.Services.AddTransient<ICheapestRouteFinder, CheapestRouteFinder>();

builder.Services.AddTransient<RouteSeeder>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<RouteSeeder>();
    await seeder.SeedAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
