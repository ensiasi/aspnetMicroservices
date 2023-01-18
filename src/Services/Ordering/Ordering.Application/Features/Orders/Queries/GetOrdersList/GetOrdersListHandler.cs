// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this
using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListHandler : IRequestHandler<GetOrdersListQuery, List<OrderDto>>
    {
        private  readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public GetOrdersListHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<OrderDto>> Handle(GetOrdersListQuery request,
            CancellationToken cancellationToken)
        {
            var orders =  await _orderRepository.GetOrdersByUserName(request.Username);
            var ordersDto= _mapper.Map<List<OrderDto>>(orders);
            return ordersDto;
        }
    }
}
