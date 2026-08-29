using BookingSystem.Data.Database;
using BookingSystem.Data.InterfacesRepositories;
using BookingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Data.Repositories;

public class CustomerRepository: GenericRepository<Customer, Guid> , ICustomerRepository
{
    public CustomerRepository(AppDbContext context) : base(context) { }

    public async Task<Customer?> GetByAuth0Id(string auth0Id)
    {
        return await _context.Customers.FirstOrDefaultAsync(c => c.Auth0Id == auth0Id);
    }
}
