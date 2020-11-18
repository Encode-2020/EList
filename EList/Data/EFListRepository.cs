using EList.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EList.Data
{
    public class EFListRepository : IListReposiroty
    {
        private EListContext context;

        public EFListRepository(EListContext ctx)
        {
            context = ctx;
        }
        public IQueryable<List> Lists => context.Lists
                                    .Include(i => i.Items);
        public List DeleteList(int listId)
        {
            //if (list == null)
            //{
            //    throw new ArgumentNullException(nameof(list));
            //}
            //context.Lists.Remove(list);

            List dbEntry = context.Lists
               .FirstOrDefault(l => l.ListId == listId);
            if (dbEntry != null)
            {
                context.Lists.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;

        }

        public void DelItem(Item item)
        {
            Item dbEntry = context.Items
                .FirstOrDefault(i => i.ItemId == item.ItemId);
            if (dbEntry != null)
            {
                context.Items.Remove(dbEntry);
                context.SaveChanges();
            }

        }

        public void EditItem(Item item)
        {
            Item _dbEntry = context.Items
                   .FirstOrDefault(i => i.ItemId == item.ItemId);
            if (_dbEntry != null)
            {

                _dbEntry.List = item.List;
                _dbEntry.ItemId = item.ItemId;
                _dbEntry.Description = item.Description;
                _dbEntry.ReminderDateTime = item.ReminderDateTime;
                _dbEntry.ListId = item.ListId;
            }

            context.SaveChanges();

        }

        public List GetListById(int listId)
        {
            List dbEntry = context.Lists
                   .FirstOrDefault(l => l.ListId == listId);
            if(dbEntry != null)
            {
                return dbEntry;
            }
            return null;
        }

        public void SaveList(List list)
        {
            if (list.ListId == 0)
            {
                context.Lists.Add(list);
            }
            else
            {
                List dbEntry = context.Lists
                    .FirstOrDefault(l => l.ListId == list.ListId);
                if (dbEntry != null)
                {
                    dbEntry.ListColor = list.ListColor;
                    dbEntry.ListId = list.ListId;
                    dbEntry.Items = list.Items;
                    dbEntry.ListName = list.ListName;
                    dbEntry.UserId = list.UserId;

                }
            }
            context.SaveChanges();

        }
    }
}
