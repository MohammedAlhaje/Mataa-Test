namespace GameStore.Entities;

public class Game
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required DateTime ReleaseDate { get; set; }
}