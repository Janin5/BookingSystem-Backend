using BookingSystem.Dtos;
using BookingSystem.Models;

namespace BookingSystem.Mappers;

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
