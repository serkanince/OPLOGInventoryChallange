using OPLOGInventory.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Infrastructure.DTO
{
    public class ApiUserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
