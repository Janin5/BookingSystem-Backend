using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Data.Models;

public class Salon
{
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Adress { get; set; }

    [Required]
    public string Phone { get; set; }


    public ICollection<Stylist> Stylists { get; set; } = new List<Stylist>();
    public ICollection<SalonSchedule> SalonSchedules { get; set; } = new List<SalonSchedule>();
    public ICollection<Procedure> Procedures { get; set; } = new List<Procedure>();

}
