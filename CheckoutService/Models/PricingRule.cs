using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutService.Models
{
    public class PricingRule
    {
        public string CustomerID { get; set; }
        public string ProductID { get; set; }
        public int? FixedQuantity { get; set; }
        public int? MinimumQuantity { get; set; }
        public decimal? DiscountedPricePerProduct { get; set; }
        public int? DiscountedPriceByQuantity { get; set; }
    }
}