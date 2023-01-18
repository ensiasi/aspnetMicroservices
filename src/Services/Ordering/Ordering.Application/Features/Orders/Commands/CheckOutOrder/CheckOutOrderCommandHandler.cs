// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Infrastructure;
using Ordering.Application.Contracts.Persistance;
using Ordering.Application.Models;
using Ordering.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.CheckOutOrder
{
    internal class CheckOutOrderCommandHandler : IRequestHandler<CheckOutOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CheckOutOrderCommandHandler> _logger;

        public CheckOutOrderCommandHandler(IOrderRepository orderRepository,
            IMapper mapper, IEmailService emailService,
            ILogger<CheckOutOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(CheckOutOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntitiy= _mapper.Map<Order>(request);
            var newOrder= await _orderRepository.AddAsync(orderEntitiy);
            _logger.LogInformation($"order {newOrder.Id} is successfully created");
            await sendEmail(newOrder);
            return newOrder.Id;
        }
        private async Task sendEmail(Order order)
        {
            try
            {
                var email = new Email { To = order.EmailAddress, Subject = "", Body = "" };
                await _emailService.SendEmailAsync(email);
                _logger.LogInformation($"Order success Email notification sent to {order.EmailAddress}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"order {order.Id} failed due to error in email service: {ex.Message}");
            }
        }
    }
}
