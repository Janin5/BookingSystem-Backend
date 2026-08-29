using BookingSystem.Data.Database;
using BookingSystem.Data.InterfacesRepositories;
using BookingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using BookingSystem.Data.Mappers;
using BookingSystem.Shared.Dtos;
using System.Runtime.CompilerServices;
using BookingSystem.Shared.Filters;

namespace BookingSystem.Data.Repositories;

public class AppointmentRepository:GenericRepository<Appointment, Guid>, IAppointmentRepository
{
    public AppointmentRepository(AppDbContext context) : base(context)
    { }
    public async Task<Appointment?> GetByIdAsync(Guid id) {

        return await _context.Appointments.FirstOrDefaultAsync(a => a.Id == id);
    
    }

    public async Task<List<Appointment>> GetAppointmentsAsync(AppointmentFilter filter)
    {
        var query = _context.Appointments.AsNoTracking();

        if(filter.StylistId is not null)
        {
            query = query.Where(a => a.StylistId == filter.StylistId);
        }

        query = query.Include(a=>a.Stylist).Include(a=>a.Procedure);
        query = query.OrderBy(a => a.Stylist.Name);
        return await query.ToListAsync();
    }
  

}
