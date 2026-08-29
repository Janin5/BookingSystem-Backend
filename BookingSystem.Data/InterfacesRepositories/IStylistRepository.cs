using BookingSystem.Data.Models;

namespace BookingSystem.Data.InterfacesRepositories;

public interface IStylistRepository : IGenericRepository<Stylist, Guid>
{
    Task<Stylist?> GetByIdwithSalon(Guid id);
    Task<List<Stylist>> GetAllwithSalon();
    Task<List<Stylist>> GetBySalonId(Guid salonId);

    Task<Stylist> GetStylistwithProcedures(Guid stylistId);

    Task AddProcedureToStylist(Guid stylistId, Guid procedureId);
}
