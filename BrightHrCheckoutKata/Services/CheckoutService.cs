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
        public Dictionary<string, int> Products;

        public CheckoutService(IProductService productService)
        {
            _productService = productService;
            Products = new Dictionary<string, int>();
        }

        public void Scan(string sku)
        {
            if (!string.IsNullOrEmpty(sku))
            {
                Product product = _productService.GetProduct(sku);


                if (product != null)
                {
                    if (Products.ContainsKey(sku))
                    {
                        Products[sku] = Products[sku] + 1;
                    }
                    else
                    {
                        Products.Add(sku, 1);
                    }
                }
            }
        }
        
        public int GetTotalPrice()
        {
            throw new NotImplementedException();
        }
    }
}
