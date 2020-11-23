using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EList.Models.ViewModels
{
    public class LoginResponse
    {
        public User user { get; set; }
        public string token { get; set; }
    }
}
