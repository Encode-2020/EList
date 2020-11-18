using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EList.Models
{
    public class Item
    {
        public string ItemId { get; set; }
        public string ListId { get; set; }
        public List List { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public DateTime? ReminderDateTime { get; set; }
    }
}
