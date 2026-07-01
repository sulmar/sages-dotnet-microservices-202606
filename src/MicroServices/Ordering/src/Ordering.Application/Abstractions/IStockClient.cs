using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Abstractions;

public interface IStockClient
{
    Task<bool> CheckAvailabilityAsync(int productId, int quantity);
}
