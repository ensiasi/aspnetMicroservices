// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using FluentValidation;


namespace Ordering.Application.Features.Orders.Commands.CheckOutOrder
{
    internal class CheckOutOrderCommandValidator : AbstractValidator<CheckOutOrderCommand>
    {
        public CheckOutOrderCommandValidator()
        {
            RuleFor(p => p.UserName)
                .NotEmpty() .WithMessage("{UserName} is required")
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
