using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Features.CreateOrder;

namespace Ordering.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddAplication(this IServiceCollection services)
    {
        services.AddScoped<CreateOrderHandler>();
        services.AddScoped<IValidator<CreateOrderRequest>, CreateOrderRequestValidator>();

        return services;
    }
}
