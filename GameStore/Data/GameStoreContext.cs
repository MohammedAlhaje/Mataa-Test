namespace GameStore.Data;

using Microsoft.EntityFrameworkCore;
using Entities;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>().HasData(
            new Game
            {
                Id = 1,
                Name = "Action-adventure",
                Description = "The Legend of Zelda: Breath of the Wild",
                Price = 59.99m,
                ReleaseDate = new DateTime(2017, 3, 3)
            },
            new Game
            {
                Id = 2,
                Name = "Action-adventure",
                Description = "Red Dead Redemption 2",
                Price = 59.99m,
                ReleaseDate = new DateTime(2018, 10, 26)
            },
            new Game
            {
                Id = 3,
                Name = "Action RPG",
                Description = "Cyberpunk 2077",
                Price = 59.99m,
                ReleaseDate = new DateTime(2020, 12, 10)
            }
        );
    }
}
