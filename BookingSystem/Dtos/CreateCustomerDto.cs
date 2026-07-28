using BookingSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Dtos;

public class CreateCustomerDto
{

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Email { get; set; }

}
