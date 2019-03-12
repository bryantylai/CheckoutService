using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutService.Models
{
    public class CheckoutRequest
    {
        public string CustomerID { get; set; }
        public List<string> ProductIDs { get; set; }
    }
}