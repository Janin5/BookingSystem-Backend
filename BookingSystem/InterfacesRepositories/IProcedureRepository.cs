using BookingSystem.Models;

namespace BookingSystem.InterfacesRepositories;

public interface IProcedureRepository: IGenericRepository<Procedure, Guid>
{
    Task<Procedure?> GetByIdwithSalon(Guid id);

    Task<List<Procedure>> GetBySalonId(Guid salonId);

    Task<Procedure> GetProcedurewithStylists(Guid procedureId);
}
