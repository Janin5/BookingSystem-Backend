using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Data.Models;

public class Stylist
{
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }


    public Guid SalonId {  get; set; }
    public Salon Salon {  get; set; }

    public ICollection<Procedure> Procedures { get; set; } = new List<Procedure>();
    
    public ICollection<StylistSchedule> StylistSchedules { get; set; } = new List<StylistSchedule>();

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
