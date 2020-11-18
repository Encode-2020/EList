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
    }
}
