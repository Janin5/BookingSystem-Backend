using BookingSystem.Shared.Filters;
using BookingSystem.Data.Database;
using BookingSystem.Data.InterfacesRepositories;
using BookingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Data.Repositories;

public class ProcedureRepository: GenericRepository<Procedure,Guid> , IProcedureRepository
{
    public ProcedureRepository(AppDbContext context) : base(context) { }

    public async Task<List<Procedure>> GetProceduresAsync(ProcedureFilter filter)
    {
        var query = _context.Procedures.AsNoTracking();
       
        if(filter.SalonId is not null)
        {
            query = query.Where(p => p.SalonId == filter.SalonId);
        }

       // query = query.OrderBy(p => p.Name)
        //    .Skip((filter.Page - 1) * filter.PageSize)
         //   .Take(filter.PageSize);
        query = query.Include(p => p.Stylists);
        return await query.ToListAsync();

    }

    public async Task<Procedure?> GetByIdAsync(Guid id)
    {
       return await _context.Procedures.Where(p => p.Id == id)
            .Include(p=>p.Stylists)
            .FirstOrDefaultAsync();
    }

}
