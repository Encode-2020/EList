using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EList.Models
{
    public class LoginUser
    {

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [Remote("IsEmailExists", "LoginUser", ErrorMessage = "Email already in use")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [UIHint("password")]
        public string Password { get; set; }
    }
}
