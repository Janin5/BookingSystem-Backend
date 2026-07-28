using BookingSystem.Database;
using BookingSystem.InterfacesRepositories;
using BookingSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using BookingSystem.Mappers;
using BookingSystem.Dtos;

namespace BookingSystem.Repositories;

public class AppointmentRepository:GenericRepository<Appointment, Guid>, IAppointmentRepository
{
    public AppointmentRepository(AppDbContext context) : base(context)
    { }
    public async Task<ReadAppointmentDto?> GetByIdWithDetails(Guid id) {

        return await _context.Appointments
              .Where(a => a.Id == id)
              .Select(AppointmentMapper.MapToAppointmentDtoExpression())
              .FirstOrDefaultAsync();
    
    }

}
