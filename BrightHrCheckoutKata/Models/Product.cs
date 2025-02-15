using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightHrCheckoutKata.Models
{
    public class Product
    {
        public string Sku { get; set; }
        public int UnitPrice { get; set; }
        public int OfferAmount { get; set; }
        public int OfferPrice { get; set; }

        public Product(string sku, int unitPrice, int offerAmount, int offerPrice)
        {
            Sku = sku;
            UnitPrice = unitPrice;
            OfferAmount = offerAmount;
            OfferPrice = offerPrice;
        }
    }
}
