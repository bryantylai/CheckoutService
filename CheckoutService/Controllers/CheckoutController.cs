using CheckoutService.Data;
using CheckoutService.Models;
using CheckoutService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CheckoutService.Controllers
{
    public class CheckoutController : ApiController
    {
        private IPricingService _pricingService;

        public CheckoutController()
        {
            _pricingService = new PricingService();
        }

        public CheckoutController(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }

        [HttpGet, Route("get")]
        public string Get()
        {
            return "hello";
        }
        
        [HttpPost, Route("checkout")]
        public decimal CheckoutProducts([FromBody] CheckoutRequest checkoutRequest)
        {
            List<Product> products = ProductData.Get();
            List<PricingRule> pricingRules = _pricingService.GetPricingRules(checkoutRequest.CustomerID);
            Checkout checkout = Checkout.New(pricingRules);

            foreach (string productID in checkoutRequest.ProductIDs)
            {
                Product product = products.FirstOrDefault(p => p.ID == productID);
                checkout.Add(product);
            }

            return checkout.Total();
        }
    }
}