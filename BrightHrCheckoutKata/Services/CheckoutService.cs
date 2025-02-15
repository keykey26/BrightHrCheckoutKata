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
            int totalPrice = 0;

            foreach(var checkOutProduct in Products)
            {
                Product product = _productService.GetProduct(checkOutProduct.Key);

                if(product.OfferAmount > 0 && checkOutProduct.Value >= product.OfferAmount)
                {
                    totalPrice = totalPrice + (product.OfferPrice * (checkOutProduct.Value / product.OfferAmount));
                    totalPrice = totalPrice + (product.UnitPrice * (checkOutProduct.Value % product.OfferAmount));
                }
                else
                {
                    totalPrice = totalPrice + product.UnitPrice * checkOutProduct.Value;
                }
            }

            return totalPrice;
        }
    }
}
