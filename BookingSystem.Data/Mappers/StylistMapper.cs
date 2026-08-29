using BookingSystem.Shared.Dtos;
using BookingSystem.Data.Models;

namespace BookingSystem.Data.Mappers;

public static class StylistMapper
{
    public static Stylist ToCreateModel(CreateStylistDto dto)
    {
        var stylist = new Stylist()
        {
            Name = dto.Name,
            Description = dto.Description,
            SalonId = dto.SalonId,
            
        };

        return stylist;
      
    }

    public static ReadStylistDto ToReadDto(Stylist stylist)
    {
        var dto = new ReadStylistDto()
        {
            Id = stylist.Id,
            Name = stylist.Name,
            Description = stylist.Description,
            //SalonName = stylist.Salon.Name,
            SalonId = stylist.SalonId
        };

        return dto;
    }

    public static void ToUpdateModel(UpdateStylistDto dto, Stylist stylist)
    {
        stylist.Name = dto.Name;
        stylist.Description = dto.Description;
        stylist.SalonId = dto.SalonId;
       
    }


}
