using EList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EList.Data
{
    public interface IUserRepository
    {
        Task<User> SaveUser(User user);
        Task<User> GetUserById(int userId);
    }
}
