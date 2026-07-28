using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Dtos;

public class ReadCustomerDto
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }
}
