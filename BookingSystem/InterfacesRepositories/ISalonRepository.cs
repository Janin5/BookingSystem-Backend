using BookingSystem.Dtos;
using BookingSystem.Models;


namespace BookingSystem.InterfacesRepositories;

public interface ISalonRepository: IGenericRepository<Salon, Guid>
{
    Task<List<ReadSalonDto>>GetAllwithProcedures();


}
