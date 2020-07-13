using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementDecorShin.Models
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> products;
        public ProductRepository()
        {
            products = new List<Product>()
            {
                new Product(){
                    ProductId= 1,
                    ProductCode = "PR1",
                    ProductName="Ghe",
                    Price = 50000,
                    Count = 5,
                    ProductImage="decor34.jpg"
                },
                new Product(){
                    ProductId= 2,
                    ProductName="Ban",
                    Price = 60000,
                    Count = 10,
                    ProductImage="decor25.jpg",
                    ProductCode = "PR2"
                }
            };
        }

        public Product Create(Product product)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Product Edit(Product product)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            return products.FirstOrDefault(p => p.ProductId == id);
        }

        public IEnumerable<Product> Gets()
        {
            return products;
        }
    }
}
