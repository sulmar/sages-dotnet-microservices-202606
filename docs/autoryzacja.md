# Autoryzacja

## **Przepływ**

```text
Client
   │ JWT
   ▼
YARP API Gateway
   │ waliduje token
   ▼
Microservice
   │ opcjonalnie ponownie waliduje token
   ▼
Handler / Use Case
```

1. **YARP** sprawdza, czy użytkownik ma poprawny token.
2. **YARP przekazuje token dalej** do mikrousługi.
3. **Mikrousługa** ponownie waliduje token i używa `claims`, np. `sub`, `role`, `scope`.

## **YARP**

```csharp
builder.Services
    .AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:7001";
        options.Audience = "gateway";
    });

builder.Services.AddAuthorization();

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
```

```csharp
app.UseAuthentication();
app.UseAuthorization();

app.MapReverseProxy();
```

Przykład konfiguracji:

```json
{
  "ReverseProxy": {
    "Routes": {
      "ordering": {
        "ClusterId": "ordering-cluster",
        "AuthorizationPolicy": "authenticated",
        "Match": {
          "Path": "/api/orders/{**catch-all}"
        }
      }
    },
    "Clusters": {
      "ordering-cluster": {
        "Destinations": {
          "ordering": {
            "Address": "https://localhost:7101/"
          }
        }
      }
    }
  }
}
```

Polityka:

```csharp
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("authenticated", policy =>
    {
        policy.RequireAuthenticatedUser();
    });
});
```

## **Mikrousługa Ordering**

W `Ordering` robisz podobnie:

```csharp
builder.Services
    .AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:7001";
        options.Audience = "ordering-api";
    });

builder.Services.AddAuthorization();
```

```csharp
app.UseAuthentication();
app.UseAuthorization();
```

Endpoint:

```csharp
app.MapPost("/api/orders", async (
    CreateOrderRequest request,
    CreateOrderHandler handler,
    ClaimsPrincipal user) =>
{
    var customerId = user.FindFirst("sub")!.Value;

    await handler.HandleAsync(request, customerId);

    return Results.Accepted();
})
.RequireAuthorization();
```

## **Token**

Dobrze, może zawierać scope:

```json
{
  "sub": "user-123",
  "scope": "orders:create carts:checkout",
  "role": "customer",
  "aud": "ordering-api",
  "iss": "https://localhost:7001"
}
```

## **Autoryzacja per use case**

Dla checkout:

```csharp
.RequireAuthorization("cart.checkout")
```

```csharp
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("cart.checkout", policy =>
    {
        policy.RequireClaim("scope", "carts:checkout");
    });

    options.AddPolicy("orders.create", policy =>
    {
        policy.RequireClaim("scope", "orders:create");
    });
});
```

## Najważniejsza zasada:


- Gateway chroni wejście do systemu.
- Mikrousługa chroni własne granice.
- Handler nie ufa danym typu customerId z request body, tylko bierze je z tokena.
