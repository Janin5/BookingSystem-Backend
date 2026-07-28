using BookingSystem.Database;
using BookingSystem.InterfacesRepositories;
using BookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Repositories;

public class ProcedureRepository: GenericRepository<Procedure,Guid> , IProcedureRepository
{
    public ProcedureRepository(AppDbContext context) : base(context) { }

    public async Task<Procedure?> GetByIdwithSalon(Guid id)
    {
        var procedure = await _context.Procedures.Include(s => s.Salon).FirstOrDefaultAsync(s => s.Id == id);
        return (procedure);
    }

    public async Task<List<Procedure>> GetBySalonId(Guid salonId)
    {

        return await _context.Procedures.Where(p => p.SalonId == salonId).ToListAsync();
    }


    public async Task<Procedure> GetProcedurewithStylists (Guid procedureId)
    {
        return await _context.Procedures.Include(p => p.Stylists).FirstOrDefaultAsync(p => p.Id == procedureId);
    }
}
