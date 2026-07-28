using BookingSystem.Dtos;
using BookingSystem.Models;

namespace BookingSystem.InterfacesRepositories;

public interface IAppointmentRepository:IGenericRepository<Appointment, Guid>
{
    Task<ReadAppointmentDto?> GetByIdWithDetails(Guid id);

}
