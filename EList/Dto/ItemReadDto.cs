using EList.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EList.Dto
{
    public class ItemReadDto
    {
        public int ItemId { get; set; }
        public int ListId { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public bool IsCompleted { get; set; }
        public string URL { get; set; }
    }
}
