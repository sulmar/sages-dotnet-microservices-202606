using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Features.CreateOrder;

// dotnet add package FluentValidation

public sealed class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>  
{
    public CreateOrderRequestValidator()
    {       
        RuleFor(p=>p.Lines).NotEmpty().WithMessage("Order must have at least one line item.");
        RuleForEach(p => p.Lines).SetValidator(new CreateOrderLineRequestValidator());
    }
}

public sealed class CreateOrderLineRequestValidator : AbstractValidator<OrderLineRequest>
{
    public CreateOrderLineRequestValidator()
    {
        RuleFor(p => p.ProductId).GreaterThan(0).WithMessage("ProductId must be greater than 0.");
        RuleFor(p => p.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0.");
    }
}
