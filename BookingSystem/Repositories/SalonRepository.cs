using BookingSystem.Models;
using BookingSystem.InterfacesRepositories;
using BookingSystem.Database;
using Microsoft.Identity.Client;
using BookingSystem.Dtos;
using BookingSystem.Mappers;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Repositories;

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
