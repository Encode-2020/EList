using EList.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EList.Data
{
    public class EFItemRepository : IItemRepository
    {
        private EListContext context;

        public EFItemRepository(EListContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Item> Items => context.Items;

        public void CreatItem(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            context.Items.Add(item);
            context.SaveChanges();
        }

        public void DeletItem(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            context.Items.Remove(item);
            context.SaveChanges();
        }

        public Item GetItemById(int itemId)
        {
            Item dbEntry = context.Items
                 .FirstOrDefault(i => i.ItemId == itemId);
            if (dbEntry != null)
            {
                return dbEntry;
            }
            return null;
        }

        public IEnumerable<Item> GetItems()
        {
            IEnumerable<Item> Items = context.Items;
            return Items;
        }

        public void UpdateItem(Item item)
        {
            Item dbEntry = context.Items
             .FirstOrDefault(i => i.ItemId == item.ItemId);
            if (dbEntry != null)
            {
                dbEntry.ItemId = item.ItemId;
                dbEntry.ListId = item.ListId;
                dbEntry.ReminderDateTime = item.ReminderDateTime;
                dbEntry.Title = item.Title;

            }
            context.SaveChanges();
        }
    }
}
