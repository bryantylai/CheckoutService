using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckoutService.Service;
using CheckoutService.Data;
using CheckoutService.Models;

namespace CheckoutServiceTest
{
    [TestClass]
    public class CheckoutTest
    {
        private IPricingService _pricingService = new PricingService();
        private Product classic = ProductData.Get().FirstOrDefault(p => p.ID == "classic");
        private Product standout = ProductData.Get().FirstOrDefault(p => p.ID == "standout");
        private Product premium = ProductData.Get().FirstOrDefault(p => p.ID == "premium");

        [TestMethod]
        public void CheckoutDefault()
        {
            Checkout checkout = Checkout.New(_pricingService.GetPricingRules("DEFAULT"));
            checkout.Add(classic);
            checkout.Add(standout);
            checkout.Add(premium);
            Assert.AreEqual(987.97m, checkout.Total());
        }

        [TestMethod]
        public void CheckoutUnilever()
        {
            Checkout checkout = Checkout.New(_pricingService.GetPricingRules("UNILEVER"));
            checkout.Add(classic);
            checkout.Add(classic);
            checkout.Add(classic);
            checkout.Add(premium);
            Assert.AreEqual(934.97m, checkout.Total());
        }

        [TestMethod]
        public void CheckoutApple()
        {
            Checkout checkout = Checkout.New(_pricingService.GetPricingRules("APPLE"));
            checkout.Add(standout);
            checkout.Add(standout);
            checkout.Add(standout);
            checkout.Add(premium);
            Assert.AreEqual(1294.96m, checkout.Total());
        }

        [TestMethod]
        public void CheckoutNike()
        {
            Checkout checkout = Checkout.New(_pricingService.GetPricingRules("NIKE"));
            checkout.Add(premium);
            checkout.Add(premium);
            checkout.Add(premium);
            checkout.Add(premium);
            Assert.AreEqual(1519.96m, checkout.Total());
        }
    }
}
