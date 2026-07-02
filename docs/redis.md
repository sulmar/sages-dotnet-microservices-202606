# Redis

## Kontener Redis


Uruchomienie kontenera Redis w tle pod nazwą `shopping-cart-redis` i udostępnienie portu `6379` na komputerze lokalnym:

```bash
docker run -d --name shopping-cart-redis -p 6379:6379 redis
```

Połączenie z uruchomionym kontenerem i otwarcie konsoli `redis-cli`, która pozwala wykonywać polecenia Redis:

```bash
docker exec -it shopping-cart-redis redis-cli 
```

Ponowne uruchomienie wcześniej utworzonego kontenera Redis:

```bash
docker start shopping-cart-redis
```

Zatrzymanie działającego kontenera Redis:

```bash
docker stop shopping-cart-redis
```

Usunięcie zatrzymanego kontenera Redis:

```bash
docker rm shopping-cart-redis
```


## Polecenia

Sprawdzenie, czy serwer Redis odpowiada:

```redis
PING
```

### Klucze

Ustawienie czasu życia klucza w sekundach. Po upływie tego czasu klucz zostanie automatycznie usunięty:

```redis
EXPIRE key seconds
```

### STRING

Zapisanie wartości tekstowej pod wskazanym kluczem:

```redis
SET key value
```

Odczytanie wartości zapisanej pod wskazanym kluczem:

```redis
GET key
```

### HASH

Zapisanie wartości w polu struktury typu hash:

```redis
HSET key field value
```

Odczytanie wartości konkretnego pola ze struktury typu hash:

```redis
HGET key field
```

Odczytanie wszystkich pól i wartości ze struktury typu hash:

```redis
HGETALL key
```

### STREAM

Dodanie zdarzenia do streamu `orders-stream`. W projekcie tak publikujemy zdarzenie `order-placed` po utworzeniu zamówienia:

```redis
XADD orders-stream * orderId 123 type order-placed occuredAt 2026-07-02T15:30:00Z lines "[{\"productId\":\"p1\",\"quantity\":2}]"
```

Odczytanie zdarzeń ze streamu od początku. Identyfikator `0-0` oznacza początek streamu:

```redis
XREAD STREAMS orders-stream 0-0
```

Utworzenie grupy konsumentów `payment-group` dla streamu `orders-stream`. Opcja `MKSTREAM` tworzy stream, jeśli jeszcze nie istnieje:

```redis
XGROUP CREATE orders-stream payment-group $ MKSTREAM
```

Odczytanie nowych wiadomości przez konsumenta `payment-1` z grupy `payment-group`. Znak `>` oznacza tylko nowe, nieprzypisane jeszcze wiadomości:

```redis
XREADGROUP GROUP payment-group payment-1 STREAMS orders-stream >
```

Potwierdzenie przetworzenia wiadomości przez grupę konsumentów. W miejsce `{id}` należy wstawić identyfikator wiadomości zwrócony przez `XREADGROUP`:

```redis
XACK orders-stream payment-group {id}
```

Sprawdzenie informacji o grupach konsumentów utworzonych dla streamu:

```redis
XINFO GROUPS orders-stream
```

