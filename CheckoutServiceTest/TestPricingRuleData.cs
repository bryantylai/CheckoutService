using CheckoutService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckoutService.Entities;

namespace CheckoutServiceTest
{
    public class TestPricingRuleData : IPricingRuleData
    {
        private List<PricingRule> _pricingRules = new List<PricingRule>()
            {
                new PricingRule()
                {
                    CustomerID = "UNILEVER",
                    ProductID = "classic",
                    FixedQuantity = 3,
                    DiscountedPriceByQuantity = 2
                },
                new PricingRule()
                {
                    CustomerID = "APPLE",
                    ProductID = "standout",
                    MinimumQuantity = 0,
                    DiscountedPricePerProduct = 299.99m
                },
                new PricingRule()
                {
                    CustomerID = "NIKE",
                    ProductID = "premium",
                    MinimumQuantity = 4,
                    DiscountedPricePerProduct = 379.99m
                },
                new PricingRule()
                {
                    CustomerID = "FORD",
                    ProductID = "classic",
                    FixedQuantity = 5,
                    DiscountedPriceByQuantity = 4
                },
                new PricingRule()
                {
                    CustomerID = "FORD",
                    ProductID = "classic",
                    MinimumQuantity = 0,
                    DiscountedPricePerProduct = 309.99m,
                },
                new PricingRule()
                {
                    CustomerID = "FORD",
                    ProductID = "classic",
                    MinimumQuantity = 4,
                    DiscountedPricePerProduct = 389.99m
                }
            };
        public List<PricingRule> Get()
        {
            return _pricingRules;
        }
    }
}
