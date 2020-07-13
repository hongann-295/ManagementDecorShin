using ManagementDecorShin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementDecorShin.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Product> products { get; set; }
        public string TitleName { get; set; }
    }
}
