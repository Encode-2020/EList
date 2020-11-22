using EList.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EList.Data
{
    public class EFUserRepository : IUserRepository
    {
        private EListContext context;

        public EFUserRepository(EListContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<User> Users => context.Users;

        public void CreateUser(User user)
        {
            bool isExist = false;
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            isExist = IsUserExists(user.Email);
            if (!isExist)
            {
                context.Users.Add(user);
                context.SaveChanges();
            } else
            {
                throw new Exception();
            }
           
           
        }
        public bool IsUserExists(string email)
        {
            //check if any of the email matches the email specified in the Parameter using the ANY extension method.  
            return context.Users.Any(x => x.Email == email);
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
        public User GetUserByEmail(string email)
        {
            User dbEntry = context.Users
                .FirstOrDefault(u => u.Email == email);
            if (dbEntry != null)
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
                dbEntry.Username = user.Username;
                dbEntry.Email = user.Email;

            }
            context.SaveChanges();
        }

       
    }
}
