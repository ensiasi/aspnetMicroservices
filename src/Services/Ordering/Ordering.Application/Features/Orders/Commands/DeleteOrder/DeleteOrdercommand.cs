// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrdercommand : IRequest
    {
        public int Id { get; set; }
    }
}
