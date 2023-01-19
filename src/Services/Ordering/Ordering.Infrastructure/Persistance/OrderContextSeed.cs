// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistance
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if(!orderContext.orders.Any())
            {
                orderContext.orders.AddRange(GetPreconfigureOrders());
                await orderContext.SaveChangesAsync();
            }
        }
        private static IEnumerable<Order> GetPreconfigureOrders()
        {
            return new List<Order>()
            {
                 new Order() {UserName = "swn", FirstName = "Mehmet", LastName = "Ozkaya", EmailAddress = "ezozkme@gmail.com", AddressLine = "Bahcelievler", Country = "Turkey", TotalPrice = 350 }
            };
        }
    }
}
