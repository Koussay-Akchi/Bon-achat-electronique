using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using bonachatelectronique.Repo;
using bonachatelectronique.Models;
using Microsoft.EntityFrameworkCore;
using bonachatelectronique.Data;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var services = new ServiceCollection();

services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = "Host=localhost;Port=5432;Username=postgres;Password=root;Database=bon_achat;";
    options.UseNpgsql(connectionString);
});

services.AddScoped<IEtatBonRepo, EtatBonRepo>();

// Build the service provider from the separate service collection
var serviceProvider = services.BuildServiceProvider();

app.MapGet("/api/EtatBon", async (IServiceProvider serviceProvider) =>
{
    // Resolve the EtatBonRepo using the built service provider
    var etatBonRepo = serviceProvider.GetRequiredService<IEtatBonRepo>();

    var etatBonList = await etatBonRepo.GetAllEtatBonAsync();
    return Results.Ok(etatBonList);
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
