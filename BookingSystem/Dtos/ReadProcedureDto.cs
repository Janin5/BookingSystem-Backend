namespace BookingSystem.Dtos;

public class ReadProcedureDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public TimeSpan Duration { get; set; }

    public Guid SalonId { get; set; }

  //  public string SalonName { get; set; }

}
