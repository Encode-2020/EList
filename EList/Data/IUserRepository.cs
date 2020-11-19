using EList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EList.Data
{
    public interface IListRepository
    {

        User GetUserById(int userId);


        IEnumerable<User> GetUsers();

        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
