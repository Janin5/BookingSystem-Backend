using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Dtos
{
    public class CreateStylistDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public Guid SalonId { get; set; }

    }
}
