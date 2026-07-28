using BookingSystem.Dtos;
using BookingSystem.Models;
using System.Linq.Expressions;

namespace BookingSystem.Mappers;

public static class AppointmentMapper
{
    public static Appointment ToCreateModel(CreateAppointmentDto dto)
    {
        var newAppointment = new Appointment()
        {
            CustomerId = dto.CustomerId,
            ProcedureId = dto.ProcedureId,
            StylistId = dto.StylistId,
            AppointmentDate = dto.AppointmentDate

        };

        return newAppointment;
    }

    public static ReadAppointmentDto ToReadDto(Appointment appointment)
    {
        var dto = new ReadAppointmentDto()
        {
            Id = appointment.Id,
            ProcedureId = appointment.ProcedureId,
            ProcedureName = appointment.Procedure.Name,
            StylistId = appointment.StylistId,
            StylistName=appointment.Stylist.Name,
            AppointmentDate=appointment.AppointmentDate,
            Status = appointment.Status
        };
        return dto;
    }

    public static Expression<Func<Appointment, ReadAppointmentDto>> MapToAppointmentDtoExpression()
    {
        return a => new ReadAppointmentDto
        {
            Id = a.Id,
            ProcedureId=a.ProcedureId,
            ProcedureName=a.Procedure.Name,
            StylistId = a.StylistId,
            StylistName=a.Stylist.Name,
            AppointmentDate=a.AppointmentDate,
            Status = a.Status
        };
    }


}
