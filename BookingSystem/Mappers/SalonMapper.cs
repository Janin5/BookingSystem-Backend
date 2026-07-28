using BookingSystem.Dtos;
using BookingSystem.Models;
using System.Linq.Expressions;

namespace BookingSystem.Mappers;

public static class SalonMapper
{
    public static Salon ToCreateModel(CreateSalonDto dto)
    {
        var salon = new Salon()
        {
            Name = dto.Name,
            Adress = dto.Adress,
            Phone = dto.Phone
        };

        return salon;
    }

    public static Expression<Func<Salon, ReadSalonDto>> MapToSalonDtoExpression()
    {
        return s => new ReadSalonDto
        {

            Id = s.Id,
            Name = s.Name,
            Adress = s.Adress,
            Phone = s.Phone,
            Procedures = s.Procedures.Select(p => p.Name).ToList()
        };
    }
    public static ReadSalonDto ToReadDto(Salon salon)
    {
        var dto = new ReadSalonDto()
        {
            Id = salon.Id,
            Name = salon.Name,
            Adress = salon.Adress,
            Phone = salon.Phone,
            Procedures = new List<string>()

        };

        return dto;
    }
    public static  void ToUpdateModel(UpdateSalonDto dto, Salon salon)
    {
        salon.Name = dto.Name;
        salon.Adress = dto.Adress;
        salon.Phone = dto.Phone;
 
    }


}
