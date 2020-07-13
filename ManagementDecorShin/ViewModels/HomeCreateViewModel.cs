using ManagementDecorShin.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementDecorShin.ViewModels
{
    public class HomeCreateViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage ="Can not exceed 50 characters")]
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public Category Categories { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Count { get; set; }
        public string Description { get; set; }
        public IFormFile ProductImage { get; set; }
    }
}
