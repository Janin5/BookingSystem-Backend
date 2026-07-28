using BookingSystem.Enums;
using System.Globalization;

namespace BookingSystem.Dtos;

public class ReadAppointmentDto
{
    public Guid Id { get; set; }

    public Guid ProcedureId { get; set; }
    public string ProcedureName { get; set; }


    public Guid StylistId { get; set; }
    public string StylistName { get; set; }

    public DateTime AppointmentDate { get; set; }

    public Status Status { get; set; }

}
