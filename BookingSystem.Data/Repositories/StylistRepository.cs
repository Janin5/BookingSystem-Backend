using BookingSystem.Data.Database;
using BookingSystem.Data.InterfacesRepositories;
using BookingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Data.Repositories;

public class StylistRepository: GenericRepository<Stylist, Guid>, IStylistRepository
{
    public StylistRepository(AppDbContext context) : base(context) { }
    
    public async Task<Stylist?> GetByIdwithSalon(Guid id)
    {
        var stylist = await _context.Stylists.Include(s => s.Salon).FirstOrDefaultAsync(s => s.Id == id);
        return (stylist);
    }


    public async Task<List<Stylist>> GetAllwithSalon()
    {
        var list = await _context.Stylists.Include(s => s.Salon).ToListAsync();
        return (list);
    }
    
    public async Task<List<Stylist>> GetBySalonId(Guid salonId)
    {
       return await _context.Stylists.Where(s => s.SalonId == salonId).ToListAsync();
    }

    public async Task<Stylist> GetStylistwithProcedures(Guid stylistId)
    {

       return await _context.Stylists.Include(s => s.Procedures).FirstOrDefaultAsync(s => s.Id == stylistId);
    }


    public async Task AddProcedureToStylist(Guid stylistId, Guid procedureId)
    {
        var stylist = await _context.Stylists
        .Include(s => s.Procedures)
        .FirstOrDefaultAsync(s => s.Id == stylistId);

        var procedure = await _context.Procedures.FindAsync(procedureId);

        if (stylist != null && procedure != null)
        {
            stylist.Procedures.Add(procedure);
            await _context.SaveChangesAsync();

        }
    }

    public async Task<StylistSchedule?>GetScheduleAsync(Guid stylistId, DayOfWeek day)
    {
        return await _context.StylistSchedules.FirstOrDefaultAsync(s => s.StylistId == stylistId && s.WorkDay == day);
    }

}
