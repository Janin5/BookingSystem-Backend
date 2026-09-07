using BookingSystem.Data.Models;
using BookingSystem.Shared.Dtos;
using BookingSystem.Shared.Filters;

namespace BookingSystem.Data.InterfacesRepositories;

public interface IAppointmentRepository:IGenericRepository<Appointment, Guid>
{
    Task<Appointment?> GetByIdAsync(Guid id);
    Task<List<Appointment>> GetAppointmentsAsync(AppointmentFilter filter);
    Task<List<Appointment>> GetConfirmedAppointmentsByDateAsync(Guid stylistId, DateOnly date);

}
