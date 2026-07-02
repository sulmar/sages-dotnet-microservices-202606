
# Przykłady ze szkolenia

## Wprowadzenie

Witaj w repozytorium z materiałami do szkolenia **Architektura mikroserwisów z wykorzystaniem .NET**.

Backendowe mikroserwisy są szkieletem do implementacji podczas szkolenia, a gotowy starter zawiera tylko klienta Blazor.

## Wymagania

Do rozpoczęcia tego kursu potrzebujesz następujących rzeczy:

1. [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
2. [Docker](https://www.docker.com/products/docker-desktop/)

## Stos technologiczny

- .NET 10
- Blazor WebAssembly
- ASP.NET Core Web API
- gRPC
- Redis
- SignalR
- Docker

## Przygotowanie
1. Sklonuj repozytorium Git
```
git clone https://github.com/sulmar/sages-dotnet-microservices-202606
```
2. Zbuduj
```
dotnet build src/Clients/Blazor.Client/BlazorApp.csproj
```

## Przypadki użycia

Lista przypadków użycia znajduje się w [docs/use-cases](docs/use-cases/README.md).

## Ściągi

- [dotnet CLI](docs/dotnet-cli-cheatsheet.md) - tworzenie projektów, solution, referencji i pakietów.

## Moduły szkolenia

- Moduł 1: Starter Blazor i katalog produktów (`UC-01`, `UC-02`, `UC-03`) - HTTP REST API.
- Moduł 2: Koszyk i snapshot danych (`UC-04`, `UC-05`, `UC-06`, `UC-07`) - HTTP REST API, Redis Hash.
- Moduł 3: Checkout, zamówienia i magazyn (`UC-08`, `UC-14`, `UC-15`) - HTTP REST API, gRPC.
- Moduł 4: Anulowanie i historia zamówień (`UC-09`, `UC-10`) - HTTP REST API, zdarzenia domenowe.
- Moduł 5: Płatności asynchroniczne i refundy (`UC-11`, `UC-12`) - Redis Stream.
- Moduł 6: Powiadomienia, retry i idempotencja (`UC-13`) - Redis Stream, Webhook.
- Moduł 7: Dashboard - SignalR.
- Moduł 8: Monitoring - healthcheck, metryki, logi, tracing.
- Moduł 9: Autoryzacja - JWT.

## Protokoły i technologie

- HTTP REST API - komunikacja klienta, gatewaya i usług synchronicznych.
- gRPC - szybka komunikacja kontraktowa między usługami, np. Ordering -> Stock.
- Redis Hash - przechowywanie stanu koszyka.
- Redis Stream - komunikacja asynchroniczna i zdarzenia.
- Webhook - integracja z zewnętrznym odbiorcą powiadomień.
- SignalR - opcjonalna komunikacja realtime dla dashboardu lub monitoringu.

## Licencja

Materiały w tym repozytorium są udostępnione wyłącznie do nauki własnej.

Możesz je przeglądać, uruchamiać i wykorzystywać do samodzielnego zdobywania wiedzy.

Nie wolno wykorzystywać tych materiałów, w całości ani we fragmentach, do prowadzenia szkoleń, warsztatów, kursów, bootcampów ani innych zajęć edukacyjnych bez pisemnej zgody autora.

Wszelkie pozostałe prawa są zastrzeżone.
