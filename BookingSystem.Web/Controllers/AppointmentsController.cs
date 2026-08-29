using BookingSystem.Business;
using BookingSystem.Data.InterfacesRepositories;
using BookingSystem.Data.Mappers;
using BookingSystem.Data.Models;
using BookingSystem.Shared.Dtos;
using BookingSystem.Shared.Enums;
using BookingSystem.Shared.Filters;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentsController : ControllerBase
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly AppointmentService _appointmentService;
    public AppointmentsController(IAppointmentRepository appointmentRepository, AppointmentService appointmentService)
    {
        _appointmentRepository = appointmentRepository;
        _appointmentService = appointmentService;
    }

    [HttpPost]
    public async Task<ActionResult<ReadAppointmentDto>> Create(CreateAppointmentDto dto)
    {
        var newAppointment = AppointmentMapper.ToCreateModel(dto);
        _appointmentRepository.Create(newAppointment);
        await _appointmentRepository.SaveChangesAsync();

        var readDto = await _appointmentRepository.GetByIdAsync(newAppointment.Id);
        return AppointmentMapper.ToReadDto(readDto);  
    }

    [HttpPatch("{id}/status")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Status newStatus)
    {
        await _appointmentService.ChangeAppointmentStatus(id, newStatus);

        return NoContent();
    }


    [HttpGet]
    public async Task<IActionResult> GetAppointments([FromQuery] AppointmentFilter filter)
    {
        var appointmnents = await _appointmentRepository.GetAppointmentsAsync(filter);
        return Ok(appointmnents.Select(a =>AppointmentMapper.ToReadDto(a)));
    }

    
}
