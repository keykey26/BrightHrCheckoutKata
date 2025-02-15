using BrightHrCheckoutKata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightHrCheckoutKata.Services
{
    public interface IProductService
    {
        Product GetProduct(string sku); 
    }
}
