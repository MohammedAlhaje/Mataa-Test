namespace GameStore.Repository;

using Dtos;
using Entities;

public interface IGameRepository
{
    List<Game> GetAll();
    Game? GetById(int id);

    Game? GetByName(String name);

    Game? GetMax(Game id);

    void Add(Game game);

    void Update(int index, GameDto updatedgame);
    void Delete(Game game);
}

