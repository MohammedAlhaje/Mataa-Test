namespace GameStore.Endpoints;

using Dtos;
using Repository;
using GameStoreMapping;

public static class GameStoreEndPoint
{
    public static RouteGroupBuilder MapGameStoreEndPoint(this WebApplication app)
    {
        string getGame = "GetGame";
        var gamesroute = app.MapGroup("/games");


        gamesroute.MapGet("", (IGameRepository context) => context.GetAll());

        gamesroute.MapGet("/{id:int}", (int id, IGameRepository context) =>
        {
            var game = context.GetById(id);
            return game is not null ? Results.Ok(game) : Results.NotFound();
        }).WithName(getGame);
        gamesroute.MapGet("/{name}", (string name, IGameRepository context) =>
        {
            var game = context.GetByName(name);
            return game is not null ? Results.Ok(game) : Results.NotFound();
        });
        gamesroute.MapPost("", (GameDto game, IGameRepository context) =>
        {
            if (context.GetById(game.Id) is not null)
            {
                game = game with { Id = context.GetMax(game.ToEntity())!.Id + 1 };
            }

            context.Add(game.ToEntity());
        });
        gamesroute.MapPut("/{id}", (int id, GameDto updatedGame, IGameRepository context) =>
        {
            context.Update(id, updatedGame);
            return Results.Ok();
        });
        gamesroute.MapDelete("/{id}", (int id, IGameRepository context) =>
        {
            var index = context.GetById(id);
            if (index == null)
            {
                return Results.NotFound();
            }

            context.Delete(index);
            return Results.Ok();
        });

        return gamesroute;
    }
}

