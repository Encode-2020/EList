using EList.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EList.Data
{
    public interface IListReposiroty
    {
        // bool SaveChanges();
        IQueryable<List> Lists { get; }

        IEnumerable<List> GetLists();
        List<List> GetListsByUserId(int id);

        void CreateList(List List);
        void UpdateList(List List);
        List GetListById(int listId);
        List GetListByName(string name);
        void DeleteList(List list);
       void EditItem(Item item);
       void DelItem(Item item);
    }
}
