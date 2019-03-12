using CheckoutService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutService.Data
{
    public class ProductData
    {
        private static List<Product> _products = new List<Product>()
            {
                new Product()
                {
                    ID = "classic",
                    Name = "Classic Ad",
                    Price = 269.99m
                },
                new Product()
                {
                    ID = "standout",
                    Name = "Standout Ad",
                    Price = 322.99m
                },
                new Product()
                {
                    ID = "premium",
                    Name = "Premium Ad",
                    Price = 394.99m
                }
            };

        public static List<Product> Get()
        {
            return _products;
        }
    }
}