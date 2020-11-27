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
        public IEnumerable<List> GetLists()
        {
            IEnumerable<List> Lists = context.Lists.Include(i => i.Items);
            return Lists;
        }
        public IEnumerable<List> GetListsByUserId(int id)
        {
            IEnumerable<List> Lists = context.Lists.Where(l => l.UserId == id).Include(l => l.Items);
            return Lists;
        }
        public void DeleteList(List list)
        {

            List dbEntry =  context.Lists
              .FirstOrDefault(l => l.ListId == list.ListId);
            if (dbEntry != null)
            {
                context.Lists.Remove(dbEntry);
             context.SaveChanges();
            }

        }

        public void EditItem(Item item)
        {
            Item _dbEntry = context.Items
                   .FirstOrDefault(i => i.ItemId == item.ItemId);
            if (_dbEntry != null)
            {

                _dbEntry.ItemId = item.ItemId;
                _dbEntry.Description = item.Description;
                _dbEntry.isCompleted = item.isCompleted;
                _dbEntry.ListId = item.ListId;
            }

            context.SaveChanges();

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
        public IEnumerable<List> GetListByName(string name)
        {
            IEnumerable<List> dbEntry = context.Lists.Where(l => l.ListName.ToLower() == name.ToLower());
            if (dbEntry != null)
            {
                return dbEntry;
            }
            return null;
        }

        public void CreateList(List list)
        {
            bool isExist = false;
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
           
            isExist = IsListExists(list.ListName);  
            if (!isExist)
            {
                context.Lists.Add(list);
                context.SaveChanges();
            }
            else
            {
                throw new Exception();
            }
        }
        public bool IsListExists(string name)
        {
            return context.Lists.Any(x => x.ListName.ToLower() == name.ToLower());
        }

        public void UpdateList(List list)
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
            context.SaveChanges();
        }


    }
}
