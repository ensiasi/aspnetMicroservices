// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Features.Orders.Commands.CheckOutOrder;
using Ordering.Application.Features.Orders.Commands.DeleteOrder;
using Ordering.Application.Features.Orders.Commands.UpdateOrder;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Ordering.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
       private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{username}", Name ="getOrder")]
        [ProducesResponseType(typeof(IEnumerable<OrderDto>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersList(string userName)
        {
            var query = new GetOrdersListQuery(userName);
            var orders=await _mediator.Send(query);
            return Ok(orders);
        }
        [HttpPost(Name = "checkOutOrder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CheckOutOrder([FromBody] CheckOutOrderCommand command)
        {
            var orderId = await _mediator.Send(command);
            return Ok(orderId);
        }
        [HttpPost(Name = "UpdateOrder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpGet("{orderId}",Name = "DeleteOrder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> DeleteOrder(int OrderId)
        {
            var query = new DeleteOrdercommand { Id=OrderId};
            await _mediator.Send(query);
            return Ok();
        }
    }
}
