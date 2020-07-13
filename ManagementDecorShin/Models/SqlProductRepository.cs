using ManagementDecorShin.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementDecorShin.Models
{
    public class SqlProductRepository : IProductRepository
    {
        private readonly AppDbContext context;

        public SqlProductRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Product Create(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

        public bool Delete(int id)
        {
            var delPrd = context.Products.Find(id);
            if (delPrd != null)
            {
                context.Products.Remove(delPrd);
                return context.SaveChanges() > 0;
            }
            return false;
        }

        public Product Edit(Product product)
        {
            var editPrd = context.Products.Attach(product);
            editPrd.State = EntityState.Modified;
            context.SaveChanges();
            return product;
        }

        public Product Get(int id)
        {
            return context.Products.Find(id);
        }

        public IEnumerable<Product> Gets()
        {
            return context.Products;
        }

        /*Product IProductRepository.Get(int id)
        {
            
        }*/
    }
}
