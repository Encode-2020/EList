using EList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EList.Data
{
    public interface IItemRepository
    {
        IQueryable<Item> Items { get; }

        Item GetItemById(int itemId);

        Item GetItemByListId(int itemId, int listId);
        IEnumerable<Item> GetItems();

        void CreatItem(Item item);
        void UpdateItem(Item item);
        void DeletItem(Item item);
    }
}
