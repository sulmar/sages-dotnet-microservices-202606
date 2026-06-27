# UC-04 – Dodanie produktu do koszyka

## Opis

Użytkownik dodaje wybrany produkt do koszyka. System zapisuje produkt wraz z ceną w momencie dodania.

---

## Aktor

- Klient (użytkownik końcowy)

---

## Cel

Dodanie produktu do koszyka użytkownika.

---

## Scenariusz główny

1. Użytkownik wybiera produkt.
2. Użytkownik klika Add to Cart.
3. Aplikacja wysyła `POST /api/cart`.

   Przykład:

   ```json
   {
     "productId": "...",
     "quantity": 1
   }
   ```

4. Shopping Cart pobiera aktualne informacje o produkcie (lub otrzymuje je w żądaniu – zależnie od architektury).
5. System zapisuje w koszyku:
   - ProductId
   - Name
   - Price
   - DiscountedPrice
   - Quantity
6. System zwraca odpowiedź.
7. Aplikacja aktualizuje licznik koszyka.

---

## Przepływ danych

Przepływ wygląda wtedy tak:

1. Klient wysyła:

   ```http
   POST /api/cart
   ```

   ```json
   {
     "productId": "P123",
     "quantity": 2
   }
   ```

2. Shopping Cart pobiera dane produktu z Product Catalog (lub ze swojego lokalnego read modelu).
3. Shopping Cart waliduje, czy produkt istnieje.
4. Shopping Cart zapisuje snapshot:
   - ProductId
   - Name
   - Price
   - DiscountedPrice
   - Quantity

## Dlaczego tak?

Po pierwsze, nie ufamy klientowi. Gdyby klient przesyłał nazwę i cenę, mógłby je zmodyfikować.

Po drugie, Product Catalog jest właścicielem produktu i ceny. To on jest źródłem prawdy.

Po trzecie, Shopping Cart potrzebuje własnego snapshotu. Dzięki temu nie musi pytać Product Catalog przy każdym wyświetleniu koszyka.
