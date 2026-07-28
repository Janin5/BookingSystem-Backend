using BookingSystem.Enums;
using System.ComponentModel.DataAnnotations;
namespace BookingSystem.Models
{
    public class Appointment
    {
        public Guid Id { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public Status Status { get; set; } = Status.Pending;


        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        public Guid ProcedureId { get; set; }
        public Procedure Procedure { get; set; }

        public  Guid StylistId { get; set; }
        public Stylist Stylist { get; set; }




    }
}
