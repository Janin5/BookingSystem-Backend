using BookingSystem.Shared.Dtos;
using BookingSystem.Data.Models;


namespace BookingSystem.Data.InterfacesRepositories;

public interface ISalonRepository: IGenericRepository<Salon, Guid>
{
    Task<List<ReadSalonDto>>GetAllwithProcedures();


}
