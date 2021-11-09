using System.ComponentModel.DataAnnotations;

namespace OPLOGInventory.Model
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

    }

}
