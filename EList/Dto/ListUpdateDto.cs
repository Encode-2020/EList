using EList.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EList.Dto
{
    public class ListUpdateDto
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "List Title is required")]
        public string ListName { get; set; }
        public string ListColor { get; set; }
        public ICollection<Item> Items { get; set; }
       
    }
}
