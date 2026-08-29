using BookingSystem.Data.Models;
using BookingSystem.Data.InterfacesRepositories;
using BookingSystem.Data.Database;
using Microsoft.Identity.Client;
using BookingSystem.Shared.Dtos;
using BookingSystem.Data.Mappers;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Data.Repositories;

public class SalonRepository : GenericRepository<Salon , Guid>, ISalonRepository
{ 
    public SalonRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<ReadSalonDto>> GetAllwithProcedures()
    {
        return await _context.Salons.Select(SalonMapper.MapToSalonDtoExpression()).ToListAsync();
           
    }

}
