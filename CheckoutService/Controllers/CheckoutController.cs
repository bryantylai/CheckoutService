using CheckoutService.Data;
using CheckoutService.Entities;
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
        private ProductData _productData;

        public CheckoutController()
        {
            _productData = new ProductData();
            _pricingService = new PricingService(new PricingRuleData());
        }

        public CheckoutController(IPricingService pricingService, ProductData productData)
        {
            _pricingService = pricingService;
            _productData = productData;
        }
        
        [HttpPost, Route("checkout")]
        public decimal CheckoutProducts([FromBody] CheckoutRequest checkoutRequest)
        {
            List<Product> products = _productData.Get();
            List<PricingRule> pricingRules = _pricingService.GetPricingRules(checkoutRequest.CustomerID);
            Checkout checkout = Checkout.New(pricingRules);

            foreach (string productID in checkoutRequest.ProductIDs)
            {
                Product product = products.FirstOrDefault(p => p.Id == productID);
                checkout.Add(product);
            }

            return checkout.Total();
        }
    }
}