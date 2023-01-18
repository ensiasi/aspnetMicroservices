// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using MediatR;
using System;
using System.Collections.Generic;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQuery : IRequest<List<OrderDto>>
    {
        public string Username { get; set; }
        public GetOrdersListQuery(string username)
        {
            Username= username ?? throw new ArgumentNullException(nameof(username));
        }
    }
}
