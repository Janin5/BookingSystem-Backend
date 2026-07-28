using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Models;

public class Customer
{
    public Guid Id {  get; set; }

    [Required]
    public string Auth0Id { get; set; }

   
    public string? FirstName { get; set; }

    
    public string? LastName { get; set; }

   
    public string? Email { get; set; }

    
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

}
