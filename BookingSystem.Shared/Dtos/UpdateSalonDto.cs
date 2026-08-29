using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Shared.Dtos
{
    public class UpdateSalonDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}
