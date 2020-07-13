using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementDecorShin.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        [Required]
        public string ProductName { get; set; }
        public int CategoriesCategoryId { get; set; }
        public Category Categories { get; set; }
        [Required]
        public string Description { get; set; }
        public int Price { get; set; }
        [Required]
        public int Count { get; set; }
        public string ProductImage { get; set; }
    }
}
