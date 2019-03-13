using CheckoutService.Data;
using CheckoutService.Entities;
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
        private IPricingRuleData _pricingRuleData;

        public PricingService(IPricingRuleData pricingRuleData)
        {
            _pricingRuleData = pricingRuleData;
        }

        public List<PricingRule> GetPricingRules(string customerID)
        {
            List<PricingRule> pricingRules = _pricingRuleData.Get();

            return pricingRules.Where(pr => pr.CustomerID == customerID).ToList();
        }
    }
}