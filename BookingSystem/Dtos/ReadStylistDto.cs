namespace BookingSystem.Dtos;

public class ReadStylistDto
{
    public required Guid Id { get; init; }

    public required string Name { get; init; }

    public required string Description { get; init; }

    public Guid SalonId { get; init; }

//    public required string SalonName { get; init; }
}
