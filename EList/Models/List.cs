using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EList.Models
{
    public class List
    {
        public int ListId { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "List Title is required")]
        public string ListName { get; set; }
        public string ListColor { get; set; }
        public ICollection<Item> Items { get; set; }

        //public virtual void AddItem(Item item)
        //{
        //    item.List = this;
        //    Items.Add(item);
        //}
        //public virtual void DelItem(Item item)
        //{
        //    if (item.List == this)
        //    {
        //        Items.Remove(item);
        //    }

        //}
    }
}
