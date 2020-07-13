using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementDecorShin.Models
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly AppDbContext context;

        public CategoriesRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Category Create(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return category;
        }

        public bool Delete(int id)
        {
            var delCate = context.Categories.Find(id);
            if (delCate != null)
            {
                context.Categories.Remove(delCate);
                return context.SaveChanges() > 0;
            }
            return false;
        }

        public Category Edit(Category category)
        {
            var editCategory = context.Categories.Attach(category);
            editCategory.State = EntityState.Modified;
            context.SaveChanges();
            return category;
        }

        public Category Get(int id)
        {
            return context.Categories.Find(id);
        }

        public IEnumerable<Category> Gets()
        {
            return context.Categories;
        }

    }
}
