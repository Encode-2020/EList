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

        public IQueryable<Item> Items => context.Items.Include(i => i.List);

    }
}
