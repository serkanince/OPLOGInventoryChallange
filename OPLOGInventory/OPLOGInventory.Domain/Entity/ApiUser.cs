using OPLOGInventory.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OPLOGInventory.Domain.Entity
{
    public class ApiUser
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        public DateTime? LastLogin { get; set; }
    }
}
