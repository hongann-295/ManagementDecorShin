using ManagementDecorShin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementDecorShin.Models
{
    public interface ICategoriesRepository
    {
        IEnumerable<Category> Gets();
        Category Get(int id);
        Category Create(Category category);
        Category Edit(Category category);
        bool Delete(int id);
    }
}
