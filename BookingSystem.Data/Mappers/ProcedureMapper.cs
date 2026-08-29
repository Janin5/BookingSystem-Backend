using BookingSystem.Shared.Dtos;
using BookingSystem.Data.Models;

namespace BookingSystem.Data.Mappers;

public static  class ProcedureMapper
{
    public static Procedure ToCreateModel (CreateProcedureDto dto)
    {
        var procedure = new Procedure()
        {
            Name = dto.Name,
            Description = dto.Description,
            Duration = dto.Duration,
            Price = dto.Price,
            SalonId = dto.SalonId,
        };
        return procedure;
    }

    public static ReadProcedureDto ToReadDto(Procedure procedure)
    {
        var dto = new ReadProcedureDto()
        {
            Id = procedure.Id,
            Name = procedure.Name,
            Description = procedure.Description,
            Duration = procedure.Duration,
            Price = procedure.Price,
            SalonId = procedure.SalonId,
            Stylists = procedure.Stylists?.Select(s => new ReadStylistDto
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description

            }).ToList() ?? new List<ReadStylistDto>()
        };

        return dto;
    }

    public static void ToUpdateModel(UpdateProcedureDto dto , Procedure procedure)
    {
        procedure.Name = dto.Name;
        procedure.Description = dto.Description;
        procedure.Duration = dto.Duration;
        procedure.Price = dto.Price;

    }


}



