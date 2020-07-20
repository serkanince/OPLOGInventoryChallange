using System.ComponentModel.DataAnnotations;

namespace OPLOGInventory.Infrastructure.DTO
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

    }

}
