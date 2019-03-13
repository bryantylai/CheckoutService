using CheckoutService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutService.Data
{
    public abstract class BaseData
    {
        protected CheckoutDatabaseEntities _entities = new CheckoutDatabaseEntities();
    }
}