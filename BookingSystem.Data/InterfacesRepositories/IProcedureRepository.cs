using BookingSystem.Shared.Filters;
using BookingSystem.Data.Models;

namespace BookingSystem.Data.InterfacesRepositories;

public interface IProcedureRepository: IGenericRepository<Procedure, Guid>
{
    Task<List<Procedure>> GetProceduresAsync(ProcedureFilter filter);
    Task<Procedure?> GetByIdAsync(Guid id);
}
