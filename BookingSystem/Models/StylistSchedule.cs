using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Models
{
    public class StylistSchedule
    {
        public Guid Id { get; set; }

        public DayOfWeek WorkDay { get; set; }

        public TimeOnly Start {  get; set; }

        public TimeOnly End { get; set; }

        public Guid StylistId { get; set; }
        public Stylist Styilist { get; set; }

       
    }
}
