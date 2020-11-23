using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EList.Dto
{
    public class UserUpdateDto
    {
        [StringLength(30, ErrorMessage = "Name length can't be more than 30.")]
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [UIHint("password")]
        public string Password { get; set; }
    }
}
