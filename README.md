This API Service hosted on Azure and is accessible via: http://checkout-api.azurewebsites.net/

The api for checkout is a HTTP POST method to http://checkout-api.azurewebsites.net/checkout which accepts a request body of the following:
{
   "CustomerID": "APPLE",
   "ProductIDs": [
      "classic",
	  "standout",
	  "premium"
   ]
}

The database ia hosted on Azure using Azure SQL Database and has the following tables:
1. Customer
- Id
- Name

2. Product
- Id
- Name
- Price

3. PricingRule
- CustomerID,
- ProductID
- FixedQuantity
- DiscountedPriceByQuantity
- MinimumQuantity
- DiscountedPricePerProduct

** Fixed Quantity and DiscountedPriceByQuantity comes in a pair whereby FixedQuantity determines that when his quantity is reached, it is discounted to DiscountedPriceByQuantity

** MinimumQuantity and DiscountedPricePerProduct comes in a pair whereby MinimumQuantity determines the minimum quantiy required to apply the DiscountedPricePerProduct

Unit Test is available in CheckoutServiceTest project.

Github: https://github.com/bryantylai/CheckoutService