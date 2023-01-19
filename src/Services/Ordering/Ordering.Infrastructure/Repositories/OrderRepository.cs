// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contracts.Persistance;
using Ordering.Domain.Entities;
using Ordering.Infrastructure.Persistance;

namespace Ordering.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            return await _context.orders.Where( o => o.UserName == userName).ToListAsync();
        }
    }
}
