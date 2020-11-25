using EList.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static EList.Models.List;

namespace EList.Dto
{
    public class ListCreateDto
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "List Title is required")]
        public string ListName { get; set; }
        public ListColors ListColor { get; set; }
        public DateTime? ReminderDateTime { get; set; }
        public ICollection<Item> Items { get; set; }
        public DateTime LastEdited { get; set; }

    }
}
