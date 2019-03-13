using CheckoutService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutService.Service
{
    public class Checkout
    {
        private List<PricingRule> _pricingRules;
        private List<Product> _products;

        private Checkout(List<PricingRule> pricingRules)
        {
            _pricingRules = pricingRules ?? new List<PricingRule>();
            _products = new List<Product>();
        }

        public static Checkout New(List<PricingRule> pricingRules)
        {
            return new Checkout(pricingRules);
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public decimal Total()
        {
            decimal totalAmount = 0.0m;
            var productsGroupedByProductId = _products
                .GroupBy(p => p.Id)
                .Select(g => new { ProductId = g.Key, Products = g.ToList() })
                .ToList();

            foreach (var groupedProduct in productsGroupedByProductId)
            {
                List<Product> products = groupedProduct.Products;

                PricingRule pricingRule = _pricingRules.Where(pr => pr.ProductID == groupedProduct.ProductId)
                    .FirstOrDefault();
                if (pricingRule == null)
                {
                    totalAmount += products.Sum(p => p.Price);
                }
                else
                {
                    if (pricingRule.FixedQuantity.HasValue && 
                        products.Count >= pricingRule.FixedQuantity.Value)
                    {
                        int remainder = products.Count % pricingRule.FixedQuantity.Value;
                        int productCountToBeDiscounted = products.Count - remainder;

                        Product product = products.FirstOrDefault();
                        totalAmount += product.Price * (productCountToBeDiscounted / pricingRule.FixedQuantity.Value * pricingRule.DiscountedPriceByQuantity.Value);
                        totalAmount += product.Price * remainder;
                    }
                    else if (pricingRule.MinimumQuantity.HasValue &&
                        products.Count >= pricingRule.MinimumQuantity.Value)
                    {
                        totalAmount += products.Count * pricingRule.DiscountedPricePerProduct.Value;
                    }
                }
            }

            return totalAmount;
        }
    }
}