using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EList.Models
{
    public class List
    {
        public enum ListColors
        {
            BG_DANGER,
            BG_INFO,
            BG_PRIMARY,
            BG_SUCCESS,
            BG_SECONDARY,
            BG_WARNING

        }
        public int ListId { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "List Title is required")]
        [Remote("IsTitleExists", "List", ErrorMessage = "List already exist")]
        public string ListName { get; set; }
        public ListColors ListColor { get; set; }
        public ICollection<Item> Items { get; set; }
        public DateTime? ReminderDateTime { get; set; }
        public DateTime LastEdited { get; set; }

        public virtual void AddItem(Item item)
        {
            Items.Add(item);
        }
        public virtual void DelItem(Item item)
        {
                Items.Remove(item);

        }
    }
}
