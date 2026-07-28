using BookingSystem.Dtos;
using BookingSystem.Models;

namespace BookingSystem.Mappers;

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
           // SalonName = procedure.Salon.Name
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

    public static ProcedurewithStylistsDto MapProcedurewithStyliststoDt0 ( Procedure procedure)
    {

        return new ProcedurewithStylistsDto()
        {
            Id = procedure.Id,
            Name = procedure.Name,
            Description = procedure.Description,
            Price = procedure.Price,
            Duration = procedure.Duration,
            SalonId = procedure.SalonId,
            Stylist = procedure.Stylists?.Select(s => new ReadStylistDto
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description

            }).ToList() ?? new List<ReadStylistDto>()
        };
    }



}



