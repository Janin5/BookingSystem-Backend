using BookingSystem.Dtos;
using BookingSystem.InterfacesRepositories;
using BookingSystem.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentRepository _appointmentRepository;
    public AppointmentController(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository=appointmentRepository;
    }

    [HttpPost]
    public async Task<ActionResult<ReadAppointmentDto>>Create(CreateAppointmentDto dto)
    {
        var newAppointment = AppointmentMapper.ToCreateModel(dto);
        _appointmentRepository.Create(newAppointment);
        await _appointmentRepository.SaveChangesAsync();

       var readDto= await _appointmentRepository.GetByIdWithDetails(newAppointment.Id);
        return readDto;
    }
}
