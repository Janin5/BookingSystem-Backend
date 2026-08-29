using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Shared.Dtos;

public class UpdateProcedureDto
{

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public TimeSpan Duration { get; set; }
}
