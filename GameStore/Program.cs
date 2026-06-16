using GameStore.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app = app.MapGameStoreEndPoint();

app.Run();


