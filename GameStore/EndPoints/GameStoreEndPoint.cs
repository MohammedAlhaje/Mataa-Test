using GameStore.Dtos;

namespace GameStore.Endpoints
{
    public static class GameStoreEndPoint
    {
        public static WebApplication MapGameStoreEndPoint(this WebApplication app)
        {
            List<GameDto> games =
            [
                new(1, "Fifa26", "last varsion on fifa relesed", 205, new DateTime(2026, 1, 1)),
                new(2, "Call of Duty", "last varsion on Call of Duty relesed", 205, new DateTime(2026, 1, 1)),
                new(3, "PES2026", "last varsion on PES relesed", 205, new DateTime(2026, 1, 1))
            ];


            app.MapGet("/games", () => games);


            app.MapGet("/games/{id:int}", (int id) =>
            {
                var game = games.FirstOrDefault(g => g.Id == id);
                return game is not null ? Results.Ok(game) : Results.NotFound();
            });
            app.MapGet("/games/{name}", (string name) =>
            {
                var game = games.FirstOrDefault(g => g.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                return game is not null ? Results.Ok(game) : Results.NotFound();
            });
            app.MapPost("/games", (GameDto game) =>
            {
                if (games.Any(g => g.Id == game.Id))
                {
                    game = game with { Id = games.Max(g => g.Id) + 1 };
                }

                games.Add(game);
                return Results.Created($"/games/{game.Id}", game);
            });
            app.MapPut("/games/{id}", (int id, GameDto updatedGame) =>
            {
                var index = games.FindIndex(g => g.Id == id);
                if (index == -1) return Results.NotFound();
                updatedGame = updatedGame with { Id = id };
                games[index] = updatedGame;
                return Results.Ok(updatedGame);
            });
            app.MapDelete("/games/{id}", (int id) =>
            {
                var index = games.FindIndex(g => g.Id == id);
                if (index == -1)
                {
                    return Results.NotFound();
                }

                games.RemoveAt(index);
                return Results.Ok();
            });
            return app;
        }
    }
}
