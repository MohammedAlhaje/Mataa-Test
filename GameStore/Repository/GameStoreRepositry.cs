using GameStore.Dtos;


namespace GameStore.Repository;

using Data;
using Entities;

public class GameStoreRepository(GameStoreContext context) : IGameRepository
{
    public List<Game> GetAll()
    {
        return context.Games.ToList();
    }

    public Game? GetById(int id)
    {
        return context.Games.FirstOrDefault(g => g.Id == id);
    }

    public Game? GetByName(String name)
    {
        return context.Games.FirstOrDefault(game => game.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public Game? GetMax(Game game)

    {
        return context.Games.Max();
    }

    public void Add(Game game)
    {
        context.Add(game);
        context.SaveChanges();
    }

    public void Update(int index, GameDto updatedgame)
    {
        var game = GetById(index);
        if (game is null) return;
        game.Name = updatedgame.Name;
        game.Description = updatedgame.Description;
        game.Price = updatedgame.Price;
        game.ReleaseDate = updatedgame.ReleaseDate;
        context.SaveChanges();
    }

    public void Delete(Game game)
    {
        context.Remove(game);
        context.SaveChanges();
    }
}



