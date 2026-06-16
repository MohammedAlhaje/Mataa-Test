namespace GameStore.Dtos;

public record GameDto(
    int Id,
    string Name,
    string Description,
    decimal Price,
    DateTime ReleaseDate
);

