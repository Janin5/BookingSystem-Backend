namespace BookingSystem.Shared.Dtos;

public class ReadSalonDto
{
    public required Guid Id { get; init; }

    
    public required string Name { get; init; }

    
    public required string Adress { get; init; }

   
    public required string Phone { get; init; }

    public required List<string> Procedures { get; init; }
}
