using CheckoutService.Entities;
using CheckoutService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutService.Data
{
    public class ProductData : BaseData
    {
        public List<Product> Get()
        {
            return _entities.Products.ToList();
        }
    }
}