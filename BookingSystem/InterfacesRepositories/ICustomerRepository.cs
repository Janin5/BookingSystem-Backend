using BookingSystem.Models;

namespace BookingSystem.InterfacesRepositories;

public interface ICustomerRepository : IGenericRepository<Customer, Guid>
{

    Task<Customer?> GetByAuth0Id(string auth0Id);
}
