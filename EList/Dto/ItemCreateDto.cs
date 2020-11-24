using EList.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EList.Dto
{
    public class ItemCreateDto
    {
        public int ListId { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public bool isCompleted { get; set; } = false;
    }
}
