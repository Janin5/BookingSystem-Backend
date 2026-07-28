namespace BookingSystem.Dtos;

public class ReadStylistwithProceduresDto
{
    public required Guid Id { get; init; }

    public required string Name { get; init; }

    public required string Description { get; init; }

    public Guid SalonId { get; init; }


    public List<ReadProcedureDto> Procedures { get; set; } = new();
}
