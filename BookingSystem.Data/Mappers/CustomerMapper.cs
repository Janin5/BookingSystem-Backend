using BookingSystem.Shared.Dtos;
using BookingSystem.Data.Models;

namespace BookingSystem.Data.Mappers;

public static class CustomerMapper
{

    public static Customer ToCreateModel(CreateCustomerDto dto)
    {
        var newCustomer = new Customer
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email
        };

        return newCustomer;
    }
}
