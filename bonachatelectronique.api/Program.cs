using bonachatelectronique.Models;
using bonachatelectronique.Repo;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Npgsql;
using bonachatelectronique.Data;
using static System.Net.Mime.MediaTypeNames;
using bonachatelectroniqueS.Data;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped(typeof(IRepository<IEtatBonRepo>), typeof(EtatBonRepo));
//builder.Services.AddTransient<ILogger,Logger>();
//builder.Services.AddLogging();


builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=root;Database=bon_achat;"));

builder.Services.AddScoped(typeof(IRepository<EtatBon>), typeof(Repository<EtatBon>));
builder.Services.AddTransient<IEtatBonRepo, EtatBonRepo>();

builder.Services.AddScoped(typeof(IRepository<TypeBon>), typeof(Repository<TypeBon>));
builder.Services.AddTransient<ITypeBonRepo, TypeBonRepo>();

builder.Services.AddScoped(typeof(IRepository<SourceBon>), typeof(Repository<SourceBon>));
builder.Services.AddTransient<ISourceBonRepo, SourceBonRepo>();

builder.Services.AddScoped(typeof(IRepository<BonAchatElectronique>), typeof(Repository<BonAchatElectronique>));
builder.Services.AddTransient<IBonAchatElectroniqueRepo, BonAchatElectroniqueRepo>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
