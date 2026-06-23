
using GameStore.Endpoints;
using GameStore.Data;
using GameStore.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionstring = builder.Configuration.GetConnectionString("GameStoreDb");

builder.Services.AddScoped<IGameRepository, GameStoreRepository>();
builder.Services.AddDbContext<GameStoreContext>(options =>
    options.UseSqlite(connectionstring));


var app = builder.Build();
app.MapGameStoreEndPoint();
app.Run();



