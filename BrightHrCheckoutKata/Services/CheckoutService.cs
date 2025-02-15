using BrightHrCheckoutKata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightHrCheckoutKata.Services
{
    public class CheckoutService: ICheckoutService
    {
        private IProductService _productService;
        public List<Product> Products;

        public CheckoutService(IProductService productService)
        {
            _productService = productService;
            Products = new List<Product>();
        }

        public void Scan(string item)
        {
            throw new NotImplementedException();
        }
        
        public int GetTotalPrice()
        {
            throw new NotImplementedException();
        }
    }
}
