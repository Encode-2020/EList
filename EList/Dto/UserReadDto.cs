using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EList.Dto
{
    public class UserReadDto
    {
        public int UserID { get; set; }

        public string Username { get; set; }


        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [UIHint("password")]
        public string Password { get; set; }
    }
}
