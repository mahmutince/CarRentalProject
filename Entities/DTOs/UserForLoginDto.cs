using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class UserForLoginDto:IDto
    {
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
