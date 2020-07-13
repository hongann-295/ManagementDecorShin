using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementDecorShin.ViewModels
{
    public class HomeEditViewModel : HomeCreateViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string ProductPath { get; set; }
    }
}
