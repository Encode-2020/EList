using EList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EList.Data
{
    public class EFUserRepository : IUserRepository
    {
        private EListContext context;

        public EFUserRepository(EListContext ctx)
        {
            context = ctx;
        }
        public IQueryable<List> Lists => context.Lists;
        public async Task<User> GetUserById(int userId)
        {
            User dbEntry = await context.Users.FindAsync(userId);
               // .FirstOrDefault(u =>u.UserID == userId);
            if(dbEntry != null)
            {
                return dbEntry;
            }
            return null;
        }

       public async Task<User> SaveUser(User user)
        {
            //if (user.UserID == 0)
            //{
            //   context.Users.Add(user);
            //}
            //else
            //{
                User dbEntry = await context.Users.FindAsync(user.UserID);
                   // .FirstOrDefault(u => u.UserID == user.UserID);
                if (dbEntry != null)
                {
                    dbEntry.Password= user.Password;
                    dbEntry.UserID = user.UserID;
                    dbEntry.LastName = user.LastName;
                    dbEntry.FirstName = user.FirstName;
                    dbEntry.Email = user.Email;

                }
           // }
           context.SaveChanges();
            return dbEntry;
        }
    }
}
