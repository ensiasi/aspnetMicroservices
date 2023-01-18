
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCmmandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCmmandValidator()
        {
            RuleFor(p => p.UserName)
               .NotEmpty().WithMessage("{UserName} is required")
               .NotNull()
               .MaximumLength(50).WithMessage("{Username} must not exceed 50 characters");
            RuleFor(p => p.EmailAddress)
                .NotEmpty().WithMessage("{EmailAddress} is required");

            RuleFor(p => p.TotalPrice)
               .NotEmpty().WithMessage("{TotalPrice} is required")
               .GreaterThan(0).WithMessage("{TotalPrice} must be greater than 0");
        }
    }
}
