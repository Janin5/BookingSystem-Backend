using BookingSystem.Data.Models;

namespace BookingSystem.Data.InterfacesRepositories;

public interface ICustomerRepository : IGenericRepository<Customer, Guid>
{

    Task<Customer?> GetByAuth0Id(string auth0Id);
}
