using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Data.Models;

public class Procedure
{
    public Guid Id { get; set; }

    [Required]                      
    public string Name { get; set; }

    public string Description { get; set; }

    [Column(TypeName ="decimal(18,2)")]
    public decimal Price { get; set; }

    public TimeSpan Duration { get; set; }

    public Guid SalonId { get; set; }
    public Salon Salon { get; set; }

    public ICollection<Stylist> Stylists { get; set; } = new List<Stylist>();
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
