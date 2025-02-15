using BrightHrCheckoutKata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightHrCheckoutKata.Services
{
    public class ProductService : IProductService
    {

        private List<Product> Products { get; set; }

        public ProductService()
        {
            Products = new List<Product>();
            Products.Add(new Product("A", 50, 3, 130));
            Products.Add(new Product("B", 30, 2, 45));
            Products.Add(new Product("C", 20, 0, 0));
            Products.Add(new Product("D", 15, 0, 0));

        }

        public Product GetProduct(string sku)
        {
            return Products.FirstOrDefault(p => p.Sku == sku);
        }
    }
}