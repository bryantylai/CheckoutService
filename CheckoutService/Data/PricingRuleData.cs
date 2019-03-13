using CheckoutService.Entities;
using CheckoutService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutService.Data
{
    public interface IPricingRuleData
    {
        List<PricingRule> Get();
    }

    public class PricingRuleData : BaseData, IPricingRuleData
    {
        public List<PricingRule> Get()
        {
            return _entities.PricingRules.ToList();
        }
    }
}