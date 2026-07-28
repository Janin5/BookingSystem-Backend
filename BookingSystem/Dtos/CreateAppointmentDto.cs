using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Dtos;

public class CreateAppointmentDto
{
    
    public Guid CustomerId { get; set; }

    
    public Guid ProcedureId { get; set; }

    
    public Guid StylistId { get; set; }

    public DateTime AppointmentDate { get; set; }
}
