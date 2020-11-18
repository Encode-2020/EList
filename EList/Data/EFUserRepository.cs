using EList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EList.Data
{
    public class EFUserRepository : IListRepository
    {
        private EListContext context;

        public EFUserRepository(EListContext ctx)
        {
            context = ctx;
        }
        public IQueryable<User> User => context.Users;

        public void CreateUser(User user)
        {

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            context.Users.Remove(user);
            context.SaveChanges();
        }

        public User GetUserById(int userId)
        {
            User dbEntry = context.Users
                .FirstOrDefault(u =>u.UserID == userId);
            if(dbEntry != null)
            {
                return dbEntry;
            }
            return null;
        }

        public IEnumerable<User> GetUsers()
        {
            IEnumerable<User> Users = context.Users;
            return Users;
        }


        public void UpdateUser(User user)
        {
            User dbEntry = context.Users
             .FirstOrDefault(u => u.UserID == user.UserID);
            if (dbEntry != null)
            {
                dbEntry.Password = user.Password;
                dbEntry.UserID = user.UserID;
                dbEntry.LastName = user.LastName;
                dbEntry.FirstName = user.FirstName;
                dbEntry.Email = user.Email;

            }
            context.SaveChanges();
        }

       
    }
}
