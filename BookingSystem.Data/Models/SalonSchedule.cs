using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Data.Models;

public class SalonSchedule
{
    public Guid Id { get; set; }

    [Required]
    public DayOfWeek WorkDay { get; set; }

    [Required]
    public TimeOnly OpenTime { get; set; }

    [Required]
    public TimeOnly CloseTime { get; set; }

    public Guid SalonId { get; set; }
    public Salon Salon { get; set; }
}
