using EList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EList.Data
{
    public interface IListReposiroty
    {
        IQueryable<List> Lists { get; }

        void SaveList(List List);
      List GetListById(int listId);
        List DeleteList(int listID);
       void EditItem(Item item);
       void DelItem(Item item);
    }
}
