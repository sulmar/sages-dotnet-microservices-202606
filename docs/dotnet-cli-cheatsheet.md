# Ściąga: dotnet CLI

Krótka lista poleceń przydatnych podczas tworzenia projektów .NET i dodawania ich do solution.

## Solution

Utworzenie nowego pliku solution:

```bash
dotnet new sln -n Sages.DotNet.Microservices
```

Dodanie istniejącego projektu do solution:

```bash
dotnet sln add src/MicroServices/ProductCatalog/src/ProductCatalog.Api/ProductCatalog.Api.csproj
```

Dodanie wielu projektów do solution:

```bash
dotnet sln add \
  src/MicroServices/ProductCatalog/src/ProductCatalog.Api/ProductCatalog.Api.csproj \
  src/MicroServices/ProductCatalog/src/ProductCatalog.Application/ProductCatalog.Application.csproj \
  src/MicroServices/ProductCatalog/src/ProductCatalog.Domain/ProductCatalog.Domain.csproj \
  src/MicroServices/ProductCatalog/src/ProductCatalog.Infrastructure/ProductCatalog.Infrastructure.csproj
```

Wyświetlenie projektów dodanych do solution:

```bash
dotnet sln list
```

Usunięcie projektu z solution:

```bash
dotnet sln remove src/MicroServices/ProductCatalog/src/ProductCatalog.Api/ProductCatalog.Api.csproj
```

## Tworzenie projektów

Web API:

```bash
dotnet new webapi -n ProductCatalog.Api -o src/MicroServices/ProductCatalog/src/ProductCatalog.Api
```

Class Library:

```bash
dotnet new classlib -n ProductCatalog.Application -o src/MicroServices/ProductCatalog/src/ProductCatalog.Application
dotnet new classlib -n ProductCatalog.Domain -o src/MicroServices/ProductCatalog/src/ProductCatalog.Domain
dotnet new classlib -n ProductCatalog.Infrastructure -o src/MicroServices/ProductCatalog/src/ProductCatalog.Infrastructure
```

gRPC:

```bash
dotnet new grpc -n Stock.GrpcService -o src/MicroServices/Stock/src/Stock.GrpcService
```

Worker Service:

```bash
dotnet new worker -n Payment.Worker -o src/MicroServices/Payment/src/Payment.Worker
```

Blazor WebAssembly:

```bash
dotnet new blazorwasm -n BlazorApp -o src/Clients/Blazor.Client
```

## Referencje między projektami

Dodanie referencji projektu:

```bash
dotnet add src/MicroServices/ProductCatalog/src/ProductCatalog.Api/ProductCatalog.Api.csproj reference \
  src/MicroServices/ProductCatalog/src/ProductCatalog.Application/ProductCatalog.Application.csproj
```

Dodanie kilku referencji:

```bash
dotnet add src/MicroServices/ProductCatalog/src/ProductCatalog.Api/ProductCatalog.Api.csproj reference \
  src/MicroServices/ProductCatalog/src/ProductCatalog.Application/ProductCatalog.Application.csproj \
  src/MicroServices/ProductCatalog/src/ProductCatalog.Infrastructure/ProductCatalog.Infrastructure.csproj
```

Usunięcie referencji:

```bash
dotnet remove src/MicroServices/ProductCatalog/src/ProductCatalog.Api/ProductCatalog.Api.csproj reference \
  src/MicroServices/ProductCatalog/src/ProductCatalog.Application/ProductCatalog.Application.csproj
```

## Pakiety NuGet

Dodanie pakietu:

```bash
dotnet add src/MicroServices/ProductCatalog/src/ProductCatalog.Infrastructure/ProductCatalog.Infrastructure.csproj package Microsoft.EntityFrameworkCore
```

Usunięcie pakietu:

```bash
dotnet remove src/MicroServices/ProductCatalog/src/ProductCatalog.Infrastructure/ProductCatalog.Infrastructure.csproj package Microsoft.EntityFrameworkCore
```

## Przydatne komendy

Przywrócenie zależności:

```bash
dotnet restore
```

Budowanie projektu lub solution:

```bash
dotnet build
dotnet build src/Clients/Blazor.Client/BlazorApp.csproj
```

Uruchomienie projektu:

```bash
dotnet run --project src/MicroServices/ProductCatalog/src/ProductCatalog.Api/ProductCatalog.Api.csproj
```

Lista dostępnych szablonów:

```bash
dotnet new list
```

Pomoc dla konkretnego szablonu:

```bash
dotnet new webapi --help
```
