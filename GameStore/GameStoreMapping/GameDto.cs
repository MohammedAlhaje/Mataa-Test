namespace GameStore.GameStoreMapping;

using Dtos;

public static class GameDtoMapping
{
    public static GameDto ToDto(this Entities.Game game)
    {
        return new GameDto(
            game.Id,
            game.Name,
            game.Description,
            game.Price,
            game.ReleaseDate
        );
    }

    public static Entities.Game ToEntity(this GameDto gameDto)
    {
        return new Entities.Game
        {
            Id = gameDto.Id,
            Name = gameDto.Name,
            Description = gameDto.Description,
            Price = gameDto.Price,
            ReleaseDate = gameDto.ReleaseDate
        };
    }
}