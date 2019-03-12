using CheckoutService.Data;
using CheckoutService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutService.Service
{
    public interface IPricingService
    {
        List<PricingRule> GetPricingRules(string customerID);
    }

    public class PricingService : IPricingService
    {
        public List<PricingRule> GetPricingRules(string customerID)
        {
            List<PricingRule> pricingRules = PricingRuleData.Get();

            return pricingRules.Where(pr => pr.CustomerID == customerID).ToList();
        }
    }
}