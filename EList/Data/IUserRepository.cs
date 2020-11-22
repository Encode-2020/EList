using EList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EList.Data
{
    public interface IUserRepository
    {

        User GetUserById(int userId);
        User GetUserByEmail(string email);
        IEnumerable<User> Users { get; }

        IEnumerable<User> GetUsers();

        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
